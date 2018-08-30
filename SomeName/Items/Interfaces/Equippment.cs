using SomeName.Domain;
using SomeName.Items.Bonuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Interfaces
{
    public abstract class Equippment : Item, ICanBeEnchanced
    {
        public ItemBonuses Bonuses { get; set; }

        public double DamageValueKoef { get; set; }

        public abstract long StatForEnchant { get; set; }

        public int EnchantmentLevel { get; set; }

        public long BaseGoldValue { get; set; }
    }
}
