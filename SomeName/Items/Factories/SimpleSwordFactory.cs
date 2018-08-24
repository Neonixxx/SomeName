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
            var damageValueKoef = RollItemDamageKoef() * additionalKoef;
            var weapon = new SimpleSword()
            {
                Level = level,
                DamageValueKoef = damageValueKoef,
                GoldValue = GetWeaponGoldValue(level, damageValueKoef),
                BaseDamage = WeaponStatsBalance.GetDamage(level, damageValueKoef),
                Bonuses = CalculateBonuses(level, additionalKoef)
            };
            weapon.Damage = weapon.BaseDamage;
            return weapon;
        }

        // TODO : Реализовать возможность выпадения бонусов шанса и силы крита.
        // TODO : Реализовать шанс выпадения бонусов.
        // TODO : Доделать выпадение разного числа бонусов.
        private WeaponBonuses CalculateBonuses(int level, double additionalKoef)
        {
            var powerValueKoef = RollItemDamageKoef() * additionalKoef;
            var vitalityValueKoef = RollItemDamageKoef() * additionalKoef;
            var itemBonusesCount = CalculateItemBonusesCount(level);

            return new WeaponBonuses
            {
                Power = WeaponStatsBalance.GetPower(level, powerValueKoef),
                Vitality = WeaponStatsBalance.GetVitality(level, vitalityValueKoef)
            };
        }
    }
}
