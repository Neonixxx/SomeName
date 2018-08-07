using SomeName.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Monsters.Interfaces
{
    public abstract class Monster
    {
        public int Level { get; private set; }

        public long MaxHealth { get; private set; }

        public Drop DroppedItems { get; private set; }

        public bool IsDead { get; private set; } = false;

        public bool IsDropTaken { get; private set; } = false;

        public long DealDamage(long damage)
        {
            var dealtDamage = GetDealtDamage(damage);
            MaxHealth -= dealtDamage;
            if (MaxHealth == 0)
                IsDead = true;
            return dealtDamage;
        }

        public long GetDealtDamage(long damage)
        {
            var result = MaxHealth - damage;
            return result >= 0
                ? result
                : MaxHealth;
        }

        public Drop GetDrop()
        {
            if (!IsDead)
                throw new MonsterNotDeadException();

            return DroppedItems;
        }
    }
}
