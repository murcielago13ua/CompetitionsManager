using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsManager
{
    class Category : Base<Category>
    {
        public bool IsLeaf { get; set; }
        public Category(string name) : base(name) { IsLeaf = true; }
        public Category(string name, Guid id) : base(name, id) { IsLeaf = true; }
        public override string ToString()
        {
            return this.Name;
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;
            Category x = (Category)obj;
            return x.Name.Equals(this.Name);
        }
        public IEnumerable<Sportsman> Sportsmans
        {
            get
            {
                foreach (Sportsman turisto in Sportsman.Items.Values)
                    if (turisto.Category.Equals(this))
                        yield return turisto;
            }
        }
    }
}
