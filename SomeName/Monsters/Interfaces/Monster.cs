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
    public abstract class Monster : IAttacker
    {
        public MonsterAttackController Attacker { get; set; }

        public DropService DropFactory { get; set; }

        public MonsterStatsBalance MonsterStatsBalance { get; set; }

        public int Level { get; private set; }

        public long Damage { get; set; }

        public double AttackSpeed { get; set; }

        public long MaxHealth { get; private set; }

        public long Health { get; private set; }

        public Drop DroppedItems { get; private set; }

        public bool IsDead { get; private set; }

        public bool IsDropTaken { get; private set; }

        public string Description { get; private set; } = "Not implemented";


        // TODO : Сделать разную скорость атаки монстров.
        public virtual void Respawn(int level)
        {
            Attacker = new MonsterAttackController(this);
            Level = level;
            Damage = MonsterStatsBalance.GetDefaultDPS(level);
            AttackSpeed = 1.0;
            MaxHealth = MonsterStatsBalance.GetDefaultHealth(level);
            Health = MaxHealth;
            DroppedItems = DropFactory.Build(level, MonsterStatsBalance.GetDefaultDropValue(level));
            IsDead = false;
            IsDropTaken = false;
        }

        public void StartAttacking(IAttackTarget target, object locker)
            => Attacker.StartAttacking(target, locker);

        public void StopAttacking()
            => Attacker.StopAttacking();

        public long TakeDamage(long damage)
        {
            var dealtDamage = GetTakenDamage(damage);
            Health -= dealtDamage;
            if (Health == 0)
                IsDead = true;
            return dealtDamage;
        }

        public long GetTakenDamage(long damage)
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

        public long GetDamage()
            => Damage;

        // TODO : Сделать шанс крита и силу крита монстрам.
        public double GetCritChance()
            => 0.0;

        public double GetCritDamage()
            => 0.0;
    }
}
