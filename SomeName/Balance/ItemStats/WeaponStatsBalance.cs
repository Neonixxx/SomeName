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
    public class WeaponStatsBalance : ItemStatsBalance
    {
        public override ItemBonusesEnum PossibleItemBonuses => ItemBonusesEnum.Power | ItemBonusesEnum.Vitality;

        protected override double PowerKoef => 1.0;

        protected override double VitalityKoef => 1.0;

        protected override double CritChanceKoef => 0.0;

        public long GetDamage(int level, double damageValueKoef)
            => ToInt64(GetBaseDamage(level) * damageValueKoef);

        private long GetBaseDamage(int level)
            => ToInt64(20 * Pow(E, 0.04 * level) - 15);
    }
}
