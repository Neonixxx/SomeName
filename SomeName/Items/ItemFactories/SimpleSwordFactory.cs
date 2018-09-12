using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Balance;
using SomeName.Balance.ItemStats;
using SomeName.Domain;
using SomeName.Items.Bonuses;
using SomeName.Items.Impl;
using SomeName.Items.Interfaces;

namespace SomeName.Items.ItemFactories
{
    public class SimpleSwordFactory : WeaponFactory
    {
        public override long GetItemGoldValue(int level)
            => GetBaseWeaponGoldValue(level);

        public override Item Build(int level, double additionalKoef = 1.0)
        {
            var damageValueKoef = RollItemDamageKoef(additionalKoef);
            var item = new SimpleSword()
            {
                Level = level,
                Damage = WeaponStatsBalance.GetDamage(level, damageValueKoef),
                Bonuses = ItemBonusesFactory.Build(WeaponStatsBalance, level, additionalKoef)
            };
            item.GoldValue.Base = GetBaseWeaponGoldValue(level);
            item.UpdateGoldValueKoef();

            return item;
        }
    }
}
