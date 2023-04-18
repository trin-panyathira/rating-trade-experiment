using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.Constant;

namespace WindowsFormsApp1
{
    public partial class ClientWaitingPage : Form
    {
        public ClientWaitingPage()
        {
            InitializeComponent();
        }

        private void ClientWaitingPage_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void ClientWaitingPage_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                SocketUtil.memoryModel.clientWaitingPage = this;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientExperimentPage page = new ClientExperimentPage();
            SocketUtil.memoryModel.isTest = true;
            page.Show();
            this.Hide();
        }
    }
}
