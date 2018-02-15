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
   
    public partial class CheckOutForm : XtraForm
    {
        public PersonnelLogonObjectClass oLogon;
        public PersonnelLogonObjectClass _oLogon = new PersonnelLogonObjectClass();
        
       
        private readonly DateTime _nullDate = Convert.ToDateTime("1/1/1960 23:59:59");
        private readonly bool _viewOnly;
        private readonly DbCheckOut _oCheckOut;

        private readonly Masterparts _oMaster;
        private readonly JobstepJobParts _oParts;
        private readonly StoresIssue _oSi;
        private bool checkoutComplete;
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
        private bool _givenByLoaded;
        private bool _inLookUp;
        private bool _isCancelling;
        private bool _jobsLoaded;
        private bool _otherReasonsLoaded;
        private int _priorStoreroom = -1;
        private bool _storeroomsLoaded;
        private bool _storesIssuesLoaded;
        private bool _takenByLoaded;
        private string dbConnection = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        private static string _storageConnectionStringSetting = "StorageConnectionString";
        private static string _storageConnectionString = CloudConfigurationManager.GetSetting(_storageConnectionStringSetting);
        private static CloudBlobClient _blobClient = _storageConnectionString != null ? CloudStorageAccount.Parse(_storageConnectionString).CreateCloudBlobClient() : null;
        bool loadOK = true;
        BindingSource jobIDLookUpBindingSourc = new BindingSource();

       

        public CheckOutForm()
        {
            ShowSplashScreen();
               
            _oCheckOut = new DbCheckOut(dbConnection, false);
            InitializeComponent();
            jobIDLookUpBindingSourc.DataSource = _oCheckOut.GetOpenJobsList(ref loadOK, _nullDate);
            System.Threading.Thread.Sleep(10000);
            CloseSplashScreen();
            System.Threading.Thread.Sleep(1000);
            
            if (_oLogon.UserID < 1)
            {
                var login = new LoginForm(ref _oLogon);

                login.ShowDialog(); 
                
                if(_oLogon.UserID < 1)
                {
                     MessageBox.Show("You are not logged in. Please login to access Checkout Form");
                    login.ShowDialog();
                }           
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
                JobIDlookUp.BackColor = Color.Crimson;
                JobIDLabel.Visible = true;
                reasonLookUp.Visible = false;
                reasonLabel.Visible = false;

            }
            storeRoom.BackColor = Color.Crimson;
            StoreRoomNameLable.Text = "";
            
            
           
            QTYspinEdit.Enabled = false;
            simpleButton1.Enabled = false;
            addPartButton.Enabled = false;
            partIDLookUp.Enabled = false;
            WorkOpLabel.Visible = false;
            WorkOpLookUp.Visible = false;

        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            dateEdit.EditValue = _nullDate;
            dateEdit.EditValue = DateTime.Now;
            lookUpEdit1.Focus();
            lookUpEdit1.EditValue = Convert.ToInt32(_oLogon.UserID);
            takenByLookUp.EditValue = Convert.ToInt32(_oLogon.UserID);
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


            QTYspinEdit.Enabled = true;
            simpleButton1.Enabled = true;
            addPartButton.Enabled = true;
            partIDLookUp.Enabled = true;
           

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
            if (storeRoom.Text != "")
            {
                var storeroomName = "";
                
                    storeroomName = storeRoom.Text;
                
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
                storeRoom.Focus();
                

            }
        }

        private void jobIDLookUpEnter(object sender, EventArgs e)
        {
            //BindingSource jobIDLookUpBindingSourc = new BindingSource();
            //jobIDLookUpBindingSourc.DataSource = _oCheckOut.GetOpenJobsList(ref loadOK, _nullDate);
            bindJobsList.DataSource = jobIDLookUpBindingSourc;
            JobIDlookUp.EditValue = bindJobsList;
        }

        private void JobIDLookUpEditValueChanged(object sender, EventArgs e)
        {
            if(_editingJobStepID < 0)
            {
                _editingJobStepID = Convert.ToInt32(JobIDlookUp.GetColumnValue("n_jobstepid"));
                jobStepText.EditValue = _editingJobStepID;
            } else
            {
                jobStepText.EditValue = _editingJobStepID;
            }
            _editingJobID = Convert.ToInt32(JobIDlookUp.GetColumnValue("n_jobid"));

        }
        #endregion

        private void ShowSplashScreen()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(SplashScreen1), true, true, true, 4000);
            
        }

        private void CloseSplashScreen()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
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
             DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
        }
        

        private void GetJobButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            BindingSource bindingOpenJobsSource = new BindingSource();
            //bindOpenJobs.DataSource = _oCheckOut.GetOpenJobsList(ref loadOK, _nullDate);
            //gridControl1.DataSource = bindOpenJobs;
            gridControl1.DataSource = jobIDLookUpBindingSourc;
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
                JobIDlookUp.Visible = true;
                JobIDLabel.Visible = true;
                WorkOpLabel.Visible = false;
                WorkOpLookUp.Visible = false;
                reasonLookUp.Visible = false;
                reasonLabel.Visible = false;
                reasonLookUp.EditValue = null;

            }

            if (toggleSwitch1.IsOn == false)
            {
                gridControl1.Visible = false;
                GetJobButton.Visible = false;
                JobIDLabel.Visible = false;
                JobIDlookUp.Visible = false;
                JobIDlookUp.EditValue = null;
                jobStepText.EditValue = null;
                reasonLabel.Visible = true;
                reasonLookUp.Visible = true;
                WorkOpLookUp.Visible = false;
                WorkOpLabel.Visible = false;
                WorkOpLookUp.EditValue = null;


            }
        }

        #region Mouse Events

        private void addPartButton_Click(object sender, EventArgs e)
        {
            if (storeRoom.Text != "")
            {
                var storeroomName = "";
               
                    storeroomName = storeRoom.Text;
                



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
                
                gridControlParts.DataSource = ds.Tables[0];
                
            }
            else
            {
                MessageBox.Show("Please pick a valid storeroom");

                storeRoom.BackColor = Color.Crimson;
                storeRoom.Focus();

                
               
                
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var partID = partIDLookUp.Text;
            var n_masterpartid = partIDLookUp.EditValue;
            int qty = Convert.ToInt32(QTYspinEdit.Value);
            int partatlocid = -1;
            var partatloc = _oCheckOut.GetPartAtLocationID(Convert.ToInt32(n_masterpartid), Convert.ToInt32(storeRoom.EditValue), _oLogon.UserID, ref partatlocid);
            

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
                row["n_partatlocid"] = partatlocid;
                
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
                    gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["n_partatlocid"], partatlocid);
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
            var result = GetSelectedJob(gridViewJobs, "n_jobid", "n_jobstepid", "Jobid");
            var x = result.GetValue(0);
            System.Type type = x.GetType();
            _editingJobID = (int)type.GetProperty("n_jobid").GetValue(x);
            _editingJobStepID = (int)type.GetProperty("n_jobstepid").GetValue(x);
            var jobid = type.GetProperty("Jobid").GetValue(x);
            JobIDlookUp.EditValue = _editingJobID;
            
            JobIDlookUp.Text = jobid.ToString();         
            jobStepText.EditValue = _editingJobStepID;            
        }

        private void M_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var selectedRows = GetSelectedRow(gridViewPartsAdded, "masterpartid", "rowhandle");
            var count = 0;
            var rowhandle = 0;
            object result;
            foreach (var rows in selectedRows)
            {
                result = selectedRows.GetValue(count);
                System.Type type = result.GetType();
                rowhandle = (int)type.GetProperty("rowhandle").GetValue(result);
                
                gridViewPartsAdded.DeleteRow(rowhandle);
                count++;
            }
        }

        void AddSelectedRows_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            AddSelectedRows(sender);     
        }

        #endregion

        #region grid row selected methods
        /// <summary>
        /// getting Selected row from the Jobs list
        /// </summary>
        /// <param name="view"></param>
        /// <param name="fieldName1"></param>
        /// <param name="fieldName2"></param>
        /// <param name="fieldName3"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Getting slected rows from the parts grid
        /// </summary>
        /// <param name="view"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        private object[] GetSelectedRow(DevExpress.XtraGrid.Views.Grid.GridView view, string fieldName, string rowhandle)
        {
            int[] selectedRows = view.GetSelectedRows();
            object[] result = new object[selectedRows.Length];
             
            for (int i = 0; i < selectedRows.Length; i++)
            {
                int rowHandle = selectedRows[i];
                if (!gridViewJobs.IsGroupRow(rowHandle))
                {
                    result[i] = new {masterpartid =  view.GetRowCellValue(rowHandle, fieldName), rowhandle = rowHandle };
                   
                }
                else
                    result[i] = -1; // default value
            }
            return result;
        }

        /// <summary>
        /// Getting Selected Rows from the parts added list
        /// </summary>
        /// <param name="view"></param>
        /// <param name="fieldName"></param>
        /// <param name="QTY"></param>
        /// <param name="n_masterpartid"></param>
        /// <param name="n_partatlocid"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Processing the parts to be checked out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkOutButton_Click(object sender, EventArgs e)
        {
            if(_editingTransactionID > -1)
            {
                _editingTransactionID = -1;

            } 
            GridView dg = gridViewPartsAdded;

            ProcessMaterialSelections(dg); 

            if(checkoutComplete == true)
            {
                gridControlPartsAdded.DataSource = null;
                navigationFrame.SelectedPageIndex = tileBarGroupTables.Items.IndexOf(tileBarItem2);
                tileBar.SelectedItem = tileBarItem2;
                checkoutComplete = false;
                StoreRoomNameLable.Text = "";
            }
            

        }

        /// <summary>
        /// Processing method that completes the checkout.
        /// </summary>
        /// <param name="dg"></param>
        private void ProcessMaterialSelections(GridView dg)
        {
            
            ///Checkout for Other
            if (dg.RowCount > 0)
            {
                var _oMaster = new Masterparts(dbConnection, false);
                JobstepJobParts _oParts = new JobstepJobParts(dbConnection, false);
                var selectedRows = new NonSortedList();
                var selectedRowsPartatLoc = new NonSortedList();
                for (var a = 0; a < dg.RowCount; a++)
                {
                    selectedRows.Add(a.ToString(), dg.GetRowCellValue(a, "n_masterpartid"));
                    selectedRowsPartatLoc.Add(a.ToString(), dg.GetRowCellValue(a, "n_partatlocid"));
                    
                }

                if (selectedRows.Count() > 0)
                {
                    var continueProcessing = true;
                    var itemsAdded = 0;
                   
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

                    if (storeRoom.EditValue != null )
                    {
                        _editingStoreroomID = Convert.ToInt32(storeRoom.EditValue);
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
                  try
                    {
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
                                JobIDlookUp.Focus();
                                JobIDlookUp.BackColor = Color.Crimson;
                                continueProcessing = false;
                                navigationFrame.SelectedPageIndex = tileBarGroupTables.Items.IndexOf(eployeesTileBarItem);
                                tileBar.SelectedItem = eployeesTileBarItem;
                                checkoutComplete = false;
                               
                                return;
                            }

                            if (jobStepText.EditValue != null)
                            {
                                _editingJobStepID = Convert.ToInt32(jobStepText.EditValue);
                            }
                            else
                            {
                                MessageBox.Show("No job step ID avalible. Please select a job that has a valid job step.");
                                JobIDlookUp.Focus();
                                JobIDlookUp.BackColor = Color.Crimson;
                                continueProcessing = false;
                                navigationFrame.SelectedPageIndex = tileBarGroupTables.Items.IndexOf(eployeesTileBarItem);
                                tileBar.SelectedItem = eployeesTileBarItem;
                                checkoutComplete = false;
                                
                                return;
                            }

                            if (_editingTransactionID <= 0)
                            {
                                var transactionID = "";
                                _oCheckOut.ClearErrors();
                                if (!_oCheckOut.GetNextTransactionID(ref transactionID, _oLogon.UserID))
                                {
                                   
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
                                        
                                        MessageBox.Show(@"Error Creating Transaction - " + _oCheckOut.LastError,
                                                                @"Transaction Error");
                                        continueProcessing = false;
                                    }

                                    //
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
                                            //_editingPartAtLocationID = Convert.ToInt32(dg.GetRowCellValue(rowIndex, "n_partatlocid"));

                                            //if (_editingPartAtLocationID == -1)
                                            //{
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
                                            //}

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
                                       
                                        _editingTransactionID = -1;
                                        _editingTransactionItemID = -1;
                                        if (itemsAdded > 0)
                                        {
                                            MessageBox.Show(itemsAdded + @" Parts Added" + Environment.NewLine +@"Transaction: " + _editingActionNum);
                                        }
                                        _editingActionNum = "";
                                        checkoutComplete = true;

                                    }

                                }
                            }



                        }
                        #endregion


                        #region Does not have JobID
                        else
                        {

                            if (reasonLookUp.EditValue != null)
                            {
                                _editingCheckOutReasonID = Convert.ToInt32(reasonLookUp.EditValue);
                            }

                            if (_editingTransactionID <= 0)
                            {
                                var transactionID = "";
                                _oCheckOut.ClearErrors();
                                if (!_oCheckOut.GetNextTransactionID(ref transactionID, _oLogon.UserID))
                                {
                                    
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
                                            //_editingPartAtLocationID =
                                            //    Convert.ToInt32(dg.GetRowCellValue(rowIndex, "n_partatlocid"));

                                            //if (_editingPartAtLocationID == -1)
                                            //{
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
                                            //}

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
                                        _editingTransactionID = -1;
                                        _editingTransactionItemID = -1;
                                       
                                        if (itemsAdded > 0)
                                        {
                                            MessageBox.Show(itemsAdded + @" Parts checked out. " + Environment.NewLine + @"Transaction: " + _editingActionNum);
                                        }
                                        _editingActionNum = "";
                                        checkoutComplete = true;
                                    }

                                }
                            }
                        }
                        #endregion
                    }
                    catch
                    {
                        MessageBox.Show(@"Error processing checkout. Not all steps may have been completed");
                    }


                }
               
            }
            
        }

        #endregion


        #region transaction process

        /// <summary>
        /// Gets the transaction history and displays a grid
        /// </summary>
        private void GetTransactionHistory()
        {
            Cursor = Cursors.WaitCursor;
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection(dbConnection);
            SqlCommand cmd = new SqlCommand();
            SqlParameterCollection param = cmd.Parameters;
            //param.AddWithValue("@StoreroomFilter", storeroomName);

            //SqlDataReader reader;

            param = cmd.Parameters;
            cmd.CommandText = "SELECT partxactions.RecordID, partxactions.n_xactionid, partxactions.xactionnum, partxactions.n_givenby, partxactions.n_jobid, partxactions.n_jobstepid, partxactions.n_storeroomid, Masterparts.n_masterpartid," +
                         " Masterparts.masterpartid, Masterparts.Description, PartsAtLocation.aisle, PartsAtLocation.bin, PartsAtLocation.qtyonhand, xactionitems.qty, Storerooms.descr, Jobs.Jobid" +
                         " FROM PartsAtLocation INNER JOIN" +
                         " Masterparts ON PartsAtLocation.n_masterpartid = Masterparts.n_masterpartid INNER JOIN" +
                         " xactionitems ON PartsAtLocation.n_partatlocid = xactionitems.n_partatlocid AND Masterparts.n_masterpartid = xactionitems.n_masterpartid INNER JOIN" +
                         " partxactions ON xactionitems.n_xactionid = partxactions.n_xactionid INNER JOIN" +
                         " Storerooms ON PartsAtLocation.n_storeroomid = Storerooms.n_storeroomid AND xactionitems.n_storeroomid = Storerooms.n_storeroomid AND partxactions.n_storeroomid = Storerooms.n_storeroomid INNER JOIN" +
                         " Jobs ON partxactions.n_jobid = Jobs.n_Jobid";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            //reader = cmd.ExecuteReader();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(ds);

            conn.Close();

            transactionHistoryGridControl.DataSource = ds.Tables[0];
            Cursor = Cursors.Default;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
            GetTransactionHistory();
            
        }


        #endregion

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection(dbConnection);
            SqlCommand cmd = new SqlCommand();
            SqlParameterCollection param = cmd.Parameters;
            param.AddWithValue("@transNum", txtTransactionNumber.EditValue);

            //SqlDataReader reader;

            param = cmd.Parameters;
            cmd.CommandText = "SELECT partxactions.RecordID, partxactions.n_xactionid, partxactions.xactionnum, partxactions.n_givenby, partxactions.n_jobid, partxactions.n_jobstepid, partxactions.n_storeroomid, Masterparts.n_masterpartid," +
                         " Masterparts.masterpartid, Masterparts.Description, PartsAtLocation.aisle, PartsAtLocation.bin, PartsAtLocation.qtyonhand, xactionitems.qty, Storerooms.descr, Jobs.Jobid" +
                         " FROM PartsAtLocation INNER JOIN" +
                         " Masterparts ON PartsAtLocation.n_masterpartid = Masterparts.n_masterpartid INNER JOIN" +
                         " xactionitems ON PartsAtLocation.n_partatlocid = xactionitems.n_partatlocid AND Masterparts.n_masterpartid = xactionitems.n_masterpartid INNER JOIN" +
                         " partxactions ON xactionitems.n_xactionid = partxactions.n_xactionid INNER JOIN" +
                         " Storerooms ON PartsAtLocation.n_storeroomid = Storerooms.n_storeroomid AND xactionitems.n_storeroomid = Storerooms.n_storeroomid AND partxactions.n_storeroomid = Storerooms.n_storeroomid INNER JOIN" +
                         " Jobs ON partxactions.n_jobid = Jobs.n_Jobid" +
                         " WHERE @transNum = partxactions.xactionnum";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            //reader = cmd.ExecuteReader();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(ds);

            conn.Close();

            transactionHistoryGridControl.DataSource = ds.Tables[0];
            Cursor = Cursors.Default;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to use existing information to make a new Check out?", "New Check Out", MessageBoxButtons.YesNoCancel);
                   
            switch(result)
            {
                case DialogResult.Yes:
                    //clear needed values
                    _editingTransactionID = -1;
                    _editingTransactionItemID = -1;
                    _editingActionNum = "";
                    txtTransactionNumber.EditValue = "";

                    //switch to focus to first page
                    navigationFrame.SelectedPageIndex = tileBarGroupTables.Items.IndexOf(eployeesTileBarItem);
                    tileBar.SelectedItem = eployeesTileBarItem;
                    break;
                case DialogResult.No:
                    //clear all inputs
                    resetform();
                    

                    navigationFrame.SelectedPageIndex = tileBarGroupTables.Items.IndexOf(eployeesTileBarItem);
                    tileBar.SelectedItem = eployeesTileBarItem;
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }
        }

        private void resetform()
        {
            takenByLookUp.EditValue = null;
            reasonLookUp.EditValue = null;
            JobIDlookUp.EditValue = null;
            partIDLookUp.EditValue = null;
            QTYspinEdit.EditValue = null;
            storeRoom.EditValue = null;
            gridControl1.DataSource = null;
            gridControlParts.DataSource = null;
            gridControlPartsAdded.DataSource = null;
            transactionHistoryGridControl.DataSource = null;
            txtTransactionNumber.EditValue = null;
            jobStepText.EditValue = null;
            _editingTransactionID = -1;
            _editingTransactionItemID = -1;

            _editingTransactionID = -1;
            _editingActionNum = "";
            _editingCarrierID = -1;

            _editingGivenByID = _oLogon.UserID;
            _editingJobID = -1;
            _editingPurchaseOrderID = -1;
            _editingStoreroomID = -1;
            _editingTakenBy = -1;
            _editingVendorID = -1;
            _editingStoresIssueID = -1;
            _editingReceivedDate = _nullDate;
            _editingInvoiceNum = "";
            _editingNotes = "";
            _editingReceiptID = -1;
            _editingJobStepID = -1;

        }

        private void gridControlParts_Click(object sender, EventArgs e)
        {

        }

        private void storeRoom_EditValueChanged(object sender, EventArgs e)
        {
            ///Add function to set the part boxes to be disable or enabled
            ///
            if(Convert.ToInt32(storeRoom.EditValue) > 0)
            {
                QTYspinEdit.Enabled = true;
                simpleButton1.Enabled = true;
                addPartButton.Enabled = true;
                partIDLookUp.Enabled = true;
            }
            else
            {
                QTYspinEdit.Enabled = false;
                simpleButton1.Enabled = false;
                addPartButton.Enabled = false;
                partIDLookUp.Enabled = false; 
            }
            
        }

        private void storeRoom_TextChanged(object sender, EventArgs e)
        {
            if (storeRoom.Text.Length < 1)
            {
                QTYspinEdit.Enabled = false;
                simpleButton1.Enabled = false;
                addPartButton.Enabled = false;
                partIDLookUp.Enabled = false;
                StoreRoomNameLable.Text = "";
                
            } else
            {
                QTYspinEdit.Enabled = true;
                simpleButton1.Enabled = true;
                addPartButton.Enabled = true;
                partIDLookUp.Enabled = true;
                StoreRoomNameLable.Text = storeRoom.Text;
            }
        }

        private void btnAddPartsFromGrid_Click(object sender, EventArgs e)
        {
            AddSelectedRows(sender);
        }

        private void AddSelectedRows(object sender)
        {
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var results = MessageBox.Show("Are you sure you want to Log out?", "Log out", MessageBoxButtons.YesNo);

            if (results == DialogResult.Yes)
            {
                _oLogon.UserID = -1;
                var login = new LoginForm(ref _oLogon);
                lookUpEdit1.Text = "";
                takenByLookUp.Text = "";
                userNameLabel.Text = "";
                storeRoom.Text = "";


                login.ShowDialog();

                
                userNameLabel.Text = _oLogon.Username;
            
                lookUpEdit1.Text = _oLogon.Username;
                lookUpEdit1.EditValue = _oLogon.UserID;
                takenByLookUp.Text = _oLogon.Username;
                takenByLookUp.EditValue = _oLogon.UserID;

            }
        }
    }
}