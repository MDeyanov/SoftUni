namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var result = context.Genres
                .ToList()// da go ka4a tuka
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games.Select(g => new
                    {
                        Id = g.Id,
                        Title = g.Name,
                        Developer = g.Developer.Name,
                        Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
                        Players = g.Purchases.Count(),
                    })
                        .Where(g => g.Players > 0)
                       .OrderByDescending(g => g.Players)
                       .ThenBy(g => g.Id),
                    // .ToList()
                    TotalPlayers = x.Games.Sum(x => x.Purchases.Count())
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();

            return JsonConvert.SerializeObject(result, Formatting.Indented);


        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            //var result = context.Users.ToList().Where(x => x.Cards.Any(c => c.Purchases.Any()))
            //   .Select(x => new UsersViewModel
            //   {
            //       Username = x.Username,
            //       TotalSpent = x.Cards
            //                        .Sum(c => c.Purchases.Where(t => t.Type.ToString() == storeType)
            //                        .Sum(p => p.Game.Price)),
            //       Purchases = x.Cards.SelectMany(c => c.Purchases)
            //                        .Select(x => new PurchasesViewModel
            //                        {
            //                            Card = x.Card.Number,
            //                            Cvc = x.Card.Cvc,
            //                            Date = x.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
            //                            Game = new GameModelView
            //                            {
            //                                Title = x.Game.Name,
            //                                Genre = x.Game.Genre.Name,
            //                                Price = x.Game.Price,
            //                            },

            //                        })
            //                        .OrderBy(x => x.Date)
            //                        .ToArray()
            //   })
            //   .OrderByDescending(x => x.TotalSpent)
            //   .ThenBy(x => x.Username)
            //   .ToArray();

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(UsersViewModel[]), new XmlRootAttribute("Users"));


            //XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //ns.Add("", "");
            //var sw = new StringWriter();
            //xmlSerializer.Serialize(sw, result, ns);
            //return sw.ToString();
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("Users");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportUserDto[]), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            using StringWriter sw = new StringWriter(sb);

            PurchaseType purchaseTypeEnum = Enum.Parse<PurchaseType>(storeType);

            var users = context.Users
                .ToArray()
                .Where(u => u.Cards.Any(c => c.Purchases.Any()))
                .Select(u => new ExportUserDto()
                {
                    Username = u.Username,
                    Purchases = context.Purchases
                        .ToArray()
                        .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseTypeEnum)
                        .OrderBy(p => p.Date)
                        .Select(p => new PurchasesViewModel()
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new GameModelView()
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price
                            }
                        })
                        .ToArray(),
                    TotalSpent = context.Purchases
                        .ToArray()
                        .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseTypeEnum)
                        .Sum(p => p.Game.Price)
                })
                .Where(u => u.Purchases.Length > 0)
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            serializer.Serialize(sw, users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}