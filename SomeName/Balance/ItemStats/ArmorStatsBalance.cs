using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;
using static System.Math;

namespace SomeName.Balance.ItemStats
{
    public abstract class ArmorStatsBalance : ItemStatsBalance
    {
        protected abstract double DefenceKoef { get; }

        public long GetDefence(int level, double damageValueKoef)
            => ToInt64(GetBaseDefence(level) * damageValueKoef);

        private long GetBaseDefence(int level)
            => ToInt64(DefenceKoef * (20 * Pow(E, 0.04 * level) - 10));
    }
}
