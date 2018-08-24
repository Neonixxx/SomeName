using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Difficulties
{
    public class BattleDifficulty
    {
        public string Name { get; private set; }

        public double ItemDamageKoef { get; private set; }

        public double ExpMultiplier { get; private set; }

        public double GoldMultiplier { get; private set; }

        public double DropMultiplier { get; private set; }

        private static readonly BattleDifficulty[] BattleDifficulties = new BattleDifficulty[]
        {
            new BattleDifficulty("Very easy", 0.85, 0.85, 0.85, 0.85),
            new BattleDifficulty("Easy", 1.1, 1.1, 1.1, 1.1),
            new BattleDifficulty("Normal", 1.3, 1.4, 1.3, 1.3),
            new BattleDifficulty("Hard", 1.7, 2.0, 1.7, 1.7),
        };

        public BattleDifficulty(string name, double itemDamageKoef, double expMultiplier, double goldMultiplier, double dropMultiplier)
        {
            Name = name;
            ItemDamageKoef = itemDamageKoef;
            ExpMultiplier = expMultiplier;
            GoldMultiplier = goldMultiplier;
            DropMultiplier = dropMultiplier;
        }

        // UNDONE : смена сложности не работает, нужно найти причину.
        public static BattleDifficulty GetCurrent() 
            => BattleDifficulties[CurrentIndex];

        public static void SetBattleDifficulty(int battleDifficultyEnum)
            => CurrentIndex = battleDifficultyEnum;

        public static int CurrentIndex { get; private set; } = 0;

        public static string[] GetStrings()
            => BattleDifficulties.Select(s => s.Name).ToArray();

    }
}
