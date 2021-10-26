using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison.CharacterTypes
{
    class Berserker : Character
    {
        public Berserker()
        {
            attack = 100;
            defense = 100;
            initiative = 80;
            damages = 20;
            maximumLife = 300;
            currentLife = 300;
            totalAttackNumber = 1;
            currentAttackNumber = 1;
            characterType = "Berserker";
        }
    }
}
