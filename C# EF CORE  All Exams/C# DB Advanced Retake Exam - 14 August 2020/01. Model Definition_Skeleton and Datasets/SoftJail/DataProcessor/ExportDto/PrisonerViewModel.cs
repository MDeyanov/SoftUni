using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class PrisonerViewModel
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public EncryptedMessageViewModel[] EncryptedMessages { get; set; }
    }
}

//< Prisoner > -- xml type
//    < Id > 3 </ Id > -- xml element
//    < Name > Binni Cornhill </ Name > -- xml element

//       < IncarcerationDate > 1967 - 04 - 29 </ IncarcerationDate > -- xml element

//       < EncryptedMessages > -- xml Array -- i pravq nov class

//         < Message >

//           < Description > !? sdnasuoht evif - ytnewt rof deksa uoy ro orez artxe na ereht sI</Description>
//      </Message>
//    </EncryptedMessages>
//  </Prisoner>

