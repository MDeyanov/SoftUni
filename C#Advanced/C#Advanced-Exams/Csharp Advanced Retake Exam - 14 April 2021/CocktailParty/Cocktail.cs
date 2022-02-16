using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CocktailParty
{
    public class Cocktail
    {
        private readonly List<Ingredient> ingredients;
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int MaxAlcoholLevel { get; private set; }
        public int CurrentAlcoholLevel => this.ingredients.Sum(x => x.Alcohol);
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            ingredients = new List<Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public void Add(Ingredient ingredient)
        {
            bool existingIngredient = !ingredients.Exists(x => x.Name == ingredient.Name);
            bool alcoholLimit = MaxAlcoholLevel >= ingredient.Alcohol;
            bool haveSpot = Capacity > ingredients.Count;
            if (existingIngredient && alcoholLimit && haveSpot)
            {
                ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            return ingredients.Remove(ingredients.FirstOrDefault(x => x.Name == name));
        }

        public Ingredient FindIngredient(string name)
        {
            return ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            for (int i = 0; i < ingredients.Count; i++)
            {
                sb.AppendLine($"{ingredients[i]}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
