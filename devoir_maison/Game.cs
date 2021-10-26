using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison
{


    //TODO CHANGE CONSOLEWRITELINE AVEC OPERATORS
    class Game
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

        //REFACTOR ALL THE ROLLS IN ONE METHOD THAT TAKES THE TYPE OF ROLL
        // REPLACE BY A SWITCH ?

        public int rollOf(string typeOfRoll, int rollValue, Character character)
        {
            int rollResult = 0;
            if (typeOfRoll == "attack")
            {
                rollResult = rollValue + character.GetAttack();
                Console.WriteLine("{0} attack = {1} ({2}+{3})", character.GetCharacterType(), rollResult, rollValue, character.GetAttack());

            }
            else if(typeOfRoll == "initiative")
            {
                rollResult = rollValue + character.GetInitiative();
                Console.WriteLine("{0} initiative = {1} ({2}+{3})", character.GetCharacterType(), rollResult, rollValue, character.GetInitiative());

            }
            else if(typeOfRoll == "defense")
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
            if(character.GetCurrentLife() <= 0)
            {
                Console.WriteLine(" {0} is dead", character.GetCharacterType());
                return false;
            }
            else
            {
                return true;
            }
        }

        public void counterAttack(Character counterAttacker, Character counterDefender, int counterAttackValue)
        {
            int counterAttacking = attack(counterAttacker);
            int counterDefending = defense(counterDefender);

            int fighting = counterAttacking - counterDefending;

            if (fighting > 0)
            {
                int damage = -counterAttackValue * counterAttacker.GetDamages() / 100;
                counterDefender.SetCurrentLife(counterDefender.GetCurrentLife() - damage);
                //Remove attacks to attacker
                counterAttacker.SetCurrentAttackNumber(counterAttacker.GetCurrentAttackNumber() - 1);
                Console.WriteLine("{0} removes {1} life points to {2}", counterAttacker.GetCharacterType(), damage, counterDefender.GetCharacterType());
            }
            //Delta negative = defender counter-attack
            else if (fighting <= 0)
            {
                counterAttack(counterDefender, counterAttacker, fighting);
            }
        }


        public void attackAndDefend(Character attacker, Character defender)
        {
            //calculate attack and defense values
            int attacking = attack(attacker);
            int defending = defense(defender);

            //(marge d'attaque) calculate delta between attack and defense values
            int fighting = attacking - defending;
            Console.WriteLine("Damages : {0}", fighting);

            if (fighting > 0)
            {
                Console.WriteLine("{0} attack", attacker.GetCharacterType());
                int damage = fighting * attacker.GetDamages() / 100;
                Console.WriteLine("Damage ({0}) = {1} * {2} /100", damage, fighting, attacker.GetDamages());
                defender.SetCurrentLife(defender.GetCurrentLife() - damage);
                Console.WriteLine("{0} removes {1} life points to {2}", attacker.GetCharacterType(), damage, defender.GetCharacterType());
                //Remove attacks to attacker
                attacker.SetCurrentAttackNumber(attacker.GetCurrentAttackNumber() - 1);
            }
            //Delta negative = defender counter-attack
            else if (fighting <= 0)
            {
                Console.WriteLine("{0} counter-attack", attacker.GetCharacterType());
                counterAttack(defender, attacker, fighting);
            } 
        }


        public void round(Character character1, Character character2)
        {
            //RESET CURENT ATTACK NUMBER
            character1.SetCurrentAttackNumber(character1.GetTotalAttackNumber());
            character2.SetCurrentAttackNumber(character1.GetTotalAttackNumber());

            Console.WriteLine("{0} attack number = {1}", character1.GetCharacterType(), character1.GetCurrentAttackNumber());
            Console.WriteLine("{0} attack number = {1}", character2.GetCharacterType(), character2.GetCurrentAttackNumber());

            int rollInitiativeCharacter1 = roll();
            int rollInitiativeCharacter2 = roll();

            int initiativeRollCharacter1 = rollOf("initiative", rollInitiativeCharacter1, character1);
            int initiativeRollCharacter2 = rollOf("initiative", rollInitiativeCharacter2, character2);

            do
            {
                if (initiativeRollCharacter1 > initiativeRollCharacter2)
                {
                    Console.WriteLine("{0} has initiative", character1.GetCharacterType());
                    attackAndDefend(character1, character2);
                    Console.WriteLine("{0} attack number = {1}", character1.GetCharacterType(), character1.GetCurrentAttackNumber());
                    Console.WriteLine("{0} attack number = {1}", character2.GetCharacterType(), character2.GetCurrentAttackNumber());
                }
                else if(initiativeRollCharacter1 < initiativeRollCharacter2)
                {
                    Console.WriteLine("{0} has initiative", character2.GetCharacterType());
                    attackAndDefend(character2, character1);
                    Console.WriteLine("{0} attack number = {1}", character1.GetCharacterType(), character1.GetCurrentAttackNumber());
                    Console.WriteLine("{0} attack number = {1}", character2.GetCharacterType(), character2.GetCurrentAttackNumber());
                }else if (initiativeRollCharacter1 < initiativeRollCharacter2)
                {

                    if(roll() > 50)
                    {
                        Console.WriteLine("{0} has initiative", character1.GetCharacterType());
                        attackAndDefend(character1, character2);
                        Console.WriteLine("{0} attack number = {1}", character1.GetCharacterType(), character1.GetCurrentAttackNumber());
                        Console.WriteLine("{0} attack number = {1}", character2.GetCharacterType(), character2.GetCurrentAttackNumber());
                    }
                    else
                    {
                        Console.WriteLine("{0} has initiative", character2.GetCharacterType());
                        attackAndDefend(character2, character1);
                        Console.WriteLine("{0} attack number = {1}", character1.GetCharacterType(), character1.GetCurrentAttackNumber());
                        Console.WriteLine("{0} attack number = {1}", character2.GetCharacterType(), character2.GetCurrentAttackNumber());
                    }
                }
                Console.WriteLine("|||||||||||||||||");
                Console.WriteLine("{0} lifepoints = {1} -- {2} lifepoints = {3}", character1.GetCharacterType(), character1.GetCurrentLife(), character2.GetCharacterType(), character2.GetCurrentLife());
                Console.WriteLine("|||||||||||||||||");
            } while (character1.GetCurrentAttackNumber() != 0 && character2.GetCurrentAttackNumber() != 0);

        }


        public string fight(Character character1, Character character2)
        {
            do
            {
                Console.WriteLine("Round starts");
                round(character1, character2);

            } while (isAlive(character1) || isAlive(character2));

            return isAlive(character1) ? character1.GetCharacterType() + " won" : character2.GetCharacterType();
        }
    }
} 
