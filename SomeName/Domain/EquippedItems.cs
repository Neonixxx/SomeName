using Newtonsoft.Json;
using SomeName.Items.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Domain
{
    [JsonObject]
    public class EquippedItems : IEnumerable<IEquippment>
    {
        public Weapon Weapon { get; set; }

        public Chest Chest { get; set; }

        public Gloves Gloves { get; set; }

        public long GetDefence()
        {
            var result = Chest?.Defence ?? 0;
            result += Gloves?.Defence ?? 0;
            return result;
        }

        public int GetPower()
        {
            var result = Weapon?.Bonuses.Power ?? 0;
            result += Chest?.Bonuses.Power ?? 0;
            result += Gloves?.Bonuses.Power ?? 0;
            return result;
        }

        public int GetVitality()
        {
            var result =  Weapon?.Bonuses.Vitality ?? 0;
            result += Chest?.Bonuses.Vitality ?? 0;
            result += Gloves?.Bonuses.Vitality ?? 0;
            return result;
        }

        public double GetCritChance()
        {
            var result = Weapon?.Bonuses.CritChance ?? 0;
            result += Chest?.Bonuses.CritChance ?? 0;
            result += Gloves?.Bonuses.CritChance ?? 0;
            return result;
        }

        public double GetCritDamage()
        {
            var result = Weapon?.Bonuses.CritDamage ?? 0;
            result += Chest?.Bonuses.CritDamage ?? 0;
            result += Gloves?.Bonuses.CritDamage ?? 0;
            return result;
        }

        public IEnumerator<IEquippment> GetEnumerator()
        {
            yield return Weapon;
            yield return Chest;
            yield return Gloves;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public void Remove(IEquippment equippment)
        {
            if (equippment == Weapon)
                Weapon = null;

            if (equippment == Chest)
                Chest = null;

            if (equippment == Gloves)
                Gloves = null;
        }
    }
}
