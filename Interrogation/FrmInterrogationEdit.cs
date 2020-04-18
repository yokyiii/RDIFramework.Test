using RDIFramework.Utilities;
using RDIFramework.WinForm.Utilities;
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
    public partial class FrmInterrogationEdit : BaseForm
    {
        private InterrogationEntity currentInterrogationEntity = null;
        IDbProvider dbProvider = null;

        public FrmInterrogationEdit()
        {
            InitializeComponent();
        }
        public FrmInterrogationEdit(string productId) : this()
        {
            this.EntityId = productId;
        }

        public override void FormOnLoad()
        {
            dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConectionString);
            //修改数据
            if (!string.IsNullOrEmpty(this.EntityId))
            {
                BindEditData();
                //修改编辑窗口标题
                this.Text = "编辑问诊 - " + currentInterrogationEntity.PatientName;
            }
            else
            {
                //修改编辑窗口标题
                this.Text = "新增问诊";
                this.Date.Text = DateTime.Now.ToString();
            }
        }

        //绑定待修改的数据
        private void BindEditData()
        {
            currentInterrogationEntity = new InterrogationManager(dbProvider).GetEntity(this.EntityId);
            if (currentInterrogationEntity == null || string.IsNullOrEmpty(currentInterrogationEntity.Id)) return;
            FormBinding.BindObjectToControls(currentInterrogationEntity, this);
        }

        #region 保存新增的数据
        //获取新实体
        InterrogationEntity newInterrogationEntity = null;
        private InterrogationEntity GetDataEntity()
        {
            newInterrogationEntity = new InterrogationEntity();
            FormBinding.BindControlsToObject(newInterrogationEntity, this);
            return newInterrogationEntity;
        }

        private void SaveData(bool close)
        {
            InterrogationManager interrogationManager = new InterrogationManager(dbProvider, this.UserInfo);
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            //读取产品实体数据
            this.GetDataEntity();
            //判断是否有重复实体
            if (interrogationManager.Exists(new[] { InterrogationTable.FieldPatientName }
                        , new object[] { newInterrogationEntity.PatientName }))
            {
                MessageBoxHelper.ShowWarningMsg("库中已经存在相同数据，请重新检查输入！");
                PatientName.Focus();
            }
            else
            {
                string returnValue = interrogationManager.AddEntity(newInterrogationEntity);
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

        // 保存修改的数据
        private bool SaveEditData()
        {
            InterrogationManager interrogationManager = new InterrogationManager(dbProvider, this.UserInfo);
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            //新方法，一句话就搞定了
            FormBinding.BindControlsToObject(currentInterrogationEntity, this);
            int returnValue = interrogationManager.Update(currentInterrogationEntity);
            if (returnValue > 0)
            {
                this.Changed = true;
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0010);
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg("更新失败");
            }


            // 设置鼠标默认状态，原来的光标状态pl
            this.Cursor = holdCursor;
            return returnValue > 0;
        }
        #endregion
 
        //保存按钮事件
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
        //取消按钮事件
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

        //关闭按钮事件
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
    }
}
