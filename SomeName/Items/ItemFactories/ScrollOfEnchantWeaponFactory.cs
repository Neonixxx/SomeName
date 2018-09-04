using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Balance.ItemStats;
using SomeName.Items.Impl;
using SomeName.Items.Interfaces;

namespace SomeName.Items.ItemFactories
{
    public class ScrollOfEnchantWeaponFactory : WeaponFactory
    {
        public override long GetItemGoldValue(int level)
            => Convert.ToInt64(GetBaseWeaponGoldValue(level) * 0.25);

        public override Item Build(int level, double additionalKoef = 1.0)
        {
            var damageValueKoef = RollItemDamageKoef(additionalKoef);
            var item = new ScrollOfEnchantWeapon()
            {
                Level = level,
                GoldValue = GetScrollOfEnchantWeaponGoldValue(level, damageValueKoef),
                Value = WeaponStatsBalance.GetDamage(level, damageValueKoef)
            };
            return item;
        }

        private long GetScrollOfEnchantWeaponGoldValue(int level, double damageValueKoef)
            => Convert.ToInt64(GetItemGoldValue(level) * damageValueKoef);
    }
}
