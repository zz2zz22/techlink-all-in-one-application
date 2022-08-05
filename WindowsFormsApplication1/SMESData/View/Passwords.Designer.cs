
namespace WindowsFormsApplication1
{
    partial class Passwords
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btOk = new XanderUI.XUIButton();
            this.btCancel = new XanderUI.XUIButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(154, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Passwords:";
            // 
            // txtPass
            // 
            this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPass.Location = new System.Drawing.Point(354, 74);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(281, 22);
            this.txtPass.TabIndex = 1;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btOk.ButtonImage = null;
            this.btOk.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btOk.ButtonText = "OK";
            this.btOk.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btOk.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btOk.CornerRadius = 5;
            this.btOk.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btOk.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btOk.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btOk.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btOk.Location = new System.Drawing.Point(220, 120);
            this.btOk.Margin = new System.Windows.Forms.Padding(4, 20, 10, 4);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(120, 31);
            this.btOk.TabIndex = 2;
            this.btOk.TextColor = System.Drawing.Color.DodgerBlue;
            this.btOk.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackgroundColor = System.Drawing.Color.DarkGray;
            this.btCancel.ButtonImage = null;
            this.btCancel.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btCancel.ButtonText = "Cancel";
            this.btCancel.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btCancel.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btCancel.CornerRadius = 5;
            this.btCancel.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btCancel.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btCancel.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btCancel.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btCancel.Location = new System.Drawing.Point(360, 120);
            this.btCancel.Margin = new System.Windows.Forms.Padding(10, 20, 4, 4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(120, 31);
            this.btCancel.TabIndex = 3;
            this.btCancel.TextColor = System.Drawing.Color.DodgerBlue;
            this.btCancel.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btOk, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPass, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btCancel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 200);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // Passwords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(700, 200);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Passwords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Passwords";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Passwords_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPass;
        private XanderUI.XUIButton btOk;
        private XanderUI.XUIButton btCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}