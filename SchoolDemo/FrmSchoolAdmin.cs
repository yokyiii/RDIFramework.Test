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
    public partial class FrmSchoolAdmin : BaseForm
    {
        public FrmSchoolAdmin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 产品信息
        /// </summary>
        private DataTable DTSchoolInfo = new DataTable(SchoolTable.TableName);
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
                return BasePageLogic.GetDataGridViewEntityId(this.dgvSchoolInfo, SchoolTable.FieldId);
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
            this.DTSchoolInfo = GetData(out recordCount, ucPager.PageIndex, ucPager.PageSize, this.searchValue);
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            // 加载绑定数据
            this.GetList();
        }


        private DataTable GetData(out int recordCount, int pageIndex, int pageSize, string search)
        {
            return new SchoolManager(dbProvider, this.UserInfo).GetDTByPage(out recordCount, pageIndex, pageSize, search, SchoolTable.FieldId + " DESC ");
        }

        #region public override void GetList() 得到数据以绑定产品信息界面
        public override void GetList()
        {
            this.dgvSchoolInfo.AutoGenerateColumns = false;
            if (this.DTSchoolInfo.Columns.Count > 0)
            {
                this.DTSchoolInfo.DefaultView.Sort = SchoolTable.FieldId;
            }
            this.dgvSchoolInfo.DataSource = this.DTSchoolInfo.DefaultView;
            this.SetControlState();
        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var frmSchoolEdit = new FrmSchoolEdit { DbLinks = this.DbLinks };
            if (frmSchoolEdit.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.Search();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var frmSchoolEdit = new FrmSchoolEdit(this.EntityId) { DbLinks = this.DbLinks };
            if (frmSchoolEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.Search();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.FormOnLoad();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show("确定关闭吗？") != DialogResult.Yes)
            {
                return;
            }

            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dgvSchoolInfo.CurrentCell == null || dgvSchoolInfo.Rows.Count <= 0)
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
        private bool DeleteData()
        {
            //方法1、常规删除
            return new SchoolManager(dbProvider, this.UserInfo).Delete(this.EntityId) > 0;
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }
    }
}
