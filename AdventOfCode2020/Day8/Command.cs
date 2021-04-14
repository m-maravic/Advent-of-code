using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    class Command
    {
        public string CommandName { get; set; }
        public string Operation { get; set; }
        public int Value { get; set; }
        public bool Done { get; set; }
        public bool ChangedName { get; set; }
    }
}
