using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using devoir_maison.Interfaces;
using devoir_maison.CharacterTypes;


namespace devoir_maison
{
    public class Character:IRoll
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

        //Living Characters are sensitive to pain, non-living character are not sensitive to pain
        protected bool isLiving;

        //Amount of pain for the caracter
        protected int pain;

        //Blessed characters received two times more damage from characters with cursed damage
        protected bool isBlessed;

        //Cursed characters received two times more damage from characters with blessed damage
        protected bool isCursed;

        //Some characters can give blessed damage
        protected bool blessedDamage;

        //Some characters can give cursed damage
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
            if(currentLife <= GetMaximumLife())
            {
                this.currentLife = currentLife;
            }
            else
            {
                this.currentLife = GetMaximumLife();
            }
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

        //
        public int Roll()
        {
            //Random is calculated from a seed based on the system clock
            //Pause code execution allows the program to fetch a new seed
            //This avoid two consecutive random number calculated to be identic 
            Thread.Sleep(1);
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            return randomNumber;
        }

        //Calculates a chance on two to be a success (or a fail)
        public bool LuckyRoll()
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

        //Life displ;ays in console
        public void ShowLife()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("<3<3<3 -- {0} has {1}/{2} lifepoints -- <3<3<3", GetName(), GetCurrentLife(), GetMaximumLife());
            Console.ResetColor();
        }

        //Check if the Character is alive
        public bool IsAlive()
        {
            if (GetCurrentLife() < 0)
            {
                Console.WriteLine("{0} ({1}) is dead", GetName(), GetCharacterType());
                return false;
            }
            else
            {
                return true;
            }
        }

        //Check if the Character has attacks
        public bool HasAttacks()
        {
            if (GetCurrentAttackNumber() > 0)
            {
                Console.WriteLine("{0} attacks ({1}/{2})", GetName(), GetCurrentAttackNumber(), GetTotalAttackNumber());
                return true;
            }
            else
            {
                Console.WriteLine("Attacking is cancelled : {0} has no more attacks ({1}/{2})", GetName(), GetCurrentAttackNumber(), GetTotalAttackNumber());
                return false;
            }
        }

        //Changes Character current life from a modifier (life amount)
        public void LifeModifier(int lifeModifier)
        {
            int newLifeValue = GetCurrentLife() + lifeModifier;
            SetCurrentLife(newLifeValue);
        }

        //Check the Character type in order to apply specific rules
        public void CheckCharacterType()
        {
            //ROBOT RULES
            if (GetCharacterType() == "Robot")
            {
                Console.WriteLine("Robot attack was {0}", GetAttack());
                SetAttack(Convert.ToInt32(GetAttack() * 1.5));
                Console.WriteLine("Robot attack is now {0}", GetAttack());
            }

            //PRIEST RULES
            if (GetCharacterType() == "Priest")
            {
                Console.WriteLine("Priest rule");
                Console.WriteLine("{1} life before : {0}", GetCurrentLife(), GetName());
                LifeModifier(Convert.ToInt32(GetMaximumLife() * 0.1));
                Console.WriteLine("{1} life after : {0}", GetCurrentLife(), GetName());
            }
        }

        //Method used to calculate the result for different type of rolls
        public int RollOf(string typeOfRoll, int rollValue)
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
                    throw new ArgumentException("Parameter should be only attack/defense/initiative");
            }
                return rollResult;
        }

        //Attack action
        public int Fight_attack()
        {
            int attackRollValue = (this as IRoll).RollOf("attack", Roll());
            return attackRollValue;
        }

        //Defense action
        public int Fight_defense()
        {
            int defenseRollValue = (this as IRoll).RollOf("defense", Roll());
            return defenseRollValue;
        }

        //Initiative action
        public int Fight_initiative()
        {
            int initiativeRollValue = (this as IRoll).RollOf("initiative", Roll());
            return initiativeRollValue;
        }
    }
}
