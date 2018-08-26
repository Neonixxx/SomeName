using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace SomeName.Items.Bonuses
{
    public class ItemBonuses
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
                result.Append($"{NewLine}Шанс крита: {CritChance.ToPercentString(1)}");

            if (CritDamage != 0)
                result.Append($"{NewLine}Сила крита: {CritDamage.ToPercentString(1)}");

            return result.ToString();
        }
    }
}
