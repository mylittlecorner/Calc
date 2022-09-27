using System;
using System.Xml.Serialization;

namespace Calc
{
    [Serializable]
    public class Data //field names present in our xml file
    {
        public string DateTime { get; set; }
        public string Calc { get; set; }
    }
}