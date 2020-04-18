namespace RDIFramework.Test
{
    partial class FrmDemoProductEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDemoProductEdit));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.ProductCode = new RDIFramework.Controls.UcTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.Description = new RDIFramework.Controls.UcTextBox(this.components);
            this.ProductUnit = new RDIFramework.Controls.UcTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ProductPrice = new RDIFramework.Controls.UcTextBox(this.components);
            this.ProductName = new RDIFramework.Controls.UcTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnCancel,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(492, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 22);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 22);
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.ProductCode);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.Description);
            this.pnlMain.Controls.Add(this.ProductUnit);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.ProductPrice);
            this.pnlMain.Controls.Add(this.ProductName);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(492, 222);
            this.pnlMain.TabIndex = 2;
            // 
            // ProductCode
            // 
            this.ProductCode.AccessibleName = "EmptyValue|NotNull";
            this.ProductCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ProductCode.Border.Class = "TextBoxBorder";
            this.ProductCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ProductCode.FocusHighlightEnabled = true;
            this.ProductCode.Location = new System.Drawing.Point(80, 11);
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.SelectedValue = null;
            this.ProductCode.Size = new System.Drawing.Size(392, 23);
            this.ProductCode.TabIndex = 0;
            this.ProductCode.Tag = "商品编号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(9, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 14);
            this.label8.TabIndex = 74;
            this.label8.Text = "商品编号：";
            // 
            // Description
            // 
            this.Description.AccessibleName = "EmptyValue";
            this.Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Description.Border.Class = "TextBoxBorder";
            this.Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Description.FocusHighlightEnabled = true;
            this.Description.Location = new System.Drawing.Point(80, 118);
            this.Description.Multiline = true;
            this.Description.Name = "Description";
            this.Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Description.SelectedValue = null;
            this.Description.Size = new System.Drawing.Size(392, 92);
            this.Description.TabIndex = 4;
            // 
            // ProductUnit
            // 
            this.ProductUnit.AccessibleName = "EmptyValue";
            this.ProductUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ProductUnit.Border.Class = "TextBoxBorder";
            this.ProductUnit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ProductUnit.FocusHighlightEnabled = true;
            this.ProductUnit.Location = new System.Drawing.Point(80, 91);
            this.ProductUnit.Name = "ProductUnit";
            this.ProductUnit.SelectedValue = null;
            this.ProductUnit.Size = new System.Drawing.Size(392, 23);
            this.ProductUnit.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 73;
            this.label7.Text = "产品备注：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(14, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 72;
            this.label4.Text = "单    位：";
            // 
            // ProductPrice
            // 
            this.ProductPrice.AccessibleName = "EmptyValue";
            this.ProductPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ProductPrice.Border.Class = "TextBoxBorder";
            this.ProductPrice.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ProductPrice.FocusHighlightEnabled = true;
            this.ProductPrice.Location = new System.Drawing.Point(80, 65);
            this.ProductPrice.Name = "ProductPrice";
            this.ProductPrice.SelectedValue = null;
            this.ProductPrice.Size = new System.Drawing.Size(392, 23);
            this.ProductPrice.TabIndex = 2;
            this.ProductPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProductPrice_KeyPress);
            // 
            // ProductName
            // 
            this.ProductName.AccessibleName = "EmptyValue|NotNull";
            this.ProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ProductName.Border.Class = "TextBoxBorder";
            this.ProductName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ProductName.FocusHighlightEnabled = true;
            this.ProductName.Location = new System.Drawing.Point(80, 37);
            this.ProductName.Name = "ProductName";
            this.ProductName.SelectedValue = null;
            this.ProductName.Size = new System.Drawing.Size(392, 23);
            this.ProductName.TabIndex = 1;
            this.ProductName.Tag = "商品名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(14, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 68;
            this.label3.Text = "单    价：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 64;
            this.label1.Text = "商品名称：";
            // 
            // FrmDemoProductEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 247);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "FrmDemoProductEdit";
            this.Text = "编辑产品";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Panel pnlMain;
        private Controls.UcTextBox ProductCode;
        private System.Windows.Forms.Label label8;
        private Controls.UcTextBox Description;
        private Controls.UcTextBox ProductUnit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private Controls.UcTextBox ProductPrice;
        private Controls.UcTextBox ProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;

    }
}