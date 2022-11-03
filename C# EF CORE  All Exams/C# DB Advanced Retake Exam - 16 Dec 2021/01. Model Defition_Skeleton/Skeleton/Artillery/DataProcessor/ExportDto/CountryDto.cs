using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Country")]
    public class CountryDto
    {
        [XmlAttribute(nameof(Country))]
        public string Country { get; set; }

        [XmlAttribute(nameof(ArmySize))]
        public int ArmySize { get; set; }
    }
}
