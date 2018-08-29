﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Items.Bonuses;

namespace SomeName.Balance.ItemStats
{
    public class ChestStatsBalance : ArmorStatsBalance
    {
        public override ItemBonusesEnum PossibleItemBonuses => ItemBonusesEnum.Power | ItemBonusesEnum.Vitality;

        protected override double DefenceKoef => 1.0;

        protected override double PowerKoef => 1.0;

        protected override double VitalityKoef => 1.0;

        protected override double CritChanceKoef => 0.0;
    }
}
