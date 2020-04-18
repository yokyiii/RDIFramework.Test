using System;
using System.Windows.Forms;

namespace RDIFramework.Test
{
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;
    using  RDIFrameworkDemo.BizLogic;

    public partial class FrmDemoProductEdit : BaseForm
    {
        private DemoProductEntity currentDemoProductEntity = null;
        IDbProvider dbProvider = null;

        public FrmDemoProductEdit()
        {
            InitializeComponent();
        }

        public FrmDemoProductEdit(string productId)
            : this()
        {            
            this.EntityId = productId;
        }

        public override void FormOnLoad()
        {
            //dbProvider = DbFactoryProvider.GetProvider(DbLinks["RDIFrameworkDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["RDIFrameworkDBLink"].DbLink));
            dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString);
            this.ProductCode.Text = BusinessLogic.NewGuid();
            //修改数据
            if (!string.IsNullOrEmpty(this.EntityId))
            {
                BindEditData();
                this.Text = "编辑产品 - " + currentDemoProductEntity.ProductName;
            }
        }

        #region private void BindEditData() 绑定待修改的数据
        private void BindEditData()
        {
            currentDemoProductEntity = new DemoProductManager(dbProvider).GetEntity(this.EntityId);
            if (currentDemoProductEntity == null || string.IsNullOrEmpty(currentDemoProductEntity.ProductName)) return;
            FormBinding.BindObjectToControls(currentDemoProductEntity, this);
        }
        #endregion

        DemoProductEntity DemoProductEntity = null;
        private DemoProductEntity GetDataEntity()
        {
            DemoProductEntity = new DemoProductEntity();
            FormBinding.BindControlsToObject(DemoProductEntity, this);
            return DemoProductEntity;
        }

        #region private void SaveData(bool close) 保存新增的数据
        private void SaveData(bool close)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            //读取产品实体数据
            this.GetDataEntity();

            if (new DemoProductManager(dbProvider, this.UserInfo).Exists(new[] { ProductInfoTable.FieldProductCode, ProductInfoTable.FieldProductName, ProductInfoTable.FieldDeleteMark }
                                                        , new object[] { DemoProductEntity.ProductCode, DemoProductEntity.ProductName, "0" }))
            {
                MessageBoxHelper.ShowWarningMsg("库中已经存在相同数据，请重新检查输入！");
                ProductName.Focus();
            }
            else
            {
                string returnValue = new DemoProductManager(dbProvider, this.UserInfo).AddEntity(DemoProductEntity);
                if (returnValue.Trim().Length > 0)
                {
                    this.Changed = true;
                    MessageBoxHelper.ShowSuccessMsg("新增成功！");
                }
                else
                {
                    MessageBoxHelper.ShowWarningMsg("新增数据失败!");
                }
            }

            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;

            if (this.Changed && close)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                if (OnFormClosedRefreash != null)
                {
                    OnFormClosedRefreash();
                }
            }
        }
        #endregion

        #region private bool SaveEditData() 保存修改的数据
        /// <summary>
        /// 保存修改的数据
        /// </summary>
        /// <returns></returns>
        private bool SaveEditData()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            //新方法，一句话就搞定了
            FormBinding.BindControlsToObject(currentDemoProductEntity, this);
         
            int returnValue = new DemoProductManager(dbProvider, this.UserInfo).Update(currentDemoProductEntity);
            if (returnValue > 0)
            {
                this.Changed = true;
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0010);
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg("更新失败");
            }


            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue > 0;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!BasePageLogic.ControlValueIsEmpty(pnlMain))
            {
                return;
            }

            if (string.IsNullOrEmpty(this.EntityId))
            {
                SaveData(true);
            }
            else
            {
                if (SaveEditData())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    if (OnFormClosedRefreash != null)
                    {
                        OnFormClosedRefreash();
                    }
                }
            }
        }

        public event FormClosedRefreashEventHandler OnFormClosedRefreash;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Changed)
            {
                if (MessageBoxHelper.Show("确定放弃操作？") == DialogResult.No)
                {
                    return;
                }

                if (OnFormClosedRefreash != null)
                {
                    OnFormClosedRefreash();
                }
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (this.Changed)
            {
                this.DialogResult = DialogResult.OK;
                if (OnFormClosedRefreash != null)
                {
                    OnFormClosedRefreash();
                }
            }
            this.Close();
        }

        //输入格式控制(主要是对KeyPress事件进行控制，只能输入数据和退格键和小数点)
        private void ProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') //小数点的话再加 e.KeyChar != '.'
            {
                e.Handled = true;
            }
        }
    }
}
