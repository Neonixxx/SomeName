using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Items.Interfaces;

namespace SomeName
{
    public class Player
    {
        public long GetDamage()
            => Balance.CalculateDamage(this);

        public int Level { get; set; }

        public int Exp { get; set; }

        public int Gold { get; set; }

        public Weapon Weapon { get; set; }

        public void TakeDrop(Drop drop)
        {

        }
    }
}
