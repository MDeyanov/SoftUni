namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .ToArray()
                .Where(x => x.NumberOfHalls >= numbersOfHalls)
                .Where(x => x.Tickets.Count >= 20)
                .Select(h => new
                {
                    Name = h.Name,
                    Halls = h.NumberOfHalls,
                    TotalIncome = h.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(p => p.Price),
                    Tickets = h.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                                        .Select(x => new
                                        {
                                            Price = x.Price,
                                            RowNumber = x.RowNumber
                                        })
                                        .OrderByDescending(x => x.Price)
                                        .ToArray()

                })
                .OrderByDescending(h => h.Halls)
                .ThenBy(h => h.Name);

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(PlaysDtoExport[]), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            using StringWriter sw = new StringWriter(sb);

            var result = context.Plays
                .ToArray()
                .Where(p => p.Rating <= (float)rating)
                .Select(x => new PlaysDtoExport()
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts
                              .ToArray()
                              .Where(c => c.IsMainCharacter == true).Select(c => new ActorsExportDto()
                              {
                                  FullName = c.FullName,
                                  MainCharacter = $"Plays main character in '{c.Play.Title}'."
                              })
                              .OrderByDescending(x => x.FullName)
                              .ToArray()
                })
                .OrderBy(x=>x.Title)
                .ThenByDescending(x=>x.Genre)
                .ToArray();

            serializer.Serialize(sw, result, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
