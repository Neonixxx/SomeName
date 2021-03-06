﻿using SomeName.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Balance;
using SomeName.Domain;

namespace SomeName.Monsters.Interfaces
{
    public abstract class Monster : IAttacker, IAttackTarget
    {
        public MonsterAttackController Attacker { get; set; }

        public DropService DropFactory { get; set; }

        public MonsterStatsBalance MonsterStatsBalance { get; set; }

        public int Level { get; private set; }

        public long Damage { get; set; }

        public double AttackSpeed { get; set; }

        public int Accuracy { get; set; }

        public int Evasion { get; set; }

        public long MaxHealth { get; private set; }

        public long Health { get; set; }

        public Drop DroppedItems { get; private set; }

        public bool IsDead { get; set; }

        public bool IsDropTaken { get; private set; }

        public string Description { get; private set; } = "Not implemented";


        // TODO : Сделать разную скорость атаки монстров.
        public virtual void Respawn(int level)
        {
            Attacker = new MonsterAttackController(this);
            Level = level;
            Damage = MonsterStatsBalance.GetDefaultDPS(level);
            AttackSpeed = 1.0;
            Accuracy = MonsterStatsBalance.GetDefaultAccuracy(level);
            Evasion = MonsterStatsBalance.GetDefaultEvasion(level);
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

        public int GetAccuracy()
            => Accuracy;

        // TODO : Сделать шанс крита и силу крита монстрам.
        public double GetCritChance()
            => 0.0;

        public double GetCritDamage()
            => 0.0;

        public int GetEvasion()
            => Evasion;

        // TODO : Сделать защиту монстра.
        public double GetDefenceKoef()
            => 0.0;

        public void OnHit() { }

    }
}
