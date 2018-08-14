using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using static System.Math;
using SomeName.Items.Interfaces;
using SomeName.Domain;
using static System.Convert;

namespace SomeName.Balance
{
    public static class DamageBalance
    {
        public static long GetExp(int level)
            => ToInt64(GetDefaultDamage(level) * GetTapsForLevel(level));

        public static long GetDefaultDamage(int level)
        {
            var itemDamageKoef = GetItemDamageKoef(level);
            var power = GetPlayerPower(level, itemDamageKoef);
            var weaponDamage = GetWeaponDamage(level, itemDamageKoef);

            return CalculateDamage(power, weaponDamage);
        }

        public static long GetDefaultMonsterHealth(int level)
            => ToInt64(GetDefaultDamage(level) * GetTapsForMonster(level));

        public static long GetWeaponDamage(int level, double damageValueKoef)
            => ToInt64(GetBaseWeaponDamage(level) * damageValueKoef);

        public static long GetBaseWeaponDamage(int level)
            => ToInt64(100 * Pow(E, 0.04 * level) - 100);

        public static double GetItemDamageKoef(int level)
            => level >= 70
                ? GetItemDamageKoef(5.0 / (level - 65))
                : 1.0;

        public static double GetItemDamageKoef(double diceValue)
            => Pow(diceValue, -0.35);

        public static double GetTapsForLevel(int level)
            => Pow(level, 1.2) * 20;

        public static double GetTapsForMonster(int level)
            => Pow(level, 0.6) * 10;

        public static int GetPlayerPower(int level, double damageValueKoef)
            => level * PowerPerLevel + GetWeaponPower(level, damageValueKoef);

        public static int GetWeaponPower(int level, double damageValueKoef)
            => ToInt32(GetBaseWeaponPower(level) * damageValueKoef);

        public static int GetBaseWeaponPower(int level)
            => ToInt32(Pow(level, 1.5));

        public static long CalculateDamage(Player player)
            => CalculateDamage(player.GetPower(), player.EquippedItems.Weapon);

        public static long CalculateDamage(int power, Weapon weapon)
            => CalculateDamage(power, weapon?.Damage ?? 1);

        public static long CalculateDamage(int power, long weaponDamage)
        {
            return ToInt64((1 + ToDouble(power) / 100) * weaponDamage);
        }

        public static int CalculatePower(Player player)
            => CalculatePower(player.Level, player.EquippedItems);

        public static int CalculatePower(int level, EquippedItems equippedItems)
            => StartPower + level * PowerPerLevel + equippedItems.GetPower();

        public static readonly int StartPower = 20;

        public static readonly int PowerPerLevel = 10;

        public static readonly int VitalityPerLevel = 10;
    }
}
