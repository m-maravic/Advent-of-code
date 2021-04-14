using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class Bag
    {
        public string Color { get; set; }
        public List<Tuple<int, Bag>> Bags { get; set; }
        public Bag()
        {
            Bags = new List<Tuple<int,Bag>>();
        }
    }
}
