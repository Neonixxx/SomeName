using SomeName.Items.Bonuses;
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
        protected virtual double PowerKoef => 0.0;

        protected virtual double VitalityKoef => 0.0;

        protected virtual double CritChanceKoef => 0.0;

        protected virtual double CritDamageKoef => 0.0;

        public abstract ItemBonusesEnum[] PossibleItemBonuses { get; }

        // TODO : Сделать формулу.
        public virtual int GetMinItemBonusesCount(int level)
            => 1;

        // TODO : Сделать формулу.
        public virtual int GetMaxItemBonusesCount(int level)
            => 2;

        public double GetItemBonusesCountKoef(int level)
            => ToDouble((GetMaxItemBonusesCount(level) - GetMinItemBonusesCount(level))) / PossibleItemBonuses.Length;


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
            => CritChanceKoef * level / 2500 + 0.01;


        public double GetCritDamage(int level, double damageValueKoef)
            => Round(GetBaseCritChance(level) * damageValueKoef, 3);

        private double GetBaseCritDamage(int level)
            => CritDamageKoef * level / 3 + 0.05;
    }
}
