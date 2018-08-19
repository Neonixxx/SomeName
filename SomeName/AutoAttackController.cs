using SomeName.Domain;
using System;
using System.Threading;

namespace SomeName
{
    public class AutoAttackController
    {
        public IAutoAttack Attacker { get; set; }

        public bool IsAttacking { get; set; }

        public AutoAttackController(IAutoAttack attacker)
            => Attacker = attacker;

        public void StartAttacking(IAttackTarget target, object locker)
        {
            IsAttacking = true;
            var attackCooldown = Convert.ToInt32(1000 / Attacker.AttackSpeed);

            while(IsAttacking)
            {
                Thread.Sleep(attackCooldown);

                lock (locker)
                {
                    if (Attacker.IsDead || target.IsDead)
                        break;

                    var dealtDamage = target.TakeDamage(Attacker.Damage);
                    if (target.IsDead)
                        break;
                }
            }
        }
    }
}