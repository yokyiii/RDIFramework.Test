namespace RDIFramework.Test
{
    partial class FrmOrderAdmin
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new RDIFramework.Controls.UcButton();
            this.btnPrint = new RDIFramework.Controls.UcButton();
            this.btnRefreash = new RDIFramework.Controls.UcButton();
            this.btnDel = new RDIFramework.Controls.UcButton();
            this.btnEdit = new RDIFramework.Controls.UcButton();
            this.btnAdd = new RDIFramework.Controls.UcButton();
            this.btnSearch = new RDIFramework.Controls.UcButton();
            this.txtSerarch = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdOrder = new RDIFramework.Controls.UcDevGridControl();
            this.gridViewOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OrderCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SellerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiscountSum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Accounts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PaymentMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PaymentState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Enabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.CreateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ModifiedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucPagerOrder = new RDIFramework.Controls.UcPagerEx();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdOrderDetail = new RDIFramework.Controls.UcDevGridControl();
            this.gridViewOrderDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetailId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UnitId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaxRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaxPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaxAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerarch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnPrint);
            this.panelControl1.Controls.Add(this.btnRefreash);
            this.panelControl1.Controls.Add(this.btnDel);
            this.panelControl1.Controls.Add(this.btnEdit);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.txtSerarch);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(5, 5);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(10);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panelControl1.Size = new System.Drawing.Size(981, 50);
            this.panelControl1.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(768, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Location = new System.Drawing.Point(687, 14);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRefreash
            // 
            this.btnRefreash.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnRefreash.Appearance.Options.UseFont = true;
            this.btnRefreash.Location = new System.Drawing.Point(606, 14);
            this.btnRefreash.Name = "btnRefreash";
            this.btnRefreash.Size = new System.Drawing.Size(75, 23);
            this.btnRefreash.TabIndex = 6;
            this.btnRefreash.Text = "刷新";
            this.btnRefreash.Click += new System.EventHandler(this.btnRefreash_Click);
            // 
            // btnDel
            // 
            this.btnDel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnDel.Appearance.Options.UseFont = true;
            this.btnDel.Location = new System.Drawing.Point(525, 14);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Location = new System.Drawing.Point(444, 14);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "修改";
            this.btnEdit.Click += new System.EventHandler(this.btnEditToTab_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Location = new System.Drawing.Point(360, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAddToTab_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Location = new System.Drawing.Point(270, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSerarch
            // 
            this.txtSerarch.Location = new System.Drawing.Point(99, 13);
            this.txtSerarch.Name = "txtSerarch";
            this.txtSerarch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtSerarch.Properties.Appearance.Options.UseFont = true;
            this.txtSerarch.Size = new System.Drawing.Size(165, 26);
            this.txtSerarch.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Location = new System.Drawing.Point(10, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "搜索关键字：";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(5, 55);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(981, 567);
            this.splitContainerControl1.SplitterPosition = 231;
            this.splitContainerControl1.TabIndex = 10;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdOrder);
            this.groupControl2.Controls.Add(this.panel1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(981, 231);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "订单列表";
            // 
            // grdOrder
            // 
            this.grdOrder.CheckboxFieldName = "colSelected";
            this.grdOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrder.Location = new System.Drawing.Point(2, 21);
            this.grdOrder.MainView = this.gridViewOrder;
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdOrder.Size = new System.Drawing.Size(977, 177);
            this.grdOrder.TabIndex = 11;
            this.grdOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOrder});
            // 
            // gridViewOrder
            // 
            this.gridViewOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.OrderDate,
            this.OrderCode,
            this.gridColumn3,
            this.SellerName,
            this.DiscountSum,
            this.Accounts,
            this.PaymentMode,
            this.PaymentState,
            this.Enabled,
            this.CreateBy,
            this.ModifiedOn,
            this.Description});
            this.gridViewOrder.GridControl = this.grdOrder;
            this.gridViewOrder.IndicatorWidth = 50;
            this.gridViewOrder.Name = "gridViewOrder";
            this.gridViewOrder.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridViewOrder.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewOrder.OptionsView.ShowAutoFilterRow = true;
            this.gridViewOrder.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewOrder.OptionsView.ShowGroupedColumns = true;
            this.gridViewOrder.OptionsView.ShowGroupPanel = false;
            this.gridViewOrder.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewOrder_FocusedRowChanged);
            this.gridViewOrder.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewOrder_CustomColumnDisplayText);
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // OrderDate
            // 
            this.OrderDate.Caption = "单据日期";
            this.OrderDate.DisplayFormat.FormatString = "d";
            this.OrderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.OrderDate.FieldName = "OrderDate";
            this.OrderDate.MaxWidth = 200;
            this.OrderDate.MinWidth = 80;
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.Visible = true;
            this.OrderDate.VisibleIndex = 0;
            this.OrderDate.Width = 100;
            // 
            // OrderCode
            // 
            this.OrderCode.Caption = "单据编号";
            this.OrderCode.FieldName = "OrderCode";
            this.OrderCode.MaxWidth = 200;
            this.OrderCode.MinWidth = 130;
            this.OrderCode.Name = "OrderCode";
            this.OrderCode.Visible = true;
            this.OrderCode.VisibleIndex = 1;
            this.OrderCode.Width = 130;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "客户名称";
            this.gridColumn3.FieldName = "CustomerName";
            this.gridColumn3.MaxWidth = 300;
            this.gridColumn3.MinWidth = 180;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 250;
            // 
            // SellerName
            // 
            this.SellerName.Caption = "销售人员";
            this.SellerName.FieldName = "SellerName";
            this.SellerName.MaxWidth = 200;
            this.SellerName.MinWidth = 80;
            this.SellerName.Name = "SellerName";
            this.SellerName.Visible = true;
            this.SellerName.VisibleIndex = 3;
            this.SellerName.Width = 80;
            // 
            // DiscountSum
            // 
            this.DiscountSum.Caption = "优惠金额";
            this.DiscountSum.DisplayFormat.FormatString = "n2";
            this.DiscountSum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DiscountSum.FieldName = "DiscountSum";
            this.DiscountSum.MaxWidth = 150;
            this.DiscountSum.MinWidth = 80;
            this.DiscountSum.Name = "DiscountSum";
            this.DiscountSum.Visible = true;
            this.DiscountSum.VisibleIndex = 4;
            this.DiscountSum.Width = 80;
            // 
            // Accounts
            // 
            this.Accounts.Caption = "收款金额";
            this.Accounts.DisplayFormat.FormatString = "n2";
            this.Accounts.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Accounts.FieldName = "Accounts";
            this.Accounts.MaxWidth = 150;
            this.Accounts.MinWidth = 80;
            this.Accounts.Name = "Accounts";
            this.Accounts.Visible = true;
            this.Accounts.VisibleIndex = 5;
            this.Accounts.Width = 80;
            // 
            // PaymentMode
            // 
            this.PaymentMode.Caption = "收款方式";
            this.PaymentMode.FieldName = "PaymentMode";
            this.PaymentMode.MaxWidth = 100;
            this.PaymentMode.MinWidth = 60;
            this.PaymentMode.Name = "PaymentMode";
            this.PaymentMode.Visible = true;
            this.PaymentMode.VisibleIndex = 6;
            this.PaymentMode.Width = 80;
            // 
            // PaymentState
            // 
            this.PaymentState.Caption = "收款状态";
            this.PaymentState.FieldName = "PaymentState";
            this.PaymentState.MaxWidth = 100;
            this.PaymentState.MinWidth = 60;
            this.PaymentState.Name = "PaymentState";
            this.PaymentState.Visible = true;
            this.PaymentState.VisibleIndex = 7;
            this.PaymentState.Width = 80;
            // 
            // Enabled
            // 
            this.Enabled.Caption = "有效";
            this.Enabled.ColumnEdit = this.repositoryItemCheckEdit1;
            this.Enabled.FieldName = "Enabled";
            this.Enabled.MaxWidth = 80;
            this.Enabled.MinWidth = 50;
            this.Enabled.Name = "Enabled";
            this.Enabled.Visible = true;
            this.Enabled.VisibleIndex = 8;
            this.Enabled.Width = 80;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // CreateBy
            // 
            this.CreateBy.Caption = "制单人员";
            this.CreateBy.FieldName = "CreateBy";
            this.CreateBy.MaxWidth = 150;
            this.CreateBy.MinWidth = 80;
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.Visible = true;
            this.CreateBy.VisibleIndex = 9;
            this.CreateBy.Width = 80;
            // 
            // ModifiedOn
            // 
            this.ModifiedOn.Caption = "最后修改时间";
            this.ModifiedOn.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.ModifiedOn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ModifiedOn.FieldName = "ModifiedOn";
            this.ModifiedOn.MaxWidth = 180;
            this.ModifiedOn.MinWidth = 130;
            this.ModifiedOn.Name = "ModifiedOn";
            this.ModifiedOn.Visible = true;
            this.ModifiedOn.VisibleIndex = 10;
            this.ModifiedOn.Width = 130;
            // 
            // Description
            // 
            this.Description.Caption = "备注";
            this.Description.FieldName = "Description";
            this.Description.MaxWidth = 300;
            this.Description.MinWidth = 150;
            this.Description.Name = "Description";
            this.Description.Visible = true;
            this.Description.VisibleIndex = 11;
            this.Description.Width = 200;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucPagerOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 31);
            this.panel1.TabIndex = 10;
            // 
            // ucPagerOrder
            // 
            this.ucPagerOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPagerOrder.AutoSize = true;
            this.ucPagerOrder.Location = new System.Drawing.Point(376, 4);
            this.ucPagerOrder.Name = "ucPagerOrder";
            this.ucPagerOrder.PageIndex = 1;
            this.ucPagerOrder.PageSize = 50;
            this.ucPagerOrder.RecordCount = 0;
            this.ucPagerOrder.Size = new System.Drawing.Size(598, 26);
            this.ucPagerOrder.TabIndex = 2;
            this.ucPagerOrder.PageChanged += new RDIFramework.Controls.PageChangedEventHandler(this.ucPagerOrder_PageChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.grdOrderDetail);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(981, 311);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "订单明细";
            // 
            // grdOrderDetail
            // 
            this.grdOrderDetail.CheckboxFieldName = "colSelected";
            this.grdOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrderDetail.Location = new System.Drawing.Point(2, 21);
            this.grdOrderDetail.MainView = this.gridViewOrderDetail;
            this.grdOrderDetail.Name = "grdOrderDetail";
            this.grdOrderDetail.Size = new System.Drawing.Size(977, 288);
            this.grdOrderDetail.TabIndex = 10;
            this.grdOrderDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOrderDetail});
            // 
            // gridViewOrderDetail
            // 
            this.gridViewOrderDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetailId,
            this.ProductName,
            this.ProductCode,
            this.UnitId,
            this.Qty,
            this.Price,
            this.Amount,
            this.TaxRate,
            this.TaxPrice,
            this.Tax,
            this.TaxAmount,
            this.colDetailDescription});
            this.gridViewOrderDetail.GridControl = this.grdOrderDetail;
            this.gridViewOrderDetail.IndicatorWidth = 50;
            this.gridViewOrderDetail.Name = "gridViewOrderDetail";
            this.gridViewOrderDetail.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridViewOrderDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewOrderDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridViewOrderDetail.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewOrderDetail.OptionsView.ShowFooter = true;
            this.gridViewOrderDetail.OptionsView.ShowGroupedColumns = true;
            this.gridViewOrderDetail.OptionsView.ShowGroupPanel = false;
            // 
            // colDetailId
            // 
            this.colDetailId.Caption = "Id";
            this.colDetailId.FieldName = "Id";
            this.colDetailId.Name = "colDetailId";
            // 
            // ProductName
            // 
            this.ProductName.Caption = "商品名称";
            this.ProductName.FieldName = "ProductName";
            this.ProductName.MaxWidth = 300;
            this.ProductName.MinWidth = 180;
            this.ProductName.Name = "ProductName";
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 0;
            this.ProductName.Width = 260;
            // 
            // ProductCode
            // 
            this.ProductCode.Caption = "商品编号";
            this.ProductCode.FieldName = "ProductCode";
            this.ProductCode.MaxWidth = 200;
            this.ProductCode.MinWidth = 120;
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.Visible = true;
            this.ProductCode.VisibleIndex = 1;
            this.ProductCode.Width = 120;
            // 
            // UnitId
            // 
            this.UnitId.Caption = "单位";
            this.UnitId.FieldName = "UnitId";
            this.UnitId.MaxWidth = 100;
            this.UnitId.MinWidth = 60;
            this.UnitId.Name = "UnitId";
            this.UnitId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "UnitId", "合计")});
            this.UnitId.Visible = true;
            this.UnitId.VisibleIndex = 2;
            this.UnitId.Width = 100;
            // 
            // Qty
            // 
            this.Qty.Caption = "数量";
            this.Qty.DisplayFormat.FormatString = "n0";
            this.Qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Qty.FieldName = "Qty";
            this.Qty.MaxWidth = 120;
            this.Qty.MinWidth = 80;
            this.Qty.Name = "Qty";
            this.Qty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:n0}")});
            this.Qty.Visible = true;
            this.Qty.VisibleIndex = 3;
            this.Qty.Width = 80;
            // 
            // Price
            // 
            this.Price.Caption = "单价";
            this.Price.DisplayFormat.FormatString = "n2";
            this.Price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Price.FieldName = "Price";
            this.Price.MaxWidth = 120;
            this.Price.MinWidth = 80;
            this.Price.Name = "Price";
            this.Price.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Price", "{0:n2}")});
            this.Price.Visible = true;
            this.Price.VisibleIndex = 4;
            this.Price.Width = 80;
            // 
            // Amount
            // 
            this.Amount.Caption = "金额";
            this.Amount.DisplayFormat.FormatString = "n2";
            this.Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.FieldName = "Amount";
            this.Amount.MaxWidth = 120;
            this.Amount.MinWidth = 80;
            this.Amount.Name = "Amount";
            this.Amount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n2}")});
            this.Amount.Visible = true;
            this.Amount.VisibleIndex = 5;
            this.Amount.Width = 80;
            // 
            // TaxRate
            // 
            this.TaxRate.Caption = "税率(%)";
            this.TaxRate.DisplayFormat.FormatString = "n2";
            this.TaxRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TaxRate.FieldName = "TaxRate";
            this.TaxRate.MaxWidth = 120;
            this.TaxRate.MinWidth = 80;
            this.TaxRate.Name = "TaxRate";
            this.TaxRate.Visible = true;
            this.TaxRate.VisibleIndex = 6;
            this.TaxRate.Width = 80;
            // 
            // TaxPrice
            // 
            this.TaxPrice.Caption = "含税单价";
            this.TaxPrice.DisplayFormat.FormatString = "n2";
            this.TaxPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TaxPrice.FieldName = "TaxPrice";
            this.TaxPrice.MaxWidth = 120;
            this.TaxPrice.MinWidth = 80;
            this.TaxPrice.Name = "TaxPrice";
            this.TaxPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TaxPrice", "{0:n2}")});
            this.TaxPrice.Visible = true;
            this.TaxPrice.VisibleIndex = 7;
            this.TaxPrice.Width = 82;
            // 
            // Tax
            // 
            this.Tax.Caption = "税额";
            this.Tax.DisplayFormat.FormatString = "n2";
            this.Tax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Tax.FieldName = "Tax";
            this.Tax.MaxWidth = 120;
            this.Tax.MinWidth = 80;
            this.Tax.Name = "Tax";
            this.Tax.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Tax", "{0:n2}")});
            this.Tax.Visible = true;
            this.Tax.VisibleIndex = 8;
            this.Tax.Width = 80;
            // 
            // TaxAmount
            // 
            this.TaxAmount.Caption = "含税金额";
            this.TaxAmount.DisplayFormat.FormatString = "n2";
            this.TaxAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TaxAmount.FieldName = "TaxAmount";
            this.TaxAmount.MaxWidth = 120;
            this.TaxAmount.MinWidth = 80;
            this.TaxAmount.Name = "TaxAmount";
            this.TaxAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TaxAmount", "{0:n2}")});
            this.TaxAmount.Visible = true;
            this.TaxAmount.VisibleIndex = 9;
            this.TaxAmount.Width = 80;
            // 
            // colDetailDescription
            // 
            this.colDetailDescription.Caption = "说明信息";
            this.colDetailDescription.FieldName = "Description";
            this.colDetailDescription.MaxWidth = 300;
            this.colDetailDescription.MinWidth = 200;
            this.colDetailDescription.Name = "colDetailDescription";
            this.colDetailDescription.Visible = true;
            this.colDetailDescription.VisibleIndex = 10;
            this.colDetailDescription.Width = 200;
            // 
            // FrmOrderAdmin
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 627);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmOrderAdmin";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "订单管理";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerarch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrderDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSerarch;
        private Controls.UcButton btnSearch;
        private Controls.UcButton btnClose;
        private Controls.UcButton btnPrint;
        private Controls.UcButton btnRefreash;
        private Controls.UcButton btnDel;
        private Controls.UcButton btnEdit;
        private Controls.UcButton btnAdd;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private Controls.UcDevGridControl grdOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOrder;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn OrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn OrderCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn SellerName;
        private DevExpress.XtraGrid.Columns.GridColumn DiscountSum;
        private DevExpress.XtraGrid.Columns.GridColumn Accounts;
        private DevExpress.XtraGrid.Columns.GridColumn PaymentMode;
        private DevExpress.XtraGrid.Columns.GridColumn PaymentState;
        private DevExpress.XtraGrid.Columns.GridColumn Enabled;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn CreateBy;
        private DevExpress.XtraGrid.Columns.GridColumn ModifiedOn;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private System.Windows.Forms.Panel panel1;
        private Controls.UcPagerEx ucPagerOrder;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Controls.UcDevGridControl grdOrderDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOrderDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailId;
        private DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn UnitId;
        private DevExpress.XtraGrid.Columns.GridColumn Qty;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private DevExpress.XtraGrid.Columns.GridColumn Amount;
        private DevExpress.XtraGrid.Columns.GridColumn TaxRate;
        private DevExpress.XtraGrid.Columns.GridColumn TaxPrice;
        private DevExpress.XtraGrid.Columns.GridColumn Tax;
        private DevExpress.XtraGrid.Columns.GridColumn TaxAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailDescription;
    }
}