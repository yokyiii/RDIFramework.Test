using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using DevExpress.XtraPrinting;

namespace RDIFramework.Test
{
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;
    using RDIFrameworkDemo.BizLogic;

    /// <summary>
    /// FrmOrderAdmin
    /// 订单管理（主子表实例）
    /// 
    /// 修改记录
    /// 
    ///     2018-08-08 EricHu 创建“订单管理”。
    /// </summary>
    public partial class FrmOrderAdmin : BaseForm
    {
        /// <summary>
        /// 订单信息
        /// </summary>
        private List<CaseOrderEntity> OrderList = new List<CaseOrderEntity>();

        IDbProvider dbProvider = null;
        private string userConstraintExpress = ""; //表约束条件
        CaseOrderService caseOrderService = new CaseOrderService();

        #region public override string EntityId 订单主键

        /// <summary>
        /// 订单主键
        /// </summary>
        public override string EntityId => BasePageLogic.GetDataGridViewEntityId(this.gridViewOrder, "Id");

        #endregion

        #region 权限控制部分

        /// <summary>
        /// 本模块的添加权限
        /// </summary>
        private bool permissionAdd = false;

        /// <summary>
        /// 本模块的修改权限
        /// </summary>
        private bool permissionEdit = false;

        /// <summary>
        /// 本模块的删除权限
        /// </summary>
        private bool permissionDelete = false;


        #region public override void GetPermission() 获得权限

        /// <summary>
        /// 获得权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAdd = this.IsAuthorized("OrderAdmin.Add");
            this.permissionEdit = this.IsAuthorized("OrderAdmin.Edit");
            this.permissionDelete = this.IsAuthorized("OrderAdmin.Delete");
        }

        #endregion

        #region public override void SetControlState() 按钮的状态设置

        /// <summary>
        /// 按钮的状态设置
        /// </summary>
        public override void SetControlState()
        {
            this.btnAdd.Enabled = this.permissionAdd;
            // 是否有数据的判断
            if (this.OrderList.Count <= 0)
            {
                this.btnEdit.Enabled = false;
                this.btnDel.Enabled = false;
            }
            else
            {
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnDel.Enabled = this.permissionDelete;
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmOrderAdmin()
        {
            InitializeComponent();
            BasePageLogic.BoundCheckEdit(repositoryItemCheckEdit1);
        }

        public override void FormOnLoad()
        {
            //绑定数据
            this.Search();
        }

        private void Search()
        {
            FrmWaiting.ShowMe(this);
            string searchValue = "", keyword = this.txtSerarch.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                searchValue += CaseOrderTable.FieldOrderCode + " LIKE '%" + keyword + "%' OR ";
                searchValue += CaseOrderTable.FieldCustomerName + " LIKE '%" + keyword + "%' OR ";
                searchValue += CaseOrderTable.FieldSellerName + " LIKE '%" + keyword + "%'";
            }
            var recordCount = 0;
            OrderList = caseOrderService.GetOrderListByPage(this.UserInfo, searchValue, out recordCount,ucPagerOrder.PageIndex, ucPagerOrder.PageSize,CaseOrderTable.FieldCreateOn + " desc ");
            ucPagerOrder.RecordCount = recordCount;
            ucPagerOrder.InitPageInfo();
            // 加载绑定数据
            this.GetList();
            FrmWaiting.HideMe(this);
        }

        public override void GetList()
        {
            this.grdOrder.DataSource = this.OrderList;
            this.SetControlState();
        }

        private void ucPagerOrder_PageChanged(object sender, EventArgs e)
        {
            FrmWaiting.ShowMe(this);
            Search();
            FrmWaiting.HideMe(this);
        }

        private void gridViewOrder_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.EntityId))
            {
                this.grdOrderDetail.DataSource = null;
                return;
            }
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(CaseOrderDetailTable.FieldOrderId, this.EntityId)
            };
            List<CaseOrderDetailEntity> listDetailOrder = caseOrderService.GetOrderDetailListByValues(this.UserInfo, parameters);
            this.grdOrderDetail.DataSource = listDetailOrder;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmProductEdit = new FrmProductEdit {DbLinks = this.DbLinks};
            if (frmProductEdit.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.Search();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var frmProductEdit = new FrmProductEdit(this.EntityId) {DbLinks = this.DbLinks};
            if (frmProductEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.Search();
            }
        }

        private void btnAddToTab_Click(object sender, EventArgs e)
        {
            var frmOrderEdit = new FrmEditOrder {DbLinks = this.DbLinks};
            this.ShowFormInMainTab(frmOrderEdit, "frmProductEdit", btnAdd.Image);
            frmOrderEdit.OnFormClosedRefreash += OnFormClosedRefreash;
        }

        private void btnEditToTab_Click(object sender, EventArgs e)
        {
            var frmOrderEdit = new FrmEditOrder(this.EntityId) {DbLinks = this.DbLinks};
            this.ShowFormInMainTab(frmOrderEdit, "frmOrderEdit", btnEdit.Image);
            frmOrderEdit.OnFormClosedRefreash += OnFormClosedRefreash;
        }

        public void OnFormClosedRefreash()
        {
            this.Search();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (BasePageLogic.CheckInputSelectAnyOne(gridViewOrder))
            {
                if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.Yes)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        int returnValue = caseOrderService.DeleteOrder(this.UserInfo,this.EntityId);
                        if (returnValue > 0)
                        {
                            Search();
                        }
                    }
                    catch (Exception ex)
                    {
                        this.ProcessException(ex);
                    }
                    finally
                    {
                        // 设置鼠标默认状态，原来的光标状态
                        this.Cursor = holdCursor;
                    }
                }
            }
        }

        private void btnRefreash_Click(object sender, EventArgs e)
        {
            this.FormOnLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show("确定关闭吗？") != DialogResult.Yes)
            {
                return;
            }

            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem())
            {
                Component = this.grdOrder,
                Landscape = true,
                PaperKind = PaperKind.A3
            };
            link.CreateMarginalHeaderArea += LinkOnCreateMarginalHeaderArea;
            link.CreateDocument();
            link.ShowPreview();

        }

        private void LinkOnCreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            string titile = "订单列表";
            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.None, titile, Color.DarkBlue,new RectangleF(0, 0, 100, 21), DevExpress.XtraPrinting.BorderSide.None);
            brick.LineAlignment = BrickAlignment.Center;
            brick.Alignment = BrickAlignment.Center;
            brick.AutoWidth = true;
            brick.Font = new Font("宋体", 15f, FontStyle.Bold);
        }

        private void gridViewOrder_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //收款方式自定义显示
            if (e.Column.FieldName == "PaymentMode")
            {
                switch (BusinessLogic.ConvertToInt(e.Value))
                {
                    case 1:
                        e.DisplayText = "现金";
                        break;
                    case 2:
                        e.DisplayText = "票汇";
                        break;
                    case 3:
                        e.DisplayText = "信汇";
                        break;
                    case 4:
                        e.DisplayText = "电汇";
                        break;
                    case 5:
                        e.DisplayText = "承兑";
                        break;
                    case 6:
                        e.DisplayText = "信用证";
                        break;
                    default:
                        e.DisplayText = "其他";
                        break;
                }
            }
            
            //收款状态
            if (e.Column.FieldName == "PaymentState")
            {
                switch (BusinessLogic.ConvertToInt(e.Value))
                {
                    case 2:
                        e.DisplayText = "部分收款";
                        break;
                    case 3:
                        e.DisplayText = "全部收款";
                        break;
                    default:
                        e.DisplayText = "未收款";
                        break;
                }
            }
        }
    }
}
