using SomeName.Items.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    public static class PlayerIO
    {
        public static Player StartNew()
        {
            return new Player()
            {
                Level = 1,
                Exp = 50,
                Gold = 0,
                Weapon = new BeginnerSword()
            };
        }
    }
}
