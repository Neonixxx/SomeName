using SomeName.Difficulties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;
using static System.Math;

namespace SomeName.Balance
{
    public class DropBalance
    {
        public double GetDropKoef()
            => BattleDifficulty.GetCurrent().DropMultiplier;

        public long GetDropValuePerSecond(int level)
            => ToInt64(GetBaseDropValuePerSecond(level) * GetDropKoef());

        private long GetBaseDropValuePerSecond(int level)
            => ToInt64(Pow(level, 2.15)) + 20;
    }
}
