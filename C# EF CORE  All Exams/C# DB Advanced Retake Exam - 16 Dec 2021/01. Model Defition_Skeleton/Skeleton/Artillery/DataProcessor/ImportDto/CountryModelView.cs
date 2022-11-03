using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class CountryModelView
    {
        [XmlElement("CountryName")]
        [Required]
        [StringLength(60, MinimumLength = 4)]
        public string CountryName { get; set; }

        [XmlElement("ArmySize")]
        [Range(50000,10000000)]
        public int ArmySize { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	CountryName – text with length [4, 60] (required)
//•	ArmySize – integer in the range[50_000….10_000_000] (required)
//•	CountriesGuns – a collection of CountryGun
