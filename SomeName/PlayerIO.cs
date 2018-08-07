using SomeName.Items.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Items.Interfaces;
using SomeName.Balance;

namespace SomeName
{
    public static class PlayerIO
    {
        public static Player StartNew()
        {
            return new Player()
            {
                Level = 1,
                Exp = 0,
                ExpForNextLevel = DamageBalance.GetExp(2),
                Gold = 0,
                Weapon = new BeginnerSword(),
                Inventory = new List<Item>()
            };
        }
    }
}
