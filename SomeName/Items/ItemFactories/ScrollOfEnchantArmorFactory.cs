﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Balance.ItemStats;
using SomeName.Domain;
using SomeName.Items.Impl;
using SomeName.Items.Interfaces;

namespace SomeName.Items.ItemFactories
{
    public class ScrollOfEnchantArmorFactory : ChestFactory
    {
        public override long GetItemGoldValue(int level)
            => Convert.ToInt64(GetBaseChestGoldValue(level) * 0.20);

        public override Item Build(int level, double additionalKoef = 1.0)
        {
            var item = new ScrollOfEnchantArmor()
            {
                Level = level,
            };
            item.GoldValue.Base = GetItemGoldValue(level);
            item.UpdateGoldValueKoef();

            return item;
        }
    }
}
