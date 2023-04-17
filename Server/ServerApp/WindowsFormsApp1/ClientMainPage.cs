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
    public partial class ClientMainPage : Form
    {
        public ClientMainPage()
        {
            InitializeComponent();
        }

        private void ClientMainPage_Load(object sender, EventArgs e)
        {

        }

        private void ClientMainPage_VisibleChanged(object sender, EventArgs e)
        {
            // start sever
            SocketUtil.isServer = false;
            SocketUtil.StartThreadServer(this);
        }

        private void buttonConnectServer_Click(object sender, EventArgs e)
        {
        }
    }
}
