using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.Test
{
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;
    using RDIFrameworkDemo.BizLogic;
    public partial class frmHospitalAdmin : BaseForm
    {
        public frmHospitalAdmin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 病人信息
        /// </summary>
        private DataTable DTPatientInfo = new DataTable(InterrogationTable.TableName);
        IDbProvider dbProvider = null;
        private string searchValue = "";

        #region public override string EntityId 病人主键
        /// <summary>
        /// 病人主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvPatientInfo, (InterrogationTable.FieldId));
            }
        }
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
            this.DTPatientInfo = GetData(out recordCount, ucPager.PageIndex, ucPager.PageSize, this.searchValue);
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            // 加载绑定数据
            this.GetList();
        }

        private DataTable GetData(out int recordCount, int pageIndex, int pageSize, string search)
        {
            return new InterrogationManager(dbProvider, this.UserInfo).GetDTByPage(out recordCount, pageIndex, pageSize, search, InterrogationTable.FieldId + " DESC ");
        }

        #region public override void GetList() 得到数据以绑定产品信息界面
        public override void GetList()
        {
            this.dgvPatientInfo.AutoGenerateColumns = false;
            if (this.DTPatientInfo.Columns.Count > 0)
            {
                this.DTPatientInfo.DefaultView.Sort = SchoolTable.FieldId;
            }
            this.dgvPatientInfo.DataSource = this.DTPatientInfo.DefaultView;
            this.SetControlState();
        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var frmInterrogationEdit = new FrmInterrogationEdit { DbLinks = this.DbLinks };
            if (frmInterrogationEdit.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.Search();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var frmInterrogationEdit = new FrmInterrogationEdit(this.EntityId) { DbLinks = this.DbLinks };
            if (frmInterrogationEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.Search();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dgvPatientInfo.CurrentCell == null || dgvPatientInfo.Rows.Count <= 0)
            {
                return;
            }

            if (MessageBoxHelper.Show("确定删除当前所选病人信息？") != DialogResult.Yes) return;
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
        private bool DeleteData()
        {
            //方法1、常规删除
            return new InterrogationManager(dbProvider, this.UserInfo).Delete(this.EntityId) > 0;
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
    }
}
