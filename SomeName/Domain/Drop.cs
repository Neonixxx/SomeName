using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Items.Interfaces;

namespace SomeName.Domain
{
    public class Drop
    {
        public long Gold { get; set; }

        public long Exp { get; set; }

        public List<Item> Items { get; set; }
    }
}
