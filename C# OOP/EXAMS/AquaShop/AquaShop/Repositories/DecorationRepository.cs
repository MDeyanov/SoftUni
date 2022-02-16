using System;
using System.Collections.Generic;
using System.Text;
using AquaShop.Repositories.Contracts;
using AquaShop.Models.Decorations.Contracts;
using System.Linq;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> decorations;
        public DecorationRepository()
        {
            decorations = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => decorations;

        public void Add(IDecoration model) => this.decorations.Add(model);


        public IDecoration FindByType(string type) => decorations.FirstOrDefault(x => x.GetType().Name == type);
       

        public bool Remove(IDecoration model) => this.decorations.Remove(model);
        
    }
}
