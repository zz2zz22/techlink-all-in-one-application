using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Warning : Form
    {
        public Warning()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Warning_Load(object sender, EventArgs e)
        {
            lbModel.Text = SaveData.Model;
            lbDate.Text = Convert.ToDateTime(SaveData.Date).ToString("dd-MM-yyyy");
            lbNGA.Text = SaveData.NGallow + "%";
        }
        private void btOK_Click(object sender, EventArgs e)
        {
            string cmd;
            DataRow[] results = GetSOFTdata.GetModel(SaveData.Date).Select("model = '" + SaveData.Model + "'");
            if (results.Length > 0)
            {
                cmd = UploadLogic.Update(SaveData.Model, SaveData.Date, SaveData.NGallow);
            }
            else
            {
                cmd = UploadLogic.Insert(SaveData.Model, SaveData.Date, SaveData.NGallow);
            }
            uploadWithTransactionSupport(cmd);
            Close();
            UpdateStatus();
        }
        public delegate void StatusUpdateHandler(object sender, EventArgs e);
        public event StatusUpdateHandler OnUpdateStatus;

        private void UpdateStatus()
        {
            EventArgs args = new EventArgs();

            //Call any listeners
            OnUpdateStatus?.Invoke(this, args);

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        static void uploadWithTransactionSupport(string cmd)
        {

            SqlConnection conn = DatabaseUtils.GetSoftDBConnection();
            SqlTransaction trans = null;
            SqlCommand cmdMS = new SqlCommand();
            try
            {
                conn.Open();                
                trans = conn.BeginTransaction();
                cmdMS.Transaction = trans;                
                cmdMS.Connection = conn;
                //Insert and update Mes_planning_excution commands execute
                cmdMS.CommandText = cmd;
                cmdMS.ExecuteNonQuery();
                trans.Commit();
                MessageBox.Show("Successfully Update to database!", "Complete!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nFail to add and update data", "Error");
                trans.Rollback();
            }

        }

    }
}
