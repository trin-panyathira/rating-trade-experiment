using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
            comboBoxRebate.SelectedIndex = 0;
            textBoxPayoffDivideRate.Text = "1";
            labelServerAddress.Text = "Server Address: " + SocketUtil.GetLocalIPAddress();
        }

        private void ServerMainPage_Shown(object sender, EventArgs e)
        {

        }

        private void buttonStart_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                SocketUtil.memoryModel.serverMainPage = this;
                SocketUtil.memoryModel.clientSubmittedModelList = new List<ClientSubmittedModel>();

                // start sever
                SocketUtil.isServer = true;
                SocketUtil.StartThreadServer();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            listBoxActivity.Items.Insert(0, "Payoff Rate: " + textBoxPayoffDivideRate.Text);
            listBoxActivity.Items.Insert(0, "Rebate: " + (comboBoxRebate.SelectedIndex == 1 ? "yes" : "no"));
            listBoxActivity.Items.Insert(0, "Test Round: " + textBoxTestRound.Text);
            listBoxActivity.Items.Insert(0, "Experiment Round: " + textBoxExperimentRound.Text);
            listBoxActivity.Items.Insert(0, "Start Experiment");

            int testRound = 0;
            try
            {
                testRound = int.Parse(textBoxTestRound.Text);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("testRound can't convert to number.");
                listBoxActivity.Items.Insert(0, "Warnning! : testRound can't convert to number.");
                return;
            }

            int experimentRound = 0;
            try
            {
                experimentRound = int.Parse(textBoxExperimentRound.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("experimentRound can't convert to number.");
                listBoxActivity.Items.Insert(0, "Warnning! : experimentRound can't convert to number.");
                return;
            }

            decimal payoffDivideRate = 1;
            try
            {
                payoffDivideRate = decimal.Parse(textBoxPayoffDivideRate.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("payoffDivideRate can't convert to number.");
                listBoxActivity.Items.Insert(0, "Warnning! : payoffDivideRate can't convert to number.");
                return;
            }

            // Use this for random same quality each person
            #region
            //List<int> qualityList = randomQuality(testRound + experimentRound);
            //string randomQualityMessage = testRound + "," + experimentRound + "," + string.Join(",", qualityList);

            //for (int i = 0; i < listBoxUser.Items.Count; i++)
            //{
            //    SocketUtil.SendMessageToHost(listBoxUser.Items[i].ToString(), SET_QUALITY_LIST, randomQualityMessage);
            //    SocketUtil.SendMessageToHost(listBoxUser.Items[i].ToString(), SET_Rebate, comboBoxRebate.SelectedIndex.ToString());
            //    SocketUtil.SendMessageToHost(listBoxUser.Items[i].ToString(), SET_START, "");

            //    listBoxActivity.Items.Insert(0, "User " + listBoxUser.Items[i].ToString() + " started");
            //}
            #endregion

            // Use this for random unique quality each person
            #region
            for (int i = 0; i < listBoxUser.Items.Count; i++)
            {
                List<int> qualityList = randomQuality(testRound + experimentRound);
                string randomQualityMessage = testRound + "," + experimentRound + "," + string.Join(",", qualityList);

                SocketUtil.SendMessageToHost(listBoxUser.Items[i].ToString(), SET_QUALITY_LIST, randomQualityMessage);
                SocketUtil.SendMessageToHost(listBoxUser.Items[i].ToString(), SET_REBASE, comboBoxRebate.SelectedIndex.ToString());
                SocketUtil.SendMessageToHost(listBoxUser.Items[i].ToString(), SET_PAYOFF_DIVIDE_RATE, textBoxPayoffDivideRate.Text);
                SocketUtil.SendMessageToHost(listBoxUser.Items[i].ToString(), SET_START, "");

                listBoxActivity.Items.Insert(0, "User " + listBoxUser.Items[i].ToString() + " started");
            }
            #endregion

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            listBoxActivity.Items.Insert(0, "Stop Experiment.");


            // Save excel by thread
            ExcelUtil.ExportSummaryExcel(SocketUtil.memoryModel.clientSubmittedModelList);
            SocketUtil.memoryModel.clientSubmittedModelList.Clear();

            for (int i = 0; i < listBoxUser.Items.Count; i++)
            {
                SocketUtil.SendMessageToHost(listBoxUser.Items[i].ToString(), SET_STOP, "");
            }
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
                listBoxActivity.Items.Add(text);
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
