using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly List<IRacer> racers;
        public RacerRepository()
        {
            this.racers = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => new List<IRacer>(racers);

        public void Add(IRacer model)
        {
            if (model is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidAddRacerRepository));
            }

            racers.Add(model);
        }

        public IRacer FindBy(string property)
        {
            IRacer racer = null;
            if (racers.Any(r=>r.Username == property))
            {
                racer = racers.First(t => t.Username == property);
            }
            return racer;
        }

        public bool Remove(IRacer model)
        {
            return racers.Remove(model);
        }
    }
}
