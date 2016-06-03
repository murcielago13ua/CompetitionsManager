using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsManager
{
    [Serializable]
    public class Base<T> where T : Base<T>
    {
        [NonSerialized]
        public static Dictionary<Guid, T> Items = new Dictionary<Guid, T>();

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Base() : this("") { }
        public Base(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Items.Add(Id, (T)this);
        }
        public Base(string name, Guid guid)
        {
            Id = guid;
            Name = name;
            Items.Add(Id, (T)this);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            Base<T> x = (Base<T>)obj;
            return this.Id.Equals(x.Id);
        }
        public static bool Exist(string name)
        {
            foreach (Base<T> item in Base<T>.Items.Values)
                if (item.Name.Equals(name))
                    return true;
            return false;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
