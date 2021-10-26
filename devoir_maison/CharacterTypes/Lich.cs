using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison.CharacterTypes
{
    class Lich : Character
    {
        public Lich(string name)
        {
            this.name = name;
            attack = 75;
            defense = 125;
            initiative = 80;
            damages = 50;
            maximumLife = 125;
            currentLife = 125;
            totalAttackNumber = 3;
            currentAttackNumber = 3;
            characterType = "Lich";
            isLiving = false;
        }
    }
}
