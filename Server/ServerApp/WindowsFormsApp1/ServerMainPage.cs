﻿using System;
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

            // set Initiate value
            textBoxTestRound.Text = "5";
            textBoxExperimentRound.Text = "20";
            labelServerAddress.Text = "Server Address: " + SocketUtil.GetLocalIPAddress();

            // start sever
            SocketUtil.isServer = true;
            SocketUtil.StartThreadServer(this);
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

        delegate void AddListBoxActivityCallback(Form f, string text);

        public void addListBoxActivity(Form form, string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (form.InvokeRequired)
            {
                AddListBoxActivityCallback d = new AddListBoxActivityCallback(addListBoxActivity);
                form.Invoke(d, new object[] { form, text });
            }
            else
            {
                listBoxActivity.Items.Insert(0, text);
            }
        }

        public void addListBoxUser(string ipv4) 
        { 
            if(listBoxUser.Items.IndexOf(ipv4) == -1)
                listBoxUser.Items.Add(ipv4);
        }

        delegate void AddListBoxUserCallback(Form f, string ipv4);
        public void addListBoxUser(Form form, string ipv4)
        {
            if (form.InvokeRequired)
            {
                AddListBoxUserCallback d = new AddListBoxUserCallback(addListBoxUser);
                form.Invoke(d, new object[] { form, ipv4 });
            }
            else
            {
                if (listBoxUser.Items.IndexOf(ipv4) == -1)
                    listBoxUser.Items.Add(ipv4);
            }
        }

        delegate void RemoveListBoxUserCallback(Form f, string ipv4);
        public void removeListBoxUser(Form form, string ipv4)
        {
            if (form.InvokeRequired)
            {
                RemoveListBoxUserCallback d = new RemoveListBoxUserCallback(removeListBoxUser);
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
