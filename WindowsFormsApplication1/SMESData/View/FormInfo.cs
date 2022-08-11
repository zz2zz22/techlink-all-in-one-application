using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormInfo : Form
    {
        public FormInfo()
        {
            InitializeComponent();
            UpdateDTGV();
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {
            UpdateDTGV();
        }

        public void UpdateDTGV()
        {
            string model = SaveData.Model;
            string line = SaveData.line;
            string date = SaveData.Date;
            dtgv_Info.DataSource = GetSOFTdata.GetInfo(model, line, date);
            dtgv_Info.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgv_Info.Columns["Date"].Visible = false;
            dtgv_Info.Columns["Time"].Visible = false;
            dtgv_Info.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgv_Info.Columns["Serno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgv_Info.Columns["Model"].FillWeight = 175;
            dtgv_Info.Columns["LotNumber"].FillWeight = 125;
            dtgv_Info.Columns["Line"].FillWeight = 50;
            dtgv_Info.Columns["DateTime"].FillWeight = 150;
            dtgv_Info.Columns["Quantity"].FillWeight = 75;
            dtgv_Info.Columns["Inspector"].FillWeight = 100;
            dtgv_Info.Columns["Remark"].FillWeight = 75;
            dtgv_Info.Columns["Serno"].FillWeight = 750;
        }

        private void btClose_Click(object sender, EventArgs e)
        {

        }

        private void btMinMax_Click(object sender, EventArgs e)
        {

        }

        private void btMin_Click(object sender, EventArgs e)
        {

        }
    }
}
