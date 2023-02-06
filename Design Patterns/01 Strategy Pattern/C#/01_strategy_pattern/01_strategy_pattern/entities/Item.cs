using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_strategy_pattern.interfaces;

namespace _01_strategy_pattern.entities
{
    internal class Item:IItem
    {
        public Guid Identifier { get; }
        public string Name { get; }

        public Item(string name)
        {
            this.Identifier = Guid.NewGuid();
            this.Name = name;
        }
    }
}
