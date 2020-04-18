using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RDIFramework.Test
{
    using RDIFramework.BizLogic;
    using RDIFramework.ServiceCaller;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;
    using RDIFrameworkDemo.BizLogic;

    /// <summary>
    /// FrmEditOrder
    /// 编辑订单
    /// 
    /// 修改记录
    /// 
    ///     2018-08-09 EricHu 创建“编辑或新增订单”。
    /// </summary>
    public partial class FrmEditOrder : BaseForm
    {
        public event FormClosedRefreashEventHandler OnFormClosedRefreash;
        CaseOrderService caseOrderService = new CaseOrderService();
        private string OrderId = string.Empty;
        

        #region public override string EntityId 订单明细主键

        /// <summary>
        /// 订单明细主键
        /// </summary>
        public override string EntityId => BasePageLogic.GetDataGridViewEntityId(this.gridViewOrderDetail, "Id");

        #endregion
    
        /// <summary>
        /// 构造函数（新增）
        /// </summary>
        public FrmEditOrder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数（修改）
        /// <param name="orderId">订单主表主键</param>
        /// </summary>
        public FrmEditOrder(string orderId) : this()
        {
            OrderId = orderId;
        }

        public override void FormOnLoad()
        {
            InitControl();
            //修改
            if (!string.IsNullOrEmpty(OrderId))
            {
                //绑定数据
                this.BindFormData();
            }
            else //新增
            {
                this.Text = @"新增订单";
                cboPaymentMode.ItemIndex = 0;
                txtOrderCode.Text = @"DD-" + DateTimeHelper.ConvertDateTimeInt(DateTime.Now).ToString().Substring(0, 10);
                txtOrderDate.Text = DateTimeHelper.GetDate(DateTime.Now);
                txtPaymentDate.Text = DateTimeHelper.GetDate(DateTime.Now);
                txtCreateBy.Text = this.UserInfo.RealName;
                txtDescription.Focus();
                grdOrderDetail.DataSource = new BindingList<CaseOrderDetailEntity>();
            }
        }

        //界面控件初始化
        private void InitControl()
        {
            //绑定收款方式
            DataTable dtPaymentMode = RDIFrameworkService.Instance.ItemDetailsService.GetDTByCode(this.UserInfo, "CRM_PaymentMode");
            if (dtPaymentMode != null && dtPaymentMode.Rows.Count > 0)
            {
                cboPaymentMode.EditValue = CiItemDetailsTable.FieldItemValue;
                cboPaymentMode.Properties.ValueMember = CiItemDetailsTable.FieldItemValue;
                cboPaymentMode.Properties.DisplayMember = CiItemDetailsTable.FieldItemName;
                cboPaymentMode.Properties.DataSource = dtPaymentMode;
            }

            //绑定客户名称
            this.txtCustomerId.Properties.DataSource = RDIFrameworkService.Instance.StaffService.GetList(this.UserInfo);
            this.txtCustomerId.Properties.ValueMember = "Id";
            this.txtCustomerId.Properties.DisplayMember = "RealName";
            
            //绑定销售人员
            this.txtSellerId.Properties.TreeList.KeyFieldName = "Id";
            this.txtSellerId.Properties.TreeList.ParentFieldName = "ParentId";
            this.txtSellerId.Properties.DataSource = RDIFrameworkService.Instance.OrganizeService.GetList(this.UserInfo);
            this.txtSellerId.Properties.ValueMember = "Id";
            this.txtSellerId.Properties.DisplayMember = "FullName";

            //绑定明细表中的商品选择信息
            string itemId = RDIFrameworkService.Instance.ItemsService.GetEntityByCode(this.UserInfo, "CRM_ProductList").Id;
            if (!string.IsNullOrEmpty(itemId))
            {
                var productList = RDIFrameworkService.Instance.ItemsService.GetItemDetailListByItemId(this.UserInfo, itemId);
                if (productList != null && productList.Count > 0)
                {
                    List<CaseOrderDetailEntity> productListNew = productList.Select(entity => new CaseOrderDetailEntity
                    {
                        ProductId = entity.Id, ProductName = entity.ItemName, ProductCode = entity.ItemValue
                    }).ToList();
                    riglupProductId.DataSource = productListNew;
                    riglupProductId.ValueMember = "ProductId";
                    riglupProductId.DisplayMember = "ProductName";
                }
            }
        }

        //绑定界面数据
        private void BindFormData()
        {
            FrmWaiting.ShowMe(this);
            var order = caseOrderService.GetOrderEntity(this.UserInfo, OrderId);
            var orderDetailList = caseOrderService.GetOrderDetailListByOrderId(this.UserInfo, OrderId);
            grdOrderDetail.DataSource = new BindingList<CaseOrderDetailEntity>(orderDetailList); //这句话非常注意，不这样绑定的话新增时录入的数据下一个单元格会丢失

            if (order != null)
            {
                txtSellerId.EditValue = order.SellerId;
                txtCustomerId.EditValue = order.CustomerId;
                txtOrderDate.Text = DateTimeHelper.FormatDate(order.OrderDate == null ? "" : order.OrderDate.ToString());
                txtOrderCode.Text = order.OrderCode;
                txtDescription.Text = order.Description;
                txtDiscountSum.Text = BusinessLogic.ConvertToString(order.DiscountSum);
                txtAccounts.Text = BusinessLogic.ConvertToString(order.Accounts);
                txtPaymentDate.Text = DateTimeHelper.FormatDate(order.PaymentDate == null ? "" : order.PaymentDate.ToString());
                cboPaymentMode.EditValue = order.PaymentMode;
                txtSaleCost.Text = BusinessLogic.ConvertToString(order.SaleCost);
                txtCreateBy.Text = order.CreateBy;
                txtContractCode.Text = order.ContractCode;
            }
            FrmWaiting.HideMe(this);
        }

        //保存数据
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.Changed)
            {   
                //数据未被修改过就直接返回即可
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                CaseOrderEntity orderEntity = GetFormOrderEntity();
                grdOrderDetail.FocusedView.CloseEditor();
                var orderDetailList = new List<CaseOrderDetailEntity>();
                for (int i = 0; i < this.gridViewOrderDetail.RowCount; i++)
                {
                    var detailInfo = gridViewOrderDetail.GetRow(i) as CaseOrderDetailEntity;
                    detailInfo.OrderId = orderEntity.Id;
                    if (detailInfo != null)
                    {
                        orderDetailList.Add(detailInfo);
                    }
                }
                try
                {
                    
                    int returnValue = caseOrderService.SaveOrder(this.UserInfo, OrderId, orderEntity, orderDetailList);
                    if (returnValue > 0)
                    {
                        MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0011);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        OnFormClosedRefreash?.Invoke();
                    }
                }
                catch (Exception ex)
                {
                    ProcessException(ex);
                }
            }
        }

        /// <summary>
        /// 得到表单上的数据转订单实体
        /// </summary>
        /// <returns></returns>
        private CaseOrderEntity GetFormOrderEntity()
        {
            CaseOrderEntity orderEntity = new CaseOrderEntity();
            if (!string.IsNullOrEmpty(this.OrderId))
            {
                orderEntity = caseOrderService.GetOrderEntity(this.UserInfo, this.OrderId);
                orderEntity.ModifiedBy = this.UserInfo.RealName;
                orderEntity.ModifiedUserId = this.UserInfo.Id;
                orderEntity.ModifiedOn = DateTime.Now;
            }
            else
            {
                orderEntity.Id = BusinessLogic.NewGuid(); //新增
                orderEntity.Enabled = 1;
                orderEntity.DeleteMark = 0;
            }
            orderEntity.CustomerName = txtCustomerId.Text;
            orderEntity.CustomerId = BusinessLogic.ConvertToString(txtCustomerId.EditValue);
            orderEntity.SellerId = BusinessLogic.ConvertToString(txtSellerId.EditValue);
            orderEntity.SellerName = txtSellerId.Text;
            orderEntity.OrderDate = BusinessLogic.ConvertToNullableDateTime(txtOrderDate.Text);
            orderEntity.OrderCode = txtOrderCode.Text;
            orderEntity.Description = txtDescription.Text.Trim();
            orderEntity.DiscountSum = BusinessLogic.ConvertToNullableDecimal(txtDiscountSum.Text);
            orderEntity.Accounts = BusinessLogic.ConvertToNullableDecimal(txtAccounts.Text);
            orderEntity.PaymentDate = BusinessLogic.ConvertToNullableDateTime(txtPaymentDate.Text);
            orderEntity.PaymentMode = cboPaymentMode.Text;
            orderEntity.SaleCost = BusinessLogic.ConvertToNullableDecimal(txtSaleCost.Text);
            orderEntity.CreateBy = this.UserInfo.RealName;
            orderEntity.ContractCode = txtContractCode.Text;

            return orderEntity;
        }

        //关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show("确定关闭吗？") != DialogResult.Yes)
            {
                return;
            }

            this.Close();
        }

        private void gridViewOrderDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null)
            {
                return;
            }
            
            view.SetRowCellValue(e.RowHandle, view.Columns["UnitId"], "套");
            view.SetRowCellValue(e.RowHandle, view.Columns["Qty"], 1.00);
            view.SetRowCellValue(e.RowHandle, view.Columns["Price"], 0.00);
            view.SetRowCellValue(e.RowHandle, view.Columns["Amount"], 0.00);
            view.SetRowCellValue(e.RowHandle, view.Columns["TaxRate"], 0.00);
            view.SetRowCellValue(e.RowHandle, view.Columns["TaxPrice"], 0.00);
            view.SetRowCellValue(e.RowHandle, view.Columns["Tax"], 0.00);
            view.SetRowCellValue(e.RowHandle, view.Columns["TaxAmount"], 0.00);
            this.Changed = true;
        }

        private void gridViewOrderDetail_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var rowdata = (CaseOrderDetailEntity)e.Row;
            Console.WriteLine(rowdata.ProductName);
        }

        private void gridViewOrderDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0)
            {
                return;
            }
            return;
            //以下代码会导致死循环，暂时取消
            //价格换算
            gridViewOrderDetail.GetRowCellValue(e.RowHandle, "Price"); 
            var qty = BusinessLogic.ConvertToNullableDecimal(gridViewOrderDetail.GetRowCellValue(e.RowHandle, "Qty")) ?? 0;                    //数量
            var price = BusinessLogic.ConvertToNullableDecimal(gridViewOrderDetail.GetRowCellValue(e.RowHandle, "Price")) ?? 0;                //单价
            var amount = BusinessLogic.ConvertToNullableDecimal(gridViewOrderDetail.GetRowCellValue(e.RowHandle, "Amount")) ?? 0;              //金额
            var taxRate = BusinessLogic.ConvertToNullableDecimal(gridViewOrderDetail.GetRowCellValue(e.RowHandle, "TaxRate")) ?? 0;            //税率(%)
            var taxPrice = BusinessLogic.ConvertToNullableDecimal(gridViewOrderDetail.GetRowCellValue(e.RowHandle, "TaxPrice")) ?? 0;          //含税单价
            var tax = BusinessLogic.ConvertToNullableDecimal(gridViewOrderDetail.GetRowCellValue(e.RowHandle, "Tax")) ?? 0;                    //税额
            var taxAmount = BusinessLogic.ConvertToNullableDecimal(gridViewOrderDetail.GetRowCellValue(e.RowHandle, "TaxAmount")) ?? 0;        //含税金额

            if (e.Column.FieldName == "TaxPrice")
            {
                //单价 * (1 + (税率 / 100))=含税单价
                price = taxPrice / (1 + (taxRate / 100));
                gridViewOrderDetail.SetRowCellValue(e.RowHandle, "Price", price);
            }
            //else
            //{
            //    //单价 * (1 + (税率 / 100))=含税单价
            //    taxPrice = price * (1 + (taxRate/ 100));
            //    gridViewOrderDetail.SetRowCellValue(e.RowHandle, "TaxPrice", taxPrice);
            //}

            //数量*单价=金额
            amount = qty * price;
            gridViewOrderDetail.SetRowCellValue(e.RowHandle, "Amount", amount);

            //(含税单价-单价)*数量=税额
            tax = (taxPrice - price) * qty;
            gridViewOrderDetail.SetRowCellValue(e.RowHandle, "Tax", tax);

            //数量*含税单价=含税金额
            taxAmount = qty * taxPrice;
            gridViewOrderDetail.SetRowCellValue(e.RowHandle, "TaxAmount", taxAmount);
        }

        private void riglupProductId_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.BaseEdit edit = gridViewOrderDetail.ActiveEditor;
            switch (gridViewOrderDetail.FocusedColumn.FieldName)
            {
                case "ProductId":
                    var entity = RDIFrameworkService.Instance.ItemDetailsService.GetEntity(this.UserInfo, edit.EditValue.ToString());
                    gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductName"], entity.ItemName);
                    gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductCode"], entity.ItemValue);
                    gridViewOrderDetail.SetFocusedRowCellValue(gridViewOrderDetail.Columns["ProductId"], edit.EditValue);
                    break;
            }
            this.Changed = true;
        }

        private void gridViewOrderDetail_KeyDown(object sender, KeyEventArgs e)
        {
            //按键盘上的delete键删除数据
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.Yes)
                {
                    GridView view = sender as GridView;
                    view.DeleteSelectedRows(); //删除选中行
                    this.Changed = true;
                    //这个只删除当前行
                    //view.DeleteRow(view.FocusedRowHandle);
                }               
            }
        }
    }
}
