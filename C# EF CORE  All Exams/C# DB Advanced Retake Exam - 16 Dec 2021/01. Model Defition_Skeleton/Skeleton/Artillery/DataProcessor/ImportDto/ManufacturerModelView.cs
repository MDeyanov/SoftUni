﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ManufacturerModelView
    {
        [XmlElement("ManufacturerName")]
        [Required]
        [StringLength(40, MinimumLength = 4)]
         
        public string ManufacturerName { get; set; }

        [XmlElement("Founded")]
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Founded { get; set; }
    }
}
//•	Id – integer, Primary Key
//•	ManufacturerName – unique text with length [4…40] (required)
//•	Founded – text with length [10…100] (required)
//•	Guns – a collection of Gun
