using SomeName.Balance.ItemStats;
using SomeName.Difficulties;
using SomeName.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;

namespace SomeName.Balance
{
    public class PlayerStatsBalance
    {
        public PlayerStatsCalculator PlayerStatsCalculator { get; set; }

        public WeaponStatsBalance WeaponStatsBalance { get; set; }

        public ChestStatsBalance ChestStatsBalance { get; set; }

        public GlovesStatsBalance GlovesStatsBalance { get; set; }


        private double GetDefaultItemDamageKoef(int level)
            => BattleDifficulty.GetCurrent().ItemDamageKoef * GetBaseItemDamageKoef(level);

        private double GetBaseItemDamageKoef(int level)
            => 1 + level * 0.01;


        public static double GetTapsPerSecond(int level)
            => 2 + 0.03 * level;


        public long GetDefaultDPS(int level)
            => ToInt64(GetDefaultDamage(level) * GetTapsPerSecond(level));

        public long GetDefaultDamage(int level)
            => GetDamage(level, GetDefaultItemDamageKoef(level));

        public long GetDefaultToughness(int level)
            => ToInt64(GetDefaultMaxHealth(level) / (1 - GetDefaultDefenceKoef(level)));

        public long GetDefaultMaxHealth(int level)
            => GetMaxHealth(level, GetDefaultItemDamageKoef(level));

        public double GetDefaultDefenceKoef(int level)
        {
            var defence = GetDefence(level, GetDefaultItemDamageKoef(level));
            return PlayerStatsCalculator.CalculateDefenceKoef(level, defence);
        }


        private long GetDamage(int level, double damageValueKoef)
        {
            var power = GetPower(level, damageValueKoef);
            var weaponDamage = WeaponStatsBalance.GetDamage(level, damageValueKoef);

            var damageWithoutCritCoef = PlayerStatsCalculator.CalculateDamage(power, weaponDamage);
            var critCoef = GetBaseCritCoef(level, damageValueKoef);

            return ToInt64(damageWithoutCritCoef * critCoef);
        }

        private long GetDefence(int level, double damageValueKoef)
            => PlayerStatsCalculator.CalculateDefence(level, GetItemsDefence(level, damageValueKoef));

        private long GetItemsDefence(int level, double damageValueKoef)
            => ChestStatsBalance.GetDefence(level, damageValueKoef);


        private int GetPower(int level, double damageValueKoef)
            => PlayerStatsCalculator.CalculatePower(level, GetItemsPower(level, damageValueKoef));

        private int GetItemsPower(int level, double damageValueKoef)
            => WeaponStatsBalance.GetPower(level, damageValueKoef) 
            + ChestStatsBalance.GetPower(level, damageValueKoef);


        private long GetMaxHealth(int level, double damageValueKoef)
            => PlayerStatsCalculator.CalculateMaxHealth(level, GetVitality(level, damageValueKoef));

        private int GetVitality(int level, double damageValueKoef)
            => PlayerStatsCalculator.CalculateVitality(level, GetItemsVitality(level, damageValueKoef));

        private int GetItemsVitality(int level, double damageValueKoef)
            => WeaponStatsBalance.GetVitality(level, damageValueKoef)
            + ChestStatsBalance.GetVitality(level, damageValueKoef);


        private double GetBaseCritCoef(int level, double damageValueKoef)
            => GetCritChance(level, damageValueKoef) * (GetCritDamage(level, damageValueKoef) - 1) + 1;


        private double GetCritChance(int level, double damageValueKoef)
            => PlayerStatsCalculator.CalculateCritChance(GetItemsCritChance(level, damageValueKoef));

        private double GetItemsCritChance(int level, double damageValueKoef)
            => GlovesStatsBalance.GetCritChance(level, damageValueKoef);


        private double GetCritDamage(int level, double damageValueKoef)
            => PlayerStatsCalculator.CalculateCritDamage(GetItemsCritDamage(level, damageValueKoef));

        private double GetItemsCritDamage(int level, double damageValueKoef)
            => GlovesStatsBalance.GetCritDamage(level, damageValueKoef);


        public static readonly PlayerStatsBalance Standard = new PlayerStatsBalance
        {
            PlayerStatsCalculator = new PlayerStatsCalculator(),
            WeaponStatsBalance = new WeaponStatsBalance(),
            ChestStatsBalance = new ChestStatsBalance(),
            GlovesStatsBalance = new GlovesStatsBalance()
        };
    }
}
