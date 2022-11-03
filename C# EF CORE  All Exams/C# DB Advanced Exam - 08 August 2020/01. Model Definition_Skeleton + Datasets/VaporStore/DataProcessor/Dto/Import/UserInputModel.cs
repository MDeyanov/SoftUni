using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserInputModel
    {
        [Required]
        [RegularExpression(@"(\b[A-Z][a-z]+) ([A-Z][a-z]+)\b")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3,103)]
        public int Age { get; set; }

        public IEnumerable<CardsInputModel> Cards { get; set; }
    }

    public class CardsInputModel
    {
        [Required]
        [RegularExpression(@"(\d{4}) (\d{4}) (\d{4}) (\d{4})")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"\b[0-9]{3}\b")]
        public string Cvc { get; set; }

        [Required]
        [EnumDataType(typeof(CardType))]
        public string Type { get; set; }
    }
}
//"FullName": "Invalid Invalidman",
//		"Username": "",
//		"Email": "invalid@invalid.com",
//		"Age": 20,
//		"Cards": [
//			{
//				"Number": "1111 1111 1111 1111",
//				"CVC": "111",
//				"Type": "Debit"
//			}
//		]

//•	Id – integer, Primary Key
//•	Username – text with length [3, 20] (required)
//•	FullName – text, which has two words, consisting of Latin letters. Both start with an upper letter and are followed by lower letters. The two words are separated by a single space (ex. "John Smith") (required)
//•	Email – text(required)
//•	Age – integer in the range[3, 103] (required)
//•	Cards – collection of type Card

//Number – text, which consists of 4 pairs of 4 digits, separated by spaces (ex. “1234 5678 9012 3456”) (required)
//•	Cvc – text, which consists of 3 digits (ex. “123”) (required)
//•	Type – enumeration of type CardType, with possible values (“Debit”, “Credit”) (required)