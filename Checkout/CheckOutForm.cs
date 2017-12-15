using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using MPETDSFactory;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Data.SqlClient;







namespace Checkout
{
   
    public partial class CheckOutForm : DevExpress.XtraEditors.XtraForm
    {
        public PersonnelLogonObjectClass _oLogon = new PersonnelLogonObjectClass();
       
        private readonly DateTime _nullDate = Convert.ToDateTime("1/1/1960 23:59:59");
        private readonly bool _viewOnly;
        private readonly DbCheckOut _oCheckOut;

        private readonly Masterparts _oMaster;
        private readonly JobstepJobParts _oParts;
        private readonly StoresIssue _oSi;





        private const int AssignedFormID = 76;
        private bool _editMode;
        private string _editingActionNum = "";
        private string _editingUnits = "";
        private int _editingCarrierID = -1;
        private int _editingCheckOutReasonID = -1;
        private DateTime _editingExpDate = Convert.ToDateTime(@"1/1/1960 23:59:59");
        private int _editingGivenByID = -1;
        private string _editingInvoiceNum = "";
        private int _editingJobID = -1;
        private int _editingJobStepID = -1;
        private string _editingMiscRef = "";
        private string _editingNotes = "";
        private int _editingPartAtLocationID = -1;
        private int _editingPartID = -1;
        private int _editingPurchaseOrderID = -1;
        private int _editingQty;
        private int _editingReceiptID = -1;
        private DateTime _editingReceivedDate = Convert.ToDateTime(@"1/1/1960 23:59:59");
        private int _editingReqID = -1;
        private int _editingReqItemID = -1;
        private int _editingReqQty;
        private int _editingRow = -1;
        private int _editingStoreroomID = -1;
        private int _editingStoresIssueID = -1;
        private int _editingTakenBy = -1;
        private int _editingTransactionID = -1;
        private int _editingTransactionItemID = -1;
        private int _editingVendorID = -1;
        //private JobsListWorkOrders _frmJobList;
        private bool _givenByLoaded;
        private bool _inLookUp;
        private bool _isCancelling;
        private bool _jobsLoaded;
        private bool _otherReasonsLoaded;
        private int _priorStoreroom = -1;
        private bool _storeroomsLoaded;
        private bool _storesIssuesLoaded;
        private bool _takenByLoaded;
        // private string dbConnection = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        private string dbConnection = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        private static string _storageConnectionStringSetting = "StorageConnectionString";
        private static string _storageConnectionString = CloudConfigurationManager.GetSetting(_storageConnectionStringSetting);
        private static CloudBlobClient _blobClient = _storageConnectionString != null ? CloudStorageAccount.Parse(_storageConnectionString).CreateCloudBlobClient() : null;
        //private InventoryListStoreroomParts _oMainList;
        //private InventoryListStoresIssues _oSiList;
        bool loadOK = true;

       

        public CheckOutForm()
        {
            //_oLogon.UserID = 1;
            //ShowSplashScreen();
          

            _oCheckOut = new DbCheckOut(dbConnection, false);
            InitializeComponent();
            if (_oLogon.UserID < 1)
            {

                LoginForm logonForm = new LoginForm();
                logonForm.FormClosed += new FormClosedEventHandler(LoginFormClosing);
                logonForm.Show();

                this.SendToBack();
                logonForm.BringToFront();
                logonForm.Focus();

            }
            if (_oLogon.UserID > 0)
            {
                userNameTextBox.EditValue = _oLogon.UserID;
                userNameLabel.Text = _oLogon.Username;
                userNameTextBox.Text = _oLogon.Username;
            }

            toggleSwitch1.IsOn = true;
            if (toggleSwitch1.IsOn)
            {
                gridControl1.Visible = true;
                GetJobButton.Visible = true;
                JobIDTextEdit.Visible = true;
                JobIDLabel.Visible = true;
                reasonLookUp.Visible = false;
                reasonLabel.Visible = false;

            }
            storeRoom.BackColor = Color.PaleVioletRed;
            storeroomLookUp.Visible = false;
            storeroomPartsLabel.Visible = false;
            dateEdit.EditValue = _nullDate;
            dateEdit.EditValue = DateTime.Now;
            

        }

        private void LoginFormClosing(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            if (_oLogon.UserID > 0)
            {
                userNameLabel.Text = _oLogon.Username;
                userNameTextBox.Text = _oLogon.Username;
                dateEdit.DateTime = DateTime.Now;
            }

        }

        private void tileBar_SelectedItemChanged(object sender, TileItemEventArgs e)
        {
            navigationFrame.SelectedPageIndex = tileBarGroupTables.Items.IndexOf(e.Item);
        }

        #region input boxes 
        private void storeRoomEnter(object sender, EventArgs e)
        {

            BindingSource storeRoomBindingSource = new BindingSource();
            storeRoomBindingSource.DataSource = _oCheckOut.GetAllStorerooms(ref loadOK);
            bindStoreroom.DataSource = storeRoomBindingSource;
            storeRoom.EditValue = bindStoreroom;

        }

        private void reasonEnter(object sender, EventArgs e)
        {
            BindingSource reasonBindingSource = new BindingSource();
            reasonBindingSource.DataSource = _oCheckOut.GetAllCheckOutReasons(ref loadOK);
            bindReason.DataSource = reasonBindingSource;
            reasonLookUp.EditValue = bindReason;

        }

        private void takenByEnter(object sender, EventArgs e)
        {
            BindingSource takenByBindingSource = new BindingSource();
            takenByBindingSource.DataSource = _oCheckOut.GetAllActiveMpetUsers(ref loadOK);
            bindUser.DataSource = takenByBindingSource;

            takenByLookUp.EditValue = bindUser;
        }

        private void WorkOpEnter(object sender, EventArgs e)
        {
            bool loadOk = true;
            BindingSource WorkOpBindingSource = new BindingSource();
            WorkOpBindingSource.DataSource = _oCheckOut.ExecuteStoredProc("GetAllWorkOps", ref loadOK);
            bindWorkOp.DataSource = WorkOpBindingSource;
            WorkOpLookUp.EditValue = bindWorkOp;

        }

        private void partEnter(object sender, EventArgs e)
        {
            if (storeRoom.Text != "" || storeroomLookUp.Text != "")
            {
                var storeroomName = "";
                if (storeroomLookUp.Visible == true && storeroomLookUp.Text != "")
                {
                    storeroomName = storeroomLookUp.Text;
                }
                if (storeRoom.Text != "")
                {
                    storeroomName = storeRoom.Text;
                }
                //NonSortedList param = new NonSortedList();

                DataSet ds = new DataSet();

                SqlConnection conn = new SqlConnection(dbConnection);
                SqlCommand cmd = new SqlCommand();
                SqlParameterCollection param = cmd.Parameters;
                //param.AddWithValue("@StoreroomLock", -1);
                param.AddWithValue("@StoreroomFilter", storeroomName);
                //param.AddWithValue("@PartNameContains", "");
                //param.AddWithValue("@DescLike", "");
                //param.AddWithValue("@AssignedToBuyer", "");
                //param.AddWithValue("@PartTypeID", "");
                //param.AddWithValue("@VendorID", "");
                //param.AddWithValue("@MfgID", "");
                //param.AddWithValue("@SpecialHandlingYNB", "");
                //param.AddWithValue("@BuyerCommentContains", "");
                //param.AddWithValue("@ListCostStart", 0);
                //param.AddWithValue("@ListCostEnd", 0);
                //param.AddWithValue("@VendorPartID", "");
                //param.AddWithValue("MFGPartID", "");
                //param.AddWithValue("@ActiveSetting", "");
                //param.AddWithValue("@Aisle", "");
                //param.AddWithValue("@Shelf", "");
                //param.AddWithValue("@Bin", "");
                //param.AddWithValue("@Notes", "");
                SqlDataReader reader;

                //cmd.CommandText = "filter_GetFilteredStoreroomPartsList";
                param = cmd.Parameters;
                cmd.CommandText = "SELECT Storerooms.n_storeroomid, Storerooms.storeroomid, Storerooms.descr, PartsAtLocation.qtyonhand, PartsAtLocation.n_masterpartid, Masterparts.n_masterpartid AS Expr1, Masterparts.masterpartid,  Masterparts.Description, PartsAtLocation.n_partatlocid FROM PartsAtLocation INNER JOIN Masterparts ON PartsAtLocation.n_masterpartid = Masterparts.n_masterpartid INNER JOIN Storerooms ON PartsAtLocation.n_storeroomid = Storerooms.n_storeroomid WHERE storeroomid = @StoreroomFilter";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                //reader = cmd.ExecuteReader();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                conn.Open();
                da.Fill(ds);

                conn.Close();

                BindingSource partBindingSource = new BindingSource();
                //partBindingSource.DataSource = reader;




                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                    }

                }

                partBindingSource.DataSource = ds.Tables[0];

                bindPart.DataSource = ds.Tables[0];
                partIDLookUp.EditValue = bindPart;
            }
            else
            {
                MessageBox.Show("Please pick a valid storeroom");
                storeRoom.Visible = false;
                storeroomLookUp.Visible = true;
                storeroomLookUp.Focus();

            }
        }

        private void storeroomLookUpEnter(object sender, EventArgs e)
        {
            BindingSource storeRoomBindingSource = new BindingSource();
            storeRoomBindingSource.DataSource = _oCheckOut.GetAllStorerooms(ref loadOK);
            bindStoreroom.DataSource = storeRoomBindingSource;
            storeroomLookUp.EditValue = bindStoreroom;

        }

        private void jobIDLookUpEnter(object sender, EventArgs e)
        {
            BindingSource jobIDLookUpBindingSourc = new BindingSource();
            jobIDLookUpBindingSourc.DataSource = _oCheckOut.GetOpenJobsList(ref loadOK, _nullDate);
            bindJobsList.DataSource = jobIDLookUpBindingSourc;
            JobIDlookUp.EditValue = bindJobsList;
        }

        private void JobIDLookUpEditValueChanged(object sender, EventArgs e)
        {
            _editingJobStepID = Convert.ToInt32(JobIDlookUp.GetColumnValue("n_jobstepid"));
            _editingJobID = Convert.ToInt32(JobIDlookUp.GetColumnValue("n_jobid"));

        }
        #endregion

        private void ShowSplashScreen()
        {
            //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(Splash), true, true);
        }

        private static bool IsServerConnected(string connectionString, out string sqlExpection)
        {
            sqlExpection = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException x)
                {
                    sqlExpection = x.Message;
                    return false;
                }
            }
        }

        private void CheckOutFormLoad(object sender, EventArgs e)
        {
            // DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
        }
        

        private void GetJobButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            BindingSource bindingOpenJobsSource = new BindingSource();
            bindOpenJobs.DataSource = _oCheckOut.GetOpenJobsList(ref loadOK, _nullDate);
            gridControl1.DataSource = bindOpenJobs;
            gridViewJobs.Columns["n_jobstepid"].Visible = false;
            gridViewJobs.Columns["n_jobid"].Visible = false;
            gridViewJobs.Columns["T"].Visible = false;
            gridViewJobs.Columns["A"].Visible = false;
            gridViewJobs.Columns["step"].Visible = false;
            gridViewJobs.Columns["Labor Class"].Visible = false;
            gridViewJobs.Columns["Group"].Visible = false;
            gridViewJobs.Columns["Supervisor"].Visible = false;
            gridViewJobs.Columns["H"].Visible = false;
            gridViewJobs.Columns["I"].Visible = false;
            gridViewJobs.Columns["cReasoncode"].Visible = false;
            gridViewJobs.Columns["AssignedTaskID"].Visible = false;
            gridViewJobs.Columns["ApplyColor"].Visible = false;
            gridViewJobs.Columns["FGColor"].Visible = false;
            gridViewJobs.Columns["BGColor"].Visible = false;
            Cursor = Cursors.Default;
            gridViewJobs.OptionsFind.AlwaysVisible = true;
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn)
            {
                gridControl1.Visible = true;
                GetJobButton.Visible = true;
                JobIDTextEdit.Visible = true;
                JobIDLabel.Visible = true;
                reasonLookUp.Visible = false;
                reasonLabel.Visible = false;

            }

            if (toggleSwitch1.IsOn == false)
            {
                gridControl1.Visible = false;
                GetJobButton.Visible = false;
                JobIDLabel.Visible = false;
                JobIDTextEdit.Visible = false;
                reasonLabel.Visible = true;
                reasonLookUp.Visible = true;


            }
        }

        #region Mouse Events

        private void addPartButton_Click(object sender, EventArgs e)
        {
            if (storeRoom.Text != "" || storeroomLookUp.Text != "")
            {
                var storeroomName = "";
                if (storeroomLookUp.Visible == true && storeroomLookUp.Text != "")
                {
                    storeroomName = storeroomLookUp.Text;
                }
                if (storeRoom.Text != "")
                {
                    storeroomName = storeRoom.Text;
                }



                //NonSortedList param = new NonSortedList();

                DataSet ds = new DataSet();

                SqlConnection conn = new SqlConnection(dbConnection);
                SqlCommand cmd = new SqlCommand();
                SqlParameterCollection param = cmd.Parameters;
                param.AddWithValue("@StoreroomFilter", storeroomName);

                //SqlDataReader reader;

                param = cmd.Parameters;
                cmd.CommandText = "SELECT Storerooms.n_storeroomid, Storerooms.storeroomid, Storerooms.descr, PartsAtLocation.qtyonhand, PartsAtLocation.n_masterpartid, Masterparts.n_masterpartid AS Expr1, Masterparts.masterpartid, PartsAtLocation.n_partatlocid,  Masterparts.Description FROM PartsAtLocation INNER JOIN Masterparts ON PartsAtLocation.n_masterpartid = Masterparts.n_masterpartid INNER JOIN Storerooms ON PartsAtLocation.n_storeroomid = Storerooms.n_storeroomid WHERE storeroomid = @StoreroomFilter";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                //reader = cmd.ExecuteReader();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                conn.Open();
                da.Fill(ds);

                conn.Close();

                BindingSource partBindingSource = new BindingSource();
                //partBindingSource.DataSource = reader;




                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                    }

                }

                partBindingSource.DataSource = ds;

                bindPart.DataSource = partBindingSource;
                partIDLookUp.EditValue = bindPart;
                BindingSource bindingPartsSource = new BindingSource();
                bindingPartsSource.DataSource = ds;
                //gridControl1.DataMember = "n_masterpartid";
                gridControlParts.DataSource = ds.Tables[0];
                //gridView1.Columns["n_jobstepid"].Visible = false;
                //gridView1.Columns["n_jobid"].Visible = false;
                //gridView1.Columns["T"].Visible = false;
                //gridView1.Columns["A"].Visible = false;
                //gridView1.Columns["step"].Visible = false;
                //gridView1.Columns["Labor Class"].Visible = false;
                //gridView1.Columns["Group"].Visible = false;
                //gridView1.Columns["Supervisor"].Visible = false;
                //gridView1.Columns["H"].Visible = false;
                //gridView1.Columns["I"].Visible = false;
                //gridView1.Columns["cReasoncode"].Visible = false;
                //gridView1.Columns["AssignedTaskID"].Visible = false;
                //gridView1.Columns["ApplyColor"].Visible = false;
                //gridView1.Columns["FGColor"].Visible = false;
                //gridView1.Columns["BGColor"].Visible = false;
            }
            else
            {
                MessageBox.Show("Please pick a valid storeroom");
                storeRoom.Visible = false;
                storeroomLabel.Visible = false;
                storeroomLookUp.Visible = true;
                storeroomPartsLabel.Visible = true;
                storeroomLookUp.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var partID = partIDLookUp.Text;
            var n_masterpartid = partIDLookUp.EditValue;
            int qty = Convert.ToInt32(QTYspinEdit.Value);
            int partatlocid = -1;
            var partatloc = _oCheckOut.GetPartAtLocationID(Convert.ToInt32(partID), Convert.ToInt32(storeRoom.EditValue), _oLogon.UserID, ref partatlocid);
            

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            if (gridViewPartsAdded.DataSource == null)
            {
                dt.Columns.Add(new DataColumn("masterpartid"));
                dt.Columns.Add(new DataColumn("QTY"));
                dt.Columns.Add(new DataColumn("n_masterpartid"));
                dt.Columns.Add(new DataColumn("n_partatlocid"));

                DataRow row = dt.NewRow();
                row["masterpartid"] = partID;
                row["QTY"] = qty;
                row["n_masterpartid"] = n_masterpartid;
                row["n_partatlocid"] = partatloc;
                
                dt.Rows.Add(row);
                ds.Tables.Add(dt);

                gridControlPartsAdded.DataSource = ds.Tables[0];

            }
            else
            {
                gridViewPartsAdded.AddNewRow();

                int rowHandle = gridViewPartsAdded.GetRowHandle(gridViewPartsAdded.DataRowCount);

                if (gridViewPartsAdded.IsNewItemRow(rowHandle))
                {
                    gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["masterpartid"], partID);
                    gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["QTY"], qty);
                    gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["n_masterpartid"], n_masterpartid);
                    gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["n_partatlocid"], partatloc);
                }

            }

        }

        private void gridControlParts_MouseClick(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                var selectedRows = gridViewJobs.GetSelectedRows();
                ContextMenuStrip m = new ContextMenuStrip();
                m.Items.Add("Add selected rows");
                m.Show(gridControlParts, new Point(e.X, e.Y));
                m.ItemClicked += new ToolStripItemClickedEventHandler(AddSelectedRows_ItemClicked);
            }
        }

        private void gridControlPartsAdded_MouseClick(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                var selectedRows = gridViewParts.GetSelectedRows();
                ContextMenuStrip m = new ContextMenuStrip();
                m.Items.Add("Delete Selected Rows");
                m.Show(gridControlPartsAdded, new Point(e.X, e.Y));
                m.ItemClicked += M_ItemClicked;
            }
        }

        private void gridControlJobs_MouseClick(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                ContextMenuStrip m = new ContextMenuStrip();
                m.Items.Add("Select Job");
                m.Show(gridControl1, new Point(e.X, e.Y));
                m.ItemClicked += M_ItemClickedJob;
            }
        }

        private void M_ItemClickedJob(object sender, ToolStripItemClickedEventArgs e)
        {
            //var x = selectedrows.GetValue(count);
            //System.Type type = x.GetType();
            //partID = type.GetProperty("masterpartid").GetValue(x).ToString();
           // n_masterpartid = (int)type.GetProperty("n_masterpartid").GetValue(x);

            var result = GetSelectedJob(gridViewJobs, "n_jobid", "n_jobstepid", "Jobid");
            var x = result.GetValue(0);
            System.Type type = x.GetType();
            //_editingJobID = Convert.ToInt32(result[0]);
            _editingJobID = (int)type.GetProperty("n_jobid").GetValue(x);
            _editingJobStepID = (int)type.GetProperty("n_jobstepid").GetValue(x);
            
            
            JobIDlookUp.EditValue = _editingJobID;
            JobIDlookUp.Text = (string)type.GetProperty("Jobid").GetValue(x);

            
        }

        private void M_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var selectedRows = GetSelectedRow(gridViewPartsAdded, "masterpartid");
            var count = 0;
            foreach (var rows in selectedRows)
            {
                gridViewPartsAdded.DeleteRow(count);
                count++;
            }
        }

        void AddSelectedRows_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            var selectedrows = GetSelectedRows(gridViewParts, "masterpartid", "QTY", "n_masterpartid", "n_partatlocid");
            if (gridControlPartsAdded.DataSource == null)
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                dt.Columns.Add(new DataColumn("masterpartid"));
                dt.Columns.Add(new DataColumn("QTY"));
                dt.Columns.Add(new DataColumn("n_masterpartid"));
                dt.Columns.Add(new DataColumn("n_partatlocid"));

                var count = 0;
                var partID = "";
                var n_masterpartid = 0;
                var qty = 0;
                var n_partatlocid = 0;

                foreach (var rows in selectedrows)
                {
                    var x = selectedrows.GetValue(count);
                    System.Type type = x.GetType();
                    partID = type.GetProperty("masterpartid").GetValue(x).ToString();
                    n_masterpartid = (int)type.GetProperty("n_masterpartid").GetValue(x);
                    n_partatlocid = (int)type.GetProperty("n_partatlocid").GetValue(x);

                    DataRow row = dt.NewRow();
                    row["masterpartid"] = partID;
                    row["QTY"] = qty;
                    row["n_masterpartid"] = n_masterpartid;
                    row["n_partatlocid"] = n_partatlocid;

                    dt.Rows.Add(row);
                    count++;

                }
                ds.Tables.Add(dt);

                gridControlPartsAdded.DataSource = ds.Tables[0];
            }
            else
            {
                if (selectedrows.Count() > 0)
                {
                    var partID = "";
                    var n_masterpartid = 0;
                    var qty = 0;
                    var count = 0;
                    var n_partatlocid = 0;

                    foreach (var rows in selectedrows)
                    {
                        var x = selectedrows.GetValue(count);
                        System.Type type = x.GetType();
                        partID = type.GetProperty("masterpartid").GetValue(x).ToString();
                        n_masterpartid = (int)type.GetProperty("n_masterpartid").GetValue(x);
                        n_partatlocid = (int)type.GetProperty("n_partatlocid").GetValue(x);




                        gridViewPartsAdded.AddNewRow();
                        int rowHandle = gridViewPartsAdded.GetRowHandle(gridViewPartsAdded.DataRowCount);

                        if (gridViewPartsAdded.IsNewItemRow(rowHandle))
                        {
                            gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["masterpartid"], partID);
                            gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["QTY"], qty);
                            gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["n_masterpartid"], n_masterpartid);
                            gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["n_partatlocid"], n_partatlocid);

                        }
                        else
                        {

                            gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["masterpartid"], partID);
                            gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["QTY"], qty);
                            gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["n_masterpartid"], n_masterpartid);
                            gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["n_partatlocid"], n_partatlocid);

                        }
                        count++;
                    }
                }
            }
        }

        #endregion

        #region grid row selected methods

        private object[] GetSelectedJob(DevExpress.XtraGrid.Views.Grid.GridView view, string fieldName1, string fieldName2, string fieldName3)
        {
            int[] selectedRows = view.GetSelectedRows();
            object[] result = new object[selectedRows.Length];

            for (int i = 0; i < selectedRows.Length; i++)
            {
                int rowHandle = selectedRows[i];
                if (!gridViewJobs.IsGroupRow(rowHandle))
                {
                    result[i] = new { n_jobid = view.GetRowCellValue(rowHandle, fieldName1), n_jobstepid = view.GetRowCellValue(rowHandle, fieldName2), Jobid = view.GetRowCellValue(rowHandle, fieldName3) };
                   
                }
                else
                    result[i] = -1; // default value
            }


            return result;
        }

        private object[] GetSelectedRow(DevExpress.XtraGrid.Views.Grid.GridView view, string fieldName)
        {
            int[] selectedRows = view.GetSelectedRows();
            object[] result = new object[selectedRows.Length];
             
            for (int i = 0; i < selectedRows.Length; i++)
            {
                int rowHandle = selectedRows[i];
                if (!gridViewJobs.IsGroupRow(rowHandle))
                {
                    result[i] = view.GetRowCellValue(rowHandle, fieldName);
                   
                }
                else
                    result[i] = -1; // default value
            }
            return result;

        }

        private object[] GetSelectedRows(DevExpress.XtraGrid.Views.Grid.GridView view, string fieldName, string QTY, string n_masterpartid, string n_partatlocid)
        {
            int[] selectedRows = view.GetSelectedRows();
            object[] result = new object[selectedRows.Length];
            
            for (int i = 0; i < selectedRows.Length; i++)
            {
                int rowHandle = selectedRows[i];
                if (!gridViewJobs.IsGroupRow(rowHandle))
                {                
                    result[i] = new { masterpartid = view.GetRowCellValue(rowHandle, fieldName), QTY = view.GetRowCellValue(rowHandle, QTY), n_masterpartid = view.GetRowCellValue(rowHandle, n_masterpartid), n_partatlocid = view.GetRowCellValue(rowHandle, n_partatlocid) };                
                }
                else
                    result[i] = -1; // default value
            }
            return result;

        }

        #endregion

      


      

        #region Checkout Process
        private void checkOutButton_Click(object sender, EventArgs e)
        {
            GridView dg = gridViewPartsAdded;

            ProcessMaterialSelections(dg);
        }



        private void ProcessMaterialSelections(GridView dg)
        {

            ///Checkout for Other
            if (dg.RowCount > 0)
            {
                var _oMaster = new Masterparts(dbConnection, false);
                JobstepJobParts _oParts = new JobstepJobParts(dbConnection, false);
                var selectedRows = new NonSortedList();
                for (var a = 0; a < dg.RowCount; a++)
                {
                    selectedRows.Add(a.ToString(), dg.GetRowCellValue(a, "n_masterpartid"));
                }

                if (selectedRows.Count() > 0)
                {
                    var continueProcessing = true;
                    var itemsAdded = 0;
                    Cursor = Cursors.WaitCursor;
                    _oCheckOut.ClearErrors();

                    #region Get values from inputs
                    if (dateEdit.EditValue != null && dateEdit.EditValue.ToString() != "")
                    {
                        _editingReceivedDate = Convert.ToDateTime(dateEdit.EditValue.ToString());
                    }
                    else
                    {
                        _editingReceivedDate = DateTime.Now;
                    }

                    if (takenByLookUp.EditValue != null)
                    {
                        _editingTakenBy = Convert.ToInt32(takenByLookUp.EditValue.ToString());
                    }
                    else
                    {
                        _editingTakenBy = -1;
                    }

                    if (storeRoom.EditValue != null || storeroomLookUp.EditValue != null)
                    {
                        _editingStoreroomID = (storeRoom.EditValue == null) ? Convert.ToInt32(storeroomLookUp.EditValue.ToString()) : Convert.ToInt32(storeRoom.EditValue);
                    }
                    else
                    {
                        _editingStoreroomID = -1;
                    }

                    if (userNameTextBox.EditValue != null)
                    {
                        _editingGivenByID = Convert.ToInt32(userNameTextBox.EditValue.ToString());
                    }
                    else
                    {
                        _editingGivenByID = -1;
                    }

                    #endregion
                    #region has jobID
                    if (toggleSwitch1.IsOn == true)
                    {

                    if (JobIDlookUp.EditValue != null)
                    {
                        _editingJobID = Convert.ToInt32(JobIDlookUp.EditValue);
                    }
                    else
                    {
                        MessageBox.Show("Please select a job to apply parts");
                        JobIDTextEdit.Focus();
                    }

                    //if (JobStepLookUp.EditValue != null)
                    //{
                    //    _editingJobStepID = Convert.ToInt32(JobStepLookUp.EditValue);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("No JobStep ID avalible");
                    //}

                        if (_editingTransactionID <= 0)
                        {
                            var transactionID = "";
                            _oCheckOut.ClearErrors();
                            if (!_oCheckOut.GetNextTransactionID(ref transactionID, _oLogon.UserID))
                            {
                                Cursor = Cursors.Default;
                                MessageBox.Show(
                                            @"Error Getting Next Transaction Number - " + _oCheckOut.LastError,
                                            @"Transaction Error");
                                continueProcessing = false;
                            }
                            else
                            {
                                _editingTransactionID = Convert.ToInt32(transactionID);
                                _editingActionNum = Convert.ToString((_editingTransactionID + 1000000));
                                txtTransactionNumber.Text = _editingActionNum;
                            }

                            if (continueProcessing)
                            {
                                if (_oCheckOut.AddTransaction(_editingTransactionID,
                                                                        _editingActionNum,
                                                                        _editingCarrierID,
                                                                        -1,
                                                                        -1,
                                                                        _editingGivenByID,
                                                                        _editingJobID,
                                                                        _editingPurchaseOrderID,
                                                                        _editingStoreroomID,
                                                                        _editingTakenBy,
                                                                        _editingVendorID,
                                                                        _editingStoresIssueID,
                                                                        "N",
                                                                        _editingReceivedDate,
                                                                        _editingInvoiceNum,
                                                                        _editingNotes,
                                                                        _editingReceiptID,
                                                                        _editingJobStepID,
                                                                        _oLogon.UserID))
                                {


                                }
                                else
                                {
                                    Cursor = Cursors.Default;
                                    MessageBox.Show(@"Error Creating Transaction - " + _oCheckOut.LastError,
                                                            @"Transaction Error");
                                    continueProcessing = false;
                                }

                                if (continueProcessing)
                                {
                                    var gotData = true;
                                    #region loop through parts added grid
                                    for (var i = 0; i < selectedRows.Count(); i++)
                                    {
                                        var rowIndex = Convert.ToInt32(selectedRows.Keys[i].ToString());
                                        
                                        _oMaster.ClearErrors();
                                        var masterpartID = Convert.ToInt32(dg.GetRowCellValue(rowIndex, "n_masterpartid"));
                                        _editingQty = Convert.ToInt32(dg.GetRowCellValue(rowIndex, "QTY"));
                                        var masterpartDetail = _oMaster.GetMasterpartDetail(masterpartID, _oLogon.UserID, ref gotData);
                                        if (gotData)
                                        {
                                            if (masterpartDetail.Tables.Count > 0)
                                            {
                                                if (masterpartDetail.Tables[0].Rows.Count > 0)
                                                {
                                                    _editingPartID =
                                                        Convert.ToInt32(masterpartDetail.Tables[0].Rows[0][0]);
                                                    _editingUnits = masterpartDetail.Tables[0].Rows[0][16].ToString();
                                                    var partID = masterpartDetail.Tables[0].Rows[0][1].ToString();
                                                    var partCost = Convert.ToDecimal(
                                                        masterpartDetail.Tables[0].Rows[0][3].ToString());
                                                    var prefMfgPartID = Convert.ToInt32(
                                                        masterpartDetail.Tables[0].Rows[0][10].ToString());
                                                    var partDesc = masterpartDetail.Tables[0].Rows[0][2].ToString();

                                                    _oParts.SetJobstepInfo(_editingJobID, _editingJobStepID);
                                                    //Add New Part To Job Record
                                                    if (!_oParts.Add(_editingPartID,
                                                                        _editingStoreroomID,
                                                                        false,
                                                                        false,
                                                                        "",
                                                                        partID,
                                                                        partCost,
                                                                        "",
                                                                        partDesc,
                                                                        0,
                                                                        _editingQty,
                                                                        _editingReceivedDate,
                                                                        prefMfgPartID,
                                                                        -1,
                                                                        _oLogon.UserID,
                                                                        -1,
                                                                        -1))
                                                    {
                                                        Cursor = Cursors.Default;
                                                        MessageBox.Show(
                                                            @"Error Adding New Part To Jobstep - " + _oParts.LastError,
                                                            @"Error Adding Part");
                                                        // ReSharper disable RedundantAssignment
                                                        continueProcessing = false;
                                                        // ReSharper restore RedundantAssignment
                                                    }
                                                }
                                                else
                                                {
                                                    Cursor = Cursors.Default;
                                                    MessageBox.Show(@"Mastpart (" + masterpartID +
                                                                    @") No Longer Exists");
                                                    // ReSharper disable RedundantAssignment
                                                    continueProcessing = false;
                                                    // ReSharper restore RedundantAssignment
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Cursor = Cursors.Default;
                                                MessageBox.Show(@"Masterpart Table Expected");
                                                // ReSharper disable RedundantAssignment
                                                continueProcessing = false;
                                                // ReSharper restore RedundantAssignment
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Cursor = Cursors.Default;
                                            MessageBox.Show(_oMaster.LastError,
                                                            @"Error Getting Masterparts Information");
                                            // ReSharper disable RedundantAssignment
                                            continueProcessing = false;
                                            // ReSharper restore RedundantAssignment
                                            break;
                                        }

                                        var newItemKey = -1;
                                        var newPartAtLocID = -1;

                                        //Determine If We Have A Valid Part At Location ID
                                        _editingPartAtLocationID =
                                            Convert.ToInt32(dg.GetRowCellValue(rowIndex, "n_partatlocid"));

                                        if (_editingPartAtLocationID == -1)
                                        {
                                            if (_oCheckOut.GetPartAtLocationID(_editingPartID,
                                                                                _editingStoreroomID,
                                                                                _oLogon.UserID,
                                                                                ref newPartAtLocID))
                                            {
                                                _editingPartAtLocationID = newPartAtLocID;
                                            }
                                            else
                                            {
                                                Cursor = Cursors.Default;
                                                MessageBox.Show(
                                                    @"Error Getting Part At Location ID - " + _oCheckOut.LastError,
                                                    @"Part At Location Error");
                                                // ReSharper disable RedundantAssignment
                                                continueProcessing = false;
                                                // ReSharper restore RedundantAssignment
                                                break;
                                            }
                                        }

                                        if (_oCheckOut.Add(_editingTransactionID,
                                                            _editingPartAtLocationID,
                                                            _editingPartID,
                                                            _editingStoreroomID,
                                                            _editingReqID,
                                                            _editingReqItemID,
                                                            false,
                                                            _editingExpDate,
                                                            _editingActionNum,
                                                            _editingReqQty,
                                                            _editingQty,
                                                            "",
                                                            _oLogon.UserID,
                                                            _oParts.RecordID,
                                                            ref newItemKey))
                                        {
                                            itemsAdded++;
                                        }
                                        else
                                        {
                                            Cursor = Cursors.Default;
                                            MessageBox.Show(
                                                @"Error Adding Item To Check Out Transaction - " +
                                                _oCheckOut.LastError, @"Error Adding Item");
                                            // ReSharper disable RedundantAssignment
                                            continueProcessing = false;
                                            // ReSharper restore RedundantAssignment
                                            break;
                                        }
                                    }
                                    #endregion
                                    Cursor = Cursors.Default;
                                    if (itemsAdded > 0)
                                    {
                                        MessageBox.Show(itemsAdded + @" Parts Added");
                                    }

                                }

                            }
                        }



                    }
                    #endregion
                    #region Does not have JobID
                    else
                    {
                       
                        if(reasonLookUp.EditValue != null)
                        {
                            _editingCheckOutReasonID = Convert.ToInt32(reasonLookUp.EditValue);
                        }

                        if (_editingTransactionID <= 0)
                        {
                            var transactionID = "";
                            _oCheckOut.ClearErrors();
                            if (!_oCheckOut.GetNextTransactionID(ref transactionID, _oLogon.UserID))
                            {
                                Cursor = Cursors.Default;
                                MessageBox.Show(
                                            @"Error Getting Next Transaction Number - " + _oCheckOut.LastError,
                                            @"Transaction Error");
                                continueProcessing = false;
                            }
                            else
                            {
                                _editingTransactionID = Convert.ToInt32(transactionID);
                                _editingActionNum = Convert.ToString((_editingTransactionID + 1000000));
                                txtTransactionNumber.Text = _editingActionNum;
                            }

                            if (continueProcessing)
                            {
                                if (_oCheckOut.AddTransaction(_editingTransactionID,
                                                                    _editingActionNum,
                                                                    _editingCarrierID,
                                                                    -1,
                                                                    _editingCheckOutReasonID,
                                                                    _editingGivenByID,
                                                                    _editingJobStepID,
                                                                    _editingPurchaseOrderID,
                                                                    _editingStoreroomID,
                                                                    _editingTakenBy,
                                                                    _editingVendorID,
                                                                    _editingStoresIssueID,
                                                                    "N",
                                                                    _editingReceivedDate,
                                                                    _editingInvoiceNum,
                                                                    _editingNotes,
                                                                    _editingReceiptID,
                                                                    _editingJobStepID,
                                                                    _oLogon.UserID))
                                {


                                }
                                else
                                {
                                    Cursor = Cursors.Default;
                                    MessageBox.Show(@"Error Creating Transaction - " + _oCheckOut.LastError,
                                                            @"Transaction Error");
                                    continueProcessing = false;
                                }

                                if (continueProcessing)
                                {
                                    var gotData = true;
                                    #region loop through parts added grid
                                    for (var i = 0; i < selectedRows.Count(); i++)
                                    {
                                        var rowIndex = Convert.ToInt32(selectedRows.Keys[i].ToString());
                                       
                                        _oMaster.ClearErrors();
                                        var masterpartID = Convert.ToInt32(dg.GetRowCellValue(rowIndex, "n_masterpartid"));
                                        _editingQty = Convert.ToInt32(dg.GetRowCellValue(rowIndex, "QTY"));
                                        var masterpartDetail = _oMaster.GetMasterpartDetail(masterpartID, _oLogon.UserID, ref gotData);
                                        if (gotData)
                                        {
                                            if (masterpartDetail.Tables.Count > 0)
                                            {
                                                if (masterpartDetail.Tables[0].Rows.Count > 0)
                                                {
                                                    _editingPartID =
                                                        Convert.ToInt32(masterpartDetail.Tables[0].Rows[0][0]);
                                                    _editingUnits = masterpartDetail.Tables[0].Rows[0][16].ToString();

                                                    var partID = masterpartDetail.Tables[0].Rows[0][1].ToString();
                                                    var partCost = Convert.ToDecimal(
                                                        masterpartDetail.Tables[0].Rows[0][3].ToString());
                                                    var prefMfgPartID = Convert.ToInt32(
                                                        masterpartDetail.Tables[0].Rows[0][10].ToString());
                                                    var partDesc = masterpartDetail.Tables[0].Rows[0][2].ToString();

                                                  
                                                }
                                                else
                                                {
                                                    Cursor = Cursors.Default;
                                                    MessageBox.Show(@"Mastpart (" + masterpartID +
                                                                    @") No Longer Exists");
                                                    // ReSharper disable RedundantAssignment
                                                    continueProcessing = false;
                                                    // ReSharper restore RedundantAssignment
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Cursor = Cursors.Default;
                                                MessageBox.Show(@"Masterpart Table Expected");
                                                // ReSharper disable RedundantAssignment
                                                continueProcessing = false;
                                                // ReSharper restore RedundantAssignment
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Cursor = Cursors.Default;
                                            MessageBox.Show(_oMaster.LastError,
                                                            @"Error Getting Masterparts Information");
                                            // ReSharper disable RedundantAssignment
                                            continueProcessing = false;
                                            // ReSharper restore RedundantAssignment
                                            break;
                                        }

                                        var newItemKey = -1;
                                        var newPartAtLocID = -1;

                                        //Determine If We Have A Valid Part At Location ID
                                        _editingPartAtLocationID =
                                            Convert.ToInt32(dg.GetRowCellValue(rowIndex, "n_partatlocid"));

                                        if (_editingPartAtLocationID == -1)
                                        {
                                            if (_oCheckOut.GetPartAtLocationID(_editingPartID,
                                                                                _editingStoreroomID,
                                                                                _oLogon.UserID,
                                                                                ref newPartAtLocID))
                                            {
                                                _editingPartAtLocationID = newPartAtLocID;
                                            }
                                            else
                                            {
                                                Cursor = Cursors.Default;
                                                MessageBox.Show(
                                                    @"Error Getting Part At Location ID - " + _oCheckOut.LastError,
                                                    @"Part At Location Error");
                                                // ReSharper disable RedundantAssignment
                                                continueProcessing = false;
                                                // ReSharper restore RedundantAssignment
                                                break;
                                            }
                                        }

                                        if (_oCheckOut.Add(_editingTransactionID,
                                                            _editingPartAtLocationID,
                                                            _editingPartID,
                                                            _editingStoreroomID,
                                                            _editingReqID,
                                                            _editingReqItemID,
                                                            false,
                                                            _editingExpDate,
                                                            _editingActionNum,
                                                            _editingReqQty,
                                                            _editingQty,
                                                            "",
                                                            _oLogon.UserID,
                                                            _oParts.RecordID,
                                                            ref newItemKey))
                                        {
                                            itemsAdded++;
                                        }
                                        else
                                        {
                                            Cursor = Cursors.Default;
                                            MessageBox.Show(
                                                @"Error Adding Item To Check Out Transaction - " +
                                                _oCheckOut.LastError, @"Error Adding Item");
                                            // ReSharper disable RedundantAssignment
                                            continueProcessing = false;
                                            // ReSharper restore RedundantAssignment
                                            break;
                                        }
                                    }
                                    #endregion
                                    Cursor = Cursors.Default;
                                    _editingTransactionID = 0;
                                    if (itemsAdded > 0)
                                    {
                                        MessageBox.Show(itemsAdded + @" Parts checked out");
                                    }

                                }

                            }
                        }
                        #endregion
                    }


                }
                Cursor = Cursors.Default;
            }
        }

        #endregion


        #region transaction process
        private void GetTransactionHistory()
        {
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection(dbConnection);
            SqlCommand cmd = new SqlCommand();
            SqlParameterCollection param = cmd.Parameters;
            //param.AddWithValue("@StoreroomFilter", storeroomName);

            //SqlDataReader reader;

            param = cmd.Parameters;
            cmd.CommandText = "SELECT xactionitems.xactionnum, Masterparts.masterpartid, PartsAtLocation.aisle, PartsAtLocation.shelf, PartsAtLocation.bin, xactionitems.ReqQty, xactionitems.qty, Masterparts.UnitOfIssue, Masterparts.Description" +
                        " FROM xactionitems INNER JOIN" +
                        " PartsAtLocation ON xactionitems.n_partatlocid = PartsAtLocation.n_partatlocid INNER JOIN" +
                        " Masterparts ON xactionitems.n_masterpartid = Masterparts.n_masterpartid AND PartsAtLocation.n_masterpartid = Masterparts.n_masterpartid";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            //reader = cmd.ExecuteReader();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(ds);

            conn.Close();

            transactionHistoryGridControl.DataSource = ds.Tables[0];
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            GetTransactionHistory();
        }
        #endregion

      
    }
}