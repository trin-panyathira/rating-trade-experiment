using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using static WindowsFormsApp1.Constant;

namespace WindowsFormsApp1
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            textBoxHostAddress.Text = "192.168.1.100";
        }

        private void buttonServer_Click(object sender, EventArgs e)
        {
            SocketUtil.isServer = true;
            ServerMainPage page = new ServerMainPage();
            this.Hide();
            page.Show();
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            // connect server
            string hostAddress = textBoxHostAddress.Text.Trim(); // 192.168.1.100
            bool isSuccess = SocketUtil.SendMessageToHost(hostAddress, CONNECT, SocketUtil.GetLocalIPAddress());

            if (isSuccess)
            {
                SocketUtil.isServer = false;
                SocketUtil.hostIpAddress = hostAddress;
                ClientMainPage page = new ClientMainPage();
                this.Hide();
                page.Show();
            }
            else
            {
                Console.WriteLine("Connect server failed.");
            }
        }
    }
}
