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

        public int rollOf(string typeOfRoll, int rollValue, Character character)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            int rollResult = 0;
            if (typeOfRoll == "attack")
            {
                rollResult = rollValue + character.GetAttack();
                Console.WriteLine("/!/ROLL/!/ => {0} attack = {1} (roll:{2}+attack:{3})", character.GetName(), rollResult, rollValue, character.GetAttack());

            }
            else if (typeOfRoll == "initiative")
            {
                rollResult = rollValue + character.GetInitiative();
                Console.WriteLine("/!/ROLL/!/ => {0} initiative = {1} (roll:{2}+initiative:{3})", character.GetName(), rollResult, rollValue, character.GetInitiative());

            }
            else if (typeOfRoll == "defense")
            {
                rollResult = rollValue + character.GetDefense();
                Console.WriteLine("/!/ROLL/!/ => {0} defense = {1} (roll:{2}+defense:{3})", character.GetName(), rollResult, rollValue, character.GetDefense());
            }

            Console.ResetColor();
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
                Console.WriteLine("{0} ({1}) is dead", character.GetName(), character.GetName());
                return false;
            }
            else
            {
                return true;
            }
        }

        public void showLife(Character character)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("<3<3<3 -- {0} has {1}/{2} lifepoints -- <3<3<3", character.GetName(), character.GetCurrentLife(), character.GetMaximumLife());
            Console.ResetColor();
        }

        //TODO A COMPLETER REMAPL:CER IF ELSE DANS SIMPLE ATTACK ET COUNTER ATTACK
        public bool hasAttacks(Character attacker) 
        {
            if(attacker.GetCurrentAttackNumber() > 0)
            {
                Console.WriteLine("{0} attacks ({1}/{2})", attacker.GetName(), attacker.GetCurrentAttackNumber(), attacker.GetTotalAttackNumber());
                return true;
            }
            else
            {
                Console.WriteLine("Counter-attack is cancelled : {0} has no more attacks ({1}/{2})", attacker.GetName(), attacker.GetCurrentAttackNumber(), attacker.GetTotalAttackNumber());
                return false;
            }
        }

        public bool canAttackPain(Character attacker)
        {     
            if (attacker.GetIsLiving())
            {
                if (attacker.GetPain() > -1)
                {
                    Console.WriteLine("{0} must skip turn because of pain ({1})", attacker.GetName(), attacker.GetPain());
                    return false;
                }
                else
                {
                    Console.WriteLine("No turn to skip because of pain");
                    return true;
                }
            }
            else
            {
                Console.WriteLine("{0} is not sensitive do pain", attacker.GetName());
                return true;
            }

        }

        public void attenuatePain(Character character)
        {
            if (character.GetPain() > -1)
            {
                int painBeforeAttenuation = character.GetPain();
                int painAfterAttenuation = character.GetPain() - 1;
                character.SetPain(painAfterAttenuation);
                Console.WriteLine("{0} pain decreases from {1} to {2}", character.GetName(), painBeforeAttenuation, painAfterAttenuation);
            }
            if(character.GetPain() == -1)
            {
                Console.WriteLine("{0} pain is now back to normal ({1})", character.GetName(), character.GetPain());
            }
        }


        public void counterAttack(Character counterAttacker, Character counterDefender, int counterAttackValue)
        {
            //CHECK IF ATTACKERS AND DEFENDERS ARE ALIVE
            if (isAlive(counterAttacker) && isAlive(counterDefender))
            {
                if (hasAttacks(counterAttacker) && canAttackPain(counterAttacker))
                {
                    showLife(counterAttacker);
                    showLife(counterDefender);

                    //Remove attacks to attacker
                    counterAttacker.SetCurrentAttackNumber(counterAttacker.GetCurrentAttackNumber() - 1);
                    int counterAttacking = attack(counterAttacker);
                    int counterDefending = defense(counterDefender);

                    int fighting = counterAttacking - counterDefending;

                    if (fighting > 0)
                    {
                        Console.WriteLine("Counter-Attack : {0}", counterAttackValue);
                        counterDefender.SetCurrentLife(counterDefender.GetCurrentLife() - (-counterAttackValue));
                        Console.WriteLine("{0} **counter-attacks** : removes {1} life points to {2}", counterAttacker.GetName(), counterAttackValue, counterDefender.GetName());
                        pain(counterDefender, (-counterAttackValue), counterDefender.GetCurrentLife());
                    }
                    //Delta negative = defender counter-attack
                    else if (fighting <= 0)
                    {
                        Console.WriteLine("{0} counter-attack", counterDefender.GetName());
                        Console.WriteLine("Counter-Attacke value = {0}", fighting);
                        counterAttack(counterDefender, counterAttacker, fighting);
                    }
                }
            }
        }

        public void simpleAttack(Character attacker, Character defender)
        {
            //CHECK IF ATTACKERS AND DEFENDERS ARE ALIVE
            if (isAlive(attacker) && isAlive(defender)){
                if (hasAttacks(attacker) && canAttackPain(attacker))
                {
                    showLife(attacker);
                    showLife(defender);
                    //Remove attacks to attacker
                    attacker.SetCurrentAttackNumber(attacker.GetCurrentAttackNumber() - 1);
                    //calculate attack and defense values
                    int attacking = attack(attacker);
                    int defending = defense(defender);

                    //(marge d'attaque) calculate delta between attack and defense values
                    int fighting = attacking - defending;

                    if (fighting > 0)
                    {
                        int damage = fighting * attacker.GetDamages() / 100;
                        Console.WriteLine("Damage ({0}) = {1} * {2} /100", damage, fighting, attacker.GetDamages());
                        defender.SetCurrentLife(defender.GetCurrentLife() - damage);
                        Console.WriteLine("{0} **attacks** removes {1} life points to {2}", attacker.GetName(), damage, defender.GetName());
                        pain(defender, damage, defender.GetCurrentLife());
                    }
                    //Delta negative = defender counter-attack
                    else if (fighting <= 0)
                    {
                        Console.WriteLine("{0} counter-attack", defender.GetName());
                        Console.WriteLine("Counter-Attacke value = {0}", fighting);
                        counterAttack(defender, attacker, fighting);
                    }
                }
            }
        }


        public void attackAndDefend(Character attacker, Character defender)
        {
                if (attacker.GetCurrentLife() > 0 && defender.GetCurrentLife() > 0)
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine("{0} attack BEGINS", attacker.GetName());

                    for (int i = 1; i <= attacker.GetTotalAttackNumber(); i++)
                    {
                        if(isAlive(attacker) && isAlive(defender))
                        {
                            simpleAttack(attacker, defender);
                        }
                    }
                    Console.WriteLine("{0} attack is OVER", attacker.GetName());
                    showLife(attacker);
                    showLife(defender);
                    Console.WriteLine("---------------");
                    Console.WriteLine("{0} attack BEGINS", defender.GetName());

                    for (int j = 0; j < defender.GetTotalAttackNumber(); j++)
                    {
                        if (isAlive(attacker) && isAlive(defender))
                        {
                            simpleAttack(defender, attacker);
                        }
                    }
                    Console.WriteLine("{0} attack is OVER", defender.GetName());
                    showLife(attacker);
                    showLife(defender);
                }
        }


        public void round(Character character1, Character character2, int roundNumber)
        {
            if (isAlive(character1) && isAlive(character2))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("===================");
                Console.WriteLine("A NEW ROUND STARTS : {0} LIFEPOINTS : {1} --- {2} LIFEPOINTS : {3}", character1.GetName(), character1.GetCurrentLife(), character2.GetName(), character2.GetCurrentLife());
                Console.WriteLine("===================");
                Console.ResetColor();

                //RESET CURENT ATTACK NUMBER
                character1.SetCurrentAttackNumber(character1.GetTotalAttackNumber());
                character2.SetCurrentAttackNumber(character2.GetTotalAttackNumber());

                //INITIATIVE
                int rollInitiativeCharacter1 = roll();
                int rollInitiativeCharacter2 = roll();
                int initiativeRollCharacter1 = rollOf("initiative", rollInitiativeCharacter1, character1);
                int initiativeRollCharacter2 = rollOf("initiative", rollInitiativeCharacter2, character2);
                if (initiativeRollCharacter1 > initiativeRollCharacter2)
                {
                    Console.WriteLine("@@@@@@ {0} has initiative @@@@@@", character1.GetName(), character1.GetTotalAttackNumber());
                    attackAndDefend(character1, character2);
                }
                else if (initiativeRollCharacter1 < initiativeRollCharacter2)
                {
                    Console.WriteLine("@@@@@@ {0} has initiative @@@@@@", character2.GetName(), character2.GetTotalAttackNumber());
                    attackAndDefend(character2, character1);
                }else if(initiativeRollCharacter1 == initiativeRollCharacter2)
                {
                    int randomRoll = roll();
                    if(randomRoll >= 50)
                    {
                        attackAndDefend(character1, character2);
                    }
                    else
                    {
                        attackAndDefend(character2, character1);
                    }
                }

                attenuatePain(character1);
                attenuatePain(character2);

                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("===================");
                Console.WriteLine("THE ROUND IS OVER : {0} LIFEPOINTS : {1} --- {2} LIFEPOINTS : {3}", character1.GetName(), character1.GetCurrentLife(), character2.GetName(), character2.GetCurrentLife());
                Console.WriteLine("===================");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("One fighter is dead !");
            }
        }

        public string fight(Character character1, Character character2)
        {
            int roundNumber = 1;
            while (isAlive(character1) && isAlive(character2))
            {
                Console.WriteLine("LETS START THE ROUND {0} ? (push enter key)", roundNumber);
                Console.ReadLine();
                round(character1, character2, roundNumber);
                roundNumber++;
            }
            return isAlive(character1) ? character1.GetName() + " won" : character2.GetName();
        }


        public void pain(Character character, int damage, int defenderLifePointsLeft)
        {
            if (character.GetIsLiving())
            {
                Console.WriteLine("{0} is a living character sensitive to pain, damage {1}, lifePointsLeft {2}", character.GetName(), damage, character.GetCurrentLife());
                Console.WriteLine("Damage, defenderLifePointsleft : {1}", damage, defenderLifePointsLeft);
                if (damage > defenderLifePointsLeft)
                {
                    float painPercentage = ((damage - defenderLifePointsLeft) * 2) / (defenderLifePointsLeft + damage);

                    if(painPercentage * 100 > roll())
                    {
                        Random random = new Random();
                        int roundsToSkip = random.Next(0, 2);
                        if (character.GetPain() < roundsToSkip)
                        {
                            character.SetPain(roundsToSkip);
                        }
                        else
                        {
                            Console.WriteLine("Pain is already here and stronger than that", character);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Luckily don't feel the pain");
                    }
                }else
                {
                    Console.WriteLine("Pain is not strong enough to affect {0}", character.GetName());
                }
            }
            else
            {
                Console.WriteLine("Undead are not sensitive to pain");
            }
        }

        public void removePain(Character character)
        {
            if(character.GetPain() > -1)
            {
                character.SetPain(character.GetPain() - 1);
                Console.WriteLine("{0} pain is decreased", character.GetName());
            }
        }
    }
}
