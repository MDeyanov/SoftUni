﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class PlaysInputModel
    {
        [XmlElement("Title")]
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Title { get; set; }

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }

        [XmlElement("Rating")]
        [Required]
        [Range(0.00,10.00)]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        [EnumDataType(typeof(Genre))]
        [Required]
        public string Genre { get; set; }

        [XmlElement("Description")]
        [Required]
        [StringLength(700)]// ne se znae
        public string Description { get; set; }

        [XmlElement("Screenwriter")]
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Screenwriter { get; set; }
    }
}
//•	Id – integer, Primary Key
//•	Title – text with length [4, 50] (required)
//•	Duration – TimeSpan in format
//{ hours: minutes: seconds}, with a minimum length of 1 hour. (required)
//•	Rating – float in the range[0.00….10.00] (required)
//•	Genre – enumeration of type Genre, with possible values (Drama, Comedy, Romance, Musical) (required)
//•	Description – text with length up to 700 characters (required)
//•	Screenwriter – text with length [4, 30] (required)
//•	Casts - a collection of type Cast
//•	Tickets - a collection of type Ticket
