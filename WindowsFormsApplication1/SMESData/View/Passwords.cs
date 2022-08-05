using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Passwords : Form
    {
        public Passwords()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SaveData.pass = txtPass.Text;
            if (SaveData.pass == "techlink1234")
            {
                SaveData.checkpass = true;
                txtPass.Text = null;
                Close();
            }
            else
            {
                SaveData.checkpass = false;
                MessageBox.Show("Incorrect Passwords");
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            txtPass.Text = null;
            Close();
        }

        private void Passwords_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveData.pass = txtPass.Text;
                if (SaveData.pass == "techlink1234")
                {
                    SaveData.checkpass = true;
                    txtPass.Text = null;
                    Close();
                }
                else
                {
                    SaveData.checkpass = false;
                    MessageBox.Show("Incorrect Passwords");
                }
            }
        }
    }
}
