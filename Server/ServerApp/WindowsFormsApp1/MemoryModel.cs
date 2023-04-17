using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class MemoryModel
    {
        public List<int> qualityTestList { get; set; } = new List<int>();
        public List<int> qualityExperimentList { get; set; } = new List<int>();

        //public void setQualityList(List<int> qualityList)
        //{
        //    this.qualityList = qualityList;
        //}

        //public List<int> getQualityList()
        //{
        //    return this.qualityList;
        //}
    }
}
