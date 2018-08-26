using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;
using static System.Math;

namespace SomeName.Balance.ItemStats
{
    public abstract class ItemStatsBalance
    {
        protected abstract double PowerKoef { get; }

        protected abstract double VitalityKoef { get; }

        protected abstract double CritChanceKoef { get; }


        public int GetPower(int level, double damageValueKoef)
            => ToInt32(GetBasePower(level) * damageValueKoef);

        private int GetBasePower(int level)
            => ToInt32(GetBaseStat(level) * PowerKoef);


        public int GetVitality(int level, double damageValueKoef)
            => ToInt32(GetBaseVitality(level) * damageValueKoef);

        private int GetBaseVitality(int level)
            => ToInt32(GetBaseStat(level) * VitalityKoef);

        private int GetBaseStat(int level)
            => ToInt32(Pow(level, 1.3));


        public double GetCritChance(int level, double damageValueKoef)
        {
            var baseCritCoef = Sqrt(damageValueKoef);
            var critKoef = baseCritCoef > 2.0
                ? 2.0
                : baseCritCoef;
            return Round(GetBaseCritChance(level) * critKoef, 3);
        }

        private double GetBaseCritChance(int level)
            => CritChanceKoef * level / 2000;

        // UNDONE : Недоделано вычисление критического урона предметов.
        public double GetCritDamage(int level, double damageValueKoef)
            => 0.0;
    }
}
