﻿using SomeName.Items.Bonuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Balance.ItemStats
{
    public class GlovesStatsBalance : ArmorStatsBalance
    {
        public override ItemBonusesEnum[] PossibleItemBonuses => new ItemBonusesEnum[] 
        {
            ItemBonusesEnum.Power,
            ItemBonusesEnum.Vitality,
            ItemBonusesEnum.CritChance,
            ItemBonusesEnum.CritDamage
        };

        protected override double DefenceKoef => 0.8;

        protected override double PowerKoef => 1.0;

        protected override double VitalityKoef => 1.0;

        protected override double CritChanceKoef => 1.0;
    }
}
