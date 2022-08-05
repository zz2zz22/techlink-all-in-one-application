using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AutoScaleMode = AutoScaleMode.None;
            //For check user control already add or not
            ucMQC = false;
            ucPQC = false;
            ucPD = false;
            //Check date time picker change
            SaveData.check = false;
            //Add event for click button line in user control MQC/PQC change to user control Product Data
            uc_MQC_PieChart.OnUpdateStatus += customControl_OnUpdateStatus;
            uc_PQC_PieChart.OnUpdateStatus += customControl_OnUpdateStatus;
            //For sync update after a user control update in every user control
            SaveData.uc_pi = 0;
            SaveData.uc_mqc = 0;
            SaveData.uc_pqc = 0;
            //Show Model Info UC
            btMQCPD_Click(sender, e);
        }

        UC_MQC_PieChart uc_MQC_PieChart = new UC_MQC_PieChart();
        UC_PQC_PieChart uc_PQC_PieChart = new UC_PQC_PieChart();
        UC_Product_Info uc_PI = new UC_Product_Info();
        //For timer tick event in every user control
        public static bool MQC;
        public static bool PQC;
        public static bool PD;
        //Check
        public static bool ucMQC;
        public static bool ucPQC;
        public static bool ucPD;

        public void updateChartPI()
        {
            if (SaveData.uc_pi == -1 && ucPD == true && SaveData.check == false)
            {
                uc_PI.UpdateDTGV();
                SaveData.uc_pi = 0;
            }
        }
        public void updateChartMQC()
        {
            if (SaveData.uc_mqc == -1 && ucMQC == true && SaveData.check == false)
            {
                uc_MQC_PieChart.renderPiechart();
                SaveData.uc_mqc = 0;
            }            
        }
        public void updateChartPQC()
        {
            if (SaveData.uc_pqc == -1 && ucPQC == true && SaveData.check == false)
            {
                uc_PQC_PieChart.renderPiechart();
                SaveData.uc_pqc = 0;
            }
        }
        private void customControl_OnUpdateStatus(object sender, EventArgs e)
        {
            PD = true;
            MQC = false;
            PQC = false;
            btMQC.BackgroundColor = System.Drawing.Color.Black;
            btPQC.BackgroundColor = System.Drawing.Color.Black;
            btMQCPD.BackgroundColor = System.Drawing.Color.SteelBlue;          
            btMQCPD.Focus();
            addUserControl(uc_PI);
            if (SaveData.Date == DateTime.Today.ToString("yyyy-MM-dd"))
                uc_PI.UpdateTime();            
            uc_PI.UpdateDTGVByLine();
            ucPD = true;
        }
        private void addUserControl(UserControl userControl)
        {           
            pnMain.Controls.Clear();
            userControl.Dock = DockStyle.Fill;            
            pnMain.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void btMQC_Click(object sender, EventArgs e)
        {
            MQC = true;
            PQC = false;
            PD = false;
            btMQC.BackgroundColor = System.Drawing.Color.SteelBlue;
            btPQC.BackgroundColor = System.Drawing.Color.Black;
            btMQCPD.BackgroundColor = System.Drawing.Color.Black;
            addUserControl(uc_MQC_PieChart);
            updateChartMQC();
            if (SaveData.Date == DateTime.Today.ToString("yyyy-MM-dd"))
            { 
                uc_MQC_PieChart.UpdateTime();
            }       
            ucMQC = true;
        }

        private void btPQC_Click(object sender, EventArgs e)
        {
            PQC = true;
            MQC = false;
            PD = false;
            btMQC.BackgroundColor = System.Drawing.Color.Black;
            btPQC.BackgroundColor = System.Drawing.Color.SteelBlue;
            btMQCPD.BackgroundColor = System.Drawing.Color.Black;
            addUserControl(uc_PQC_PieChart);
            updateChartPQC();
            if (SaveData.Date == DateTime.Today.ToString("yyyy-MM-dd"))
            {
                uc_PQC_PieChart.UpdateTime();
            }           
            ucPQC = true;
        }

        private void btMQCPD_Click(object sender, EventArgs e)
        {          
            PD = true;
            MQC = false;
            PQC = false;
            btMQC.BackgroundColor = System.Drawing.Color.Black;
            btPQC.BackgroundColor = System.Drawing.Color.Black;
            btMQCPD.BackgroundColor = System.Drawing.Color.SteelBlue;
            addUserControl(uc_PI);
            updateChartPI();
            if (SaveData.Date == DateTime.Today.ToString("yyyy-MM-dd"))
            {
                uc_PI.UpdateTime();
            }    
            ucPD = true;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (uc_PI != null)
                if (e.KeyCode == Keys.Enter)
                    uc_PI.tbSearch_KeyDown(sender, e);
        }

        private void btNornal_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
