using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Domain
{
    public interface IAttackTarget : ICanDie
    {
        long TakeDamage(long damage);

        long GetTakenDamage(long damage);
    }
}
