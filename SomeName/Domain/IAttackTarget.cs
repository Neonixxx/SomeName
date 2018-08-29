using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Domain
{
    public interface IAttackTarget : ICanDie
    {
        long Health { get; set; }

        double GetDefenceKoef();
    }
}
