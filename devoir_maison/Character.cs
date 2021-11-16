using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace devoir_maison
{
    public class Character
    {
        protected int attack;

        protected int defense;

        protected int initiative;

        protected int damages;

        protected int maximumLife;

        protected int currentLife;

        protected int currentAttackNumber;

        protected int totalAttackNumber;

        protected string characterType;

        protected string name;

        protected bool isLiving;

        protected int pain;

        protected bool isBlessed;

        protected bool isCursed;

        protected bool blessedDamage;

        protected bool cursedDamage;

        protected Randomizer random = new Randomizer();

        public Character()
        {
            this.pain = -1;
        }

        public int GetAttack()
        {
            return attack;
        }

        public void SetAttack(int attack)
        {
            this.attack = attack;
        }

        public int GetDefense()
        {
            return defense;
        }

        public void SetDefense(int defense)
        {
            this.defense = defense;
        }

        public int GetInitiative()
        {
            return initiative;
        }

        public void SetInitiative(int initiative)
        {
            this.initiative = initiative;
        }

        public int GetDamages()
        {
            return damages;
        }

        public void SetDamages(int damages)
        {
            this.damages = damages;
        }

        public int GetMaximumLife()
        {
            return maximumLife;
        }

        public void SetMaximumLife(int maximumLife)
        {
            this.maximumLife = maximumLife;
        }

        public int GetCurrentLife()
        {
            return currentLife;
        }

        public void SetCurrentLife(int currentLife)
        {
            this.currentLife = currentLife;
        }

        public int GetCurrentAttackNumber()
        {
            return currentAttackNumber;
        }

        public void SetCurrentAttackNumber(int currentAttackNumber)
        {
            this.currentAttackNumber = currentAttackNumber;
        }

        public int GetTotalAttackNumber()
        {
            return totalAttackNumber;
        }

        public void SetTotalAttackNumber(int totalAttackNumber)
        {
            this.totalAttackNumber = totalAttackNumber;
        }

        public string GetCharacterType()
        {
            return characterType;
        }

        public void SetCharacterType(string characterType)
        {
            this.characterType = characterType;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public bool GetIsLiving()
        {
            return isLiving;
        }

        public void SetIsLiving(bool isLiving)
        {
            this.isLiving = isLiving;
        }

        public int GetPain()
        {
            return pain;
        }
        
        public void SetPain(int pain)
        {
            this.pain = pain;
        }

        public bool GetIsBlessed()
        {
            return isBlessed;
        }

        public void SetIsBlessed(bool isBlessed)
        {
            this.isBlessed = isBlessed;
        }

        public bool GetIsCursed()
        {
            return isCursed;
        }

        public void SetIsCursed(bool isCursed)
        {
            this.isCursed = isCursed;
        }

        public bool GetBlessedDamage()
        {
            return blessedDamage;
        }

        public void SetBlessedDamage(bool blessedDamage)
        {
            this.blessedDamage = blessedDamage;
        }

        public bool GetCursedDamage()
        {
            return cursedDamage;
        }

        public void SetCursedDamage(bool cursedDamage)
        {
            this.cursedDamage = cursedDamage;
        }

        
        public int roll()
        {
            Thread.Sleep(1);
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            return randomNumber;
        }

        public bool luckyRoll()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            Console.WriteLine("Roll of Luck  : {0}", randomNumber);
            if (randomNumber > 50)
            {
                Console.WriteLine("Lucky Roll");
                return true;
            }
            else
            {
                Console.WriteLine("Not Lucky Roll");
                return false;
            }
        }

        public int rollOf(string typeOfRoll, int rollValue)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            int rollResult;

            //ROBOT RULES
            if (GetCharacterType() == "Robot")
            {
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
            }
            else
            {
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
            }
            Console.ResetColor();
            return rollResult;
        }

        public int fight_attack()
        {
            int attackRollValue = rollOf("attack", roll());
            return attackRollValue;
        }

        public int fight_defense()
        {
            int defenseRollValue = rollOf("defense", roll());
            return defenseRollValue;
        }

        public int fight_initiative()
        {
            int initiativeRollValue = rollOf("initiative", roll());
            return initiativeRollValue;
        }

        public void showLife()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("<3<3<3 -- {0} has {1}/{2} lifepoints -- <3<3<3", GetName(), GetCurrentLife(), GetMaximumLife());
            Console.ResetColor();
        }
    }
}
