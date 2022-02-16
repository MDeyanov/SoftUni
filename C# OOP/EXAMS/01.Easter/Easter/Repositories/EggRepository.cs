using System;
using System.Collections.Generic;
using System.Text;
using Easter.Repositories.Contracts;
using Easter.Models.Eggs.Contracts;
using System.Linq;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models { get; private set; } = new List<IEgg>();

        public void Add(IEgg model)
        {
            eggs.Add(model);
            Models = eggs;
        }

        public IEgg FindByName(string name)
        {
            return eggs.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IEgg model)
        {
            if (eggs.Contains(model))
            {
                eggs.Remove(model);
                Models = eggs;
                return true;
            }
            return false;
        }
    }
}
