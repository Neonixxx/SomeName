using SomeName.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Balance;
using SomeName.Domain;

namespace SomeName.Monsters.Interfaces
{
    public abstract class Monster
    {
        public int Level { get; private set; }

        public long MaxHealth { get; private set; }

        public long Health { get; private set; }

        public Drop DroppedItems { get; private set; }

        public bool IsDead { get; private set; }

        public bool IsDropTaken { get; private set; }

        public string Description { get; private set; } = "Not implemented";

        public void Respawn(int level)
        {
            Level = level;
            MaxHealth = DamageBalance.GetDefaultMonsterHealth(level);
            Health = MaxHealth;
            DroppedItems = DropBalance.CalculateDrop(Level, MaxHealth);
            IsDead = false;
            IsDropTaken = false;
        }

        public long DealDamage(long damage)
        {
            var dealtDamage = GetDealtDamage(damage);
            Health -= dealtDamage;
            if (Health == 0)
                IsDead = true;
            return dealtDamage;
        }

        public long GetDealtDamage(long damage)
        {
            return Health - damage >= 0
                ? damage
                : Health;
        }

        public Drop GetDrop()
        {
            if (!IsDead)
                throw new MonsterNotDeadException();

            return DroppedItems;
        }

        public override string ToString()
            => $"Level {Level} {Description}";
    }
}
