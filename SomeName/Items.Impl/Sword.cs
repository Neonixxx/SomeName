using SomeName.Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Balance;

namespace SomeName.Items.Impl
{
    public class Sword : Weapon
    {
        public Sword()
        {
            Description = "Стальной меч";
        }
    }
}
