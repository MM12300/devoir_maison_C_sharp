using devoir_maison.Interfaces;
using System;

namespace devoir_maison.CharacterTypes
{
    class Zombie : Character, IRoll
    {
        public Zombie(string name)
        {
            this.name = name;
            attack = 100;
            defense = 0;
            initiative = 20;
            damages = 60;
            maximumLife = 100;
            currentLife = 100;
            totalAttackNumber = 1;
            currentAttackNumber = 1;
            characterType = "Zombie";
            isLiving = false;
            isCursed = true;
            isBlessed = false;
            blessedDamage = false;
            cursedDamage = false;
        }

        int IRoll.RollOf(string typeOfRoll, int rollValue)
        {
            int rollResult;
            if (typeOfRoll == "attack")
            {
                rollResult = rollValue + GetAttack();
                Console.WriteLine("/!/ROLL/!/ => {0} attack = {1} (roll:{2}+attack:{3})", GetName(), rollResult, rollValue, GetAttack());

            }
            else if (typeOfRoll == "initiative")
            {
                rollResult = rollValue + GetInitiative();
                Console.WriteLine("/!/ROLL/!/ => {0} initiative = {1} (roll:{2}+initiative:{3})", GetName(), rollResult, rollValue, GetInitiative());

            }
            else if (typeOfRoll == "defense")
            {
                //ZOMBIE RULE
                if (GetCharacterType() == "Zombie")
                {
                    Console.WriteLine("{0} defense roll is always 0", GetCharacterType());
                    rollResult = GetDefense();
                }
                else
                {
                    rollResult = rollValue + GetDefense();
                }

                Console.WriteLine("/!/ROLL/!/ => {0} defense = {1} (roll:{2}+defense:{3})", GetName(), rollResult, rollValue, GetDefense());
            }
            else
            {
                //TODO : remove this throw error
                rollResult = 0;
                Console.WriteLine("type of roll must be attack, defense or initiative");
            }
            return rollResult;
        }


    }
}
