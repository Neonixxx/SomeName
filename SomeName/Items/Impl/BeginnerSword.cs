using SomeName.Items.Interfaces;
using SomeName.Items.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Impl
{
    public class BeginnerSword : Weapon
    {
        public BeginnerSword()
        {
            Level = 1;
            Description = "Меч ученика";
            Damage.Base = 5;
            Damage.Koef = 1.0;
            Bonuses = new Bonuses.ItemBonuses();
            Image = ItemImages.BeginnerSword;
        }
    }
}
