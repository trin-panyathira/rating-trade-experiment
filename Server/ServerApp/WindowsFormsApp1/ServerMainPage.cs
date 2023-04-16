using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ServerMainPage : Form
    {
        public ServerMainPage()
        {
            InitializeComponent();
        }

        private void ServerMainPage_Load(object sender, EventArgs e)
        {

        }

        private void ServerMainPage_Shown(object sender, EventArgs e)
        {

        }

        private void buttonStart_VisibleChanged(object sender, EventArgs e)
        {
            // random quality
            setQuality();

            // start sever
            SocketUtil.StartThreadServer();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {

        }

        private void ServerMainPage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void setQuality()
        {
            Random rnd = new Random();
            List<int> qualityList = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                int quality = rnd.Next() % 5 + 1;
                qualityList.Add(quality);
            }
            SocketUtil.memoryModel.setQualityList(qualityList);
        }

        private void ServerMainPage_Load_1(object sender, EventArgs e)
        {

        }
    }
}
