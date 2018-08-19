using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Domain
{
    public interface IAutoAttack : ICanDie
    {
        long Damage { get; }

        double AttackSpeed { get; }
    }
}
