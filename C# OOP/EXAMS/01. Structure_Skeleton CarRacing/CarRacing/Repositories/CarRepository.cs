using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System.Linq;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {

        private readonly List<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>(); 
        }

        public IReadOnlyCollection<ICar> Models => new List<ICar>(models);

        public void Add(ICar model)
        {
            if (model is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidAddCarRepository));
            }

            this.models.Add(model);

        }

        public ICar FindBy(string property)
        {
            return Models.FirstOrDefault(m => m.VIN == property);
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }
    }
}
