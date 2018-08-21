using SomeName.Monsters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Monsters.Impl
{
    public static class MonsterFacture
    {
        /// <summary>
        /// Не доделано.
        /// </summary>
        /// <param name="level">Уровень монстра.</param>
        /// <returns></returns>
        public static Monster GetRandomMonster(int level)
        {
            return new SimpleMonster(level);
        }
    }
}
