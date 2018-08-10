﻿using SomeName.Items.Interfaces;
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
            BaseDamage = 5;
            Damage = 5;
        }
    }
}
