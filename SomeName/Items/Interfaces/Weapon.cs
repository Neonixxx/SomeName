using SomeName.Domain;
using SomeName.Items.Bonuses;
using SomeName.Items.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace SomeName.Items.Interfaces
{
    public abstract class Weapon : Equippment
    {
        public long BaseDamage { get; set; }

        public long Damage { get; set; }

        public override long BaseStatToEnchant { get => BaseDamage; set => BaseDamage = value; }

        public override long StatToEnchant { get => Damage; set => Damage = value; }

        public override string ToString()
        {
            var result = new StringBuilder($"{base.ToString()}{NewLine}Damage: {Damage}");
            var bonusesString = Bonuses.ToString();
            if (bonusesString != string.Empty)
                result.Append($"{NewLine}{bonusesString}");
            return result.ToString();
        }
    }
}
