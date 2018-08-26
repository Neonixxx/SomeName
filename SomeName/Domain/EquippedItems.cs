﻿using Newtonsoft.Json;
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

        public Chest Armor { get; set; }

        public Gloves Gloves { get; set; }

        public long GetDefence()
        {
            var result = Armor?.Defence ?? 0;
            result += Gloves?.Defence ?? 0;
            return result;
        }

        public int GetPower()
        {
            var result = Weapon?.Bonuses.Power ?? 0;
            result += Armor?.Bonuses.Power ?? 0;
            result += Gloves?.Bonuses.Power ?? 0;
            return result;
        }

        public int GetVitality()
        {
            var result =  Weapon?.Bonuses.Vitality ?? 0;
            result += Armor?.Bonuses.Vitality ?? 0;
            result += Gloves?.Bonuses.Vitality ?? 0;
            return result;
        }

        public double GetCritChance()
        {
            var result = Weapon?.Bonuses.CritChance ?? 0;
            result += Armor?.Bonuses.CritChance ?? 0;
            result += Gloves?.Bonuses.CritChance ?? 0;
            return result;
        }

        public double GetCritDamage()
        {
            var result = Weapon?.Bonuses.CritDamage ?? 0;
            result += Armor?.Bonuses.CritDamage ?? 0;
            result += Gloves?.Bonuses.CritDamage ?? 0;
            return result;
        }
    }
}
