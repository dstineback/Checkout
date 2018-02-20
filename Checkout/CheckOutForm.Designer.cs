using DevExpress.XtraEditors;

namespace Checkout
{
    partial class CheckOutForm
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true);
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckOutForm));
            this.tileBar = new DevExpress.XtraBars.Navigation.TileBar();
            this.tileBarGroupTables = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.eployeesTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.customersTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarItem2 = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.navigationFrame = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.employeesNavigationPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.jobStepText = new DevExpress.XtraEditors.TextEdit();
            this.JobIDlookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.bindJobsList = new System.Windows.Forms.BindingSource(this.components);
            this.WorkOpLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.bindWorkOp = new System.Windows.Forms.BindingSource(this.components);
            this.WorkOpLabel = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.bindUser = new System.Windows.Forms.BindingSource(this.components);
            this.JobIDLabel = new DevExpress.XtraEditors.LabelControl();
            this.GetJobButton = new DevExpress.XtraEditors.SimpleButton();
            this.reasonLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.bindReason = new System.Windows.Forms.BindingSource(this.components);
            this.takenByLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindOpenJobs = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewJobs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.dateLabel = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit = new DevExpress.XtraEditors.DateEdit();
            this.reasonLabel = new DevExpress.XtraEditors.LabelControl();
            this.takenByLabel = new DevExpress.XtraEditors.LabelControl();
            this.userNameIDLabel = new DevExpress.XtraEditors.LabelControl();
            this.employeesLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.storeRoomCombo = new DevExpress.XtraEditors.LookUpEdit();
            this.bindStoreroom = new System.Windows.Forms.BindingSource(this.components);
            this.userNameTextBox = new DevExpress.XtraEditors.LookUpEdit();
            this.JobIDTextEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.customersNavigationPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.partIDLookUp = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.bindPart = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColumnN_masterpartid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnMasterpartid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnMasterpartDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StoreRoomNameLable = new DevExpress.XtraEditors.LabelControl();
            this.btnAddPartsFromGrid = new DevExpress.XtraEditors.SimpleButton();
            this.storeRoom = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.storeroomPartsLabel = new DevExpress.XtraEditors.LabelControl();
            this.QTYLabel = new DevExpress.XtraEditors.LabelControl();
            this.QTYspinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlPartsAdded = new DevExpress.XtraGrid.GridControl();
            this.gridViewPartsAdded = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.masterpartid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnMasterpartIDDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.n_masterpartid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkOutButton = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlParts = new DevExpress.XtraGrid.GridControl();
            this.gridViewParts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.partIDLabel = new DevExpress.XtraEditors.LabelControl();
            this.addPartButton = new DevExpress.XtraEditors.SimpleButton();
            this.customersLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.btnGetSingleTransaction = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.transactionNumberLabel = new DevExpress.XtraEditors.LabelControl();
            this.txtTransactionNumber = new DevExpress.XtraEditors.TextEdit();
            this.transactionHistoryGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewTrransactionHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TextTransactionNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.masterpart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.storeroomcolumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Aisle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Shelf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Bin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReqQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QTYNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UOI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.jobid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.userNameLabel = new DevExpress.XtraEditors.LabelControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogOut = new DevExpress.XtraEditors.SimpleButton();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).BeginInit();
            this.navigationFrame.SuspendLayout();
            this.employeesNavigationPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobStepText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobIDlookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindJobsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkOpLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindWorkOp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reasonLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.takenByLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindOpenJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeRoomCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindStoreroom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.customersNavigationPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partIDLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeRoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QTYspinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPartsAdded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPartsAdded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewParts)).BeginInit();
            this.navigationPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransactionNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionHistoryGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTrransactionHistory)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // tileBar
            // 
            this.tileBar.AllowDrag = false;
            this.tileBar.AllowGlyphSkinning = true;
            this.tileBar.AllowSelectedItem = true;
            this.tileBar.AppearanceGroupText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tileBar.AppearanceGroupText.Options.UseForeColor = true;
            this.tileBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tileBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.tileBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileBar.DropDownButtonWidth = 30;
            this.tileBar.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar.Groups.Add(this.tileBarGroupTables);
            this.tileBar.IndentBetweenGroups = 10;
            this.tileBar.IndentBetweenItems = 10;
            this.tileBar.ItemPadding = new System.Windows.Forms.Padding(8, 6, 12, 6);
            this.tileBar.Location = new System.Drawing.Point(0, 0);
            this.tileBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tileBar.MaxId = 5;
            this.tileBar.MaximumSize = new System.Drawing.Size(0, 110);
            this.tileBar.MinimumSize = new System.Drawing.Size(100, 110);
            this.tileBar.Name = "tileBar";
            this.tileBar.Padding = new System.Windows.Forms.Padding(29, 11, 29, 11);
            this.tileBar.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.None;
            this.tileBar.SelectedItem = this.eployeesTileBarItem;
            this.tileBar.SelectionBorderWidth = 2;
            this.tileBar.SelectionColor = System.Drawing.Color.DodgerBlue;
            this.tileBar.SelectionColorMode = DevExpress.XtraBars.Navigation.SelectionColorMode.UseItemBackColor;
            this.tileBar.ShowGroupText = false;
            this.tileBar.Size = new System.Drawing.Size(1008, 110);
            this.tileBar.TabIndex = 1;
            this.tileBar.Text = "tileBar";
            this.tileBar.WideTileWidth = 150;
            this.tileBar.SelectedItemChanged += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileBar_SelectedItemChanged);
            // 
            // tileBarGroupTables
            // 
            this.tileBarGroupTables.Items.Add(this.eployeesTileBarItem);
            this.tileBarGroupTables.Items.Add(this.customersTileBarItem);
            this.tileBarGroupTables.Items.Add(this.tileBarItem2);
            this.tileBarGroupTables.Name = "tileBarGroupTables";
            this.tileBarGroupTables.Text = "TABLES";
            // 
            // eployeesTileBarItem
            // 
            this.eployeesTileBarItem.AppearanceItem.Hovered.BackColor = System.Drawing.Color.Crimson;
            this.eployeesTileBarItem.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.eployeesTileBarItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.Gray;
            this.eployeesTileBarItem.AppearanceItem.Normal.Options.UseBackColor = true;
            this.eployeesTileBarItem.AppearanceItem.Pressed.BackColor = System.Drawing.Color.Crimson;
            this.eployeesTileBarItem.AppearanceItem.Pressed.Options.UseBackColor = true;
            this.eployeesTileBarItem.AppearanceItem.Selected.BackColor = System.Drawing.Color.Red;
            this.eployeesTileBarItem.AppearanceItem.Selected.Options.UseBackColor = true;
            this.eployeesTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.ImageUri.Uri = "Cube;Size32x32;GrayScaled";
            tileItemElement1.Text = "Check Out Type";
            this.eployeesTileBarItem.Elements.Add(tileItemElement1);
            this.eployeesTileBarItem.Name = "eployeesTileBarItem";
            // 
            // customersTileBarItem
            // 
            this.customersTileBarItem.AppearanceItem.Hovered.BackColor = System.Drawing.Color.Crimson;
            this.customersTileBarItem.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.customersTileBarItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.Gray;
            this.customersTileBarItem.AppearanceItem.Normal.Options.UseBackColor = true;
            this.customersTileBarItem.AppearanceItem.Pressed.BackColor = System.Drawing.Color.Crimson;
            this.customersTileBarItem.AppearanceItem.Pressed.Options.UseBackColor = true;
            this.customersTileBarItem.AppearanceItem.Selected.BackColor = System.Drawing.Color.Red;
            this.customersTileBarItem.AppearanceItem.Selected.Options.UseBackColor = true;
            this.customersTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.ImageUri.Uri = "Cube;Size32x32;GrayScaled";
            tileItemElement2.Text = "Parts";
            this.customersTileBarItem.Elements.Add(tileItemElement2);
            this.customersTileBarItem.Id = 2;
            this.customersTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.customersTileBarItem.Name = "customersTileBarItem";
            // 
            // tileBarItem2
            // 
            this.tileBarItem2.AppearanceItem.Hovered.BackColor = System.Drawing.Color.Crimson;
            this.tileBarItem2.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileBarItem2.AppearanceItem.Normal.BackColor = System.Drawing.Color.Gray;
            this.tileBarItem2.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileBarItem2.AppearanceItem.Pressed.BackColor = System.Drawing.Color.Crimson;
            this.tileBarItem2.AppearanceItem.Pressed.Options.UseBackColor = true;
            this.tileBarItem2.AppearanceItem.Selected.BackColor = System.Drawing.Color.Red;
            this.tileBarItem2.AppearanceItem.Selected.Options.UseBackColor = true;
            this.tileBarItem2.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement3.Text = "Transaction History";
            this.tileBarItem2.Elements.Add(tileItemElement3);
            this.tileBarItem2.Id = 4;
            this.tileBarItem2.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem2.Name = "tileBarItem2";
            this.tileBarItem2.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileBar_SelectedItemChanged);
            // 
            // navigationFrame
            // 
            this.navigationFrame.Controls.Add(this.employeesNavigationPage);
            this.navigationFrame.Controls.Add(this.customersNavigationPage);
            this.navigationFrame.Controls.Add(this.navigationPage1);
            this.navigationFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame.Location = new System.Drawing.Point(0, 110);
            this.navigationFrame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.navigationFrame.Name = "navigationFrame";
            this.navigationFrame.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.employeesNavigationPage,
            this.customersNavigationPage,
            this.navigationPage1});
            this.navigationFrame.SelectedPage = this.employeesNavigationPage;
            this.navigationFrame.Size = new System.Drawing.Size(1008, 619);
            this.navigationFrame.TabIndex = 0;
            this.navigationFrame.Text = "navigationFrame";
            // 
            // employeesNavigationPage
            // 
            this.employeesNavigationPage.Caption = "employeesNavigationPage";
            this.employeesNavigationPage.Controls.Add(this.jobStepText);
            this.employeesNavigationPage.Controls.Add(this.JobIDlookUp);
            this.employeesNavigationPage.Controls.Add(this.WorkOpLookUp);
            this.employeesNavigationPage.Controls.Add(this.WorkOpLabel);
            this.employeesNavigationPage.Controls.Add(this.lookUpEdit1);
            this.employeesNavigationPage.Controls.Add(this.JobIDLabel);
            this.employeesNavigationPage.Controls.Add(this.GetJobButton);
            this.employeesNavigationPage.Controls.Add(this.reasonLookUp);
            this.employeesNavigationPage.Controls.Add(this.takenByLookUp);
            this.employeesNavigationPage.Controls.Add(this.gridControl1);
            this.employeesNavigationPage.Controls.Add(this.toggleSwitch1);
            this.employeesNavigationPage.Controls.Add(this.dateLabel);
            this.employeesNavigationPage.Controls.Add(this.dateEdit);
            this.employeesNavigationPage.Controls.Add(this.reasonLabel);
            this.employeesNavigationPage.Controls.Add(this.takenByLabel);
            this.employeesNavigationPage.Controls.Add(this.userNameIDLabel);
            this.employeesNavigationPage.Controls.Add(this.employeesLabelControl);
            this.employeesNavigationPage.Controls.Add(this.storeRoomCombo);
            this.employeesNavigationPage.Controls.Add(this.userNameTextBox);
            this.employeesNavigationPage.Controls.Add(this.JobIDTextEdit);
            this.employeesNavigationPage.Name = "employeesNavigationPage";
            this.employeesNavigationPage.Size = new System.Drawing.Size(1008, 619);
            // 
            // jobStepText
            // 
            this.jobStepText.Location = new System.Drawing.Point(317, 171);
            this.jobStepText.Name = "jobStepText";
            this.jobStepText.Size = new System.Drawing.Size(100, 20);
            this.jobStepText.TabIndex = 38;
            this.jobStepText.Visible = false;
            // 
            // JobIDlookUp
            // 
            this.JobIDlookUp.Location = new System.Drawing.Point(707, 70);
            this.JobIDlookUp.Name = "JobIDlookUp";
            this.JobIDlookUp.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.JobIDlookUp.Properties.Appearance.Options.UseFont = true;
            this.JobIDlookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.JobIDlookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Jobid", "Job ID", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Step Title", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.JobIDlookUp.Properties.DataSource = this.bindJobsList;
            this.JobIDlookUp.Properties.DisplayMember = "Jobid";
            this.JobIDlookUp.Properties.NullText = "";
            this.JobIDlookUp.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.JobIDlookUp.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.JobIDlookUp.Properties.ValueMember = "n_jobid";
            this.JobIDlookUp.Properties.EditValueChanged += new System.EventHandler(this.JobIDLookUpEditValueChanged);
            this.JobIDlookUp.Properties.Enter += new System.EventHandler(this.jobIDLookUpEnter);
            this.JobIDlookUp.Size = new System.Drawing.Size(211, 26);
            this.JobIDlookUp.TabIndex = 37;
            // 
            // WorkOpLookUp
            // 
            this.WorkOpLookUp.Location = new System.Drawing.Point(708, 118);
            this.WorkOpLookUp.Name = "WorkOpLookUp";
            this.WorkOpLookUp.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.WorkOpLookUp.Properties.Appearance.Options.UseFont = true;
            this.WorkOpLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.WorkOpLookUp.Properties.DataSource = this.bindWorkOp;
            this.WorkOpLookUp.Properties.DisplayMember = "WorkOpID";
            this.WorkOpLookUp.Properties.NullText = "";
            this.WorkOpLookUp.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.WorkOpLookUp.Properties.ValueMember = "n_WorkOpID";
            this.WorkOpLookUp.Size = new System.Drawing.Size(210, 26);
            this.WorkOpLookUp.TabIndex = 34;
            this.WorkOpLookUp.Enter += new System.EventHandler(this.WorkOpEnter);
            // 
            // WorkOpLabel
            // 
            this.WorkOpLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.WorkOpLabel.Appearance.Options.UseFont = true;
            this.WorkOpLabel.Location = new System.Drawing.Point(590, 121);
            this.WorkOpLabel.Name = "WorkOpLabel";
            this.WorkOpLabel.Size = new System.Drawing.Size(112, 19);
            this.WorkOpLabel.TabIndex = 32;
            this.WorkOpLabel.Text = "Work Operation";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(317, 25);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lookUpEdit1.Properties.Appearance.Options.UseFont = true;
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserID", "User ID", 59, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nUserID", "n User ID", 55, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEdit1.Properties.DataSource = this.bindUser;
            this.lookUpEdit1.Properties.DisplayMember = "Name";
            this.lookUpEdit1.Properties.NullText = "";
            this.lookUpEdit1.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lookUpEdit1.Properties.ValueMember = "nUserID";
            this.lookUpEdit1.Properties.Enter += new System.EventHandler(this.takenByEnter);
            this.lookUpEdit1.Size = new System.Drawing.Size(211, 26);
            this.lookUpEdit1.TabIndex = 31;
            // 
            // JobIDLabel
            // 
            this.JobIDLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.JobIDLabel.Appearance.Options.UseFont = true;
            this.JobIDLabel.Location = new System.Drawing.Point(590, 77);
            this.JobIDLabel.Name = "JobIDLabel";
            this.JobIDLabel.Size = new System.Drawing.Size(47, 19);
            this.JobIDLabel.TabIndex = 30;
            this.JobIDLabel.Text = "Job ID";
            // 
            // GetJobButton
            // 
            this.GetJobButton.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.GetJobButton.Appearance.Options.UseFont = true;
            this.GetJobButton.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.GetJobButton.AppearanceHovered.Options.UseBackColor = true;
            this.GetJobButton.AppearancePressed.BackColor = System.Drawing.Color.Silver;
            this.GetJobButton.AppearancePressed.Options.UseBackColor = true;
            this.GetJobButton.Location = new System.Drawing.Point(35, 208);
            this.GetJobButton.Name = "GetJobButton";
            this.GetJobButton.Size = new System.Drawing.Size(75, 23);
            this.GetJobButton.TabIndex = 28;
            this.GetJobButton.Text = "Get Jobs";
            this.GetJobButton.Click += new System.EventHandler(this.GetJobButton_Click);
            // 
            // reasonLookUp
            // 
            this.reasonLookUp.Location = new System.Drawing.Point(317, 118);
            this.reasonLookUp.Name = "reasonLookUp";
            this.reasonLookUp.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.reasonLookUp.Properties.Appearance.Options.UseFont = true;
            this.reasonLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reasonLookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("checkoutreasonid", "Reason ", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("description", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("n_checkoutreasonid", "nJobReasonID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.reasonLookUp.Properties.DataSource = this.bindReason;
            this.reasonLookUp.Properties.DisplayMember = "checkoutreasonid";
            this.reasonLookUp.Properties.DropDownRows = 10;
            this.reasonLookUp.Properties.NullText = "";
            this.reasonLookUp.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.reasonLookUp.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.reasonLookUp.Properties.ValueMember = "n_checkoutreasonid";
            this.reasonLookUp.Properties.Enter += new System.EventHandler(this.reasonEnter);
            this.reasonLookUp.Size = new System.Drawing.Size(211, 26);
            this.reasonLookUp.TabIndex = 27;
            // 
            // takenByLookUp
            // 
            this.takenByLookUp.Location = new System.Drawing.Point(317, 70);
            this.takenByLookUp.Name = "takenByLookUp";
            this.takenByLookUp.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.takenByLookUp.Properties.Appearance.Options.UseFont = true;
            this.takenByLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.takenByLookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserID", "User ID ", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.takenByLookUp.Properties.DataSource = this.bindUser;
            this.takenByLookUp.Properties.DisplayMember = "Name";
            this.takenByLookUp.Properties.DropDownRows = 10;
            this.takenByLookUp.Properties.NullText = "";
            this.takenByLookUp.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.takenByLookUp.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.takenByLookUp.Properties.ValueMember = "nUserID";
            this.takenByLookUp.Properties.Enter += new System.EventHandler(this.takenByEnter);
            this.takenByLookUp.Size = new System.Drawing.Size(211, 26);
            this.takenByLookUp.TabIndex = 26;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindOpenJobs;
            this.gridControl1.Location = new System.Drawing.Point(124, 208);
            this.gridControl1.MainView = this.gridViewJobs;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(794, 338);
            this.gridControl1.TabIndex = 22;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewJobs});
            // 
            // gridViewJobs
            // 
            this.gridViewJobs.GridControl = this.gridControl1;
            this.gridViewJobs.Name = "gridViewJobs";
            this.gridViewJobs.OptionsFind.AlwaysVisible = true;
            this.gridViewJobs.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridViewJobs.PaintStyleName = "Style3D";
            this.gridViewJobs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControlJobs_MouseClick);
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(32, 21);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.toggleSwitch1.Properties.Appearance.Options.UseFont = true;
            this.toggleSwitch1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.toggleSwitch1.Properties.OffText = "No Job ID";
            this.toggleSwitch1.Properties.OnText = "Has Job ID";
            this.toggleSwitch1.Size = new System.Drawing.Size(124, 27);
            this.toggleSwitch1.TabIndex = 21;
            this.toggleSwitch1.Toggled += new System.EventHandler(this.toggleSwitch1_Toggled);
            // 
            // dateLabel
            // 
            this.dateLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dateLabel.Appearance.Options.UseFont = true;
            this.dateLabel.Location = new System.Drawing.Point(590, 28);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(32, 19);
            this.dateLabel.TabIndex = 18;
            this.dateLabel.Text = "Date";
            // 
            // dateEdit
            // 
            this.dateEdit.EditValue = null;
            this.dateEdit.Location = new System.Drawing.Point(707, 25);
            this.dateEdit.Name = "dateEdit";
            this.dateEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dateEdit.Properties.Appearance.Options.UseFont = true;
            this.dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit.Size = new System.Drawing.Size(211, 26);
            this.dateEdit.TabIndex = 17;
            // 
            // reasonLabel
            // 
            this.reasonLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.reasonLabel.Appearance.Options.UseFont = true;
            this.reasonLabel.Location = new System.Drawing.Point(209, 125);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(51, 19);
            this.reasonLabel.TabIndex = 14;
            this.reasonLabel.Text = "Reason";
            // 
            // takenByLabel
            // 
            this.takenByLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.takenByLabel.Appearance.Options.UseFont = true;
            this.takenByLabel.Location = new System.Drawing.Point(209, 73);
            this.takenByLabel.Name = "takenByLabel";
            this.takenByLabel.Size = new System.Drawing.Size(102, 19);
            this.takenByLabel.TabIndex = 13;
            this.takenByLabel.Text = "Taken by User";
            // 
            // userNameIDLabel
            // 
            this.userNameIDLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.userNameIDLabel.Appearance.Options.UseFont = true;
            this.userNameIDLabel.Location = new System.Drawing.Point(209, 26);
            this.userNameIDLabel.Name = "userNameIDLabel";
            this.userNameIDLabel.Size = new System.Drawing.Size(78, 19);
            this.userNameIDLabel.TabIndex = 10;
            this.userNameIDLabel.Text = "User Name\r\n";
            // 
            // employeesLabelControl
            // 
            this.employeesLabelControl.Appearance.Font = new System.Drawing.Font("Tahoma", 25.25F);
            this.employeesLabelControl.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.employeesLabelControl.Appearance.Options.UseFont = true;
            this.employeesLabelControl.Appearance.Options.UseForeColor = true;
            this.employeesLabelControl.Appearance.Options.UseTextOptions = true;
            this.employeesLabelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.employeesLabelControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.employeesLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.employeesLabelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeesLabelControl.Location = new System.Drawing.Point(0, 0);
            this.employeesLabelControl.Name = "employeesLabelControl";
            this.employeesLabelControl.Size = new System.Drawing.Size(1008, 619);
            this.employeesLabelControl.TabIndex = 2;
            // 
            // storeRoomCombo
            // 
            this.storeRoomCombo.Location = new System.Drawing.Point(35, 205);
            this.storeRoomCombo.Name = "storeRoomCombo";
            this.storeRoomCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.storeRoomCombo.Properties.DataSource = this.bindStoreroom;
            this.storeRoomCombo.Properties.NullText = "";
            this.storeRoomCombo.Properties.PopupSizeable = false;
            this.storeRoomCombo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.storeRoomCombo.Size = new System.Drawing.Size(100, 20);
            this.storeRoomCombo.TabIndex = 6;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(284, 23);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.userNameTextBox.Properties.NullText = "";
            this.userNameTextBox.Size = new System.Drawing.Size(211, 20);
            this.userNameTextBox.TabIndex = 8;
            // 
            // JobIDTextEdit
            // 
            this.JobIDTextEdit.Location = new System.Drawing.Point(284, 145);
            this.JobIDTextEdit.Name = "JobIDTextEdit";
            this.JobIDTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.JobIDTextEdit.Properties.DataSource = this.bindOpenJobs;
            this.JobIDTextEdit.Properties.NullText = "";
            this.JobIDTextEdit.Properties.View = this.gridLookUpEdit1View;
            this.JobIDTextEdit.Size = new System.Drawing.Size(211, 20);
            this.JobIDTextEdit.TabIndex = 29;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // customersNavigationPage
            // 
            this.customersNavigationPage.Caption = "customersNavigationPage";
            this.customersNavigationPage.Controls.Add(this.partIDLookUp);
            this.customersNavigationPage.Controls.Add(this.StoreRoomNameLable);
            this.customersNavigationPage.Controls.Add(this.btnAddPartsFromGrid);
            this.customersNavigationPage.Controls.Add(this.storeRoom);
            this.customersNavigationPage.Controls.Add(this.labelControl2);
            this.customersNavigationPage.Controls.Add(this.storeroomPartsLabel);
            this.customersNavigationPage.Controls.Add(this.QTYLabel);
            this.customersNavigationPage.Controls.Add(this.QTYspinEdit);
            this.customersNavigationPage.Controls.Add(this.simpleButton1);
            this.customersNavigationPage.Controls.Add(this.gridControlPartsAdded);
            this.customersNavigationPage.Controls.Add(this.checkOutButton);
            this.customersNavigationPage.Controls.Add(this.gridControlParts);
            this.customersNavigationPage.Controls.Add(this.partIDLabel);
            this.customersNavigationPage.Controls.Add(this.addPartButton);
            this.customersNavigationPage.Controls.Add(this.customersLabelControl);
            this.customersNavigationPage.Name = "customersNavigationPage";
            this.customersNavigationPage.Size = new System.Drawing.Size(1008, 619);
            // 
            // partIDLookUp
            // 
            this.partIDLookUp.EditValue = "";
            this.partIDLookUp.Location = new System.Drawing.Point(465, 49);
            this.partIDLookUp.Name = "partIDLookUp";
            this.partIDLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.partIDLookUp.Properties.DataSource = this.bindPart;
            this.partIDLookUp.Properties.DisplayMember = "Description";
            this.partIDLookUp.Properties.ValueMember = "n_masterpartid";
            this.partIDLookUp.Properties.View = this.gridView1;
            this.partIDLookUp.Size = new System.Drawing.Size(179, 20);
            this.partIDLookUp.TabIndex = 28;
            this.partIDLookUp.Enter += new System.EventHandler(this.partEnter);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColumnN_masterpartid,
            this.ColumnMasterpartid,
            this.ColumnMasterpartDescription});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ColumnN_masterpartid
            // 
            this.ColumnN_masterpartid.FieldName = "n_masterpartid";
            this.ColumnN_masterpartid.Name = "ColumnN_masterpartid";
            // 
            // ColumnMasterpartid
            // 
            this.ColumnMasterpartid.Caption = "Part ID";
            this.ColumnMasterpartid.FieldName = "masterpartid";
            this.ColumnMasterpartid.Name = "ColumnMasterpartid";
            this.ColumnMasterpartid.Visible = true;
            this.ColumnMasterpartid.VisibleIndex = 0;
            this.ColumnMasterpartid.Width = 50;
            // 
            // ColumnMasterpartDescription
            // 
            this.ColumnMasterpartDescription.Caption = "Description";
            this.ColumnMasterpartDescription.FieldName = "Description";
            this.ColumnMasterpartDescription.Name = "ColumnMasterpartDescription";
            this.ColumnMasterpartDescription.Visible = true;
            this.ColumnMasterpartDescription.VisibleIndex = 1;
            this.ColumnMasterpartDescription.Width = 125;
            // 
            // StoreRoomNameLable
            // 
            this.StoreRoomNameLable.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.StoreRoomNameLable.Appearance.Options.UseFont = true;
            this.StoreRoomNameLable.Location = new System.Drawing.Point(165, 13);
            this.StoreRoomNameLable.Name = "StoreRoomNameLable";
            this.StoreRoomNameLable.Size = new System.Drawing.Size(140, 25);
            this.StoreRoomNameLable.TabIndex = 27;
            this.StoreRoomNameLable.Text = "labelControl1";
            // 
            // btnAddPartsFromGrid
            // 
            this.btnAddPartsFromGrid.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnAddPartsFromGrid.Appearance.Options.UseFont = true;
            this.btnAddPartsFromGrid.Location = new System.Drawing.Point(800, 142);
            this.btnAddPartsFromGrid.Name = "btnAddPartsFromGrid";
            this.btnAddPartsFromGrid.Size = new System.Drawing.Size(156, 31);
            this.btnAddPartsFromGrid.TabIndex = 26;
            this.btnAddPartsFromGrid.Text = "Add parts from grid";
            this.btnAddPartsFromGrid.Click += new System.EventHandler(this.btnAddPartsFromGrid_Click);
            // 
            // storeRoom
            // 
            this.storeRoom.Location = new System.Drawing.Point(58, 49);
            this.storeRoom.Name = "storeRoom";
            this.storeRoom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.storeRoom.Properties.Appearance.Options.UseFont = true;
            this.storeRoom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.storeRoom.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("storeroomid", "Store room", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("descr", "Description", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.storeRoom.Properties.DataSource = this.bindStoreroom;
            this.storeRoom.Properties.DisplayMember = "storeroomid";
            this.storeRoom.Properties.DropDownRows = 10;
            this.storeRoom.Properties.NullText = "";
            this.storeRoom.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.storeRoom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.storeRoom.Properties.ValueMember = "n_storeroomid";
            this.storeRoom.Properties.Enter += new System.EventHandler(this.storeRoomEnter);
            this.storeRoom.Size = new System.Drawing.Size(276, 26);
            this.storeRoom.TabIndex = 25;
            this.storeRoom.EditValueChanged += new System.EventHandler(this.storeRoom_EditValueChanged);
            this.storeRoom.TextChanged += new System.EventHandler(this.storeRoom_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(58, 385);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 23);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Parts List";
            // 
            // storeroomPartsLabel
            // 
            this.storeroomPartsLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.storeroomPartsLabel.Appearance.Options.UseFont = true;
            this.storeroomPartsLabel.Location = new System.Drawing.Point(58, 18);
            this.storeroomPartsLabel.Name = "storeroomPartsLabel";
            this.storeroomPartsLabel.Size = new System.Drawing.Size(90, 19);
            this.storeroomPartsLabel.TabIndex = 14;
            this.storeroomPartsLabel.Text = "Store Room:";
            // 
            // QTYLabel
            // 
            this.QTYLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.QTYLabel.Appearance.Options.UseFont = true;
            this.QTYLabel.Location = new System.Drawing.Point(663, 17);
            this.QTYLabel.Name = "QTYLabel";
            this.QTYLabel.Size = new System.Drawing.Size(32, 19);
            this.QTYLabel.TabIndex = 12;
            this.QTYLabel.Text = "QTY";
            // 
            // QTYspinEdit
            // 
            this.QTYspinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.QTYspinEdit.Location = new System.Drawing.Point(663, 49);
            this.QTYspinEdit.Name = "QTYspinEdit";
            this.QTYspinEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.QTYspinEdit.Properties.Appearance.Options.UseFont = true;
            this.QTYspinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.QTYspinEdit.Size = new System.Drawing.Size(100, 26);
            this.QTYspinEdit.TabIndex = 11;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(800, 49);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(154, 29);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "Add single part";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControlPartsAdded
            // 
            this.gridControlPartsAdded.Location = new System.Drawing.Point(58, 414);
            this.gridControlPartsAdded.MainView = this.gridViewPartsAdded;
            this.gridControlPartsAdded.Name = "gridControlPartsAdded";
            this.gridControlPartsAdded.Size = new System.Drawing.Size(720, 193);
            this.gridControlPartsAdded.TabIndex = 9;
            this.gridControlPartsAdded.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPartsAdded});
            this.gridControlPartsAdded.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControlPartsAdded_MouseClick);
            // 
            // gridViewPartsAdded
            // 
            this.gridViewPartsAdded.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.masterpartid,
            this.ColumnMasterpartIDDescription,
            this.QTY,
            this.n_masterpartid});
            this.gridViewPartsAdded.GridControl = this.gridControlPartsAdded;
            this.gridViewPartsAdded.Name = "gridViewPartsAdded";
            this.gridViewPartsAdded.OptionsSelection.MultiSelect = true;
            this.gridViewPartsAdded.PaintStyleName = "Style3D";
            // 
            // masterpartid
            // 
            this.masterpartid.Caption = "Part ID";
            this.masterpartid.FieldName = "masterpartid";
            this.masterpartid.Name = "masterpartid";
            this.masterpartid.OptionsColumn.AllowEdit = false;
            this.masterpartid.OptionsColumn.ReadOnly = true;
            this.masterpartid.Visible = true;
            this.masterpartid.VisibleIndex = 0;
            // 
            // ColumnMasterpartIDDescription
            // 
            this.ColumnMasterpartIDDescription.Caption = "Description";
            this.ColumnMasterpartIDDescription.FieldName = "Description";
            this.ColumnMasterpartIDDescription.Name = "ColumnMasterpartIDDescription";
            this.ColumnMasterpartIDDescription.Visible = true;
            this.ColumnMasterpartIDDescription.VisibleIndex = 1;
            // 
            // QTY
            // 
            this.QTY.Caption = "QTY";
            this.QTY.FieldName = "QTY";
            this.QTY.Name = "QTY";
            this.QTY.Visible = true;
            this.QTY.VisibleIndex = 2;
            // 
            // n_masterpartid
            // 
            this.n_masterpartid.Caption = "n_masterpartid";
            this.n_masterpartid.FieldName = "n_masterpartid";
            this.n_masterpartid.Name = "n_masterpartid";
            // 
            // checkOutButton
            // 
            this.checkOutButton.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.checkOutButton.Appearance.Options.UseFont = true;
            this.checkOutButton.AppearanceHovered.BackColor = System.Drawing.Color.DarkGray;
            this.checkOutButton.AppearanceHovered.Options.UseBackColor = true;
            this.checkOutButton.AppearancePressed.BackColor = System.Drawing.Color.DarkGray;
            this.checkOutButton.AppearancePressed.Options.UseBackColor = true;
            this.checkOutButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.checkOutButton.Location = new System.Drawing.Point(817, 488);
            this.checkOutButton.Name = "checkOutButton";
            this.checkOutButton.Size = new System.Drawing.Size(156, 49);
            this.checkOutButton.TabIndex = 8;
            this.checkOutButton.Text = "Check out";
            this.checkOutButton.Click += new System.EventHandler(this.checkOutButton_Click);
            // 
            // gridControlParts
            // 
            this.gridControlParts.Location = new System.Drawing.Point(58, 132);
            this.gridControlParts.MainView = this.gridViewParts;
            this.gridControlParts.Name = "gridControlParts";
            this.gridControlParts.Size = new System.Drawing.Size(915, 236);
            this.gridControlParts.TabIndex = 7;
            this.gridControlParts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewParts});
            this.gridControlParts.Click += new System.EventHandler(this.gridControlParts_Click);
            this.gridControlParts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridControlParts_MouseClick);
            // 
            // gridViewParts
            // 
            this.gridViewParts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridViewParts.GridControl = this.gridControlParts;
            this.gridViewParts.Name = "gridViewParts";
            this.gridViewParts.OptionsBehavior.Editable = false;
            this.gridViewParts.OptionsBehavior.ReadOnly = true;
            this.gridViewParts.OptionsFind.AlwaysVisible = true;
            this.gridViewParts.OptionsFind.ShowCloseButton = false;
            this.gridViewParts.OptionsFind.ShowFindButton = false;
            this.gridViewParts.OptionsSelection.MultiSelect = true;
            this.gridViewParts.PaintStyleName = "Style3D";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Part #";
            this.gridColumn1.FieldName = "masterpartid";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Description";
            this.gridColumn2.FieldName = "Description";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "QOH";
            this.gridColumn3.FieldName = "qtyonhand";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // partIDLabel
            // 
            this.partIDLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.partIDLabel.Appearance.Options.UseFont = true;
            this.partIDLabel.Location = new System.Drawing.Point(465, 17);
            this.partIDLabel.Name = "partIDLabel";
            this.partIDLabel.Size = new System.Drawing.Size(50, 19);
            this.partIDLabel.TabIndex = 5;
            this.partIDLabel.Text = "Part ID";
            // 
            // addPartButton
            // 
            this.addPartButton.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.addPartButton.Appearance.Options.UseFont = true;
            this.addPartButton.Location = new System.Drawing.Point(58, 94);
            this.addPartButton.Name = "addPartButton";
            this.addPartButton.Size = new System.Drawing.Size(183, 32);
            this.addPartButton.TabIndex = 4;
            this.addPartButton.Text = "Get all Storeroom parts";
            this.addPartButton.Click += new System.EventHandler(this.addPartButton_Click);
            // 
            // customersLabelControl
            // 
            this.customersLabelControl.Appearance.Font = new System.Drawing.Font("Tahoma", 25.25F);
            this.customersLabelControl.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.customersLabelControl.Appearance.Options.UseFont = true;
            this.customersLabelControl.Appearance.Options.UseForeColor = true;
            this.customersLabelControl.Appearance.Options.UseTextOptions = true;
            this.customersLabelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.customersLabelControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.customersLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.customersLabelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customersLabelControl.Location = new System.Drawing.Point(0, 0);
            this.customersLabelControl.Name = "customersLabelControl";
            this.customersLabelControl.Size = new System.Drawing.Size(1008, 619);
            this.customersLabelControl.TabIndex = 2;
            // 
            // navigationPage1
            // 
            this.navigationPage1.Caption = "navigationPage1";
            this.navigationPage1.Controls.Add(this.btnGetSingleTransaction);
            this.navigationPage1.Controls.Add(this.simpleButton2);
            this.navigationPage1.Controls.Add(this.transactionNumberLabel);
            this.navigationPage1.Controls.Add(this.txtTransactionNumber);
            this.navigationPage1.Controls.Add(this.transactionHistoryGridControl);
            this.navigationPage1.Name = "navigationPage1";
            this.navigationPage1.Size = new System.Drawing.Size(1008, 619);
            // 
            // btnGetSingleTransaction
            // 
            this.btnGetSingleTransaction.Location = new System.Drawing.Point(396, 49);
            this.btnGetSingleTransaction.Name = "btnGetSingleTransaction";
            this.btnGetSingleTransaction.Size = new System.Drawing.Size(235, 26);
            this.btnGetSingleTransaction.TabIndex = 4;
            this.btnGetSingleTransaction.Text = "Get transaction";
            this.btnGetSingleTransaction.Click += new System.EventHandler(this.GetSingleTransaction_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(36, 150);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(229, 23);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "Get All transactions";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // transactionNumberLabel
            // 
            this.transactionNumberLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.transactionNumberLabel.Appearance.Options.UseFont = true;
            this.transactionNumberLabel.Location = new System.Drawing.Point(36, 17);
            this.transactionNumberLabel.Name = "transactionNumberLabel";
            this.transactionNumberLabel.Size = new System.Drawing.Size(171, 23);
            this.transactionNumberLabel.TabIndex = 2;
            this.transactionNumberLabel.Text = "Transaction Number";
            // 
            // txtTransactionNumber
            // 
            this.txtTransactionNumber.Location = new System.Drawing.Point(36, 46);
            this.txtTransactionNumber.Name = "txtTransactionNumber";
            this.txtTransactionNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtTransactionNumber.Properties.Appearance.Options.UseFont = true;
            this.txtTransactionNumber.Size = new System.Drawing.Size(323, 30);
            this.txtTransactionNumber.TabIndex = 1;
            // 
            // transactionHistoryGridControl
            // 
            this.transactionHistoryGridControl.Location = new System.Drawing.Point(36, 192);
            this.transactionHistoryGridControl.MainView = this.gridViewTrransactionHistory;
            this.transactionHistoryGridControl.Name = "transactionHistoryGridControl";
            this.transactionHistoryGridControl.Size = new System.Drawing.Size(939, 403);
            this.transactionHistoryGridControl.TabIndex = 0;
            this.transactionHistoryGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTrransactionHistory});
            // 
            // gridViewTrransactionHistory
            // 
            this.gridViewTrransactionHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TextTransactionNumber,
            this.masterpart,
            this.storeroomcolumn,
            this.Aisle,
            this.Shelf,
            this.Bin,
            this.ReqQty,
            this.QTYNumber,
            this.UOI,
            this.Description,
            this.jobid});
            this.gridViewTrransactionHistory.GridControl = this.transactionHistoryGridControl;
            this.gridViewTrransactionHistory.GroupCount = 2;
            this.gridViewTrransactionHistory.Name = "gridViewTrransactionHistory";
            this.gridViewTrransactionHistory.OptionsFind.AlwaysVisible = true;
            this.gridViewTrransactionHistory.OptionsFind.ShowCloseButton = false;
            this.gridViewTrransactionHistory.OptionsFind.ShowFindButton = false;
            this.gridViewTrransactionHistory.OptionsPrint.PrintPreview = true;
            this.gridViewTrransactionHistory.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridViewTrransactionHistory.PaintStyleName = "Style3D";
            this.gridViewTrransactionHistory.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.TextTransactionNumber, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.jobid, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // TextTransactionNumber
            // 
            this.TextTransactionNumber.Caption = "Transaction Number";
            this.TextTransactionNumber.FieldName = "xactionnum";
            this.TextTransactionNumber.Name = "TextTransactionNumber";
            this.TextTransactionNumber.Visible = true;
            this.TextTransactionNumber.VisibleIndex = 0;
            this.TextTransactionNumber.Width = 107;
            // 
            // masterpart
            // 
            this.masterpart.Caption = "Master Part ID";
            this.masterpart.FieldName = "masterpartid";
            this.masterpart.Name = "masterpart";
            this.masterpart.Visible = true;
            this.masterpart.VisibleIndex = 0;
            this.masterpart.Width = 93;
            // 
            // storeroomcolumn
            // 
            this.storeroomcolumn.Caption = "Store Room";
            this.storeroomcolumn.FieldName = "descr";
            this.storeroomcolumn.Name = "storeroomcolumn";
            this.storeroomcolumn.Visible = true;
            this.storeroomcolumn.VisibleIndex = 1;
            this.storeroomcolumn.Width = 94;
            // 
            // Aisle
            // 
            this.Aisle.Caption = "Aisle";
            this.Aisle.FieldName = "aisle";
            this.Aisle.Name = "Aisle";
            this.Aisle.Visible = true;
            this.Aisle.VisibleIndex = 2;
            this.Aisle.Width = 45;
            // 
            // Shelf
            // 
            this.Shelf.Caption = "Shelf";
            this.Shelf.FieldName = "shelf";
            this.Shelf.Name = "Shelf";
            this.Shelf.Visible = true;
            this.Shelf.VisibleIndex = 3;
            this.Shelf.Width = 56;
            // 
            // Bin
            // 
            this.Bin.Caption = "Bin";
            this.Bin.FieldName = "bin";
            this.Bin.Name = "Bin";
            this.Bin.Visible = true;
            this.Bin.VisibleIndex = 4;
            this.Bin.Width = 60;
            // 
            // ReqQty
            // 
            this.ReqQty.Caption = "ReqQty";
            this.ReqQty.FieldName = "ReqQty";
            this.ReqQty.Name = "ReqQty";
            this.ReqQty.Visible = true;
            this.ReqQty.VisibleIndex = 5;
            this.ReqQty.Width = 49;
            // 
            // QTYNumber
            // 
            this.QTYNumber.Caption = "QTY";
            this.QTYNumber.FieldName = "qty";
            this.QTYNumber.Name = "QTYNumber";
            this.QTYNumber.Visible = true;
            this.QTYNumber.VisibleIndex = 6;
            this.QTYNumber.Width = 40;
            // 
            // UOI
            // 
            this.UOI.Caption = "UOI";
            this.UOI.FieldName = "UnitOfIssue";
            this.UOI.Name = "UOI";
            this.UOI.Visible = true;
            this.UOI.VisibleIndex = 7;
            this.UOI.Width = 56;
            // 
            // Description
            // 
            this.Description.Caption = "Description";
            this.Description.FieldName = "Description";
            this.Description.Name = "Description";
            this.Description.Visible = true;
            this.Description.VisibleIndex = 8;
            this.Description.Width = 209;
            // 
            // jobid
            // 
            this.jobid.Caption = "Job ID";
            this.jobid.FieldName = "Jobid";
            this.jobid.Name = "jobid";
            this.jobid.Visible = true;
            this.jobid.VisibleIndex = 9;
            this.jobid.Width = 112;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Appearance.Options.UseForeColor = true;
            this.labelControl9.Location = new System.Drawing.Point(804, 23);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(73, 19);
            this.labelControl9.TabIndex = 2;
            this.labelControl9.Text = "Log in As:";
            // 
            // userNameLabel
            // 
            this.userNameLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.userNameLabel.Appearance.ForeColor = System.Drawing.Color.Black;
            this.userNameLabel.Appearance.Options.UseFont = true;
            this.userNameLabel.Appearance.Options.UseForeColor = true;
            this.userNameLabel.Location = new System.Drawing.Point(883, 23);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(84, 19);
            this.userNameLabel.TabIndex = 3;
            this.userNameLabel.Text = "UserName";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(126, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.toolStripMenuItem2.Text = "Add Parts";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.addPartButton_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.AppearanceHovered.BackColor = System.Drawing.Color.Gray;
            this.simpleButton4.AppearanceHovered.Options.UseBackColor = true;
            this.simpleButton4.AppearancePressed.BackColor = System.Drawing.Color.Silver;
            this.simpleButton4.AppearancePressed.Options.UseBackColor = true;
            this.simpleButton4.Location = new System.Drawing.Point(804, 79);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(152, 23);
            this.simpleButton4.TabIndex = 4;
            this.simpleButton4.Text = "New Check Out";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(804, 49);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(152, 23);
            this.btnLogOut.TabIndex = 5;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // CheckOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.navigationFrame);
            this.Controls.Add(this.tileBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "CheckOutForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckOutForm_Closing);
            this.Load += new System.EventHandler(this.CheckoutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).EndInit();
            this.navigationFrame.ResumeLayout(false);
            this.employeesNavigationPage.ResumeLayout(false);
            this.employeesNavigationPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobStepText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobIDlookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindJobsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkOpLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindWorkOp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reasonLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.takenByLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindOpenJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeRoomCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindStoreroom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.customersNavigationPage.ResumeLayout(false);
            this.customersNavigationPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partIDLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeRoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QTYspinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPartsAdded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPartsAdded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewParts)).EndInit();
            this.navigationPage1.ResumeLayout(false);
            this.navigationPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransactionNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionHistoryGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTrransactionHistory)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TileBar tileBar;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroupTables;
        private DevExpress.XtraBars.Navigation.TileBarItem eployeesTileBarItem;
        private DevExpress.XtraBars.Navigation.TileBarItem customersTileBarItem;
        private DevExpress.XtraBars.Navigation.NavigationPage employeesNavigationPage;
        private DevExpress.XtraBars.Navigation.NavigationPage customersNavigationPage;
        private DevExpress.XtraEditors.LabelControl employeesLabelControl;
        private DevExpress.XtraEditors.LabelControl customersLabelControl;
        
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewJobs;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
        private DevExpress.XtraEditors.LabelControl dateLabel;
        private DevExpress.XtraEditors.DateEdit dateEdit;
        private DevExpress.XtraEditors.LabelControl reasonLabel;
        private DevExpress.XtraEditors.LabelControl takenByLabel;
        private DevExpress.XtraEditors.LabelControl userNameIDLabel;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl userNameLabel;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem2;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private System.Windows.Forms.BindingSource bindStoreroom;
        private DevExpress.XtraEditors.LookUpEdit storeRoomCombo;
        private System.Windows.Forms.BindingSource bindReason;
        private System.Windows.Forms.BindingSource bindUser;
        
        private DevExpress.XtraEditors.LookUpEdit reasonLookUp;
        private DevExpress.XtraEditors.LookUpEdit takenByLookUp;
        private System.Windows.Forms.BindingSource bindOpenJobs;
        private DevExpress.XtraEditors.SimpleButton GetJobButton;
        private DevExpress.XtraEditors.SimpleButton checkOutButton;
        private DevExpress.XtraGrid.GridControl gridControlParts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewParts;
        private DevExpress.XtraEditors.LabelControl partIDLabel;
        private DevExpress.XtraEditors.SimpleButton addPartButton;
        private System.Windows.Forms.BindingSource bindPart;
        private DevExpress.XtraGrid.GridControl gridControlPartsAdded;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPartsAdded;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl QTYLabel;
        private DevExpress.XtraEditors.SpinEdit QTYspinEdit;
        private DevExpress.XtraGrid.Columns.GridColumn masterpartid;
        private DevExpress.XtraGrid.Columns.GridColumn QTY;
        private DevExpress.XtraEditors.LabelControl storeroomPartsLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private DevExpress.XtraEditors.LabelControl JobIDLabel;
        private DevExpress.XtraGrid.GridControl transactionHistoryGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTrransactionHistory;
        private DevExpress.XtraGrid.Columns.GridColumn TextTransactionNumber;
        private DevExpress.XtraEditors.LabelControl transactionNumberLabel;
        private DevExpress.XtraEditors.TextEdit txtTransactionNumber;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LookUpEdit userNameTextBox;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn Aisle;
        private DevExpress.XtraGrid.Columns.GridColumn Shelf;
        private DevExpress.XtraGrid.Columns.GridColumn Bin;
        private DevExpress.XtraGrid.Columns.GridColumn QTYNumber;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private DevExpress.XtraGrid.Columns.GridColumn masterpart;
        private DevExpress.XtraGrid.Columns.GridColumn UOI;
        private DevExpress.XtraGrid.Columns.GridColumn ReqQty;
        private DevExpress.XtraEditors.LookUpEdit WorkOpLookUp;
        private DevExpress.XtraEditors.LabelControl WorkOpLabel;
        private System.Windows.Forms.BindingSource bindWorkOp;
        private DevExpress.XtraGrid.Columns.GridColumn n_masterpartid;
        private DevExpress.XtraEditors.GridLookUpEdit JobIDTextEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private LookUpEdit JobIDlookUp;
        private System.Windows.Forms.BindingSource bindJobsList;
        private DevExpress.XtraGrid.Columns.GridColumn jobid;
        private DevExpress.XtraGrid.Columns.GridColumn storeroomcolumn;
        private SimpleButton btnGetSingleTransaction;
        private SimpleButton simpleButton4;
        private TextEdit jobStepText;
        private LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private LookUpEdit storeRoom;
        private LabelControl StoreRoomNameLable;
        private SimpleButton btnAddPartsFromGrid;
        private SimpleButton btnLogOut;
        
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private SearchLookUpEdit partIDLookUp;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnN_masterpartid;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnMasterpartid;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnMasterpartDescription;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnMasterpartIDDescription;

        public object Appearance { get; private set; }
        public FormBorderEffect FormBorderEffect { get; private set; }
    }
}