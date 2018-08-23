using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Difficulties
{
    public class BattleDifficulty
    {
        public double ItemDamageKoef { get; private set; }

        public double ExpMultiplier { get; private set; }

        public double GoldMultiplier { get; private set; }

        public double DropMultiplier { get; private set; }

        private static readonly BattleDifficulty[] BattleDifficulties = new BattleDifficulty[]
        {
            new BattleDifficulty(0.7, 0.7, 0.7, 0.7),
            new BattleDifficulty(1, 1, 1, 1),
            new BattleDifficulty(1.25, 1.4, 1.25, 1.25),
        };

        public BattleDifficulty(double itemDamageKoef, double expMultiplier, double goldMultiplier, double dropMultiplier)
        {
            ItemDamageKoef = itemDamageKoef;
            ExpMultiplier = expMultiplier;
            GoldMultiplier = goldMultiplier;
            DropMultiplier = dropMultiplier;
        }


        public static BattleDifficulty Current { get; private set; } = BattleDifficulties[0];

        public static void SetBattleDifficulty(BattleDifficultyEnum battleDifficultyEnum)
            => Current = BattleDifficulties[(int)battleDifficultyEnum];

    }
}
