using SomeName.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace SomeName.Items.Interfaces
{
    public abstract class Weapon : Item
    {
        public long BaseDamage { get; set; }

        public long Damage { get; set; }

        public WeaponBonuses Bonuses { get; set; } = new WeaponBonuses();

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
