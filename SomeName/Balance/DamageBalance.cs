using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using static System.Math;
using SomeName.Items.Interfaces;

namespace SomeName.Balance
{
    public static class DamageBalance
    {
        public static long GetExp(int level)
            => Convert.ToInt64(GetDefaultDamage(level) * GetTapsForLevel(level));

        public static long GetDefaultDamage(int level)
        {
            var weaponDamage = GetWeaponDamage(level, GetItemDamageKoef(level));

            return CalculateDamage(level, weaponDamage);
        }

        public static long GetDefaultMonsterHealth(int level)
            => Convert.ToInt64(GetDefaultDamage(level) * GetTapsForMonster(level));

        public static long GetWeaponDamage(int level, double damageValueKoef)
            => Convert.ToInt64(GetBaseWeaponDamage(level) * damageValueKoef);

        public static long GetBaseWeaponDamage(int level)
            => Convert.ToInt64(100 * Pow(E, 0.04 * level) - 100);

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

        public static long CalculateDamage(Player player)
            => CalculateDamage(player.Level, player.EquippedItems.Weapon);

        public static long CalculateDamage(int level, Weapon weapon)
            => CalculateDamage(level, weapon?.Damage ?? 1);

        public static long CalculateDamage(int level, long weaponDamage)
        {
            return level * weaponDamage;
        }
    }
}
