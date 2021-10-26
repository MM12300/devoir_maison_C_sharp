using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison.CharacterTypes
{
    class Kamikaze : Character
    {
        public Kamikaze()
        {
            attack = 50;
            defense = 125;
            initiative = 20;
            damages = 75;
            maximumLife = 500;
            currentLife = 500;
            totalAttackNumber = 6;
            currentAttackNumber = 6;
            characterType = "Kamikaze";
        }
    }
}
