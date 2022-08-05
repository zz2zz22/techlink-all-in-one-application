using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication1.ChartDrawing;

namespace WindowsFormsApplication1
{
    public partial class UC_MQC_PieChart : UserControl
    {
        public UC_MQC_PieChart()
        {
            InitializeComponent();
        }

        private void UC_MQC_PieChart_Load(object sender, EventArgs e)
        {
            // Date time format
            dtpChart.Value = DateTime.Today;
            dtpChart.CustomFormat = "dd-MM-yyyy";
            dtpChart.Format = DateTimePickerFormat.Custom;
            dtpChart.Enabled = false;
            dtpChart.ValueChanged += new EventHandler(dtpChart_ValueChanged);
            renderPiechart();
            //
            lblTime.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            //Timer          
            timer1.Start();
            startTime = DateTime.Now;
            btStart.Enabled = false;
            btStart.BackgroundColor = Color.Gainsboro;
            pnTimeControl.Enabled = false;
        }

        //List data
        List<double> dataL01 = new List<double>();
        List<double> dataL02 = new List<double>();
        List<double> dataL03 = new List<double>();
        List<double> dataL04 = new List<double>();
        List<double> dataL05 = new List<double>();
        List<double> dataL06 = new List<double>();
        List<double> dataL07 = new List<double>();
        //
        public int secondsToWait = 300;
        private DateTime startTime;

        public void lineData()
        {
            string date = dtpChart.Value.ToString("yyyy-MM-dd");
            string [] remark = { "OP", "RW", "NG" };
            double d;
            double temp;
            MessageWaitForm msf = new MessageWaitForm();
            Thread backgroundThreadFetchData = new Thread(
                    new ThreadStart(() =>
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            //L01
                            temp = GetSOFTdata.getTotalRemark("L01", remark[i], date);
                            if (temp == 0 || temp is double.NaN)
                                d = 0;
                            else
                                d = Math.Round(temp / GetSOFTdata.getTotalMQC("L01", date) * 100, 2);
                            dataL01.Add(d);

                            //L02
                            temp = GetSOFTdata.getTotalRemark("L02", remark[i], date);
                            if (temp == 0 || temp is double.NaN)
                                d = 0;
                            else
                                d = Math.Round(temp / GetSOFTdata.getTotalMQC("L02", date) * 100, 2);
                            dataL02.Add(d);

                            //L03
                            temp = GetSOFTdata.getTotalRemark("L03", remark[i], date);
                            if (temp == 0 || temp is double.NaN)
                                d = 0;
                            else
                                d = Math.Round(temp / GetSOFTdata.getTotalMQC("L03", date) * 100, 2);
                            dataL03.Add(d);

                            //L04
                            temp = GetSOFTdata.getTotalRemark("L04", remark[i], date);
                            if (temp == 0 || temp is double.NaN)
                                d = 0;
                            else
                                d = Math.Round(temp / GetSOFTdata.getTotalMQC("L04", date) * 100, 2);
                            dataL04.Add(d);

                            //L05
                            temp = GetSOFTdata.getTotalRemark("L05", remark[i], date);
                            if (temp == 0 || temp is double.NaN)
                                d = 0;
                            else
                                d = Math.Round(temp / GetSOFTdata.getTotalMQC("L05", date) * 100, 2);
                            dataL05.Add(d);

                            //L06
                            temp = GetSOFTdata.getTotalRemark("L06", remark[i], date);
                            if (temp == 0 || temp is double.NaN)
                                d = 0;
                            else
                                d = Math.Round(temp / GetSOFTdata.getTotalMQC("L06", date) * 100, 2);
                            dataL06.Add(d);

                            //L07
                            temp = GetSOFTdata.getTotalRemark("L07", remark[i], date);
                            if (temp == 0 || temp is double.NaN)
                                d = 0;
                            else
                                d = Math.Round(temp / GetSOFTdata.getTotalMQC("L07", date) * 100, 2);
                            dataL07.Add(d);    
                            msf.UpdateProgress(100 * (i + 1) / 3, "Application is running, please wait ... ");
                            Thread.Sleep(50);
                        }
                        msf.BeginInvoke(new Action(() => msf.Close()));
                    }
                ));
            backgroundThreadFetchData.Start();
            msf.ShowDialog();
        }
        public void createPieChart()
        {
            //Change visible false
            L01Chart.Visible = false;
            L02Chart.Visible = false;
            L03Chart.Visible = false;
            L04Chart.Visible = false;
            L05Chart.Visible = false;
            L06Chart.Visible = false;
            L07Chart.Visible = false;
            //Binding Data
            string[] remark = { "OUTPUT", "REWORK", "NO GOOD" };
            List<System.Windows.Media.Color> bgColors = new List<System.Windows.Media.Color>();
            bgColors.Add(System.Windows.Media.Color.FromRgb(30, 144, 255));
            bgColors.Add(System.Windows.Media.Color.FromRgb(255, 140, 0));
            bgColors.Add(System.Windows.Media.Color.FromRgb(255, 0, 0));
            //L01
            for (int i = 0; i < 3; i++)
            {
                L01Chart.Series.Add(new PieSeries
                {
                    Title = remark[i],
                    Values = new ChartValues<double> { dataL01[i] },
                    Fill = new System.Windows.Media.SolidColorBrush(bgColors[i])
                });
            }
            //L02
            for (int i = 0; i < 3; i++)
            {
                L02Chart.Series.Add(new PieSeries
                {
                    Title = remark[i],
                    Values = new ChartValues<double> { dataL02[i] },
                    Fill = new System.Windows.Media.SolidColorBrush(bgColors[i])
                });
            }
            //L03
            for (int i = 0; i < 3; i++)
            {
                L03Chart.Series.Add(new PieSeries
                {
                    Title = remark[i],
                    Values = new ChartValues<double> { dataL03[i] },
                    Fill = new System.Windows.Media.SolidColorBrush(bgColors[i])
                });
            }
            //L04
            for (int i = 0; i < 3; i++)
            {
                L04Chart.Series.Add(new PieSeries
                {
                    Title = remark[i],
                    Values = new ChartValues<double> { dataL04[i] },
                    Fill = new System.Windows.Media.SolidColorBrush(bgColors[i])
                });
            }
            //L05
            for (int i = 0; i < 3; i++)
            {
                L05Chart.Series.Add(new PieSeries
                {
                    Title = remark[i],
                    Values = new ChartValues<double> { dataL05[i] },
                    Fill = new System.Windows.Media.SolidColorBrush(bgColors[i])
                });
            }
            //L06
            for (int i = 0; i < 3; i++)
            {
                L06Chart.Series.Add(new PieSeries
                {
                    Title = remark[i],
                    Values = new ChartValues<double> { dataL06[i] },
                    Fill = new System.Windows.Media.SolidColorBrush(bgColors[i])
                });
            }
            //L07
            for (int i = 0; i < 3; i++)
            {
                L07Chart.Series.Add(new PieSeries
                {
                    Title = remark[i],
                    Values = new ChartValues<double> { dataL07[i] },
                    Fill = new System.Windows.Media.SolidColorBrush(bgColors[i])
                });
            }
            //Hide Legend
            L01Chart.LegendLocation = LegendLocation.None;
            L02Chart.LegendLocation = LegendLocation.None;
            L03Chart.LegendLocation = LegendLocation.None;
            L04Chart.LegendLocation = LegendLocation.None;
            L05Chart.LegendLocation = LegendLocation.None;
            L06Chart.LegendLocation = LegendLocation.None;
            L07Chart.LegendLocation = LegendLocation.None;
            ///Change visible true
            L01Chart.Visible = true;
            L02Chart.Visible = true;
            L03Chart.Visible = true;
            L04Chart.Visible = true;
            L05Chart.Visible = true;
            L06Chart.Visible = true;
            L07Chart.Visible = true;
        }
        public void clearData()
        {
            dataL01.Clear();
            dataL02.Clear();
            dataL03.Clear();
            dataL04.Clear();
            dataL05.Clear();
            dataL06.Clear();
            dataL07.Clear();
            L01Chart.Series.Clear();
            L02Chart.Series.Clear();
            L03Chart.Series.Clear();
            L04Chart.Series.Clear();
            L05Chart.Series.Clear();
            L06Chart.Series.Clear();
            L07Chart.Series.Clear();
        }
        public void renderPiechart()
        {
            clearData();
            changePanel();
            //Add data
            lineData();
            createPieChart();
            //Add legends L01           
            if (dataL01[0] == 0 && dataL01[1] == 0 && dataL01[2] == 0)
            {
                lbOP1.Visible = false;
                lbRW1.Visible = false;
                lbNG1.Visible = false;
                btL1.Visible = false;
                lbWar1.Visible = true;
                lbWar1.Text = "No Data";
                lbWar1.Font = new Font("Times New Roman", 48, FontStyle.Bold);
            }
            else
            {
                lbWar1.Visible = false;
                lbOP1.Visible = true;
                lbRW1.Visible = true;
                lbNG1.Visible = true;
                btL1.Visible = true;
                lbOP1.BackColor = Color.DodgerBlue;
                lbRW1.BackColor = Color.Orange;
                lbNG1.BackColor = Color.Red;
                lbOP1.Text = "OUTPUT: " + dataL01[0].ToString() + "%";
                lbRW1.Text = "REWORK: " + dataL01[1].ToString() + "%";
                lbNG1.Text = "NO GOOD: " + dataL01[2].ToString() + "%";
                lbOP1.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lbRW1.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lbNG1.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            }
            //Add legends L02
            if (dataL02[0] == 0 && dataL02[1] == 0 && dataL02[2] == 0)
            {
                lbOP2.Visible = false;
                lbRW2.Visible = false;
                lbNG2.Visible = false;
                btL2.Visible = false;
                lbWar2.Visible = true;
                lbWar2.Text = "No Data";
                lbWar2.Font = new Font("Times New Roman", 48, FontStyle.Bold);
            }
            else
            {
                lbWar2.Visible = false;
                lbOP2.Visible = true;
                lbRW2.Visible = true;
                lbNG2.Visible = true;
                btL2.Visible = true;
                lbOP2.BackColor = Color.DodgerBlue;
                lbRW2.BackColor = Color.Orange;
                lbNG2.BackColor = Color.Red;
                lbOP2.Text = "OUTPUT: " + dataL02[0].ToString() + "%";
                lbRW2.Text = "REWORK: " + dataL02[1].ToString() + "%";
                lbNG2.Text = "NO GOOD: " + dataL02[2].ToString() + "%";
                lbOP2.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lbRW2.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lbNG2.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            }
            //Add legends L03
            if (dataL03[0] == 0 && dataL03[1] == 0 && dataL03[2] == 0)
            {
                lbOP3.Visible = false;
                lbRW3.Visible = false;
                lbNG3.Visible = false;
                btL3.Visible = false;
                lbWar3.Visible = true;
                lbWar3.Text = "No Data";
                lbWar3.Font = new Font("Times New Roman", 48, FontStyle.Bold);
            }
            else
            {
                lbWar3.Visible = false;
                lbOP3.Visible = true;
                lbRW3.Visible = true;
                lbNG3.Visible = true;
                btL3.Visible = true;
                lbOP3.BackColor = Color.DodgerBlue;
                lbRW3.BackColor = Color.Orange;
                lbNG3.BackColor = Color.Red;
                lbOP3.Text = "OUTPUT: " + dataL03[0].ToString() + "%";
                lbRW3.Text = "REWORK: " + dataL03[1].ToString() + "%";
                lbNG3.Text = "NO GOOD: " + dataL03[2].ToString() + "%";
                lbOP3.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lbRW3.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lbNG3.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            }
            //Add legends L04
            if (dataL04[0] == 0 && dataL04[1] == 0 && dataL04[2] == 0)
            {
                lbOP4.Visible = false;
                lbRW4.Visible = false;
                lbNG4.Visible = false;
                btL4.Visible = false;
                lbWar4.Visible = true;
                lbWar4.Text = "No Data";
                lbWar4.Font = new Font("Times New Roman", 48, FontStyle.Bold);
            }
            else
            {
                lbWar4.Visible = false;
                lbOP4.Visible = true;
                lbRW4.Visible = true;
                lbNG4.Visible = true;
                btL4.Visible = true;
                lbOP4.BackColor = Color.DodgerBlue;
                lbRW4.BackColor = Color.Orange;
                lbNG4.BackColor = Color.Red;
                lbOP4.Text = "OUTPUT: " + dataL04[0].ToString() + "%";
                lbRW4.Text = "REWORK: " + dataL04[1].ToString() + "%";
                lbNG4.Text = "NO GOOD: " + dataL04[2].ToString() + "%";
                lbOP4.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lbRW4.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lbNG4.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            }
            //Add legends L05
            if (dataL05[0] == 0 && dataL05[1] == 0 && dataL05[2] == 0)
            {
                lbOP5.Visible = false;
                lbRW5.Visible = false;
                lbNG5.Visible = false;
                btL5.Visible = false;
                lbWar5.Visible = true;
                lbWar5.Text = "No Data";
                lbWar5.Font = new Font("Times New Roman", 48, FontStyle.Bold);
            }
            else
            {
                lbWar5.Visible = false;
                lbOP5.Visible = true;
                lbRW5.Visible = true;
                lbNG5.Visible = true;
                btL5.Visible = true;
                lbOP5.BackColor = Color.DodgerBlue;
                lbRW5.BackColor = Color.Orange;
                lbNG5.BackColor = Color.Red;
                lbOP5.Text = "OUTPUT: " + dataL05[0].ToString() + "%";
                lbRW5.Text = "REWORK: " + dataL05[1].ToString() + "%";
                lbNG5.Text = "NO GOOD: " + dataL05[2].ToString() + "%";
                lbOP5.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lbRW5.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lbNG5.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            }
            //Add legends L06
            if (dataL06[0] == 0 && dataL06[1] == 0 && dataL06[2] == 0)
            {
                lbOP6.Visible = false;
                lbRW6.Visible = false;
                lbNG6.Visible = false;
                btL6.Visible = false;
                lbWar6.Visible = true;
                lbWar6.Text = "No Data";
                lbWar6.Font = new Font("Times New Roman", 48, FontStyle.Bold);
            }
            else
            {
                lbWar6.Visible = false;
                lbOP6.Visible = true;
                lbRW6.Visible = true;
                lbNG6.Visible = true;
                btL6.Visible = true;
                lbOP6.BackColor = Color.DodgerBlue;
                lbRW6.BackColor = Color.Orange;
                lbNG6.BackColor = Color.Red;
                lbOP6.Text = "OUTPUT: " + dataL06[0].ToString() + "%";
                lbRW6.Text = "REWORK: " + dataL06[1].ToString() + "%";
                lbNG6.Text = "NO GOOD: " + dataL06[2].ToString() + "%";
                lbOP6.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lbRW6.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lbNG6.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            }
            //Add legends L07
            if (dataL07[0] == 0 && dataL07[1] == 0 && dataL07[2] == 0)
            {
                lbOP7.Visible = false;
                lbRW7.Visible = false;
                lbNG7.Visible = false;
                btL7.Visible = false;
                lbWar7.Visible = true;
                lbWar7.Text = "No Data";
                lbWar7.Font = new Font("Times New Roman", 48, FontStyle.Bold);
            }
            else
            {
                lbWar7.Visible = false;
                lbOP7.Visible = true;
                lbRW7.Visible = true;
                lbNG7.Visible = true;
                btL7.Visible = true;
                lbOP7.BackColor = Color.DodgerBlue;
                lbRW7.BackColor = Color.Orange;
                lbNG7.BackColor = Color.Red;
                lbOP7.Text = "OUTPUT: " + dataL07[0].ToString() + "%";
                lbRW7.Text = "REWORK: " + dataL07[1].ToString() + "%";
                lbNG7.Text = "NO GOOD: " + dataL07[2].ToString() + "%";
                lbOP7.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lbRW7.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                lbNG7.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            }
            dtpChart.Visible = true;          
        }

        private void dtpChart_ValueChanged(object sender, EventArgs e)
        {
            SaveData.check = true;
            dtpChart.Visible = false;
            renderPiechart();
        }
        public void UpdateTime()
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
            SaveData.Date = dtpChart.Value.ToString("yyyy-MM-dd");
            SaveData.check = false;
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
            if (MainForm.MQC == true)
            {               
                int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
                int remainingSeconds = secondsToWait - elapsedSeconds;
                TimeSpan ts = TimeSpan.FromSeconds(remainingSeconds);
                string time = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                ts.Hours,
                                ts.Minutes,
                                ts.Seconds);
                lblTime.Text = "Chart update in: " + "\r\n" + time.ToString();
                if (remainingSeconds < 0)
                {
                    lblTime.Text = "Data is being" + "\r\n" + "updated";
                    timer1.Stop();
                    SaveData.uc_pi = -1;
                    SaveData.uc_mqc = 0;
                    SaveData.uc_pqc = -1;
                    renderPiechart();
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
            lblTime.Text = "Auto update" + "\r\n" + "chart is stopping";
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

        public delegate void StatusUpdateHandler(object sender, EventArgs e);
        public event StatusUpdateHandler OnUpdateStatus;

        private void UpdateStatus()
        {
            EventArgs args = new EventArgs();

            //Call any listeners
            OnUpdateStatus?.Invoke(this, args);

        }
        private void btL1_Click(object sender, EventArgs e)
        {
            SaveData.MQC = true;
            SaveData.PQC = false;
            SaveData.MQCClick = true;
            SaveData.PQCClick = false;
            SaveData.line = "L01";
            SaveData.Date = dtpChart.Value.ToString("yyyy-MM-dd");
            UpdateStatus();
        }

        private void btL2_Click(object sender, EventArgs e)
        {
            SaveData.MQC = true;
            SaveData.PQC = false;
            SaveData.MQCClick = true;
            SaveData.PQCClick = false;
            SaveData.line = "L02";
            SaveData.Date = dtpChart.Value.ToString("yyyy-MM-dd");
            UpdateStatus();
        }

        private void btL3_Click(object sender, EventArgs e)
        {
            SaveData.MQC = true;
            SaveData.PQC = false;
            SaveData.MQCClick = true;
            SaveData.PQCClick = false;
            SaveData.line = "L03";
            SaveData.Date = dtpChart.Value.ToString("yyyy-MM-dd");
            UpdateStatus();
        }

        private void btL4_Click(object sender, EventArgs e)
        {
            SaveData.MQC = true;
            SaveData.PQC = false;
            SaveData.MQCClick = true;
            SaveData.PQCClick = false;
            SaveData.line = "L04";
            SaveData.Date = dtpChart.Value.ToString("yyyy-MM-dd");
            UpdateStatus();
        }

        private void btL5_Click(object sender, EventArgs e)
        {
            SaveData.MQC = true;
            SaveData.PQC = false;
            SaveData.MQCClick = true;
            SaveData.PQCClick = false;
            SaveData.line = "L05";
            SaveData.Date = dtpChart.Value.ToString("yyyy-MM-dd");
            UpdateStatus();
        }

        private void btL6_Click(object sender, EventArgs e)
        {
            SaveData.MQC = true;
            SaveData.PQC = false;
            SaveData.MQCClick = true;
            SaveData.PQCClick = false;
            SaveData.line = "L06";
            SaveData.Date = dtpChart.Value.ToString("yyyy-MM-dd");
            UpdateStatus();
        }

        private void btL7_Click(object sender, EventArgs e)
        {
            SaveData.MQC = true;
            SaveData.PQC = false;
            SaveData.MQCClick = true;
            SaveData.PQCClick = false;
            SaveData.line = "L07";
            SaveData.Date = dtpChart.Value.ToString("yyyy-MM-dd");
            UpdateStatus();
        }
        public void changePanel()
        {
            SaveData.dtTemp1 = new DataTable();
            SaveData.dtTemp1 = GetSOFTdata.GetListMQC(dtpChart.Value.ToString("yyyy-MM-dd"), "");
            if (SaveData.dtTemp1.Rows.Count > 0)
            {
                DataRow[] results1 = SaveData.dtTemp1.Select("Line = 'L01' and NG_rate_realtime > NG_rate_allow and RW_rate_realtime > RW_rate_allow");
                DataRow[] results11 = SaveData.dtTemp1.Select("Line = 'L01' and (NG_rate_realtime > NG_rate_allow or RW_rate_realtime > RW_rate_allow)");
                //DataRow[] results111 = SaveData.dtTemp1.Select("Line = 'L01' and RW_rate_realtime > RW_rate_allow");
                DataRow[] results2 = SaveData.dtTemp1.Select("Line = 'L02' and NG_rate_realtime > NG_rate_allow and RW_rate_realtime > RW_rate_allow");
                DataRow[] results22 = SaveData.dtTemp1.Select("Line = 'L02' and (NG_rate_realtime > NG_rate_allow or RW_rate_realtime > RW_rate_allow)");
                //DataRow[] results222 = SaveData.dtTemp1.Select("Line = 'L02' and RW_rate_realtime > RW_rate_allow");
                DataRow[] results3 = SaveData.dtTemp1.Select("Line = 'L03' and NG_rate_realtime > NG_rate_allow and RW_rate_realtime > RW_rate_allow");
                DataRow[] results33 = SaveData.dtTemp1.Select("Line = 'L03' and (NG_rate_realtime > NG_rate_allow or RW_rate_realtime > RW_rate_allow)");
                //DataRow[] results333 = SaveData.dtTemp1.Select("Line = 'L03' and RW_rate_realtime > RW_rate_allow");
                DataRow[] results4 = SaveData.dtTemp1.Select("Line = 'L04' and NG_rate_realtime > NG_rate_allow and RW_rate_realtime > RW_rate_allow");
                DataRow[] results44 = SaveData.dtTemp1.Select("Line = 'L04' and (NG_rate_realtime > NG_rate_allow or RW_rate_realtime > RW_rate_allow)");
                //DataRow[] results444 = SaveData.dtTemp1.Select("Line = 'L04' and RW_rate_realtime > RW_rate_allow");
                DataRow[] results5 = SaveData.dtTemp1.Select("Line = 'L05' and NG_rate_realtime > NG_rate_allow and RW_rate_realtime > RW_rate_allow");
                DataRow[] results55 = SaveData.dtTemp1.Select("Line = 'L05' and (NG_rate_realtime > NG_rate_allow or RW_rate_realtime > RW_rate_allow)");
                //DataRow[] results555 = SaveData.dtTemp1.Select("Line = 'L05' and RW_rate_realtime > RW_rate_allow");
                DataRow[] results6 = SaveData.dtTemp1.Select("Line = 'L06' and NG_rate_realtime > NG_rate_allow and RW_rate_realtime > RW_rate_allow");
                DataRow[] results66 = SaveData.dtTemp1.Select("Line = 'L06' and (NG_rate_realtime > NG_rate_allow or RW_rate_realtime > RW_rate_allow)");
                //DataRow[] results666 = SaveData.dtTemp1.Select("Line = 'L06' and RW_rate_realtime > RW_rate_allow");
                DataRow[] results7 = SaveData.dtTemp1.Select("Line = 'L07' and NG_rate_realtime > NG_rate_allow and RW_rate_realtime > RW_rate_allow");
                DataRow[] results77 = SaveData.dtTemp1.Select("Line = 'L07' and (NG_rate_realtime > NG_rate_allow or RW_rate_realtime > RW_rate_allow)");
                //DataRow[] results777 = SaveData.dtTemp1.Select("Line = 'L07' and RW_rate_realtime > RW_rate_allow");
                //pn1
                if (results1.Length > 0)
                {
                    panel1.BorderStyle = BorderStyle.FixedSingle;
                    panel1.BackColor = Color.DarkViolet;
                    L01Chart.BackColor = Color.DarkViolet;
                }
                else if (results11.Length > 0)
                {
                    panel1.BorderStyle = BorderStyle.FixedSingle;
                    panel1.BackColor = Color.Yellow;
                    L01Chart.BackColor = Color.Yellow;
                }
                //else if (results111.Length > 0)
                //{
                //    panel1.BorderStyle = BorderStyle.FixedSingle;
                //    panel1.BackColor = Color.LightYellow;
                //    linePCanvas1.BackColor = Color.LightYellow;
                //}
                else
                {
                    panel1.BorderStyle = BorderStyle.Fixed3D;
                    panel1.BackColor = Color.White;
                    L01Chart.BackColor = Color.White;
                }
                //pn2
                if (results2.Length > 0)
                {
                    panel2.BorderStyle = BorderStyle.FixedSingle;
                    panel2.BackColor = Color.DarkViolet;
                    L02Chart.BackColor = Color.DarkViolet;
                }
                else if (results22.Length > 0)
                {
                    panel2.BorderStyle = BorderStyle.FixedSingle;
                    panel2.BackColor = Color.Yellow;
                    L02Chart.BackColor = Color.Yellow;
                }
                //else if (results222.Length > 0)
                //{
                //    panel2.BorderStyle = BorderStyle.FixedSingle;
                //    panel2.BackColor = Color.LightYellow;
                //    L02Chart.BackColor = Color.LightYellow;
                //}
                else
                {
                    panel2.BorderStyle = BorderStyle.Fixed3D;
                    panel2.BackColor = Color.White;
                    L02Chart.BackColor = Color.White;
                }
                //pn3
                if (results3.Length > 0)
                {
                    panel3.BorderStyle = BorderStyle.FixedSingle;
                    panel3.BackColor = Color.DarkViolet;
                    L03Chart.BackColor = Color.DarkViolet;
                }
                else if (results33.Length > 0)
                {
                    panel3.BorderStyle = BorderStyle.FixedSingle;
                    panel3.BackColor = Color.Yellow;
                    L03Chart.BackColor = Color.Yellow;
                }
                //else if (results333.Length > 0)
                //{
                //    panel3.BorderStyle = BorderStyle.FixedSingle;
                //    panel3.BackColor = Color.LightYellow;
                //    L03Chart.BackColor = Color.LightYellow;
                //}
                else
                {
                    panel3.BorderStyle = BorderStyle.Fixed3D;
                    panel3.BackColor = Color.White;
                    L03Chart.BackColor = Color.White;
                }
                //pn4
                if (results4.Length > 0)
                {
                    panel4.BorderStyle = BorderStyle.FixedSingle;
                    panel4.BackColor = Color.DarkViolet;
                    L04Chart.BackColor = Color.DarkViolet;
                }
                else if (results44.Length > 0)
                {
                    panel4.BorderStyle = BorderStyle.FixedSingle;
                    panel4.BackColor = Color.Yellow;
                    L04Chart.BackColor = Color.Yellow;
                }
                //else if (results444.Length > 0)
                //{
                //    panel4.BorderStyle = BorderStyle.FixedSingle;
                //    panel4.BackColor = Color.LightYellow;
                //    L04Chart.BackColor = Color.LightYellow;
                //}
                else
                {
                    panel4.BorderStyle = BorderStyle.Fixed3D;
                    panel4.BackColor = Color.White;
                    L04Chart.BackColor = Color.White;
                }
                //pn5
                if (results5.Length > 0)
                {
                    panel5.BorderStyle = BorderStyle.FixedSingle;
                    panel5.BackColor = Color.DarkViolet;
                    L05Chart.BackColor = Color.DarkViolet;
                }
                else if (results55.Length > 0)
                {
                    panel5.BorderStyle = BorderStyle.FixedSingle;
                    panel5.BackColor = Color.Yellow;
                    L05Chart.BackColor = Color.Yellow;
                }
                //else if (results555.Length > 0)
                //{
                //    panel5.BorderStyle = BorderStyle.FixedSingle;
                //    panel5.BackColor = Color.LightYellow;
                //    L05Chart.BackColor = Color.LightYellow;
                //}
                else
                {
                    panel5.BorderStyle = BorderStyle.Fixed3D;
                    panel5.BackColor = Color.White;
                    L05Chart.BackColor = Color.White;
                }
                //pn6
                if (results6.Length > 0)
                {
                    panel6.BorderStyle = BorderStyle.FixedSingle;
                    panel6.BackColor = Color.DarkViolet;
                    L06Chart.BackColor = Color.DarkViolet;
                }
                else if (results66.Length > 0)
                {
                    panel6.BorderStyle = BorderStyle.FixedSingle;
                    panel6.BackColor = Color.Yellow;
                    L06Chart.BackColor = Color.Yellow;
                }
                //else if (results666.Length > 0)
                //{
                //    panel6.BorderStyle = BorderStyle.FixedSingle;
                //    panel6.BackColor = Color.LightYellow;
                //    L06Chart.BackColor = Color.LightYellow;
                //}
                else
                {
                    panel6.BorderStyle = BorderStyle.Fixed3D;
                    panel6.BackColor = Color.White;
                    L06Chart.BackColor = Color.White;
                }
                //pn7
                if (results7.Length > 0)
                {
                    panel7.BorderStyle = BorderStyle.FixedSingle;
                    panel7.BackColor = Color.DarkViolet;
                    L07Chart.BackColor = Color.DarkViolet;
                }
                else if (results77.Length > 0)
                {
                    panel7.BorderStyle = BorderStyle.FixedSingle;
                    panel7.BackColor = Color.Yellow;
                    L07Chart.BackColor = Color.Yellow;
                }
                //else if (results777.Length > 0)
                //{
                //    panel7.BorderStyle = BorderStyle.FixedSingle;
                //    panel7.BackColor = Color.LightYellow;
                //    L07Chart.BackColor = Color.LightYellow;
                //}
                else
                {
                    panel7.BorderStyle = BorderStyle.Fixed3D;
                    panel7.BackColor = Color.White;
                    L07Chart.BackColor = Color.White;
                }
            }    
            else
            {
                //pn1
                panel1.BorderStyle = BorderStyle.Fixed3D;
                panel1.BackColor = Color.White;
                L01Chart.BackColor = Color.White;
                //pn2
                panel2.BorderStyle = BorderStyle.Fixed3D;
                panel2.BackColor = Color.White;
                L02Chart.BackColor = Color.White;
                //pn3
                panel3.BorderStyle = BorderStyle.Fixed3D;
                panel3.BackColor = Color.White;
                L03Chart.BackColor = Color.White;
                //pn4
                panel4.BorderStyle = BorderStyle.Fixed3D;
                panel4.BackColor = Color.White;
                L04Chart.BackColor = Color.White;
                //pn5
                panel5.BorderStyle = BorderStyle.Fixed3D;
                panel5.BackColor = Color.White;
                L05Chart.BackColor = Color.White;
                //pn6
                panel6.BorderStyle = BorderStyle.Fixed3D;
                panel6.BackColor = Color.White;
                L06Chart.BackColor = Color.White;
                //pn7
                panel7.BorderStyle = BorderStyle.Fixed3D;
                panel7.BackColor = Color.White;
                L07Chart.BackColor = Color.White;
            }    
        }
    }
}
