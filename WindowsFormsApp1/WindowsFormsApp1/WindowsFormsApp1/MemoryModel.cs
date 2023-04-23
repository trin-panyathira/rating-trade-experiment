using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class MemoryModel
    {
        // Server
        public ServerMainPage serverMainPage = null;
        public List<ClientSubmittedModel> clientSubmittedModelList = null;

        // Client
        public ClientMainPage clientMainPage = null;
        public ClientExperimentPage clientExperimentPage = null;
        public ClientWaitingPage clientWaitingPage = null;
        public ClientFinalPage clientFinalPage = null;

        public List<BuyingModel> buyingModelList = null;

        public List<int> qualityTestList { get; set; } = new List<int>();
        public List<int> qualityExperimentList { get; set; } = new List<int>();
        public int rebate { get; set; }
        public bool isTest { get; set; } = false;
        public decimal payoffDivideRate { get; set; } = 1;
    }
}
