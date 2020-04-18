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
    public partial class FrmSchoolEdit : BaseForm
    {
        private SchoolEntity currentSchoolEntity = null;
        IDbProvider dbProvider = null;
        public FrmSchoolEdit()
        {
            InitializeComponent();
        }

        public FrmSchoolEdit(string productId)
: this()
        {
            this.EntityId = productId;
        }

        public override void FormOnLoad()
        {
            //dbProvider = DbFactoryProvider.GetProvider(DbLinks["RDIFrameworkDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["RDIFrameworkDBLink"].DbLink));
            dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString);
            this.Id.Text = BusinessLogic.NewGuid();
            //修改数据
            if (!string.IsNullOrEmpty(this.EntityId))
            {
                BindEditData();
                this.Text = "编辑产品 - " + currentSchoolEntity.NAME;
            }
        }

        #region private void BindEditData() 绑定待修改的数据
        private void BindEditData()
        {
            currentSchoolEntity = new SchoolManager(dbProvider).GetEntity(this.EntityId);
            if (currentSchoolEntity == null || string.IsNullOrEmpty(currentSchoolEntity.NAME)) return;
            FormBinding.BindObjectToControls(currentSchoolEntity, this);
        }
        #endregion




        #region private void SaveData(bool close) 保存新增的数据
        private void SaveData(bool close)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            //读取产品实体数据
            this.GetDataEntity();

            if (new SchoolManager(dbProvider, this.UserInfo).Exists(new[] { SchoolTable.FieldId, SchoolTable.FieldName, SchoolTable.FieldDelectmark }
                                                        , new object[] { schoolEntity.Id, schoolEntity.NAME, "0" }))
            {
                MessageBoxHelper.ShowWarningMsg("库中已经存在相同数据，请重新检查输入！");
                NAME.Focus();
            }
            else
            {
                string returnValue = new SchoolManager(dbProvider, this.UserInfo).AddEntity(schoolEntity);
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
            FormBinding.BindControlsToObject(currentSchoolEntity, this);

            int returnValue = new SchoolManager(dbProvider, this.UserInfo).Update(currentSchoolEntity);
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
        public event FormClosedRefreashEventHandler OnFormClosedRefreash;
        SchoolEntity schoolEntity = null;
        private SchoolEntity GetDataEntity()
        {
            schoolEntity = new SchoolEntity();
            FormBinding.BindControlsToObject(schoolEntity, this);
            return schoolEntity;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
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

        private void toolStripButton3_Click(object sender, EventArgs e)
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

        private void toolStripButton2_Click(object sender, EventArgs e)
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
    }
}
