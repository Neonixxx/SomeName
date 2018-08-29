using SomeName.Balance;
using SomeName.Monsters.Interfaces;
using SomeName.Items.ItemFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Monsters.Impl
{
    public class SimpleMonster : Monster
    {
        public SimpleMonster(int level)
        {
            DropFactory = DropService.Standard;
            MonsterStatsBalance = MonsterStatsBalance.Standard;
            Respawn(level); 
        }
    }
}
