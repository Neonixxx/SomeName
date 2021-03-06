﻿using SomeName.Balance.ItemStats;
using SomeName.Items.Bonuses;
using SomeName.Items.ItemFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Bonuses
{
    public class ItemBonusesFactory
    {
        public ItemBonuses Build(ItemStatsBalance itemStatsBalance, int level, double additionalKoef)
        {
            var minBonusesCount = itemStatsBalance.GetMinItemBonusesCount(level);
            var maxBonusesCount = itemStatsBalance.GetMaxItemBonusesCount(level);
            var bonusesCount = Dice.GetRange(minBonusesCount, maxBonusesCount);

            var itemBonusesBuilder = new ItemBonusesBuilder(itemStatsBalance, level);
            foreach (var itemBonuseEnum in itemStatsBalance.PossibleItemBonuses.TakeRandom(bonusesCount))
                itemBonusesBuilder.Calculate(itemBonuseEnum, ItemFactory.RollItemDamageKoef(additionalKoef));

            return itemBonusesBuilder.Build();
        }
    }
}
