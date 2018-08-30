using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Items.Bonuses;
using SomeName.Items.Impl;
using SomeName.Items.Interfaces;

namespace SomeName.Items.ItemFactories
{
    public class SimpleGlovesFactory : GlovesFactory
    {
        public override long GetItemGoldValue(int level)
            => GetBaseGlovesGoldValue(level);

        public override Item Build(int level, double additionalKoef = 1.0)
        {
            var damageValueKoef = RollItemDamageKoef(additionalKoef);
            var item = new SimpleGloves()
            {
                Level = level,
                DamageValueKoef = damageValueKoef,
                BaseGoldValue = GetGlovesGoldValue(level, damageValueKoef),
                BaseDefence = GlovesStatsBalance.GetDefence(level, damageValueKoef),
                Bonuses = ItemBonusesFactory.Build(GlovesStatsBalance, level, additionalKoef)
            };
            item.Defence = item.BaseDefence;
            item.GoldValue = item.BaseGoldValue;
            return item;
        }
    }
}
