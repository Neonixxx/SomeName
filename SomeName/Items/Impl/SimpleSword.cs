using SomeName.Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Balance;
using SomeName.Items.Resources;

namespace SomeName.Items.Impl
{
    public class SimpleSword : Weapon
    {
        public SimpleSword()
        {
            Description = "Стальной меч";
            Image = ItemImages.SimpleSword;
        }
    }
}
