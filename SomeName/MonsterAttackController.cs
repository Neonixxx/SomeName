using SomeName.Domain;
using SomeName.Monsters.Interfaces;
using System;
using System.Threading;

namespace SomeName
{
    public class MonsterAttackController
    {
        public Monster Monster { get; set; }

        public AttackManager AttackManager { get; set; }

        public bool IsAttacking { get; private set; }

        public MonsterAttackController(Monster monster)
        {
            Monster = monster;
            AttackManager = new AttackManager(monster);
        }

        public void StartAttacking(IAttackTarget attackTarget, object locker)
        {
            IsAttacking = true;
            var attackCooldown = Convert.ToInt32(1000 / Monster.AttackSpeed);

            while(IsAttacking)
            {
                Thread.Sleep(attackCooldown);

                lock (locker)
                {
                    if (Monster.IsDead || attackTarget.IsDead)
                        break;

                    var dealtDamage = AttackManager.Attack(attackTarget);
                    if (attackTarget.IsDead)
                        break;
                }
            }
        }

        public void StopAttacking()
            => IsAttacking = false;
    }
}