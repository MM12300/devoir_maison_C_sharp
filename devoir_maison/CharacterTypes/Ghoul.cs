using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison.CharacterTypes
{
    class Ghoul : Character
    {
        public Ghoul(string name)
        {
            this.name = name;
            attack = 50;
            defense = 80;
            initiative = 120;
            damages = 30;
            maximumLife = 250;
            currentLife = 250;
            totalAttackNumber = 5;
            currentAttackNumber = 5;
            characterType = "Ghoul";
            isLiving = false;
            isCursed = true;
            isBlessed = false;
        }
    }
}
