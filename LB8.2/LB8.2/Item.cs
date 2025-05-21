using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB8._2
{
    public class Item
    {
        public string Name { get;set; }
        public double Volume { get; set; }
        public Item(string name, double volume)
        {
            Name = name;
            Volume = volume;
        }
        public override string ToString()
        {
            return $"{Name} (об'єм: {Volume} )";
        }

    }
}
