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
                reasonLookUp.Visible = false;
                reasonLabel.Visible = false;

            }
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
            var storeroomName = storeRoom.Text;
            //NonSortedList param = new NonSortedList();
            
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection(dbConnection);
            SqlCommand cmd = new SqlCommand();
            SqlParameterCollection param = cmd.Parameters;
            //param.AddWithValue("@StoreroomLock", -1);
            //param.AddWithValue("@StoreroomFilter",  storeroomName);
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
            cmd.CommandText = "SELECT Storerooms.n_storeroomid, Storerooms.storeroomid, Storerooms.descr, PartsAtLocation.qtyonhand, PartsAtLocation.n_masterpartid, Masterparts.n_masterpartid AS Expr1, Masterparts.masterpartid,  Masterparts.Description FROM PartsAtLocation INNER JOIN Masterparts ON PartsAtLocation.n_masterpartid = Masterparts.n_masterpartid INNER JOIN Storerooms ON PartsAtLocation.n_storeroomid = Storerooms.n_storeroomid";
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
            
            partBindingSource.DataSource = ds;
            
            bindPart.DataSource = partBindingSource;
            partIDLookUp.EditValue = bindPart;
            
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
            gridView1.Columns["n_jobstepid"].Visible = false;
            gridView1.Columns["n_jobid"].Visible = false;
            gridView1.Columns["T"].Visible = false;
            gridView1.Columns["A"].Visible = false;
            gridView1.Columns["step"].Visible = false;
            gridView1.Columns["Labor Class"].Visible = false;
            gridView1.Columns["Group"].Visible = false;
            gridView1.Columns["Supervisor"].Visible = false;
            gridView1.Columns["H"].Visible = false;
            gridView1.Columns["I"].Visible = false;
            gridView1.Columns["cReasoncode"].Visible = false;
            gridView1.Columns["AssignedTaskID"].Visible = false;
            gridView1.Columns["ApplyColor"].Visible = false;
            gridView1.Columns["FGColor"].Visible = false;
            gridView1.Columns["BGColor"].Visible = false;
            
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn)
            {
                gridControl1.Visible = true;
                GetJobButton.Visible = true;
                reasonLookUp.Visible = false;
                reasonLabel.Visible = false;

            }

            if(toggleSwitch1.IsOn == false)
            {
                gridControl1.Visible = false;
                GetJobButton.Visible = false;
                reasonLabel.Visible = true;
                reasonLookUp.Visible = true;


            }
        }
    }
}