using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MessageWaitForm : Form
    {
        public MessageWaitForm()
        {
            InitializeComponent();
        }

        public void UpdateProgress(int progress, string announce)
        {
            lbWait.BeginInvoke(
                new Action(() =>
                {
                    lbWait.Text = announce + progress + "%";
                }));
            progressBar1.BeginInvoke(
                new Action(() =>
                {
                    progressBar1.Value = progress;
                }
            ));
        }
    }
}
