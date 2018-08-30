using SomeName.Domain;
using SomeName.Items.Bonuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Interfaces
{
    public abstract class Equippment : Item, IEquippment
    {
        public ItemBonuses Bonuses { get; set; }

        public double DamageValueKoef { get; set; }

        public long BaseGoldValue { get; set; }

        public abstract long BaseStatToEnchant { get; set; }

        public abstract long StatToEnchant { get; set; }

        public int EnchantmentLevel { get; set; }  
    }
}
