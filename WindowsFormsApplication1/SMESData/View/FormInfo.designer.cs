
namespace WindowsFormsApplication1
{
    partial class FormInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInfo));
            this.btClose = new XanderUI.XUIButton();
            this.dtgv_Info = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BackgroundColor = System.Drawing.Color.Transparent;
            this.btClose.ButtonImage = global::WindowsFormsApplication1.Properties.Resources.close;
            this.btClose.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btClose.ButtonText = "";
            this.btClose.ClickBackColor = System.Drawing.Color.Transparent;
            this.btClose.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btClose.CornerRadius = 5;
            this.btClose.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btClose.HoverBackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btClose.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btClose.ImagePosition = XanderUI.XUIButton.imgPosition.Right;
            this.btClose.Location = new System.Drawing.Point(2320, 0);
            this.btClose.Margin = new System.Windows.Forms.Padding(0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(80, 74);
            this.btClose.TabIndex = 81;
            this.btClose.TextColor = System.Drawing.Color.DodgerBlue;
            this.btClose.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // dtgv_Info
            // 
            this.dtgv_Info.AllowUserToAddRows = false;
            this.dtgv_Info.AllowUserToDeleteRows = false;
            this.dtgv_Info.AllowUserToResizeColumns = false;
            this.dtgv_Info.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.6F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgv_Info.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_Info.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_Info.BackgroundColor = System.Drawing.Color.LightGray;
            this.dtgv_Info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgv_Info.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_Info.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv_Info.ColumnHeadersHeight = 55;
            this.dtgv_Info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10.6F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_Info.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgv_Info.EnableHeadersVisualStyles = false;
            this.dtgv_Info.Location = new System.Drawing.Point(0, 80);
            this.dtgv_Info.Margin = new System.Windows.Forms.Padding(0);
            this.dtgv_Info.Name = "dtgv_Info";
            this.dtgv_Info.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_Info.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgv_Info.RowHeadersVisible = false;
            this.dtgv_Info.RowHeadersWidth = 51;
            this.dtgv_Info.RowTemplate.Height = 50;
            this.dtgv_Info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgv_Info.Size = new System.Drawing.Size(2400, 744);
            this.dtgv_Info.TabIndex = 82;
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(2400, 822);
            this.Controls.Add(this.dtgv_Info);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInfo";
            this.Load += new System.EventHandler(this.FormInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Info)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private XanderUI.XUIButton btClose;
        private System.Windows.Forms.DataGridView dtgv_Info;
    }
}