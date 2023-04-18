using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class MemoryModel
    {
        public ServerMainPage serverMainPage = null;

        public ClientMainPage clientMainPage = null;
        public ClientExperimentPage clientExperimentPage = null;

        public List<int> qualityTestList { get; set; } = new List<int>();
        public List<int> qualityExperimentList { get; set; } = new List<int>();
        public int rebase { get; set; }
    }
}
