using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Balance;
using SomeName.Domain;
using SomeName.Items.Impl;
using SomeName.Items.Interfaces;

namespace SomeName.Items.Factories
{
    public class SimpleSwordFactory : WeaponFactory
    {
        public override long GetItemGoldValue(int level)
            => GetBaseWeaponGoldValue(level);

        public override Item Build(int level)
        {
            var damageValueKoef = DamageBalance.GetItemDamageKoef(Dice.Roll);
            var weapon = new SimpleSword()
            {
                Level = level,
                DamageValueKoef = damageValueKoef,
                GoldValue = GetWeaponGoldValue(level, damageValueKoef),
                BaseDamage = DamageBalance.GetWeaponDamage(level, damageValueKoef),
                Bonuses = CalculateBonuses(level)
            };
            weapon.Damage = weapon.BaseDamage;
            return weapon;
        }

        // TODO : Реализовать возможность выпадения бонусов шанса и силы крита.
        // TODO : Реализовать шанс выпадения бонусов.
        // TODO : Доделать выпадение разного числа бонусов.
        private WeaponBonuses CalculateBonuses(int level)
        {
            var powerValueKoef = DamageBalance.GetItemDamageKoef(Dice.Roll);
            var vitalityValueKoef = DamageBalance.GetItemDamageKoef(Dice.Roll);
            var itemBonusesCount = CalculateItemBonusesCount(level);

            return new WeaponBonuses
            {
                Power = DamageBalance.GetWeaponPower(level, powerValueKoef),
                Vitality = DamageBalance.GetWeaponVitality(level, vitalityValueKoef)
            };
        }
    }
}
