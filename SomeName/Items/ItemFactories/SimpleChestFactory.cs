using SomeName.Balance;
using SomeName.Balance.ItemStats;
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
                DamageValueKoef = damageValueKoef,
                BaseGoldValue = GetChestGoldValue(level, damageValueKoef),
                BaseDefence = ChestStatsBalance.GetDefence(level, damageValueKoef),
                Bonuses = ItemBonusesFactory.Build(ChestStatsBalance, level, additionalKoef)
            };
            item.Defence = item.BaseDefence;
            item.GoldValue = item.BaseGoldValue;
            return item;
        }
    }
}
