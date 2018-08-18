using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Domain;
using SomeName.Items.Impl;
using SomeName.Items.Interfaces;
using static System.Math;

namespace SomeName.Balance
{
    public static class DropBalance
    {
        private static readonly Random _rand = new Random();

        public static readonly double DropGoldValueKoef = 0.3;

        public static readonly double DropItemsValueKoef = 1 - DropGoldValueKoef;

        /// <summary>
        /// Не реализовано (заглушка).
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Drop CalculateDrop(int level, long value)
        {
            return new Drop()
            {
                Gold = CalculateGoldDrop(value),
                Exp = value,
                Items = CalculateItemsDrop(level, value)
            };
        }

        public static long CalculateGoldDrop(long value)
        {
            var randomKoef = _rand.NextDouble() + 0.5;
            return Convert.ToInt64(value * DropGoldValueKoef * randomKoef);
        }

        // TODO : реализовать выпадение других видов предметов.
        public static List<Item> CalculateItemsDrop(int level, long value)
        {
            var itemDropValue = value * DropItemsValueKoef;
            var dropChance = itemDropValue / GetBaseWeaponGoldValue(level);
            var items = new List<Item>();
            if (Dice.TryGetChance(dropChance))
                items.Add(CalculateWeaponDrop(level));

            return items;
        }

        // TODO : возможно реализовать другие виды оружия.
        public static Weapon CalculateWeaponDrop(int level)
        {
            var damageValueKoef = DamageBalance.GetItemDamageKoef(Dice.Roll);
            var weapon = new Sword()
            {
                Level = level,
                DamageValueKoef = damageValueKoef,
                GoldValue = GetWeaponGoldValue(level, damageValueKoef),
                BaseDamage = DamageBalance.GetWeaponDamage(level, damageValueKoef),
                Bonuses = CalculateWeaponBonuses(level)
            };
            weapon.Damage = weapon.BaseDamage;
            return weapon;
        }

        // TODO : Реализовать возможность выпадения бонусов шанса и силы крита.
        // TODO : Реализовать шанс выпадения бонусов.
        // TODO : Доделать выпадение разного числа бонусов.
        public static WeaponBonuses CalculateWeaponBonuses(int level)
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

        public static int CalculateItemBonusesCount(int level)
            => Dice.GetRange(GetMinItemBonusesCount(level), GetMaxItemBonusesCount(level));

        // TODO : Сделать формулу.
        public static int GetMinItemBonusesCount(int level)
            => 1;

        // TODO : Сделать формулу.
        public static int GetMaxItemBonusesCount(int level)
            => 2;

        public static long GetWeaponGoldValue(int level, double damageValueKoef)
            => Convert.ToInt64(GetBaseWeaponGoldValue(level) * damageValueKoef);

        public static long GetBaseWeaponGoldValue(int level)
            => Convert.ToInt64(GetBaseItemGoldValue(level) * WeaponGoldValueKoef);

        /// <summary>
        /// Получить стандартный коэффициент ценности предмета определенного уровня.
        /// </summary>
        /// <param name="level"></param>
        public static long GetBaseItemGoldValue(int level)
            => DamageBalance.GetExp(level);

        /// <summary>
        /// Получить коэффициент ценности оружия по отношению к стандартному.
        /// </summary>
        /// <param name="level"></param>
        public const double WeaponGoldValueKoef = 0.5;
    }
}
