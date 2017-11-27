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
    public enum CheckOutType
    {
        /// <summary>
        /// 
        /// </summary>
        All,
        /// <summary>
        /// 
        /// </summary>
        CheckOutForJob,
        /// <summary>
        /// 
        /// </summary>
        CheckOutForOther,
        /// <summary>
        /// 
        /// </summary>
        CheckOutForStoresIssue
    };




    public partial class CheckOutForm : DevExpress.XtraEditors.XtraForm
    {
        public PersonnelLogonObjectClass _oLogon = new PersonnelLogonObjectClass();   
        private readonly CheckOutType _checkOutType;
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

        public object onClick { get; private set; }

        public CheckOutForm()
        {
            //ShowSplashScreen();
            //dateEdit.DateTime = DateTime.Now;
            
            _oCheckOut = new DbCheckOut(dbConnection, false);
            InitializeComponent();
            if ( _oLogon.UserID < 1)
            {
               
                LoginForm logonForm = new LoginForm();
                logonForm.FormClosed += new FormClosedEventHandler(LoginFormClosing);
                logonForm.Show();
                
                this.SendToBack();
                logonForm.BringToFront();
                logonForm.Focus();
                              
            }
            if( _oLogon.UserID > 0)
            {
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
            param.AddWithValue("@StoreroomFilter",  storeroomName);
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
            cmd.CommandText = "SELECT Storerooms.n_storeroomid, Storerooms.storeroomid, Storerooms.descr, PartsAtLocation.qtyonhand, PartsAtLocation.n_masterpartid, Masterparts.n_masterpartid AS Expr1, Masterparts.masterpartid,  Masterparts.Description FROM PartsAtLocation INNER JOIN Masterparts ON PartsAtLocation.n_masterpartid = Masterparts.n_masterpartid INNER JOIN Storerooms ON PartsAtLocation.n_storeroomid = Storerooms.n_storeroomid WHERE storeroomid = @StoreroomFilter";
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


            
            
                if(ds.Tables.Count > 0)
                {
                    if(ds.Tables[0].Rows.Count > 0)
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

        private void employeesLabelControl_Click(object sender, EventArgs e)
        {

        }

        private void GetJobButton_Click(object sender, EventArgs e)
        {
            BindingSource bindingOpenJobsSource = new BindingSource();
            bindOpenJobs.DataSource = _oCheckOut.GetAllJobsList(ref loadOK, _nullDate);
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

            if(toggleSwitch1.IsOn == false)
            {
                gridControl1.Visible = false;
                GetJobButton.Visible = false;
                JobIDLabel.Visible = false;
                JobIDTextEdit.Visible = false;
                reasonLabel.Visible = true;
                reasonLookUp.Visible = true;


            }
        }

        private void gridViewPartsList_click(object sender, EventArgs e)
        {

        }

        private void addPartButton_Click(object sender, EventArgs e)
        {
            if(storeRoom.Text != "" || storeroomLookUp.Text != "")
            {
                var storeroomName = "";
                if(storeroomLookUp.Visible == true && storeroomLookUp.Text != "")
                {
                    storeroomName = storeroomLookUp.Text;
                }
                if(storeRoom.Text != "")
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
            cmd.CommandText = "SELECT Storerooms.n_storeroomid, Storerooms.storeroomid, Storerooms.descr, PartsAtLocation.qtyonhand, PartsAtLocation.n_masterpartid, Masterparts.n_masterpartid AS Expr1, Masterparts.masterpartid,  Masterparts.Description FROM PartsAtLocation INNER JOIN Masterparts ON PartsAtLocation.n_masterpartid = Masterparts.n_masterpartid INNER JOIN Storerooms ON PartsAtLocation.n_storeroomid = Storerooms.n_storeroomid WHERE storeroomid = @StoreroomFilter";
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
            int qty = Convert.ToInt32(QTYspinEdit.Value);

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            if (gridViewPartsAdded.DataSource == null)
            {
                dt.Columns.Add(new DataColumn("masterpartid"));
                dt.Columns.Add(new DataColumn("QTY"));

                DataRow row = dt.NewRow();
                row["masterpartid"] = partID;
                row["QTY"] = qty;
                dt.Rows.Add(row);
                ds.Tables.Add(dt);

                gridControlPartsAdded.DataSource = ds.Tables[0];

            } else
            {
                gridViewPartsAdded.AddNewRow();
            
                int rowHandle = gridViewPartsAdded.GetRowHandle(gridViewPartsAdded.DataRowCount);

                if (gridViewPartsAdded.IsNewItemRow(rowHandle))
                {
                    gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["masterpartid"], partID);
                    gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["QTY"], qty);
                }           

            }

        }

        private void gridControlParts_MouseClick(object sender, MouseEventArgs e)
        {
            if(MouseButtons.Right == e.Button)
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
            if(MouseButtons.Right == e.Button)
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
            if(MouseButtons.Right == e.Button)
            {
            ContextMenuStrip m = new ContextMenuStrip();
            m.Items.Add("Select Job");
            m.Show(gridControl1, new Point(e.X, e.Y));
            m.ItemClicked += M_ItemClickedJob;
            }
        }

        private void M_ItemClickedJob(object sender, ToolStripItemClickedEventArgs e)
        {
            var result = GetSelectedRows(gridViewJobs, "n_jobid");
            JobIDTextEdit.Text = result[0].ToString();
        }

        private void M_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var selectedRows = GetSelectedRows(gridViewPartsAdded, "masterpartid");
            var count = 0;
            foreach(var rows in selectedRows)
            {
                gridViewPartsAdded.DeleteRow(count);
                count++;
            }
     }

        private object[] GetSelectedRows(DevExpress.XtraGrid.Views.Grid.GridView view, string fieldName)
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

        void AddSelectedRows_ItemClicked( object sender, ToolStripItemClickedEventArgs  e)
        {
            ToolStripItem item = e.ClickedItem;
            var selectedrows = GetSelectedRows(gridViewParts, "masterpartid");

            if (selectedrows.Count() > 0)
            {
                var partID = "";
                var qty = 0;
                var count = 0;

                foreach (var rows in selectedrows)
                {                                    
                    partID = selectedrows.GetValue(count).ToString();
                  
                    gridViewPartsAdded.AddNewRow();
                    int rowHandle = gridViewPartsAdded.GetRowHandle(gridViewPartsAdded.DataRowCount);

                    if (gridViewPartsAdded.IsNewItemRow(rowHandle))
                    {
                        gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["masterpartid"], partID);
                        gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["QTY"], qty);

                    } else
                    {
                        rowHandle = rowHandle + 1;
                        if (gridViewPartsAdded.IsNewItemRow(rowHandle))
                        {
                            gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["masterpartid"], partID);
                            gridViewPartsAdded.SetRowCellValue(rowHandle, gridViewPartsAdded.Columns["QTY"], qty);
                        }
                    }
                    count++;
                }
            }
        }


        private void storeroomLookUpEnter(object sender, EventArgs e)
        {
            BindingSource storeRoomBindingSource = new BindingSource();
            storeRoomBindingSource.DataSource = _oCheckOut.GetAllStorerooms(ref loadOK);
            bindStoreroom.DataSource = storeRoomBindingSource;
            storeroomLookUp.EditValue = bindStoreroom;
            
        }
    }
}