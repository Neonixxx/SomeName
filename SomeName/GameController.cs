using SomeName.Difficulties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    public class GameController
    {
        public readonly string[] BattleDifficulties = new string[] { "Very Easy", "Easy", "Normal" };

        public int GetCurrentDifficultyIndex()
            => BattleDifficulty.CurrentIndex;

        public void SetBattleDifficulty(int battleDifficultyIndex)
            => SetBattleDifficulty((BattleDifficultyEnum)battleDifficultyIndex);

        public void SetBattleDifficulty(BattleDifficultyEnum battleDifficultyEnum)
            => BattleDifficulty.SetBattleDifficulty(battleDifficultyEnum);
    }
}
