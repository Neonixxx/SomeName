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

        public int Accuracy { get; set; }

        public int Evasion { get; set; }

        public double CritChance { get; set; }

        public double CritDamage { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            if (Power != 0)
                result.Append($"Power: {Power}");
            if (Vitality != 0)
            {
                if (result.Length != 0)
                    result.Append($"{NewLine}");
                result.Append($"Vitality: {Vitality}");
            }
            if (Accuracy != 0)
            {
                if (result.Length != 0)
                    result.Append($"{NewLine}");
                result.Append($"Accuracy: {Accuracy}");
            }
            if (Evasion != 0)
            {
                if (result.Length != 0)
                    result.Append($"{NewLine}");
                result.Append($"Evasion: {Evasion}");
            }
            if (CritChance != 0)
            {
                if (result.Length != 0)
                    result.Append($"{NewLine}");
                result.Append($"Шанс крита: {CritChance.ToPercentString(1)}");
            }
            if (CritDamage != 0)
            {
                if (result.Length != 0)
                    result.Append($"{NewLine}");
                result.Append($"Сила крита: {CritDamage.ToPercentString(1)}");
            }

            return result.ToString();
        }
    }
}
