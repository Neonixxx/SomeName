﻿using System;
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
        protected override double PowerKoef => 1.0;

        protected override double VitalityKoef => 1.0;


        public long GetDamage(int level, double damageValueKoef)
            => ToInt64(GetBaseDamage(level) * damageValueKoef);

        private long GetBaseDamage(int level)
            => ToInt64(100 * Pow(E, 0.04 * level) - 100);
    }
}