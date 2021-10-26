using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison.CharacterTypes
{
    class Robot : Character
    {
        public Robot(string name)
        {
            this.name = name;
            attack = 10;
            defense = 100;
            initiative = 50;
            damages = 50;
            maximumLife = 200;
            currentLife = 200;
            totalAttackNumber = 1;
            currentAttackNumber = 1;
            characterType = "Robot";
            isLiving = true;
        }
    }
}
