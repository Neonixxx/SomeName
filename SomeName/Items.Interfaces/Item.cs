using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Interfaces
{
    public abstract class Item
    {
        public int Level { get; set; }

        public long GoldValue { get; set; }

        public double DamageValueKoef { get; set; }

        public string Description { get; set; }
    }
}
