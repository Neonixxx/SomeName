using SomeName.Domain;
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

        public DropBalance DropBalance { get; set; }


        public DropValue GetDefaultDropValue(int level)
            => DropBalance.GetDropValue(level, GetDefaultBattleLength(level));

        public long GetDefaultHealth(int level)
            => ToInt64(PlayerStatsBalance.GetDefaultDPS(level) * GetDefaultBattleLength(level));

        public long GetDefaultDPS(int level)
            => PlayerStatsBalance.GetDefaultToughness(level) / GetDefaultBattleLength(level);

        public long GetDefaultBattleLength(int level)
            => ToInt64(ToDouble(DropBalance.GetSecondsForLevel(level)) / GetMonstersForLevel(level));


        private static int GetMonstersForLevel(int level)
            => ToInt32(level / 2.0 + 1);


        public static readonly MonsterStatsBalance Standard = new MonsterStatsBalance
        {
            PlayerStatsBalance = PlayerStatsBalance.Standard,
            DropBalance = DropBalance.Standard
        };
    }
}
