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

        public long Damage { get; set; }

        public override string ToString()
        {
            return $"Level: {Level}" +
                $"{NewLine}Damage: {Damage}";
        }
    }
}
