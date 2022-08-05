
namespace WindowsFormsApplication1
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnMenu = new System.Windows.Forms.Panel();
            this.btClose = new XanderUI.XUIButton();
            this.btNornal = new XanderUI.XUIButton();
            this.btMin = new XanderUI.XUIButton();
            this.btMQCPD = new XanderUI.XUIButton();
            this.btMQC = new XanderUI.XUIButton();
            this.btPQC = new XanderUI.XUIButton();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnMain.BackgroundImage")));
            this.pnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(180, 0);
            this.pnMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(2220, 1102);
            this.pnMain.TabIndex = 10;
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.Black;
            this.pnMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnMenu.BackgroundImage")));
            this.pnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnMenu.Controls.Add(this.btClose);
            this.pnMenu.Controls.Add(this.btNornal);
            this.pnMenu.Controls.Add(this.btMin);
            this.pnMenu.Controls.Add(this.btMQCPD);
            this.pnMenu.Controls.Add(this.btMQC);
            this.pnMenu.Controls.Add(this.btPQC);
            this.pnMenu.Controls.Add(this.pbLogo);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMenu.Location = new System.Drawing.Point(0, 0);
            this.pnMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(180, 1102);
            this.pnMenu.TabIndex = 9;
            // 
            // btClose
            // 
            this.btClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btClose.BackgroundColor = System.Drawing.Color.Black;
            this.btClose.ButtonImage = global::WindowsFormsApplication1.Properties.Resources.close;
            this.btClose.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btClose.ButtonText = "";
            this.btClose.ClickBackColor = System.Drawing.Color.Black;
            this.btClose.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btClose.CornerRadius = 5;
            this.btClose.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btClose.HoverBackgroundColor = System.Drawing.Color.White;
            this.btClose.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btClose.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btClose.Location = new System.Drawing.Point(41, 971);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(100, 100);
            this.btClose.TabIndex = 14;
            this.btClose.TextColor = System.Drawing.Color.DodgerBlue;
            this.btClose.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btNornal
            // 
            this.btNornal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btNornal.BackgroundColor = System.Drawing.Color.Black;
            this.btNornal.ButtonImage = global::WindowsFormsApplication1.Properties.Resources.maximize;
            this.btNornal.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btNornal.ButtonText = "";
            this.btNornal.ClickBackColor = System.Drawing.Color.Black;
            this.btNornal.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btNornal.CornerRadius = 5;
            this.btNornal.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btNornal.HoverBackgroundColor = System.Drawing.Color.White;
            this.btNornal.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btNornal.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btNornal.Location = new System.Drawing.Point(41, 853);
            this.btNornal.Name = "btNornal";
            this.btNornal.Size = new System.Drawing.Size(100, 100);
            this.btNornal.TabIndex = 13;
            this.btNornal.TextColor = System.Drawing.Color.DodgerBlue;
            this.btNornal.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btNornal.Click += new System.EventHandler(this.btNornal_Click);
            // 
            // btMin
            // 
            this.btMin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btMin.BackgroundColor = System.Drawing.Color.Black;
            this.btMin.ButtonImage = global::WindowsFormsApplication1.Properties.Resources.minimize__1_;
            this.btMin.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btMin.ButtonText = "";
            this.btMin.ClickBackColor = System.Drawing.Color.Black;
            this.btMin.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btMin.CornerRadius = 5;
            this.btMin.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btMin.HoverBackgroundColor = System.Drawing.Color.White;
            this.btMin.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btMin.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btMin.Location = new System.Drawing.Point(41, 735);
            this.btMin.Name = "btMin";
            this.btMin.Size = new System.Drawing.Size(100, 100);
            this.btMin.TabIndex = 12;
            this.btMin.TextColor = System.Drawing.Color.DodgerBlue;
            this.btMin.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btMin.Click += new System.EventHandler(this.btMin_Click);
            // 
            // btMQCPD
            // 
            this.btMQCPD.BackgroundColor = System.Drawing.Color.Black;
            this.btMQCPD.ButtonImage = null;
            this.btMQCPD.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btMQCPD.ButtonText = "Model Data";
            this.btMQCPD.ClickBackColor = System.Drawing.Color.SteelBlue;
            this.btMQCPD.ClickTextColor = System.Drawing.Color.White;
            this.btMQCPD.CornerRadius = 5;
            this.btMQCPD.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold);
            this.btMQCPD.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btMQCPD.HoverBackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.btMQCPD.HoverTextColor = System.Drawing.Color.White;
            this.btMQCPD.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btMQCPD.Location = new System.Drawing.Point(0, 422);
            this.btMQCPD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btMQCPD.Name = "btMQCPD";
            this.btMQCPD.Size = new System.Drawing.Size(180, 120);
            this.btMQCPD.TabIndex = 11;
            this.btMQCPD.TextColor = System.Drawing.Color.White;
            this.btMQCPD.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btMQCPD.Click += new System.EventHandler(this.btMQCPD_Click);
            // 
            // btMQC
            // 
            this.btMQC.BackgroundColor = System.Drawing.Color.Black;
            this.btMQC.ButtonImage = null;
            this.btMQC.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btMQC.ButtonText = "MQC";
            this.btMQC.ClickBackColor = System.Drawing.Color.SteelBlue;
            this.btMQC.ClickTextColor = System.Drawing.Color.White;
            this.btMQC.CornerRadius = 5;
            this.btMQC.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold);
            this.btMQC.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btMQC.HoverBackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.btMQC.HoverTextColor = System.Drawing.Color.White;
            this.btMQC.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btMQC.Location = new System.Drawing.Point(0, 138);
            this.btMQC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btMQC.Name = "btMQC";
            this.btMQC.Size = new System.Drawing.Size(180, 120);
            this.btMQC.TabIndex = 0;
            this.btMQC.TextColor = System.Drawing.Color.White;
            this.btMQC.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btMQC.Click += new System.EventHandler(this.btMQC_Click);
            // 
            // btPQC
            // 
            this.btPQC.BackgroundColor = System.Drawing.Color.Black;
            this.btPQC.ButtonImage = null;
            this.btPQC.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btPQC.ButtonText = "PQC";
            this.btPQC.ClickBackColor = System.Drawing.Color.SteelBlue;
            this.btPQC.ClickTextColor = System.Drawing.Color.White;
            this.btPQC.CornerRadius = 5;
            this.btPQC.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold);
            this.btPQC.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btPQC.HoverBackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.btPQC.HoverTextColor = System.Drawing.Color.White;
            this.btPQC.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btPQC.Location = new System.Drawing.Point(0, 280);
            this.btPQC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btPQC.Name = "btPQC";
            this.btPQC.Size = new System.Drawing.Size(180, 120);
            this.btPQC.TabIndex = 10;
            this.btPQC.TextColor = System.Drawing.Color.White;
            this.btPQC.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btPQC.Click += new System.EventHandler(this.btPQC_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Black;
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(180, 132);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2400, 1102);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowMESData";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.pnMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Panel pnMenu;
        private XanderUI.XUIButton btMQC;
        private XanderUI.XUIButton btMQCPD;
        private XanderUI.XUIButton btPQC;
        private XanderUI.XUIButton btClose;
        private XanderUI.XUIButton btNornal;
        private XanderUI.XUIButton btMin;
    }
}

