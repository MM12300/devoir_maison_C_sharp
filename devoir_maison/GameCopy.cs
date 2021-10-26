﻿using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison
{


    //TODO CHANGE CONSOLEWRITELINE AVEC OPERATORS
    class GameCopy
    {
        public Character CreateCharacter(int attack, int defense, int initiative, int damages, int maximumLife, int currentLife, int currentAttackNumber, int totalAttackNumber)
        {
            Character newCharacter = new Character();

            newCharacter.SetAttack(attack);
            newCharacter.SetDefense(defense);
            newCharacter.SetInitiative(initiative);
            newCharacter.SetDamages(damages);
            newCharacter.SetMaximumLife(maximumLife);
            newCharacter.SetCurrentLife(currentLife);
            newCharacter.SetCurrentAttackNumber(currentAttackNumber);
            newCharacter.SetTotalAttackNumber(totalAttackNumber);

            return new Character();
        }

        public int roll()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 100);
            //WITHOUT DELAY ADDED THE ROLLS ALWAYS SEND THE SAME NUMBERS
            Thread.Sleep(100);
            return randomNumber;
        }

        public int rollOf(string typeOfRoll, int rollValue, Character character)
        {
            int rollResult = 0;
            if (typeOfRoll == "attack")
            {
                rollResult = rollValue + character.GetAttack();
                Console.WriteLine("{0} attack = {1} ({2}+{3})", character.GetCharacterType(), rollResult, rollValue, character.GetAttack());

            }
            else if (typeOfRoll == "initiative")
            {
                rollResult = rollValue + character.GetInitiative();
                Console.WriteLine("{0} initiative = {1} ({2}+{3})", character.GetCharacterType(), rollResult, rollValue, character.GetInitiative());

            }
            else if (typeOfRoll == "defense")
            {
                rollResult = rollValue + character.GetDefense();
                Console.WriteLine("{0} defense = {1} ({2}+{3})", character.GetCharacterType(), rollResult, rollValue, character.GetDefense());
            }

            return rollResult;
        }

        public int attack(Character character)
        {
            int rollValue = roll();
            int attackRollValue = rollOf("attack", rollValue, character);
            return attackRollValue;
        }

        public int defense(Character character)
        {
            int rollValue = roll();
            int defenseRollValue = rollOf("defense", rollValue, character);
            return defenseRollValue;
        }

        public bool isAlive(Character character)
        {
            if (character.GetCurrentLife() < 0)
            {
                Console.WriteLine("{0} is dead", character.GetCharacterType());
                return false;
            }
            else
            {
                return true;
            }
        }

        public void showLife(Character character)
        {
            Console.WriteLine("{0} has {1}/{2} lifepoints", character.GetCharacterType(), character.GetCurrentLife(), character.GetMaximumLife());
        }

        //TODO A COMPLETER REMAPL:CER IF ELSE DANS SIMPLE ATTACK ET COUNTER ATTACK
        public void stillHasAttacks() { }


        public void counterAttack(Character counterAttacker, Character counterDefender, int counterAttackValue)
        {
            if (counterAttacker.GetCurrentAttackNumber() > 0)
            {
                Console.WriteLine("<3<3<3<3<3<3<3");
                showLife(counterAttacker);
                showLife(counterDefender);
                Console.WriteLine("<3<3<3<3<3<3<3");
                Console.WriteLine("{0} attacks ({1}/{2})", counterAttacker.GetCharacterType(), counterAttacker.GetCurrentAttackNumber(), counterAttacker.GetTotalAttackNumber());
                //Remove attacks to attacker
                counterAttacker.SetCurrentAttackNumber(counterAttacker.GetCurrentAttackNumber() - 1);
                int counterAttacking = attack(counterAttacker);
                int counterDefending = defense(counterDefender);

                int fighting = counterAttacking - counterDefending;

                if (fighting > 0)
                {
                    counterDefender.SetCurrentLife(counterDefender.GetCurrentLife() - (-counterAttackValue));
                    Console.WriteLine("{0} **counter-attacks** : removes {1} life points to {2}", counterAttacker.GetCharacterType(), counterAttackValue, counterDefender.GetCharacterType());
                }
                //Delta negative = defender counter-attack
                else if (fighting <= 0)
                {
                    counterAttack(counterDefender, counterAttacker, fighting);
                }
            }
            else
            {
                Console.WriteLine("Counter-attack is cancelled : {0} has no more attacks ({1}/{2})", counterAttacker.GetCharacterType(), counterAttacker.GetCurrentAttackNumber(), counterAttacker.GetTotalAttackNumber());
            }
        }

        public void simpleAttack(Character attacker, Character defender)
        {
            if (isAlive(attacker) && isAlive(defender)){
                if (attacker.GetCurrentAttackNumber() > 0)
                {
                    Console.WriteLine("<3<3<3<3<3<3<3");
                    showLife(attacker);
                    showLife(defender);
                    Console.WriteLine("<3<3<3<3<3<3<3");

                    Console.WriteLine("{0} attacks ({1}/{2})", attacker.GetCharacterType(), attacker.GetCurrentAttackNumber(), attacker.GetTotalAttackNumber());
                    //Remove attacks to attacker
                    attacker.SetCurrentAttackNumber(attacker.GetCurrentAttackNumber() - 1);
                    //calculate attack and defense values
                    int attacking = attack(attacker);
                    int defending = defense(defender);

                    //(marge d'attaque) calculate delta between attack and defense values
                    int fighting = attacking - defending;
                    Console.WriteLine("Damages : {0}", fighting);

                    if (fighting > 0)
                    {
                        int damage = fighting * attacker.GetDamages() / 100;
                        Console.WriteLine("Damage ({0}) = {1} * {2} /100", damage, fighting, attacker.GetDamages());
                        defender.SetCurrentLife(defender.GetCurrentLife() - damage);
                        Console.WriteLine("{0} **attacks** removes {1} life points to {2}", attacker.GetCharacterType(), damage, defender.GetCharacterType());
                        Console.WriteLine("Attack({0}/{1})", attacker.GetCurrentAttackNumber(), attacker.GetTotalAttackNumber());
                    }
                    //Delta negative = defender counter-attack
                    else if (fighting <= 0)
                    {
                        Console.WriteLine("{0} counter-attack", defender.GetCharacterType());
                        counterAttack(defender, attacker, fighting);
                    }
                }
                else
                {
                    Console.WriteLine("Attack is cancelled : {0} has no more attacks ({1}/{2})", attacker.GetCharacterType(), attacker.GetCurrentAttackNumber(), attacker.GetTotalAttackNumber());
                }
            }
            
        }


        public void attackAndDefend(Character attacker, Character defender)
        {
            if (attacker.GetCurrentLife() > 0 && defender.GetCurrentLife() > 0)
            {
                Console.WriteLine("---------------");
                Console.WriteLine("{0} attack BEGINS", attacker.GetCharacterType());

                for (int i = 1; i <= attacker.GetTotalAttackNumber(); i++)
                {
                    //Console.WriteLine("{0} attacks ({1}/{2})", attacker.GetCharacterType(), attacker.GetCurrentAttackNumber(), attacker.GetTotalAttackNumber());
                    simpleAttack(attacker, defender);
                    
                }
                Console.WriteLine("{0} attack is OVER", attacker.GetCharacterType());
                Console.WriteLine("---------------");
                Console.WriteLine("{0} attack BEGINS", defender.GetCharacterType());

                for (int j = 0; j < defender.GetTotalAttackNumber(); j++)
                {
                    simpleAttack(defender, attacker);
                }
            }
            else
            {
                Console.WriteLine("One is dead #######################################");
            }
        }


        public void round(Character character1, Character character2)
        {
            
            if(isAlive(character1) && isAlive(character2))
            {
                Console.WriteLine("===================");
                Console.WriteLine("A NEW ROUND STARTS");
                Console.WriteLine("{0} LIFEPOINTS : {1} --- {2} LIFEPOINTS : {3}", character1.GetCharacterType(), character1.GetCurrentLife(), character2.GetCharacterType(), character2.GetCurrentLife());

                //RESET CURENT ATTACK NUMBER
                character1.SetCurrentAttackNumber(character1.GetTotalAttackNumber());
                character2.SetCurrentAttackNumber(character2.GetTotalAttackNumber());


                int rollInitiativeCharacter1 = roll();
                int rollInitiativeCharacter2 = roll();
                int initiativeRollCharacter1 = rollOf("initiative", rollInitiativeCharacter1, character1);
                int initiativeRollCharacter2 = rollOf("initiative", rollInitiativeCharacter2, character2);

                if (initiativeRollCharacter1 > initiativeRollCharacter2)
                {
                    Console.WriteLine("@@@@@@");
                    Console.WriteLine("{0} has initiative (AttackerNumbers = {1})", character1.GetCharacterType(), character1.GetTotalAttackNumber());
                    Console.WriteLine("@@@@@@");
                    attackAndDefend(character1, character2);
                }
                else
                {
                    Console.WriteLine("@@@@@@");
                    Console.WriteLine("{0} has initiative (AttackerNumbers = {1})", character2.GetCharacterType(), character2.GetTotalAttackNumber());
                    Console.WriteLine("@@@@@@");
                    attackAndDefend(character2, character1);
                }
                Console.WriteLine("THE ROUND IS OVER : {0} lifepoints = {1} -- {2} lifepoints = {3}", character1.GetCharacterType(), character1.GetCurrentLife(), character2.GetCharacterType(), character2.GetCurrentLife());
                Console.WriteLine("===================");
            }
            else
            {
                Console.WriteLine("One fighter is dead !");
            }
            
            
        }

        public string fight(Character character1, Character character2)
        {
            while (isAlive(character1) && isAlive(character2))
            {
                round(character1, character2);
            }

            return isAlive(character1) ? character1.GetCharacterType() + " won" : character2.GetCharacterType();
        }
    }
}
