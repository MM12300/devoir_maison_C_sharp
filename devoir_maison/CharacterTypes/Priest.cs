using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison.CharacterTypes
{
    class Priest : Character
    {
        public Priest(string name)
        {
            this.name = name;
            attack = 75;
            defense = 125;
            initiative =50;
            damages = 50;
            maximumLife = 150;
            currentLife = 150;
            totalAttackNumber = 1;
            currentAttackNumber = 1;
            characterType = "Priest";
            isLiving = true;
            isCursed = false;
            isBlessed = true;
        }
    }
}
