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
        public override ItemBonusesEnum[] PossibleItemBonuses => new ItemBonusesEnum[] 
        {
            ItemBonusesEnum.Power,
            ItemBonusesEnum.Vitality,
            ItemBonusesEnum.Accuracy,
            ItemBonusesEnum.Evasion
        };

        protected override double DefenceKoef => 1.0;

        protected override double PowerKoef => 1.0;

        protected override double VitalityKoef => 1.0;

        protected override double AccuracyKoef => 1.0;

        protected override double EvasionKoef => 1.0;
    }
}
