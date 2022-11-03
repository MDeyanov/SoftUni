using Artillery.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class ExportGunsDto
    {
        [XmlAttribute("Manufacturer")]
        public string Manufacturer { get; set; }

        [XmlAttribute("GunType")]
        //[EnumDataType(typeof(GunType))]
        public string GunType { get; set; }

        [XmlAttribute("GunWeight")]
        public int GunWeight { get; set; }

        [XmlAttribute("BarrelLength")]
        public double BarrelLength { get; set; }

        [XmlAttribute("Range")]
        public int Range { get; set; }

        [XmlArray("Countries")]
        public CountryDto[] Countries { get; set; }

    }

    //[XmlType("Country")]
    //public class CountryDto
    //{
    //    [XmlAttribute("Country")]
    //    public string CountryName { get; set; }

    //    [XmlAttribute("ArmySize")]
    //    public int ArmySize { get; set; }
    //}
}
