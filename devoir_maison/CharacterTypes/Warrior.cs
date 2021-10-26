using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison.CharacterTypes
{
    class Warrior : Character
    {
        public Warrior()
        {
            attack = 100;
            defense = 100;
            initiative = 50;
            damages = 100;
            maximumLife = 200;
            currentLife = 200;
            totalAttackNumber = 2;
            currentAttackNumber = 2;
            characterType = "Warrior";
        }
    }
}
