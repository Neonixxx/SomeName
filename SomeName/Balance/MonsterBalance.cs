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
            => ToInt64(DamageBalance.GetDefaultDamage(level) * DamageBalance.GetTapsForMonster(level));
    }
}
