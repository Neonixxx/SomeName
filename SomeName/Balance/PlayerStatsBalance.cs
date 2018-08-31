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

        public ItemStatsBalance[] ItemStatsBalances { get; set; }


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
            var weaponDamage = GetItemsDamage(level, damageValueKoef);

            var damageWithoutCritCoef = PlayerStatsCalculator.CalculateDamage(power, weaponDamage);
            var critCoef = GetBaseCritCoef(level, damageValueKoef);

            return ToInt64(damageWithoutCritCoef * critCoef);
        }

        private long GetItemsDamage(int level, double damageValueKoef)
        {
            long result = 0;
            foreach (WeaponStatsBalance item in ItemStatsBalances)
                result += item.GetDamage(level, damageValueKoef);
            return result;
        }

        private long GetDefence(int level, double damageValueKoef)
            => PlayerStatsCalculator.CalculateDefence(level, GetItemsDefence(level, damageValueKoef));

        private long GetItemsDefence(int level, double damageValueKoef)
        {
            long result = 0;
            foreach (ArmorStatsBalance item in ItemStatsBalances)
                result += item.GetDefence(level, damageValueKoef);
            return result;
        }


        private int GetPower(int level, double damageValueKoef)
            => PlayerStatsCalculator.CalculatePower(level, GetItemsPower(level, damageValueKoef));

        private int GetItemsPower(int level, double damageValueKoef)
        {
            int result = 0;
            foreach (var item in ItemStatsBalances)
                result += item.GetPower(level, damageValueKoef);
            return result;
        }


        private long GetMaxHealth(int level, double damageValueKoef)
            => PlayerStatsCalculator.CalculateMaxHealth(level, GetVitality(level, damageValueKoef));

        private int GetVitality(int level, double damageValueKoef)
            => PlayerStatsCalculator.CalculateVitality(level, GetItemsVitality(level, damageValueKoef));

        private int GetItemsVitality(int level, double damageValueKoef)
        {
            int result = 0;
            foreach (var item in ItemStatsBalances)
                result += item.GetVitality(level, damageValueKoef);
            return result;
        }


        private double GetBaseCritCoef(int level, double damageValueKoef)
            => GetCritChance(level, damageValueKoef) * (GetCritDamage(level, damageValueKoef) - 1) + 1;


        private double GetCritChance(int level, double damageValueKoef)
            => PlayerStatsCalculator.CalculateCritChance(GetItemsCritChance(level, damageValueKoef));

        private double GetItemsCritChance(int level, double damageValueKoef)
        {
            double result = 0.0;
            foreach (var item in ItemStatsBalances)
                result += item.GetCritChance(level, damageValueKoef);
            return result;
        }


        private double GetCritDamage(int level, double damageValueKoef)
            => PlayerStatsCalculator.CalculateCritDamage(GetItemsCritDamage(level, damageValueKoef));

        private double GetItemsCritDamage(int level, double damageValueKoef)
        {
            double result = 0.0;
            foreach (var item in ItemStatsBalances)
                result += item.GetCritDamage(level, damageValueKoef);
            return result;
        }


        public static readonly PlayerStatsBalance Standard = new PlayerStatsBalance
        {
            PlayerStatsCalculator = new PlayerStatsCalculator(),
            ItemStatsBalances = new ItemStatsBalance[]
            {
                new WeaponStatsBalance(),
                new ChestStatsBalance(),
                new GlovesStatsBalance()
            }
        };
    }
}
