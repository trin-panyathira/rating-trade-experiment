using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppServer
{
    internal class MemoryModel
    {
        private List<int> qualityList { get; set; } = new List<int>();

        public void setQualityList(List<int> qualityList)
        {
            this.qualityList = qualityList;
        }

        public List<int> getQualityList()
        {
            return this.qualityList;
        }
    }
}
