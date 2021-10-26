using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison.CharacterTypes
{
    class Zombie : Character
    {
        public Zombie(string name)
        {
            this.name = name;
            attack = 100;
            defense = 0;
            initiative = 20;
            damages = 60;
            maximumLife = 1000;
            currentLife = 1500;
            totalAttackNumber = 1;
            currentAttackNumber = 1;
            characterType = "Zombie";
        }
    }
}
