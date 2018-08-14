using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Domain
{
    public class WeaponBonuses
    {
        public int Power { get; set; }

        public override string ToString()
            => Power == 0
            ? string.Empty
            : $"Power: {Power}";
    }
}
