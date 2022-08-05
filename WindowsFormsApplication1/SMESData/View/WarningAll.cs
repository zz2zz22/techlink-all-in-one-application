using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class WarningAll : Form
    {
        public WarningAll()
        {
            InitializeComponent();
        }
        public static string temp;
        private void WarningAll_Load(object sender, EventArgs e)
        {
            lbDate.Text = Convert.ToDateTime(SaveData.Date).ToString("dd-MM-yyyy");
            lbNGA.Text = SaveData.NGallow + "%";
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            string cmd;
            MessageWaitForm msf = new MessageWaitForm();
            Thread backgroundThreadFetchData = new Thread(
                    new ThreadStart(() =>
                    {
                        for (int i = 0; i < GetSOFTdata.getAllModel().Rows.Count; i++)
                        {
                            temp = GetSOFTdata.getAllModel().Rows[i].ItemArray[0].ToString();
                            DataRow[] results = GetSOFTdata.GetModel(SaveData.Date).Select("model = '" + temp + "'");
                            if (results.Length > 0)
                            {
                                cmd = UploadLogic.Update(temp, SaveData.Date, SaveData.NGallow);
                            }
                            else
                            {
                                cmd = UploadLogic.Insert(temp, SaveData.Date, SaveData.NGallow);
                            }
                            uploadWithTransactionSupport(cmd);
                            msf.UpdateProgress(100 * (i + 1) / GetSOFTdata.getAllModel().Rows.Count, "Data is being updated, please wait ... ");
                            Thread.Sleep(50);
                        }
                        msf.BeginInvoke(new Action(() => msf.Close()));
                    }));
            backgroundThreadFetchData.Start();
            msf.ShowDialog();
            MessageBox.Show("Successfully Update to database!", "Complete!");
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

        private void btClose_Click(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nFail to update %NG allow of all Model to database", "Error");
                trans.Rollback();
            }
        }
    }
}
