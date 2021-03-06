﻿using SomeName.Balance;
using SomeName.Balance.ItemStats;
using SomeName.Domain;
using SomeName.Items.Bonuses;
using SomeName.Items.Impl;
using SomeName.Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.ItemFactories
{
    public class SimpleChestFactory : ChestFactory
    {
        public override long GetItemGoldValue(int level)
            => GetBaseChestGoldValue(level);

        public override Item Build(int level, double additionalKoef = 1.0)
        {
            var damageValueKoef = RollItemDamageKoef(additionalKoef);
            var item = new SimpleChest()
            {
                Level = level,
                Defence = ChestStatsBalance.GetDefence(level, damageValueKoef),
                Bonuses = ItemBonusesFactory.Build(ChestStatsBalance, level, additionalKoef),
            };
            item.GoldValue.Base = GetBaseChestGoldValue(level);
            item.UpdateGoldValueKoef();

            return item;
        }
    }
}
