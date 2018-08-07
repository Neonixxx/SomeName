﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using static System.Math;
using SomeName.Items.Interfaces;

namespace SomeName
{
    public static class Balance
    {
        public static long GetExp(int level)
            => Convert.ToInt64(GetDefaultDamage(level) * GetTapsForLevel(level));

        public static long GetDefaultDamage(int level)
        {
            var weaponDamage = Convert.ToInt64(GetBaseWeaponDamage(level) * GetValueKoef(level));

            return CalculateDamage(level, weaponDamage);
        }

        public static long GetBaseWeaponDamage(int level)
            => Convert.ToInt64(100 * Pow(E, 0.04 * level) - 100);

        public static double GetValueKoef(int level)
            => GetValueKoef(1.0 / level);

        public static double GetValueKoef(double diceValue)
            => Pow(diceValue, -0.35);

        public static double GetTapsForLevel(int level)
            => Pow(level, 1.4) * 20;

        public static long CalculateDamage(Player player)
            => CalculateDamage(player.Level, player.Weapon);

        public static long CalculateDamage(int level, Weapon weapon)
            => CalculateDamage(level, weapon.Damage);

        public static long CalculateDamage(int level, long weaponDamage)
        {
            return level * weaponDamage;
        }
    }
}
