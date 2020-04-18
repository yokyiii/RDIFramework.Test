using System;
using System.Data;
using System.Windows.Forms;
using RDIFramework.Test.WCFDemoProductService;

namespace RDIFramework.Test
{
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;
    using  RDIFrameworkDemo.BizLogic;

    public partial class FrmDemoProductAdmin : BaseForm
    {
        public FrmDemoProductAdmin()
        {
            InitializeComponent();
        }

         /// <summary>
        /// 产品信息
        /// </summary>
        private DataTable DTProductInfo = new DataTable(DemoProductTable.TableName);
        IDbProvider dbProvider = null;
        private string searchValue = "";

        #region public override string EntityId 产品主键
        /// <summary>
        /// 产品主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvProductInfo, DemoProductTable.FieldID);
            }
        }
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
        
         /// <summary>
        /// 本模块的查找权限
        /// </summary>
        private bool permissionSearch = false;

        #region public override void GetPermission() 获得权限
        /// <summary>
        /// 获得权限
        /// </summary>
        public override void GetPermission()
        {    
            this.permissionAdd      = this.IsAuthorized("DemoProductAdmin.Add");
            this.permissionEdit     = this.IsAuthorized("DemoProductAdmin.Edit");
            this.permissionDelete   = this.IsAuthorized("DemoProductAdmin.Delete");
            this.permissionSearch     = this.IsAuthorized("DemoProductAdmin.Search");
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
            if (this.DTProductInfo.DefaultView.Count <= 0)
            {                
                this.btnEdit.Enabled     = false;
                this.btnDelete.Enabled   = false;
            }
            else
            {
                this.btnEdit.Enabled     = this.permissionEdit;
                this.btnDelete.Enabled   = this.permissionDelete;
                this.btnSearch.Enabled     = this.permissionSearch;
            }           
        }
        #endregion

        #endregion

        public override void FormOnLoad()
        {
            //得到数据提供者（指定数据库类型【默认为：MsSqlserver】与数据库连接字符串【解密后】）
            //dbProvider = DbFactoryProvider.GetProvider(DbLinks["ProductDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["ProductDBLink"].DbLink));
            dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString);
            //绑定数据
            this.Search();
        }

        private void Search()
        {
            var recordCount = 0;
            this.DTProductInfo = GetData(out recordCount, ucPager.PageIndex, ucPager.PageSize, this.searchValue);
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            // 加载绑定数据
            this.GetList();
        }

        private DataTable GetData(out int recordCount, int pageIndex, int pageSize,string search)
        {
            return new DemoProductManager(dbProvider, this.UserInfo).GetDTByPage(out recordCount, pageIndex, pageSize, search, DemoProductTable.FieldCreateOn + " DESC ");
        }

        #region public override void GetList() 得到数据以绑定产品信息界面
        public override void GetList()
        {
            this.dgvProductInfo.AutoGenerateColumns = false;
            if (this.DTProductInfo.Columns.Count > 0)
            {
                this.DTProductInfo.DefaultView.Sort = DemoProductTable.FieldCreateOn;
            }
            this.dgvProductInfo.DataSource = this.DTProductInfo.DefaultView;
            this.SetControlState();
        }
        #endregion

        private void ucPager_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            Search();
            this.Cursor = holdCursor;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmProductEdit = new FrmDemoProductEdit { DbLinks = this.DbLinks };
            if (frmProductEdit.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.Search();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var frmProductEdit = new FrmDemoProductEdit(this.EntityId) { DbLinks = this.DbLinks };
            if (frmProductEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.Search();
            }
        }

        public void OnFormClosedRefreash()
        {
            this.Search();
        }

        private bool DeleteData()
        {
            //方法1、常规删除
            return new DemoProductManager(dbProvider, this.UserInfo).Delete(this.EntityId) > 0;
            //方法2：调用服务删除
            //return new DemoProductService().Delete(this.UserInfo, this.EntityId) >0;
            //方法3：调用WCF服务删除
            //WCFDemoProductService.UserInfo wcfUser = new WCFDemoProductService.UserInfo
            //{
            //    Idk__BackingField = this.UserInfo.Id,
            //    UserNamek__BackingField = this.UserInfo.UserName,
            //    IsAdministratork__BackingField = this.UserInfo.IsAdministrator
            //};
            //return new DemoProductServiceClient().Delete(wcfUser, this.EntityId) > 0;
            //方法4：WCF服务动态调用
            //string url = "http://localhost:8097/DemoProductService.svc";
            //IDemoProductService proxy = WCFInvokeFactory.CreateServiceByUrl<IDemoProductService>(url);
            //return proxy.Delete(this.UserInfo,this.EntityId) > 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProductInfo.CurrentCell == null || dgvProductInfo.Rows.Count <= 0)
            {
                return;
            }

            if (MessageBoxHelper.Show("确定删除当前所选产品信息？") != DialogResult.Yes) return;
            if (DeleteData())
            {
                MessageBoxHelper.ShowSuccessMsg("删除数据成功！");
                this.Search();
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg("删除数据失败！");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          
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
    }
}
