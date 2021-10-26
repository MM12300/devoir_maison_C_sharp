﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison.CharacterTypes
{
    class Guardian : Character
    {
        public Guardian()
        {
            attack = 50;
            defense = 150;
            initiative = 50;
            damages = 50;
            maximumLife = 150;
            currentLife = 150;
            totalAttackNumber = 3;
            currentAttackNumber = 3;
            characterType = "Guardian";
        }
    }
}
