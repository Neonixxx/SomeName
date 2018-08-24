using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;

namespace SomeName.Balance
{
    public class MonsterStatsBalance
    {
        public PlayerStatsBalance PlayerStatsBalance { get; set; }

        public MonsterStatsBalance(PlayerStatsBalance playerStatsBalance)
            => PlayerStatsBalance = playerStatsBalance;

        private static double GetTapsForMonster(int level)
            => Math.Pow(level, 0.75) * 4 + 20;


        public long GetDefaultMonsterHealth(int level)
            => ToInt64(PlayerStatsBalance.GetDefaultDamage(level) * GetTapsForMonster(level));

        public long GetDefaultMonsterDPS(int level)
            => PlayerStatsBalance.GetDefaultToughness(level) / GetDefaultBattleLength(level);

        public long GetDefaultBattleLength(int level)
            => ToInt64(GetTapsForMonster(level) / PlayerStatsBalance.GetTapsPerSecond(level));


        public static readonly MonsterStatsBalance Standard = new MonsterStatsBalance(PlayerStatsBalance.Standard);
    }
}
