namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using TeisterMask.DataProcessor;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var playsXml = XmlConverter.Deserializer<PlaysInputModel>(xmlString, "Plays");

            List<Play> plays = new List<Play>();

            foreach (var playsDto in playsXml)
            {
                if (!IsValid(playsDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDurationValid = TimeSpan
                    .TryParseExact(playsDto.Duration, "c", CultureInfo.InvariantCulture,
                    TimeSpanStyles.None, out TimeSpan durationValue);

                if (!isDurationValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (durationValue.TotalHours <= 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isGenreValid = Enum.TryParse(playsDto.Genre, out Genre genre);

                if (!isGenreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play()
                {
                    Title = playsDto.Title,
                    Duration = durationValue,
                    Rating = playsDto.Rating,
                    Genre = genre,
                    Description = playsDto.Description,
                    Screenwriter = playsDto.Screenwriter
                };
                plays.Add(play);
                sb.AppendLine(string.Format
                    (SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }
            context.Plays.AddRange(plays);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var castsXml = XmlConverter.Deserializer<CastInputModel>(xmlString, "Casts");
            List<Cast> casts = new List<Cast>();

            foreach (var castXml in castsXml)
            {
                if (!IsValid(castXml))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast()
                {
                    FullName = castXml.FullName,
                    IsMainCharacter = castXml.IsMainCharacter,
                    PhoneNumber = castXml.PhoneNumber,
                    PlayId = castXml.PlayId
                };
                var character = cast.IsMainCharacter == false ? "lesser" : "main";
                casts.Add(cast);
                sb.AppendLine(string.Format
                   (SuccessfulImportActor,cast.FullName,character));
            }
            context.Casts.AddRange(casts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var theatersJson = JsonConvert.DeserializeObject<IEnumerable<TheatreAndTicketsInputModel>>(jsonString);

            var theaters = new List<Theatre>();

            foreach (var theater in theatersJson)
            {
                if (!IsValid(theater))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theatre = new Theatre()
                {
                    Name = theater.Name,
                    NumberOfHalls = theater.NumberOfHalls,
                    Director = theater.Director,                   
                };

                foreach (var ticket in theater.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticketModel = new Ticket()
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId
                    };
                    theatre.Tickets.Add(ticketModel);
                }
                theaters.Add(theatre);
                sb.AppendLine(string.Format
                   (SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }
            context.Theatres.AddRange(theaters);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
