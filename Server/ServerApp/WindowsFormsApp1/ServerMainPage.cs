﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.Constant;

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
            // set Initiate value
            textBoxTestRound.Text = "5";
            textBoxExperimentRound.Text = "20";
            comboBoxRebase.SelectedIndex = 0;
            labelServerAddress.Text = "Server Address: " + SocketUtil.GetLocalIPAddress();
        }

        private void ServerMainPage_Shown(object sender, EventArgs e)
        {

        }

        private void buttonStart_VisibleChanged(object sender, EventArgs e)
        {
            // start sever
            SocketUtil.isServer = true;
            SocketUtil.memoryModel.serverMainPage = this;
            SocketUtil.StartThreadServer();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int testRound = 0;
            int experimentRound = 0;
            try
            {
                testRound = int.Parse(textBoxTestRound.Text);
                experimentRound = int.Parse(textBoxExperimentRound.Text);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("testRound or experimentRound can't convert to number.");
            }

            List<int> qualityList = randomQuality(testRound + experimentRound);
            string randomQualityMessage = testRound + "," + experimentRound + "," + string.Join(",", qualityList);

            for (int i = 0; i < listBoxUser.Items.Count; i++)
            {
                SocketUtil.SendMessageToHost(listBoxUser.Items[i].ToString(), SET_QUALITY_LIST, randomQualityMessage);
                SocketUtil.SendMessageToHost(listBoxUser.Items[i].ToString(), SET_REBASE, comboBoxRebase.SelectedIndex.ToString());
                SocketUtil.SendMessageToHost(listBoxUser.Items[i].ToString(), SET_START, "");
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {

        }

        private void ServerMainPage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private List<int> randomQuality(int qty)
        {
            Random rnd = new Random();
            List<int> qualityList = new List<int>();
            for (int i = 0; i < qty; i++)
            {
                int quality = rnd.Next() % 5 + 1;
                qualityList.Add(quality);
            }
            return qualityList;
        }

        delegate void ActivityCallback(Form f, string text);

        public void addListBoxActivity(Form form, string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (form.InvokeRequired)
            {
                ActivityCallback d = new ActivityCallback(addListBoxActivity);
                form.Invoke(d, new object[] { form, text });
            }
            else
            {
                listBoxActivity.Items.Insert(0, text);
            }
        }

        public void addListBoxUser(Form form, string ipv4)
        {
            if (form.InvokeRequired)
            {
                ActivityCallback d = new ActivityCallback(addListBoxUser);
                form.Invoke(d, new object[] { form, ipv4 });
            }
            else
            {
                if (listBoxUser.Items.IndexOf(ipv4) == -1)
                    listBoxUser.Items.Add(ipv4);
            }
        }

        public void removeListBoxUser(Form form, string ipv4)
        {
            if (form.InvokeRequired)
            {
                ActivityCallback d = new ActivityCallback(removeListBoxUser);
                form.Invoke(d, new object[] { form, ipv4 });
            }
            else
            {
                if (listBoxUser.Items.IndexOf(ipv4) != -1)
                    listBoxUser.Items.Remove(ipv4);
            }
        }
    }
}
