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
using SomeName.Difficulties;

namespace SomeName.Balance
{
    // TODO : Разделить этот класс и добиться расширяемости к внедрению новых типов предметов.
    // Для этого можно сделать фабричные классы и методы.
    public static class DamageBalance
    {
        public static long GetExp(int level)
            => ToInt64(GetDefaultPlayerDamage(level) * GetTapsForLevel(level));

        public static long GetDefaultPlayerDamage(int level)
        {
            var itemDamageKoef = GetItemDamageKoef();
            var power = GetPlayerPower(level, itemDamageKoef);
            var weaponDamage = GetWeaponDamage(level, itemDamageKoef);

            var damageWithoutCritCoef = CalculateDamage(power, weaponDamage);
            var critCoef = GetBaseCritCoef(level);


            return ToInt64(damageWithoutCritCoef * critCoef);
        }

        public static long GetDefaultPlayerToughness(int level)
            => ToInt64(GetDefaultPlayerMaxHealth(level) / (1 - GetDefaultPlayerDefenceKoef(level)));

        public static long GetDefaultPlayerMaxHealth(int level)
            => GetPlayerMaxHealth(level, GetItemDamageKoef());

        public static double GetDefaultPlayerDefenceKoef(int level)
        {
            var defence = GetPlayerDefence(level, GetItemDamageKoef());
            return CalculateDefenceKoef(level, defence);
        }

        public static long GetWeaponDamage(int level, double damageValueKoef)
            => ToInt64(GetBaseWeaponDamage(level) * damageValueKoef);

        public static long GetBaseWeaponDamage(int level)
            => ToInt64(100 * Pow(E, 0.04 * level) - 100);

        /// <summary>
        /// Получить стандартный коэффициент урона предмета для определенного уровня игрока.
        /// </summary>
        /// <param name="level">Уровень игрока.</param>
        /// <returns></returns>
        public static double GetItemDamageKoef()
            => BattleDifficulty.Get.ItemDamageKoef;

        public static double GetItemDamageKoef(double diceValue)
            => Pow(diceValue, -0.35);


        public static double GetTapsForLevel(int level)
            => Pow(level, 1.2) * 20;

        public static double GetTapsForMonster(int level)
            => Pow(level, 0.6) * 10;

        public static double GetTapsPerSecond(int level)
            => 2 + 0.03 * level;

        // TODO : доделать формулу + сделать для остальных предметов.
        public static long GetPlayerDefence(int level, double damageValueKoef)
            => StartDefence + DefencePerLevel * level + GetArmorDefence(level, damageValueKoef);

        public static long GetArmorDefence(int level, double damageValueKoef)
            => ToInt64(GetBaseArmorDefence(level) * damageValueKoef);

        public static long GetBaseArmorDefence(int level)
            => GetBaseItemDefence(level);

        public static long GetBaseItemDefence(int level)
            => ToInt64(20 * Pow(E, 0.04 * level) - 10);

        public static long GetBaseDefenceValue(int level)
            => ToInt64(Pow(level, 2));


        public static int GetPlayerPower(int level, double damageValueKoef)
            => StartPower + level * PowerPerLevel 
                + GetWeaponPower(level, damageValueKoef) 
                + GetArmorPower(level, damageValueKoef);

        public static int GetWeaponPower(int level, double damageValueKoef)
            => ToInt32(GetBaseWeaponPower(level) * damageValueKoef);

        public static int GetBaseWeaponPower(int level)
            => GetBaseItemStat(level);

        public static int GetArmorPower(int level, double damageValueKoef)
            => ToInt32(GetBaseArmorPower(level) * damageValueKoef);

        public static int GetBaseArmorPower(int level)
            => GetBaseItemStat(level);


        public static long GetPlayerMaxHealth(int level, double damageValueKoef)
            => ToInt64(GetPlayerVitality(level, damageValueKoef)) * GetMaxHealthPerVitality(level);


        public static int GetMaxHealthPerVitality(int level)
            => level >= 10
                ? level
                : 10;

        public static int GetPlayerVitality(int level, double damageValueKoef)
            => StartVitality + level * VitalityPerLevel 
                + GetWeaponVitality(level, damageValueKoef)
                + GetArmorVitality(level, damageValueKoef);

        public static int GetWeaponVitality(int level, double damageValueKoef)
            => ToInt32(GetBaseWeaponVitality(level) * damageValueKoef);

        public static int GetBaseWeaponVitality(int level)
            => GetBaseItemStat(level);

        public static int GetArmorVitality(int level, double damageValueKoef)
            => ToInt32(GetBaseArmorVitality(level) * damageValueKoef);

        public static int GetBaseArmorVitality(int level)
            => GetBaseItemStat(level);

        public static int GetBaseItemStat(int level)
            => ToInt32(Pow(level, 1.3));


        public static double GetBaseCritCoef(int level)
            => GetPlayerCritChance(level) * (GetPlayerCritDamage(level) - 1) + 1;

        public static double GetPlayerCritChance(int level)
            => StartCritChance + GetBaseWeaponCritChance(level);

        public static double GetBaseWeaponCritChance(int level)
            => 0.0;

        public static double GetPlayerCritDamage(int level)
            => StartCritDamage + GetBaseWeaponCritDamage(level);

        public static double GetBaseWeaponCritDamage(int level)
            => 0.0;


        public static long CalculateDamage(Player player)
            => CalculateDamage(player.GetPower(), player.EquippedItems.Weapon, player.GetCritChance(), player.GetCritDamage());

        public static long CalculateDamage(int power, Weapon weapon, double critChance, double critDamage)
            => CalculateDamage(power, weapon?.Damage ?? 1, critChance, critDamage);

        public static long CalculateDamage(int power, long weaponDamage, double critChance = 0, double critDamage = 0)
        {
            var damageWithoutCrit = ToInt64((1 + ToDouble(power) / 100) * weaponDamage);
            if (Dice.TryGetChance(critChance))
                damageWithoutCrit = ToInt64(damageWithoutCrit * critDamage);
            return damageWithoutCrit;
        }


        public static double CalculateDefenceKoef(Player player)
            => CalculateDefenceKoef(player.Level, CalculateDefence(player));

        public static double CalculateDefenceKoef(int level, long defence)
            => ToDouble(defence) / (defence + GetBaseDefenceValue(level));

        public static long CalculateDefence(Player player)
            => CalculateDefence(player.Level, player.EquippedItems);

        public static long CalculateDefence(int level, EquippedItems equippedItems)
            => StartDefence + DefencePerLevel * level + equippedItems.GetDefence();


        public static int CalculatePower(Player player)
            => CalculatePower(player.Level, player.EquippedItems);

        public static int CalculatePower(int level, EquippedItems equippedItems)
            => StartPower + level * PowerPerLevel + equippedItems.GetPower();


        public static long CalculateMaxHealth(Player player)
            => ToInt64(CalculateVitality(player)) * GetMaxHealthPerVitality(player.Level);

        public static int CalculateVitality(Player player)
            => CalculateVitality(player.Level, player.EquippedItems);

        public static int CalculateVitality(int level, EquippedItems equippedItems)
            => StartVitality + level * VitalityPerLevel + equippedItems.GetVitality();


        public static double CalculateCritChance(Player player)
            => CalculateCritChance(player.EquippedItems);

        public static double CalculateCritChance(EquippedItems equippedItems)
            => StartCritChance + equippedItems.GetCritChance();

        public static double CalculateCritDamage(Player player)
            => CalculateCritDamage(player.EquippedItems);

        public static double CalculateCritDamage(EquippedItems equippedItems)
            => StartCritDamage + equippedItems.GetCritDamage();


        public static readonly long StartDefence = 0;

        public static readonly long DefencePerLevel = 10;

        public static readonly int StartPower = 20;

        public static readonly int PowerPerLevel = 10;

        public static readonly int StartVitality = 20;

        public static readonly int VitalityPerLevel = 10;

        public static readonly double StartCritChance = 0.05;

        public static readonly double StartCritDamage = 1.5;
    }
}
