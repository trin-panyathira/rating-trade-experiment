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
    public partial class ClientExperimentPage : Form
    {
        public ClientExperimentPage()
        {
            InitializeComponent();
        }

        private void ClientExperimentPage_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void ClientExperimentPage_VisibleChanged(object sender, EventArgs e)
        {
            SocketUtil.memoryModel.clientExperimentPage = this;
        }

        delegate void ActivityCallback(Form f, string text);

        //public void startExpirement(Form form, string text)
        //{
        //    if (form.InvokeRequired)
        //    {
        //        ActivityCallback d = new ActivityCallback(startExpirement);
        //        form.Invoke(d, new object[] { form, text });
        //    }
        //    else
        //    {
        //        ServerMainPage page = new ServerMainPage();
        //        page.Show();
        //        this.Hide();
        //    }
        //}
    }
}
