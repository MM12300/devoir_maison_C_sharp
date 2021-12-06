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

        
        public int Roll()
        {
            Thread.Sleep(1);
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            return randomNumber;
        }

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

        //public int RollOf(string typeOfRoll, int rollValue)
        //{
        //    Console.BackgroundColor = ConsoleColor.Blue;
        //    int rollResult;

        //    //ROBOT RULES
        //    if (GetCharacterType() == "Robot")
        //    {
        //        if (typeOfRoll == "attack")
        //        {
        //            rollResult = 50 + GetAttack();
        //            Console.WriteLine("/!/ROLL/!/ => {0} attack = {1} (50 + attack:{2})", GetName(), rollResult, GetAttack());
        //        }
        //        else if (typeOfRoll == "initiative")
        //        {
        //            rollResult = 50 + this.GetInitiative();
        //            Console.WriteLine("/!/ROLL/!/ => {0} initiative = {1} (50 + initiative:{2})", GetName(), rollResult, GetInitiative());

        //        }
        //        else if (typeOfRoll == "defense")
        //        {
        //            rollResult = 50 + this.GetDefense();
        //            Console.WriteLine("/!/ROLL/!/ => {0} defense = {1} (50 + defense:{2})", GetName(), rollResult, GetDefense());
        //        }
        //        else
        //        {
        //            Console.WriteLine("type of roll must be attack, defense or initiative");
        //            throw new ArgumentException("Type of roll can't have these values : attack, defense, initiative", nameof(typeOfRoll));
        //        }
        //    }
        //    else
        //    {
        //        if (typeOfRoll == "attack")
        //        {
        //            rollResult = rollValue + GetAttack();
        //            Console.WriteLine("/!/ROLL/!/ => {0} attack = {1} (roll:{2}+attack:{3})", GetName(), rollResult, rollValue, GetAttack());

        //        }
        //        else if (typeOfRoll == "initiative")
        //        {
        //            rollResult = rollValue + GetInitiative();
        //            Console.WriteLine("/!/ROLL/!/ => {0} initiative = {1} (roll:{2}+initiative:{3})", GetName(), rollResult, rollValue, GetInitiative());

        //        }
        //        else if (typeOfRoll == "defense")
        //        {
        //            //ZOMBIE RULE
        //            if (GetCharacterType() == "Zombie")
        //            {
        //                Console.WriteLine("{0} defense roll is always 0", GetCharacterType());
        //                rollResult = GetDefense();
        //            }
        //            else
        //            {
        //                rollResult = rollValue + GetDefense();
        //            }

        //            Console.WriteLine("/!/ROLL/!/ => {0} defense = {1} (roll:{2}+defense:{3})", GetName(), rollResult, rollValue, GetDefense());
        //        }
        //        else
        //        {
        //            //TODO : remove this throw error
        //            rollResult = 0;
        //            Console.WriteLine("type of roll must be attack, defense or initiative");
        //        }
        //    }
        //    Console.ResetColor();
        //    return rollResult;
        //}

        public void ShowLife()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("<3<3<3 -- {0} has {1}/{2} lifepoints -- <3<3<3", GetName(), GetCurrentLife(), GetMaximumLife());
            Console.ResetColor();
        }

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

        public void LifeModifier(int lifeModifier)
        {
            int newLifeValue = GetCurrentLife() + lifeModifier;

            if (newLifeValue > GetMaximumLife())
            {
                Console.WriteLine("new life value is maxed");
                SetCurrentLife(GetMaximumLife());
            }
            else
            {
                Console.WriteLine("Life has been changed");
                SetCurrentLife(newLifeValue);
            }
        }

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
                    //TODO : remove this throw error
                    rollResult = 0;
                    Console.WriteLine("type of roll must be attack, defense or initiative");
                }
                return rollResult;
        }

        public int Fight_attack()
        {
            int attackRollValue = (this as IRoll).RollOf("attack", Roll());
            return attackRollValue;
        }

        public int Fight_defense()
        {
            int defenseRollValue = (this as IRoll).RollOf("defense", Roll());
            return defenseRollValue;
        }

        public int Fight_initiative()
        {
            int initiativeRollValue = (this as IRoll).RollOf("initiative", Roll());
            return initiativeRollValue;
        }
    }
}
