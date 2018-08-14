using Newtonsoft.Json;
using SomeName.Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Domain
{
    public class EquippedItems
    {
        public Weapon Weapon { get; set; }

        public int GetPower()
            => Weapon?.Bonuses.Power ?? 0;
    }
}
