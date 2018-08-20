using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;

namespace SomeName.Balance
{
    public static class MonsterBalance
    {
        public static long GetDefaultMonsterHealth(int level)
            => ToInt64(DamageBalance.GetDefaultPlayerDamage(level) * DamageBalance.GetTapsForMonster(level));

        public static long GetDefaultMonsterDPS(int level)
            => DamageBalance.GetDefaultPlayerToughness(level) / GetDefaultBattleLength(level);

        public static long GetDefaultBattleLength(int level)
            => ToInt64(DamageBalance.GetTapsForMonster(level) / DamageBalance.GetTapsPerSecond(level));
    }
}
