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

namespace SomeName.Items.Factories
{
    public class SimpleSwordFactory : WeaponFactory
    {
        public override long GetItemGoldValue(int level)
            => GetBaseWeaponGoldValue(level);

        public override Item Build(int level, double additionalKoef = 1.0)
        {
            var damageValueKoef = RollItemDamageKoef(additionalKoef);
            var weapon = new SimpleSword()
            {
                Level = level,
                DamageValueKoef = damageValueKoef,
                BaseGoldValue = GetWeaponGoldValue(level, damageValueKoef),
                BaseDamage = WeaponStatsBalance.GetDamage(level, damageValueKoef),
                Bonuses = CalculateBonuses(level, additionalKoef)
            };
            weapon.Damage = weapon.BaseDamage;
            weapon.GoldValue = weapon.BaseGoldValue;
            return weapon;
        }

        // TODO : Реализовать возможность выпадения бонусов шанса и силы крита.
        // TODO : Реализовать шанс выпадения бонусов.
        // TODO : Доделать выпадение разного числа бонусов.
        private ItemBonuses CalculateBonuses(int level, double additionalKoef)
        {
            var itemBonusesCount = CalculateItemBonusesCount(level);

            return new ItemBonusesBuilder(level, WeaponStatsBalance)
                .CalculatePower(RollItemDamageKoef(additionalKoef))
                .CalculateVitality(RollItemDamageKoef(additionalKoef))
                .Build();
        }
    }
}
