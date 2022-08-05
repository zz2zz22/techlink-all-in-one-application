using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UC_Product_Info : UserControl
    {
        public UC_Product_Info()
        {
            InitializeComponent();
        }
        private void UC_Product_Info_Load(object sender, EventArgs e)
        {
            // Date time format
            dtpChart.Value = DateTime.Today;
            dtpChart.CustomFormat = "dd-MM-yyyy";
            dtpChart.Format = DateTimePickerFormat.Custom;
            dtpChart.Enabled = false;
            SaveData.Date = DateTime.Today.ToString("yyyy-MM-dd");
            dtpChart.ValueChanged += new EventHandler(dtpChart_ValueChanged);           
            //Setting
            lblTime.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            //Timer          
            pnTimeControl.Enabled = false;
            wn.OnUpdateStatus += customControl_OnUpdateStatus;
            wnAll.OnUpdateStatus += customControl_OnUpdateStatus;
            //Update datagridview
            SaveData.MQCClick = false;
            SaveData.PQCClick = false;
            SaveData.MQC = true;
            SaveData.PQC = false;
            lbQC.Text = "MQC";
            UpdateDTGV();
            dtgv_MQC_PD.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dtgv_MQC_PD_DataBindingComplete);
            //Update btMQC, btPQC BackgroundColor
            btMQCD.BackgroundColor = Color.FromArgb(40, 96, 144);
            btPQCD.BackgroundColor = Color.DodgerBlue;
        }

        //List data
        List<double> dataMQC = new List<double>();
        List<double> dataPQC = new List<double>();
        Warning wn = new Warning();
        WarningAll wnAll = new WarningAll();
        FormInfo FI = new FormInfo();
        Passwords pw = new Passwords();
        //
        public int secondsToWait = 300;
        private DateTime startTime;
        //       
        

        private void dtgv_MQC_PD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dataMQC.Clear();
                dataPQC.Clear();
                SaveData.Date = dtpChart.Value.ToString("yyyy-MM-dd");
                SaveData.Model = dtgv_MQC_PD.Rows[e.RowIndex].Cells[0].Value.ToString();
                SaveData.line = dtgv_MQC_PD.Rows[e.RowIndex].Cells[2].Value.ToString();
                SaveData.op = double.Parse(dtgv_MQC_PD.Rows[e.RowIndex].Cells[3].Value.ToString());
                SaveData.rw = double.Parse(dtgv_MQC_PD.Rows[e.RowIndex].Cells[4].Value.ToString());
                SaveData.ng = double.Parse(dtgv_MQC_PD.Rows[e.RowIndex].Cells[5].Value.ToString());
                SaveData.total = double.Parse(dtgv_MQC_PD.Rows[e.RowIndex].Cells[6].Value.ToString());
                SaveData.target = double.Parse(dtgv_MQC_PD.Rows[e.RowIndex].Cells[7].Value.ToString());
                SaveData.NGrealtime = double.Parse(dtgv_MQC_PD.Rows[e.RowIndex].Cells[8].Value.ToString());
                SaveData.NGallow = dtgv_MQC_PD.Rows[e.RowIndex].Cells[9].Value.ToString();
                SaveData.RWrealtime = double.Parse(dtgv_MQC_PD.Rows[e.RowIndex].Cells[10].Value.ToString());
                SaveData.RWallow = dtgv_MQC_PD.Rows[e.RowIndex].Cells[11].Value.ToString();
                lbModel.Text = SaveData.Model;
                lbLine.Text = SaveData.line;
                lbOP.Text = SaveData.op.ToString();
                lbRW.Text = SaveData.rw.ToString();
                lbNG.Text = SaveData.ng.ToString();
                lbTt.Text = SaveData.total.ToString();
                lbTarget.Text = SaveData.target.ToString();
                lbNGR.Text = SaveData.NGrealtime.ToString() + "%";
                tbNGA.Text = SaveData.NGallow.ToString() + "%";
                lbRWR.Text = SaveData.RWrealtime.ToString() + "%";
                lbRWA.Text = SaveData.RWallow.ToString() + "%";
                renderPiechart();
            }            
        }
        public void lineData()
        {
            double OP = Math.Round(SaveData.op / SaveData.total * 100, 1);
            double RW = Math.Round(SaveData.rw / SaveData.total * 100, 1);
            double NG = Math.Round(SaveData.ng / SaveData.total * 100, 1);
            dataMQC.Add(OP);
            dataMQC.Add(RW);
            dataMQC.Add(NG);
            dataPQC.Add(OP);
            dataPQC.Add(RW);
            dataPQC.Add(NG);
        }
        public void renderPiechart()
        {
            //Add QC text
            if (SaveData.MQC == true)
                lbQC.Text = "MQC";
            else
                lbQC.Text = "PQC";
            //Add data
            lineData();
            //Binding Data
            linePCanvas1.Visible = false;
            string[] remark = { "OUTPUT", "REWORK", "NO GOOD" };
            List<System.Windows.Media.Color> bgColors = new List<System.Windows.Media.Color>();
            bgColors.Add(System.Windows.Media.Color.FromRgb(30, 144, 255));
            bgColors.Add(System.Windows.Media.Color.FromRgb(255, 140, 0));
            bgColors.Add(System.Windows.Media.Color.FromRgb(255, 0, 0));
            if (SaveData.MQC == true)
            {
                linePCanvas1.Series.Clear();
                for (int i = 0; i < 3; i++)
                {
                    linePCanvas1.Series.Add(new PieSeries
                    {
                        Title = remark[i],
                        Values = new ChartValues<double> { dataMQC[i] },
                        Fill = new System.Windows.Media.SolidColorBrush(bgColors[i])
                    });
                }
            }    
            else
            {
                linePCanvas1.Series.Clear();
                for (int i = 0; i < 3; i++)
                {
                    linePCanvas1.Series.Add(new PieSeries
                    {
                        Title = remark[i],
                        Values = new ChartValues<double> { dataPQC[i] },
                        Fill = new System.Windows.Media.SolidColorBrush(bgColors[i])
                    });
                }
            }
            linePCanvas1.Visible = true;
            //Add legends MQC           
            if (dataMQC[0] == 0 && dataMQC[1] == 0 && dataMQC[2] == 0 || GetSOFTdata.GetListMQC(dtpChart.Value.ToString("yyyy-MM-dd"), "") == null && SaveData.MQC == true || GetSOFTdata.GetListPQC(dtpChart.Value.ToString("yyyy-MM-dd"), "") == null && SaveData.PQC == true || dtgv_MQC_PD.Rows.Count <= 0)
            {
                lbOP1.Visible = false;
                lbRW1.Visible = false;
                lbNG1.Visible = false;
                lbMdl.Visible = false;
                lbModel.Visible = false;
                linePCanvas1.Visible = false;
                lbWar1.Visible = true;
                lbWar1.Text = "No Data";
                lbWar1.Font = new Font("Times New Roman", 72, FontStyle.Bold);
                lbOP.Text = "";
                lbRW.Text = "";
                lbNG.Text = "";
                lbTt.Text = "";
                lbLine.Text = "";
                lbNGR.Text = "";
                tbNGA.Text = "";
            }
            else
            {
                lbWar1.Visible = false;
                lbOP1.Visible = true;
                lbRW1.Visible = true;
                lbNG1.Visible = true;
                lbMdl.Visible = true;
                lbModel.Visible = true;
                linePCanvas1.Visible = true;
                lbOP1.BackColor = Color.DodgerBlue;
                lbRW1.BackColor = Color.Orange;
                lbNG1.BackColor = Color.Red;
                lbOP1.Text = "OUTPUT: " + dataMQC[0].ToString() + "%";
                lbRW1.Text = "REWORK: " + dataMQC[1].ToString() + "%";
                lbNG1.Text = "NO GOOD: " + dataMQC[2].ToString() + "%";
                lbOP1.Font = new Font("Times New Roman", 13, FontStyle.Bold);
                lbRW1.Font = new Font("Times New Roman", 13, FontStyle.Bold);
                lbNG1.Font = new Font("Times New Roman", 13, FontStyle.Bold);      
            }            
        }
        public void UpdateDTGV()
        {           
            string date = dtpChart.Value.ToString("yyyy-MM-dd");
            SaveData.line = "";
            string line = SaveData.line;
            if (GetSOFTdata.GetListMQC(date, line) != null && SaveData.MQC == true || GetSOFTdata.GetListPQC(date, line) != null && SaveData.PQC == true)
            {              
                if (SaveData.MQC == true)
                {                    
                    dataMQC.Clear();
                    dtgv_MQC_PD.DataSource = GetSOFTdata.GetListMQC(date, line);
                    dtpChart.Visible = true;
                }  
                else
                {                  
                    dataPQC.Clear();
                    dtgv_MQC_PD.DataSource = GetSOFTdata.GetListPQC(date, line);
                    dtpChart.Visible = true;
                }             
            }
        }
        public void UpdateDTGVByLine()
        {           
            dtpChart.Value = Convert.ToDateTime(SaveData.Date);
            string date = SaveData.Date;
            string line = SaveData.line;
            if (GetSOFTdata.GetListMQC(date, line) != null && SaveData.MQC == true || GetSOFTdata.GetListPQC(date, line) != null && SaveData.PQC == true)
            {                
                if (SaveData.MQC == true)
                {
                    dataMQC.Clear();
                    dtgv_MQC_PD.DataSource = GetSOFTdata.GetListMQC(date, line);
                }    
                else
                {
                    dataPQC.Clear();
                    dtgv_MQC_PD.DataSource = GetSOFTdata.GetListPQC(date, line);
                }
            }
            if (SaveData.Date != DateTime.Today.ToString("yyyy-MM-dd"))
            {
                btStart.Enabled = true;
                btStart.BackgroundColor = Color.DodgerBlue;
                btStop.Enabled = false;
                btStop.BackgroundColor = Color.Gainsboro;
                dtpChart.Enabled = true;
                pnTimeControl.Enabled = true;
                lblTime.Text = "Auto update" + "\r\n" + "data is stopping";
                SaveData.MQCClick = false;
                SaveData.PQCClick = false;
            }    
        }
        public void ChangeColor()
        {                       
            if ((GetSOFTdata.GetListMQC(dtpChart.Value.ToString("yyyy-MM-dd"), "") != null && SaveData.MQC == true || GetSOFTdata.GetListPQC(dtpChart.Value.ToString("yyyy-MM-dd"), "") != null && SaveData.PQC == true) && dtgv_MQC_PD.Rows.Count > 0)
            {
                MessageWaitForm msf = new MessageWaitForm();
                Thread backgroundThreadFetchData = new Thread(
                        new ThreadStart(() =>
                        { 
                            for (int i = 0; i < dtgv_MQC_PD.Rows.Count; i++)
                            {
                                if (double.Parse(dtgv_MQC_PD.Rows[i].Cells[8].Value.ToString()) > double.Parse(dtgv_MQC_PD.Rows[i].Cells[9].Value.ToString()) && double.Parse(dtgv_MQC_PD.Rows[i].Cells[10].Value.ToString()) > double.Parse(dtgv_MQC_PD.Rows[i].Cells[11].Value.ToString()))
                                {
                                    for (int j = 0; j < dtgv_MQC_PD.Columns.Count; j++)
                                    {
                                        dtgv_MQC_PD[j, i].Style.BackColor = Color.DarkViolet;
                                        dtgv_MQC_PD[j, i].Style.ForeColor = Color.Yellow;
                                        dtgv_MQC_PD[j, i].Style.SelectionBackColor = Color.FromArgb(102, 51, 153);
                                    }
                                }
                                else if (double.Parse(dtgv_MQC_PD.Rows[i].Cells[8].Value.ToString()) > double.Parse(dtgv_MQC_PD.Rows[i].Cells[9].Value.ToString()))
                                {
                                    for (int j = 0; j < dtgv_MQC_PD.Columns.Count; j++)
                                    {
                                        dtgv_MQC_PD[j, i].Style.BackColor = Color.Red;
                                        dtgv_MQC_PD[j, i].Style.ForeColor = Color.White;
                                        dtgv_MQC_PD[j, i].Style.SelectionBackColor = Color.FromArgb(220, 20, 60);
                                    }
                                }
                                else if (double.Parse(dtgv_MQC_PD.Rows[i].Cells[10].Value.ToString()) > double.Parse(dtgv_MQC_PD.Rows[i].Cells[11].Value.ToString()))
                                {
                                    for (int j = 0; j < dtgv_MQC_PD.Columns.Count; j++)
                                    {
                                        dtgv_MQC_PD[j, i].Style.BackColor = Color.Yellow;
                                        dtgv_MQC_PD[j, i].Style.ForeColor = Color.Black;
                                        dtgv_MQC_PD[j, i].Style.SelectionBackColor = Color.FromArgb(255, 165, 0);
                                    }
                                }     
                                else
                                {
                                    for (int j = 0; j < dtgv_MQC_PD.Columns.Count; j++)
                                    {
                                        dtgv_MQC_PD[j, i].Style.BackColor = Color.FromArgb(248, 251, 255);
                                        dtgv_MQC_PD[j, i].Style.ForeColor = Color.Black;
                                        dtgv_MQC_PD[j, i].Style.SelectionBackColor = Color.FromArgb(221, 238, 255);
                                    }
                                }
                                msf.UpdateProgress(100 * (i + 1) / dtgv_MQC_PD.Rows.Count, "Application is running, please wait ... ");
                                Thread.Sleep(50);
                            }
                            msf.BeginInvoke(new Action(() => msf.Close()));
                        }));
                backgroundThreadFetchData.Start();
                msf.ShowDialog();
            }
        }
        public void ChangeData()
        {
            if ((GetSOFTdata.GetListMQC(dtpChart.Value.ToString("yyyy-MM-dd"), "") != null && SaveData.MQC == true || GetSOFTdata.GetListPQC(dtpChart.Value.ToString("yyyy-MM-dd"), "") != null && SaveData.PQC == true) && dtgv_MQC_PD.Rows.Count > 0)
            {
                dataMQC.Clear();
                dataPQC.Clear();
                SaveData.Date = dtpChart.Value.ToString("yyyy-MM-dd");
                SaveData.Model = dtgv_MQC_PD.Rows[0].Cells[0].Value.ToString();
                SaveData.line = dtgv_MQC_PD.Rows[0].Cells[2].Value.ToString();
                SaveData.op = double.Parse(dtgv_MQC_PD.Rows[0].Cells[3].Value.ToString());
                SaveData.rw = double.Parse(dtgv_MQC_PD.Rows[0].Cells[4].Value.ToString());
                SaveData.ng = double.Parse(dtgv_MQC_PD.Rows[0].Cells[5].Value.ToString());
                SaveData.total = double.Parse(dtgv_MQC_PD.Rows[0].Cells[6].Value.ToString());
                SaveData.target = double.Parse(dtgv_MQC_PD.Rows[0].Cells[7].Value.ToString());
                SaveData.NGrealtime = double.Parse(dtgv_MQC_PD.Rows[0].Cells[8].Value.ToString());
                SaveData.NGallow = dtgv_MQC_PD.Rows[0].Cells[9].Value.ToString();
                SaveData.RWrealtime = double.Parse(dtgv_MQC_PD.Rows[0].Cells[10].Value.ToString());
                SaveData.RWallow = dtgv_MQC_PD.Rows[0].Cells[11].Value.ToString();
                lbModel.Text = SaveData.Model;
                lbLine.Text = SaveData.line;
                lbOP.Text = SaveData.op.ToString();
                lbRW.Text = SaveData.rw.ToString();
                lbNG.Text = SaveData.ng.ToString();
                lbTt.Text = SaveData.total.ToString();
                lbTarget.Text = SaveData.target.ToString();
                lbNGR.Text = SaveData.NGrealtime.ToString() + "%";
                tbNGA.Text = SaveData.NGallow.ToString() + "%";
                lbRWR.Text = SaveData.RWrealtime.ToString() + "%";
                lbRWA.Text = SaveData.RWallow.ToString() + "%";
            }
            renderPiechart();
        }
        private void dtpChart_ValueChanged(object sender, EventArgs e)
        {
            if (SaveData.MQCClick == false && SaveData.PQCClick == false)
            {
                SaveData.check = true;
                dtpChart.Visible = false;
                UpdateDTGV();
            }  
        }
        public void UpdateTime()
        {
            if (GetSOFTdata.GetListMQC(dtpChart.Value.ToString("yyyy-MM-dd"), "") != null && SaveData.MQC == true || GetSOFTdata.GetListPQC(dtpChart.Value.ToString("yyyy-MM-dd"), "") != null && SaveData.PQC == true)
            {
                dtpChart.Value = DateTime.Today;
                btStart.Enabled = false;
                btStart.BackgroundColor = Color.Gainsboro;
                btStop.Enabled = true;
                btStop.BackgroundColor = Color.Orange;
                dtpChart.Enabled = false;
                pnTimeControl.Enabled = false;
                timer1.Start();
                startTime = DateTime.Now;
                SaveData.MQCClick = false;
                SaveData.PQCClick = false;
                SaveData.Date = dtpChart.Value.ToString("yyyy-MM-dd");
                SaveData.check = false;
            }
        }
        public void ChangeUpdateTime()
        {
            int h = Int32.Parse(nbH.Value.ToString());
            int m = Int32.Parse(nbM.Value.ToString());
            int s = Int32.Parse(nbS.Value.ToString());
            if (h == 0 && m == 0 && s == 0)
                secondsToWait = 300;
            else
                secondsToWait = h * 3600 + m * 60 + s;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MainForm.PD == true)
            {
                int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
                int remainingSeconds = secondsToWait - elapsedSeconds;
                TimeSpan ts = TimeSpan.FromSeconds(remainingSeconds);
                string time = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                ts.Hours,
                                ts.Minutes,
                                ts.Seconds);
                lblTime.Text = "Data update in: " + "\r\n" + time.ToString();
                if (remainingSeconds < 0)
                {
                    lblTime.Text = "Data is being" + "\r\n" + "updated";
                    timer1.Stop();
                    SaveData.uc_pi = 0;
                    SaveData.uc_mqc = -1;
                    SaveData.uc_pqc = -1;
                    UpdateDTGV();                   
                    UpdateTime();                    
                }
            }
            else
                timer1.Stop();
        }
        private void btStart_Click(object sender, EventArgs e)
        {
            UpdateTime();
        }
        private void btStop_Click(object sender, EventArgs e)
        {
            btStart.Enabled = true;
            btStart.BackgroundColor = Color.DodgerBlue;
            btStop.Enabled = false;
            btStop.BackgroundColor = Color.Gainsboro;
            dtpChart.Enabled = true;
            pnTimeControl.Enabled = true;
            timer1.Stop();
            lblTime.Text = "Auto update" + "\r\n" + "data is stopping";
        }

        private void nbH_ValueChanged(object sender, EventArgs e)
        {
            ChangeUpdateTime();
        }

        private void nbM_ValueChanged(object sender, EventArgs e)
        {
            ChangeUpdateTime();
        }

        private void nbS_ValueChanged(object sender, EventArgs e)
        {
            ChangeUpdateTime();
        }

        
        private void search_Click(object sender, EventArgs e)
        {
            string model = tbSearch.Text.Trim();
            string line;
            string date = dtpChart.Value.ToString("yyyy-MM-dd");
            if (SaveData.MQCClick == true || SaveData.PQCClick == true)
            {
                line = SaveData.line;
            }
            else
                line = "";
            if (SaveData.MQC == true)
            {
                DataRow[] results = GetSOFTdata.GetListMQC(date, line).Select("Model like '%" + model + "%'");               
                if (results.Length > 0)
                {
                    DataTable searchResultTable = results.CopyToDataTable();
                    dataMQC.Clear();
                    dtgv_MQC_PD.DataSource = searchResultTable;
                }
                else
                {
                    MessageBox.Show("No result!");
                }
            }
            else
            {
                DataRow[] results = GetSOFTdata.GetListPQC(date, line).Select("Model like '%" + model + "%'");
                if (results.Length > 0)
                {
                    DataTable searchResultTable = results.CopyToDataTable();
                    dataPQC.Clear();
                    dtgv_MQC_PD.DataSource = searchResultTable;
                }
                else
                {
                    MessageBox.Show("No result!");
                }
            }
        }

        private void btMQCD_Click(object sender, EventArgs e)
        {
            btPQCD.BackgroundColor = Color.DodgerBlue;
            btMQCD.BackgroundColor = Color.FromArgb(40, 96, 144);
            SaveData.MQCClick = false;
            SaveData.PQCClick = false;
            SaveData.MQC = true;
            SaveData.PQC = false;
            UpdateDTGV();
        }
        private void btPQCD_Click(object sender, EventArgs e)
        {
            btMQCD.BackgroundColor = Color.DodgerBlue;
            btPQCD.BackgroundColor = Color.FromArgb(40, 96, 144);
            SaveData.MQCClick = false;
            SaveData.PQCClick = false;
            SaveData.MQC = false;
            SaveData.PQC = true;
            UpdateDTGV();
        }

        private void btFix_Click(object sender, EventArgs e)
        {
            SaveData.checkpass = false;
            pw.ShowDialog();
            if (SaveData.checkpass == true)
            {
                if (tbNGA.Text != null && tbNGA.Text != "" && lbModel.Text != null && lbModel.Text != "" && lbModel.Text != "..")
                {
                    SaveData.NGallow = tbNGA.Text.Replace("%", "").Trim();
                    wn.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No Data");
                }
            }
        }

        private void btFixAll_Click(object sender, EventArgs e)
        {
            SaveData.checkpass = false;
            pw.ShowDialog();
            if (SaveData.checkpass == true)
            {
                if (tbNGA.Text != null && tbNGA.Text != "")
                {
                    SaveData.NGallow = tbNGA.Text.Replace("%", "").Trim();
                    wnAll.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please enter %NG Allow");
                }
            }
        }

        public void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string model = tbSearch.Text.Trim();
                string line;
                string date = dtpChart.Value.ToString("yyyy-MM-dd");
                if (SaveData.MQCClick == true || SaveData.PQCClick == true)
                {
                    line = SaveData.line;
                }
                else
                    line = "";
                if (SaveData.MQC == true)
                {
                    DataRow[] results = GetSOFTdata.GetListMQC(date, line).Select("Model like '%" + model + "%'");
                    if (results.Length > 0)
                    {
                        DataTable searchResultTable = results.CopyToDataTable();
                        dataMQC.Clear();
                        dtgv_MQC_PD.DataSource = searchResultTable;
                    }
                    else
                    {
                        MessageBox.Show("No result!");
                    }
                }
                else
                {
                    DataRow[] results = GetSOFTdata.GetListPQC(date, line).Select("Model like '%" + model + "%'");
                    if (results.Length > 0)
                    {
                        DataTable searchResultTable = results.CopyToDataTable();
                        dataPQC.Clear();
                        dtgv_MQC_PD.DataSource = searchResultTable;
                    }
                    else
                    {
                        MessageBox.Show("No result!");
                    }
                }
            }    
        }
        private void customControl_OnUpdateStatus(object sender, EventArgs e)
        {
            UpdateDTGV();
        }

        private void btSI_Click(object sender, EventArgs e)
        {            
            FI.ShowDialog();
        }
        public void dtgvSetting()
        {
            dtgv_MQC_PD.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14.5F, FontStyle.Bold);
            dtgv_MQC_PD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv_MQC_PD.Columns["NG_rate_allow"].Visible = false;
            dtgv_MQC_PD.Columns["RW_rate_allow"].Visible = false;
            if (SaveData.PQC == true)
            {
                dtgv_MQC_PD.Columns["Target"].HeaderText = "TARGET";
                dtgv_MQC_PD.Columns["Target"].Visible = true;
                dtgv_MQC_PD.Columns["Target"].FillWeight = 2;
            }
            if(SaveData.MQC == true)
            {
                dtgv_MQC_PD.Columns["DailyTarget"].HeaderText = "DAILY TARGET";
                dtgv_MQC_PD.Columns["DailyTarget"].FillWeight = 2;
                dtgv_MQC_PD.Columns["Target"].Visible = false;
            }
            dtgv_MQC_PD.Columns["NG_rate_realtime"].HeaderText = "NG_realtime(%)";
            dtgv_MQC_PD.Columns["RW_rate_realtime"].HeaderText = "RW_realtime(%)";
            dtgv_MQC_PD.Columns["Model"].HeaderText = "MODEL";
            dtgv_MQC_PD.Columns["Date"].HeaderText = "DATE";
            dtgv_MQC_PD.Columns["Line"].HeaderText = "LINE";
            dtgv_MQC_PD.Columns["Total"].HeaderText = "TOTAL";            
            dtgv_MQC_PD.Columns["Model"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgv_MQC_PD.Columns["Model"].FillWeight = 3;
            dtgv_MQC_PD.Columns["Date"].FillWeight = 2;
            dtgv_MQC_PD.Columns["Line"].FillWeight = 1;
            dtgv_MQC_PD.Columns["OUTPUT"].FillWeight = 2;
            dtgv_MQC_PD.Columns["REWORK"].FillWeight = 2;
            dtgv_MQC_PD.Columns["NOGOOD"].FillWeight = 2;
            dtgv_MQC_PD.Columns["Total"].FillWeight = 1;
            dtgv_MQC_PD.Columns["NG_rate_realtime"].FillWeight = 2;
            dtgv_MQC_PD.Columns["RW_rate_realtime"].FillWeight = 2;
        }
        private void dtgv_MQC_PD_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgvSetting();
            ChangeColor();
            ChangeData();      
        }
    }
}
