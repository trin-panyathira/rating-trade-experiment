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
    public partial class ClientFinalPage : Form
    {
        public ClientFinalPage()
        {
            InitializeComponent();
        }

        private void ClientFinalPage_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void ClientFinalPage_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                SocketUtil.memoryModel.clientFinalPage = this;

                // Set Actual Payment
                try
                {
                    decimal actualPaymentAmount = CalculateActualPayment();
                    labelActualPayment.Text = "Actual Payment is " + actualPaymentAmount + " THB";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Set Actual Payment : {0}", ex.ToString());
                }

                // Send Result to Host
                SendResultToHost(SocketUtil.memoryModel.buyingModelList);
            }
        }

        private decimal CalculateActualPayment()
        {
            // Create index list for random without duplicate
            List<int> indexList = new List<int>();
            for (int i = 0; i < SocketUtil.memoryModel.qualityExperimentList.Count; i++)
            {
                indexList.Add(i);
            }

            int randomRoundQty = 3;
            List<int> randomPayoffIndex = new List<int>();
            for (int i = 0; i < randomRoundQty; i++)
            {
                Random rnd = new Random();
                int randomIndex = rnd.Next() % indexList.Count();
                int index = indexList.ElementAt(randomIndex);

                randomPayoffIndex.Add(index);
                indexList.Remove(index);
            }

            // Sum random payoff
            decimal sumRandomPayoff = 0;
            randomPayoffIndex.ForEach(index =>
            {
                sumRandomPayoff = sumRandomPayoff + SocketUtil.memoryModel.buyingModelList.ElementAt(index).payoff;
            });

            // Avg random payoff
            return sumRandomPayoff / randomRoundQty;
        }

        private void SendResultToHost(List<BuyingModel> modelList)
        {
            List<string> resultList = modelList.Select(model =>
            {
                return model.round + "," +
                    model.quality + "," +
                    model.rating + "," +
                    model.buy + "," +
                    model.claim + "," +
                    model.feedback + "," +
                    model.payoff + "," +
                    model.rebase + "," +
                    model.epp;
            }).ToList();

            string resultMessage = String.Join("|", resultList);
            SocketUtil.SendMessageToHost(SocketUtil.GetLocalIPAddress(), SEND_RESULT, resultMessage);
        }
    }
}
