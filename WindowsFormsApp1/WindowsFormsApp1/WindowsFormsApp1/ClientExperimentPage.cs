using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
            if (this.Visible == true)
            {
                SocketUtil.memoryModel.clientExperimentPage = this;

                setExperiment();
                startNextRound();
            }
        }

        private void startTimer(int second)
        {
            labelTimer.Text = second.ToString();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int currentTime = int.Parse(labelTimer.Text);

            if (currentTime > 0)
                labelTimer.Text = (currentTime - 1).ToString();
            else
            {
                timer1.Stop();

                saveRoundData(buyingModel);
                startNextRound();
            }
        }

        List<int> qualityList;
        int curQuality = 0;
        int curRound = 0;
        decimal curRating = 0;
        private void setExperiment() 
        {
            // classify qualityList (Test/Real)
            if (SocketUtil.memoryModel.isTest)
                qualityList = SocketUtil.memoryModel.qualityTestList;
            else 
                qualityList = SocketUtil.memoryModel.qualityExperimentList;

            curRound = 0;
            curRating = -1;

            // reset buyingModelList
            SocketUtil.memoryModel.buyingModelList = new List<BuyingModel>();
        }

        BuyingModel buyingModel;
        private void startNextRound()
        {
            int lastRound = qualityList.Count;
            if (curRound == lastRound)
            {
                // Finish Experiment
                if (SocketUtil.memoryModel.isTest)
                {
                    timer1.Stop();

                    ClientWaitingPage page = new ClientWaitingPage();
                    page.Show();
                    this.Hide();
                }
                else
                {
                    timer1.Stop();

                    ClientFinalPage page = new ClientFinalPage();
                    page.Show();
                    this.Hide();
                }

                return;
            }

            curRound = curRound + 1;
            labelRound.Text = "" + curRound;
            curQuality = qualityList.ElementAt(curRound - 1);

            // calculate rating
            if (curRound == 1)
            {
                curRating = -1;
            }
            else if (curRound <= 5)
            {
                // random rating for first 5 rounds
                Random rnd = new Random();

                int maxRating = 5;
                curRating = (rnd.Next() % maxRating) + 1;
            }
            else
            {
                int passedRound = curRound - 1;
                int countRoundFeedback = passedRound > 5 ? 5 : passedRound;
                decimal sumFeedback = 0;
                int countFeedback = 0;
                for (int i = 0; i < countRoundFeedback; i++)
                {
                    int lastList = SocketUtil.memoryModel.buyingModelList.Count;
                    int beforeFeedback = SocketUtil.memoryModel.buyingModelList.ElementAt(lastList - i - 1).feedback;

                    // skip calculate feeback if user don't select feedback that round then use next feedback
                    if (beforeFeedback <= 0 && countRoundFeedback < passedRound)
                    {
                        countRoundFeedback = countRoundFeedback + 1;
                        continue;
                    }
                    else if (beforeFeedback <= 0 && countRoundFeedback == passedRound)
                    {
                        break;
                    }

                    sumFeedback = sumFeedback + beforeFeedback;
                    countFeedback = countFeedback + 1;
                }

                if (countFeedback > 0)
                    curRating = sumFeedback / countFeedback;
                else
                    curRating = -1;
            }

            buyingModel = new BuyingModel();
            buyingModel.round = curRound;
            buyingModel.quality = curQuality;
            buyingModel.rating = curRating;
            buyingModel.buy = -1;
            buyingModel.claim = -1;
            buyingModel.payoff = 0;
            buyingModel.feedback = -1;
            buyingModel.rebate = SocketUtil.memoryModel.rebate;
            buyingModel.epp = 0;

            // Set Interface
            setState(stateBuy);

            startTimer(60);
        }

        string curState = "";
        string nextState = "";
        string stateBuy = "BUY";
        string stateClaim = "CLAIM";
        string stateFeedBack = "FEEDBACK";
        string statePayOff = "PAYOFF";
        private void setState(string state)
        {
            curState = state;
            if (state == stateBuy)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;

                labelRating1.Visible = true;
                if (curRating <= 0)
                    labelRating1.Text = "Seller don't have rating";
                else
                    labelRating1.Text = "Seller’s Rating is " + curRating.ToString("F");

                labelQuality1.Visible = false;

                labelQuestion1.Visible = true;
                labelQuestion1.Text = "Do you wants to place buying order?";

                nextState = stateClaim;
            }
            else if (state == stateClaim)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;

                labelQuality1.Visible = true;
                labelQuality1.Text = "Quality is " + curQuality;

                labelQuestion1.Visible = true;
                labelQuestion1.Text = "Do you wants to Claim?";

                nextState = stateFeedBack;
            }
            else if (state == stateFeedBack)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                groupBox3.Visible = false;

                if (SocketUtil.memoryModel.rebate == 1)
                    labelRewardRebate.Visible = true;
                else
                    labelRewardRebate.Visible = false;

                nextState = statePayOff;
            }
            else if (state == statePayOff)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;

                int cost = 1200;
                int payoff = 0;
                if (buyingModel.buy == 1)
                {
                    payoff = 1100 + (curQuality * 100);
                    if (buyingModel.claim > 0)
                        payoff = 1600 - 100;

                    payoff = payoff - cost;

                    if (buyingModel.rebate == 1 && buyingModel.feedback > 0)
                        payoff = payoff + 100;
                }

                buyingModel.payoff = payoff;
                labelPayoff.Text = "Your Payoff For This Round " + payoff;

                nextState = null;
            }
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            if (curState == stateBuy)
            {
                buyingModel.buy = 1;
            }
            else if (curState == stateClaim)
            {
                buyingModel.claim = 1;
            }

            setState(nextState);
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            if (curState == stateBuy)
            {
                buyingModel.buy = 0;
                nextState = statePayOff;
            }
            else if (curState == stateClaim)
            {
                buyingModel.claim = 0;
            }

            setState(nextState);
        }

        private void saveRoundData(BuyingModel buyingModel)
        {
            SocketUtil.memoryModel.buyingModelList.Add(buyingModel);
        }

        private void buttonRating0_Click(object sender, EventArgs e)
        {
            buyingModel.feedback = 0;
            setState(nextState);
        }

        private void buttonRating1_Click(object sender, EventArgs e)
        {
            buyingModel.feedback = 1;
            setState(nextState);
        }

        private void buttonRating2_Click(object sender, EventArgs e)
        {
            buyingModel.feedback = 2;
            setState(nextState);
        }

        private void buttonRating3_Click(object sender, EventArgs e)
        {
            buyingModel.feedback = 3;
            setState(nextState);
        }

        private void buttonRating4_Click(object sender, EventArgs e)
        {
            buyingModel.feedback = 4;
            setState(nextState);
        }

        private void buttonRating5_Click(object sender, EventArgs e)
        {
            buyingModel.feedback = 5;
            setState(nextState);
        }

        private void buttonNextRound_Click(object sender, EventArgs e)
        {
            saveRoundData(buyingModel);
            startNextRound();
        }

        private void labelQuestion1_Click(object sender, EventArgs e)
        {

        }

        //delegate void ActivityCallback(Form f, string text);

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
