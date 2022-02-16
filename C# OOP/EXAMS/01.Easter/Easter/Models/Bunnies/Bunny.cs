using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Easter.Utilities.Messages;
using System.Linq;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;

        public Bunny(string name,int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.Dyes = new List<IDye>();
        }
        public string Name         
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                this.name = value;
            }
        }

        public int Energy { get; protected set; }

        public ICollection<IDye> Dyes { get; }

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }

        public virtual void Work()
        {
            Energy -= 10;
            if (Energy < 0)
            {
                Energy = 0;
            }
            else
            {
                while (Dyes.Any())
                {
                    if (Dyes.First().IsFinished() == false)
                    {
                        Dyes.First().Use();
                        break;
                    }

                    Dyes.Remove(Dyes.First());
                }
            }
        }
    }
}
