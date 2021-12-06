using devoir_maison.Interfaces;
using System;

namespace devoir_maison.CharacterTypes
{
    class Robot : Character, IRoll
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
            isCursed = false;
            isBlessed = false;
            blessedDamage = false;
            cursedDamage = false;
        }

        int IRoll.RollOf(string typeOfRoll, int rollValue)
        {
            Console.WriteLine("Je suis un robot");
            int rollResult;
            if (typeOfRoll == "attack")
            {
                rollResult = 50 + GetAttack();
                Console.WriteLine("/!/ROLL/!/ => {0} attack = {1} (50 + attack:{2})", GetName(), rollResult, GetAttack());
            }
            else if (typeOfRoll == "initiative")
            {
                rollResult = 50 + this.GetInitiative();
                Console.WriteLine("/!/ROLL/!/ => {0} initiative = {1} (50 + initiative:{2})", GetName(), rollResult, GetInitiative());

            }
            else if (typeOfRoll == "defense")
            {
                rollResult = 50 + this.GetDefense();
                Console.WriteLine("/!/ROLL/!/ => {0} defense = {1} (50 + defense:{2})", GetName(), rollResult, GetDefense());
            }
            else
            {
                Console.WriteLine("type of roll must be attack, defense or initiative");
                throw new ArgumentException("Type of roll can't have these values : attack, defense, initiative", nameof(typeOfRoll));
            }
            return rollResult;

        }
    }
}
