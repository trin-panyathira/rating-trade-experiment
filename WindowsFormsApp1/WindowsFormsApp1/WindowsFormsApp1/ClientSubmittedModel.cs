using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class ClientSubmittedModel
    {
        public string address { get; set; }
        public List<BuyingModel> buyingModelList { get; set; }
    }
}
