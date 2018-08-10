using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Interfaces
{
    public abstract class Weapon : Item
    {
        public long BaseDamage { get; set; }

        public long Damage { get; set; }
    }
}
