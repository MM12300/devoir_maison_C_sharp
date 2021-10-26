using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison.CharacterTypes
{
    class Vampire : Character
    {
        public Vampire(string name)
        {
            this.name = name;
            attack = 100;
            defense = 100;
            initiative = 120;
            damages = 50;
            maximumLife = 300;
            currentLife = 300;
            totalAttackNumber = 2;
            currentAttackNumber = 2;
            characterType = "Zombie";
            isLiving = false;
        }
    }
}
