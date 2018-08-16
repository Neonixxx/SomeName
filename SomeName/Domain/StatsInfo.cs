using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace SomeName.Domain
{
    public class StatsInfo
    {
        public int Level { get; set; }

        public int Power { get; set; }

        public double CritChance { get; set; }

        public double CritDamage { get; set; }

        public long Damage { get; set; }

        public override string ToString()
        {
            return $"Level: {Level}" +
                $"{NewLine}Power: {Power}" +
                $"{NewLine}Damage: {Damage}" +
                $"{NewLine}Шанс крита: {CritChance.ToPercentString(0)}" +
                $"{NewLine}Сила крита: {CritDamage.ToPercentString(0)}";
        }
    }
}
