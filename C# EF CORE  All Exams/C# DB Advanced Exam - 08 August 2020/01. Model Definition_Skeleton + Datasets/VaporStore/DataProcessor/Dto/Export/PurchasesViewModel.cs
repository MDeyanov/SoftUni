//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Xml.Serialization;

//namespace VaporStore.DataProcessor.Dto.Export
//{
//    [XmlType("Purchase")]
//    public class PurchasesViewModel
//    {
//        [XmlElement("Card")]
//        public string Card { get; set; }

//        [XmlElement("Cvc")]
//        public string CVC { get; set; }

//        [XmlElement("Date")]
//        public string Date { get; set; }

//        [XmlElement("Game")]
//        public GameModelView Game { get; set; }
//    }
//}
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Purchase")]
    public class PurchasesViewModel
    {
        [XmlElement("Card")]
        public string Card { get; set; }

        [XmlElement("Cvc")]
        public string Cvc { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

        [XmlElement("Game")]
        public GameModelView Game { get; set; }
    }
}