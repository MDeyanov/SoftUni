namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();

			var games = JsonConvert.DeserializeObject<IEnumerable<GamesInputModel>>(jsonString);

            foreach (var game in games)
            {
                if (!IsValid(game) ||
					!game.Tags.Any())
                {
					sb.AppendLine("Invalid Data");
					continue;
				}
				var releaseDate = DateTime.ParseExact(
					game.ReleaseDate,
					"yyyy-MM-dd",
					CultureInfo.InvariantCulture);
				var genre = context.Genres.FirstOrDefault(x => x.Name == game.Genre);
                if (genre == null)
                {
					genre = new Genre { Name = game.Genre };
				}

				var developer = context.Developers.FirstOrDefault(x => x.Name == game.Developer)
					?? new Developer { Name = game.Developer };
				// tova e sushtoto kato gornoto s if proverkata tezi ?? ozna4avat ako e null go syzdai ako li ne si ostava 

				var gameForGames = new Game
				{
					Name = game.Name,
					Price = game.Price,
					ReleaseDate = releaseDate,
					Developer = developer,
					Genre = genre,
				};
                foreach (var jsonGameTag in game.Tags)
                {
					var tag = context.Tags.FirstOrDefault(x => x.Name == jsonGameTag)
						?? new Tag { Name = jsonGameTag };

					gameForGames.GameTags.Add(new GameTag { Tag = tag });
                }

				context.Games.Add(gameForGames);
				context.SaveChanges();
				sb.AppendLine($"Added {game.Name} ({game.Genre}) with {game.Tags.Count()} tags");
            }

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();
			var usersJson = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(jsonString);

            foreach (var user in usersJson)
            {
                if (!IsValid(user) ||
					!user.Cards.Any())
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var userCreation = new User
				{
					FullName = user.FullName,
					Username = user.Username,
					Email = user.Email,
					Age = user.Age,
					Cards = user.Cards.Select(c => new Card
					{
						Number = c.Number,
						Cvc = c.Cvc,
						Type =  Enum.Parse<CardType>(c.Type)
					}).ToList()
				};

				context.Users.Add(userCreation);
				context.SaveChanges();
				sb.AppendLine($"Imported {user.Username} with {user.Cards.Count()} cards");
            }
			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var sb = new StringBuilder();
			var purchasesXml = XmlConverter.Deserializer<PurchaseInputModel>(xmlString, "Purchases");

            foreach (var purchase in purchasesXml)
            {
                if (!IsValid(purchase))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var dateAndTime = DateTime.ParseExact(
					purchase.Date,
					"dd/MM/yyyy HH:mm",
					CultureInfo.InvariantCulture);

				var newPurchase = new Purchase
				{
					Type = Enum.Parse<PurchaseType>(purchase.Type),
					ProductKey = purchase.Key,
					Date = dateAndTime,
				};

				newPurchase.Card = context.Cards.FirstOrDefault(x => x.Number == purchase.Card);

				newPurchase.Game = context.Games.FirstOrDefault(x => x.Name == purchase.Title);

				context.Purchases.Add(newPurchase);
				context.SaveChanges();

				var userName = context.Users.FirstOrDefault(x => x.Id == newPurchase.Card.UserId);
				// ili var userName = context.Users.Where(x => x.Id == newPurchase.Card.UserId)
				// .Select(x=>x.Username).FirstOrDefault();
				sb.AppendLine($"Imported {purchase.Title} for {userName.Username}");
            }

			return sb.ToString().TrimEnd();
        }

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}