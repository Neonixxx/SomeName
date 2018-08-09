using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Items.Interfaces;
using SomeName.Balance;

namespace SomeName
{
    public class Player
    {
        public Player() { }

        public int Level { get; set; }

        public long ExpForNextLevel { get; set; }

        public long Exp { get; set; }

        public long Gold { get; set; }

        public Weapon Weapon { get; set; }

        public List<Item> Inventory { get; set; }

        public long GetDamage()
            => DamageBalance.CalculateDamage(this);

        public void TakeDrop(Drop drop)
        {
            TakeExp(drop.Exp);
            Gold += drop.Gold;
            TakeItems(drop.Items);
        }

        public void TakeExp(long exp)
        {
            var totalExp = Exp + exp;
            while (totalExp >= ExpForNextLevel)
            {
                totalExp -= ExpForNextLevel;
                Level++;
                ExpForNextLevel = DamageBalance.GetExp(Level);
            }
            Exp = totalExp;
        }

        public void TakeItems(List<Item> items)
        {
            Inventory.AddRange(items);
        }
    }
}
