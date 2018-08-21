﻿using SomeName.Items.Interfaces;
using SomeName.Items.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Impl
{
    public class BeginnerSword : Weapon
    {
        public BeginnerSword()
        {
            Level = 1;
            GoldValue = 0;
            Description = "Меч ученика";
            Bonuses.Power = 0;
            BaseDamage = 5;
            Damage = 5;
            Image = ItemImages.BeginnerSword;
        }
    }
}