
namespace WindowsFormsApplication1
{
    partial class WarningAll
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbWar = new System.Windows.Forms.Label();
            this.btClose = new XanderUI.XUIButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbSD = new System.Windows.Forms.Label();
            this.lbNGA = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbMdl = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btOk = new XanderUI.XUIButton();
            this.btCancel = new XanderUI.XUIButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 92.52631F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.473684F));
            this.tableLayoutPanel1.Controls.Add(this.lbWar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btClose, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(950, 270);
            this.tableLayoutPanel1.TabIndex = 87;
            // 
            // lbWar
            // 
            this.lbWar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbWar.AutoSize = true;
            this.lbWar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWar.Location = new System.Drawing.Point(187, 32);
            this.lbWar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbWar.Name = "lbWar";
            this.lbWar.Size = new System.Drawing.Size(504, 35);
            this.lbWar.TabIndex = 72;
            this.lbWar.Text = "Do you want to fix the following data ?";
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btClose.Location = new System.Drawing.Point(878, 0);
            this.btClose.Margin = new System.Windows.Forms.Padding(0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(72, 67);
            this.btClose.TabIndex = 76;
            this.btClose.TextColor = System.Drawing.Color.DodgerBlue;
            this.btClose.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.71264F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.05747F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.86207F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.25287F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbDate, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbSD, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbNGA, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 134);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(878, 67);
            this.tableLayoutPanel2.TabIndex = 85;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(119, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(182, 35);
            this.label1.TabIndex = 72;
            this.label1.Text = "%NG Allow:";
            // 
            // lbDate
            // 
            this.lbDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lbDate.Location = new System.Drawing.Point(580, 16);
            this.lbDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDate.Name = "lbDate";
            this.lbDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbDate.Size = new System.Drawing.Size(39, 35);
            this.lbDate.TabIndex = 71;
            this.lbDate.Text = "...";
            // 
            // lbSD
            // 
            this.lbSD.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSD.AutoSize = true;
            this.lbSD.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lbSD.Location = new System.Drawing.Point(488, 16);
            this.lbSD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSD.Name = "lbSD";
            this.lbSD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbSD.Size = new System.Drawing.Size(84, 35);
            this.lbSD.TabIndex = 70;
            this.lbSD.Text = "Date:";
            // 
            // lbNGA
            // 
            this.lbNGA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbNGA.AutoSize = true;
            this.lbNGA.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lbNGA.Location = new System.Drawing.Point(309, 16);
            this.lbNGA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNGA.Name = "lbNGA";
            this.lbNGA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbNGA.Size = new System.Drawing.Size(39, 35);
            this.lbNGA.TabIndex = 69;
            this.lbNGA.Text = "...";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.7909F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.2091F));
            this.tableLayoutPanel4.Controls.Add(this.lbMdl, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lbModel, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 67);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(878, 67);
            this.tableLayoutPanel4.TabIndex = 87;
            // 
            // lbMdl
            // 
            this.lbMdl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMdl.AutoSize = true;
            this.lbMdl.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbMdl.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lbMdl.Location = new System.Drawing.Point(195, 16);
            this.lbMdl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMdl.Name = "lbMdl";
            this.lbMdl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbMdl.Size = new System.Drawing.Size(106, 35);
            this.lbMdl.TabIndex = 68;
            this.lbMdl.Text = "Model:";
            // 
            // lbModel
            // 
            this.lbModel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbModel.AutoSize = true;
            this.lbModel.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbModel.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lbModel.Location = new System.Drawing.Point(309, 16);
            this.lbModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbModel.Name = "lbModel";
            this.lbModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbModel.Size = new System.Drawing.Size(134, 35);
            this.lbModel.TabIndex = 66;
            this.lbModel.Text = "all Model";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.85591F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.14409F));
            this.tableLayoutPanel3.Controls.Add(this.btOk, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btCancel, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 201);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(878, 69);
            this.tableLayoutPanel3.TabIndex = 88;
            // 
            // btOk
            // 
            this.btOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btOk.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btOk.ButtonImage = null;
            this.btOk.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btOk.ButtonText = "Ok";
            this.btOk.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btOk.ClickTextColor = System.Drawing.Color.White;
            this.btOk.CornerRadius = 5;
            this.btOk.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btOk.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btOk.HoverBackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.btOk.HoverTextColor = System.Drawing.Color.Black;
            this.btOk.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btOk.Location = new System.Drawing.Point(307, 4);
            this.btOk.Margin = new System.Windows.Forms.Padding(4, 4, 10, 4);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(120, 60);
            this.btOk.TabIndex = 85;
            this.btOk.TextColor = System.Drawing.Color.White;
            this.btOk.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btOk.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btCancel.BackgroundColor = System.Drawing.Color.Orange;
            this.btCancel.ButtonImage = null;
            this.btCancel.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btCancel.ButtonText = "Cancel";
            this.btCancel.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btCancel.ClickTextColor = System.Drawing.Color.White;
            this.btCancel.CornerRadius = 5;
            this.btCancel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btCancel.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btCancel.HoverBackgroundColor = System.Drawing.Color.Moccasin;
            this.btCancel.HoverTextColor = System.Drawing.Color.Black;
            this.btCancel.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btCancel.Location = new System.Drawing.Point(447, 4);
            this.btCancel.Margin = new System.Windows.Forms.Padding(10, 4, 4, 4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(120, 60);
            this.btCancel.TabIndex = 84;
            this.btCancel.TextColor = System.Drawing.Color.White;
            this.btCancel.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // WarningAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(950, 270);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WarningAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warning";
            this.Load += new System.EventHandler(this.WarningAll_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbWar;
        private XanderUI.XUIButton btClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbSD;
        private System.Windows.Forms.Label lbNGA;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lbMdl;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private XanderUI.XUIButton btOk;
        private XanderUI.XUIButton btCancel;
    }
}