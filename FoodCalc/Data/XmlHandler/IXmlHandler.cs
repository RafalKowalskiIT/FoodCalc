using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Data.XmlHandler
{
    public interface IXmlHandler
    {
        void QueryXml();
        void CreateXml(string description);
       
    }
}
