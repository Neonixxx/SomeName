using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace SomeName.Domain
{
    public class WeaponBonuses
    {
        public int Power { get; set; }

        public int Vitality { get; set; }

        public double CritChance { get; set; }

        public double CritDamage { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            if (Power != 0)
                result.Append($"Power: {Power}");

            if (Vitality != 0)
                result.Append($"{NewLine}Vitality: {Vitality}");

            if (CritChance != 0)
                result.Append($"{NewLine}Шанс крита: {CritChance.ToPercentString(0)}");

            if (CritDamage != 0)
                result.Append($"{NewLine}Сила крита: {CritDamage.ToPercentString(0)}");

            return result.ToString();
        }
    }
}
