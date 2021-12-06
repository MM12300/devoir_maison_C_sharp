using System;
using System.Collections.Generic;
using System.Linq;
using devoir_maison.CharacterTypes;


namespace devoir_maison
{
    //TODO CHANGE CONSOLEWRITELINE AVEC OPERATORS
    class Game
    {
        private Randomizer random = new Randomizer();

        //PAIN RULES
        public bool CanAttackPain(Character attacker)
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

        //PAIN RULES
        public void AttenuatePain(Character character)
        {
            if (character.GetPain() == -1)
            {
                Console.WriteLine("{0} pain is now back to normal ({1})", character.GetName(), character.GetPain());
            }
            if (character.GetPain() > -1)
            {
                int painBeforeAttenuation = character.GetPain();
                int painAfterAttenuation = character.GetPain() - 1;
                character.SetPain(painAfterAttenuation);
                Console.WriteLine("{0} pain decreases from {1} to {2}", character.GetName(), painBeforeAttenuation, painAfterAttenuation);
            }
        }


        public void CounterAttack(Character counterAttacker, Character counterDefender, int counterAttackValue)
        {
            //CHECK IF ATTACKERS AND DEFENDERS ARE ALIVE
            if (counterAttacker.IsAlive() && counterDefender.IsAlive())
            {
                if (counterAttacker.HasAttacks() && CanAttackPain(counterAttacker))
                {
                    counterAttacker.ShowLife();
                    counterDefender.ShowLife();

                    //Remove attacks to attacker
                    counterAttacker.SetCurrentAttackNumber(counterAttacker.GetCurrentAttackNumber() - 1);
                    int counterAttacking;

                    //GUARDIAN RULES
                    if (counterAttacker.GetCharacterType() == "Guardian")
                    {
                        Console.WriteLine("The {0} has a double counter-attack : counter-attacke value original ({1}) and now doubled ({2})", counterAttacker.GetCharacterType(), counterAttackValue, counterAttackValue * 2);
                        counterAttacking = counterAttacker.Fight_attack() + (counterAttackValue * -2);
                    }
                    else
                    {
                        counterAttacking = counterAttacker.Fight_attack() + (counterAttackValue * -1);
                    }
                    int counterDefending = counterDefender.Fight_defense();

                    int attack_margin = counterAttacking - counterDefending;

                    if (attack_margin > 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("COUNTER ATTACK SUCCESS");
                        Console.ResetColor();

                        int damage;
                        //BERSERKER RULE : add lost life points of Berserker to his damage during an attack
                        if (counterAttacker.GetCharacterType() == "Berserker")
                        {
                            int berserkerLostLifePoints = counterAttacker.GetMaximumLife() - counterAttacker.GetCurrentLife();
                            damage = attack_margin * (counterAttacker.GetDamages() + berserkerLostLifePoints) / 100;
                            Console.WriteLine("Berserker type of attack , lost live points : {0} = {1} - {2}", berserkerLostLifePoints, counterAttacker.GetMaximumLife(), counterAttacker.GetCurrentLife());
                        }
                        else
                        {
                            damage = attack_margin * counterAttacker.GetDamages() / 100;
                        }

                        int damageGiven = DamageModifier(counterAttacker, counterDefender, damage);
                        Console.WriteLine("DamageGiven ({0}) = {1} * {2} /100", damageGiven, attack_margin, counterAttacker.GetDamages());

                        //VAMPIRE RULE
                        if (counterAttacker.GetCharacterType() == "Vampire")
                        {
                            Console.WriteLine("VAmpire life modifier");
                            counterAttacker.LifeModifier((counterAttacker.GetCurrentLife() + (damageGiven / 2)));
                        }

                        counterDefender.SetCurrentLife(counterDefender.GetCurrentLife() - damageGiven);
                        Console.WriteLine("{0} **attacks** removes {1} life points to {2}", counterAttacker.GetName(), damageGiven, counterDefender.GetName());
                        Pain(counterDefender, damage, counterDefender.GetCurrentLife());
                    }
                    //Delta negative = defender counter-attack
                    else if (attack_margin <= 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("{0} has failded so {1} counter-attack BACK", counterAttacker.GetName(), counterDefender.GetName());
                        Console.WriteLine("Counter-Attack value = {0}", attack_margin);
                        Console.ResetColor();
                        CounterAttack(counterDefender, counterAttacker, attack_margin);
                    }
                }
            }
        }

        public void SimpleAttack(Character attacker, Character defender)
        {
            int damage;

            //CHECK IF ATTACKERS AND DEFENDERS ARE ALIVE
            if (attacker.IsAlive() && defender.IsAlive())
            {
                if (attacker.HasAttacks() && CanAttackPain(attacker))
                {
                    attacker.ShowLife();
                    defender.ShowLife();
                    //Remove attacks to attacker
                    attacker.SetCurrentAttackNumber(attacker.GetCurrentAttackNumber() - 1);
                    //calculate attack and defense values
                    int attacking = attacker.Fight_attack();
                    int defending = defender.Fight_defense();

                    //(marge d'attaque) calculate delta between attack and defense values
                    int attack_margin = attacking - defending;

                    if (attack_margin > 0)
                    {
                        //BERSERKER RULE : add lost life points of Berserker to his damage during an attack
                        if (attacker.GetCharacterType() == "Berserker")
                        {
                            int berserkerLostLifePoints = attacker.GetMaximumLife() - attacker.GetCurrentLife();
                            damage = attack_margin * (attacker.GetDamages() + berserkerLostLifePoints) / 100;
                            Console.WriteLine("Berserker type of attack , lost live points : {0} = {1} - {2}", berserkerLostLifePoints, attacker.GetMaximumLife(), attacker.GetCurrentLife());
                        }
                        else
                        {
                            damage = attack_margin * attacker.GetDamages() / 100;
                        }

                        int damageGiven = DamageModifier(attacker, defender, damage);

                        Console.WriteLine("DamageGiven ({0}) = {1} * {2} /100", damageGiven, attack_margin, attacker.GetDamages());

                        //VAMPIRE RULE
                        if (attacker.GetCharacterType() == "Vampire")
                        {
                            Console.WriteLine("Vampire life modifier");
                            attacker.LifeModifier((attacker.GetCurrentLife() + (damageGiven / 2)));
                        }

                        defender.SetCurrentLife(defender.GetCurrentLife() - damageGiven);
                        Console.WriteLine("{0} **attacks** removes {1} life points to {2}", attacker.GetName(), damageGiven, defender.GetName());
                        Pain(defender, damage, defender.GetCurrentLife());
                    }
                    //Delta negative = defender counter-attack
                    else if (attack_margin <= 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("{0} counter-attack", defender.GetName());
                        Console.WriteLine("Counter-Attacke value = {0}", attack_margin);
                        Console.ResetColor();

                        //ZOMBIE RULE : useless because zombie defense is 0 and defense roll is always 0 but better to keep it if we want to change this character parameters later
                        if (attacker.GetCharacterType() != "Zombie")
                        {
                            CounterAttack(defender, attacker, attack_margin);
                        }
                        else
                        {
                            Console.WriteLine("{0} can't counter attack, he is a {1}", attacker.GetName(), attacker.GetCharacterType());
                        }
                    }
                }
            }
        }

        public void BattleRoyaleAttackAndDefend(Character attacker, Character defender)
        {
            if (attacker.IsAlive() && defender.IsAlive())
            {
                Console.WriteLine("---------------");
                Console.WriteLine("{0} attack BEGINS", attacker.GetName());

                for (int i = 1; i <= attacker.GetTotalAttackNumber(); i++)
                {
                    if (attacker.IsAlive() && defender.IsAlive())
                    {
                        SimpleAttack(attacker, defender);
                    }
                }
                Console.WriteLine("{0} attack is OVER", attacker.GetName());
                attacker.ShowLife();
                defender.ShowLife();
            }
        }

        //PAIN RULES
        public void Pain(Character character, int damage, int defenderLifePointsLeft)
        {
            if (character.IsAlive())
            {
                if (character.GetIsLiving() || character.GetCharacterType() == "Ghoul")
                {
                    Console.WriteLine("{0} is a {1}", character.GetName(), character.GetCharacterType());
                    //BERSERKER AND PAIN RULE
                    if (character.GetCharacterType() != "Berserker")
                    {
                        Console.WriteLine("{0} is a living character sensitive to pain, damage {1}, lifePointsLeft {2}", character.GetName(), damage, character.GetCurrentLife());
                        if (damage > defenderLifePointsLeft)
                        {
                            double painPercentage = ((Convert.ToDouble(damage) - Convert.ToDouble(defenderLifePointsLeft)) * 2) / (Convert.ToDouble(defenderLifePointsLeft) + Convert.ToDouble(damage));

                            int roll = random.RandomNumber(0, 100);
                            double painRoll = Convert.ToDouble(roll);

                            Console.WriteLine("painPercentage = {0}, painRoll = {1}", painPercentage * 100, painRoll);

                            if (painPercentage * 100 > painRoll)
                            {
                                int roundsToSkip;

                                //WARRIOR RULES
                                if (character.GetCharacterType() == "Warrior")
                                {
                                    roundsToSkip = 0;
                                    Console.Write("When in pain the {0} ({1}) can only skip the current turn", character.GetCharacterType(), character.GetName());
                                }
                                else
                                {
                                    roundsToSkip = random.RandomNumber(0, 2);
                                }

                                Console.WriteLine("rounds to skip possible = {0}", roundsToSkip);

                                if (character.GetPain() < roundsToSkip)
                                {
                                    character.SetPain(roundsToSkip);
                                    Console.WriteLine("{0} has now a pain of ({1})", character.GetName(), character.GetPain());
                                }
                                else
                                {
                                    Console.WriteLine("Pain is already here and stronger than that", character);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Luckily don't feel the pain, painPercentage = {0}", painPercentage);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pain is not strong enough to affect {0}", character.GetName());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Berserker doesn't feel the pain");
                    }
                }
                else
                {
                    Console.WriteLine("Undead doesn't feel the pain, except the ghoul");
                }
            }
            else
            {
                Console.WriteLine("{0} is dead so can't feel the pain", character.GetName());
            }
        }

        //CURSED AND BLESSED RULES
        public int DamageModifier(Character attacker, Character defender, int damage)
        {
            // if defender = blessed AND attacker = cursed OR defender = cursed AND attacker = blessed, life points lost after attack multiplied by 2
            if ((defender.GetIsBlessed() && attacker.GetCursedDamage()) || (defender.GetIsCursed() && attacker.GetBlessedDamage()))
            {
                int doubleDamage = damage * 2;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Attacker is a {0} and defender is a {1} so damage*2 = {2} * 2 = {3}", attacker.GetCharacterType(), defender.GetCharacterType(), damage, doubleDamage);
                Console.ResetColor();
                return doubleDamage;
            }
            else
            {
                return damage;
            }
        }

        public void BattleRoyaleResetAttackNumber(List<Character> fightersList)
        {
            foreach (Character fighter in fightersList)
            {
                //BERSERKER RULE
                if (fighter.GetCharacterType() == "Berserker" && fighter.GetCurrentLife() < (fighter.GetMaximumLife() / 2))
                {
                    Console.WriteLine("{0} is a {1} with less than half of its total life points {2}/{3}", fighter.GetName(), fighter.GetCharacterType(), fighter.GetCurrentLife(), fighter.GetMaximumLife());
                    fighter.SetCurrentAttackNumber(4);
                    fighter.SetTotalAttackNumber(4);
                    Console.WriteLine("Attack number is set at {0}", fighter.GetCurrentAttackNumber());
                }
                else
                {
                    fighter.SetCurrentAttackNumber(fighter.GetTotalAttackNumber());
                }
            }
        }

        public List<Character> BattleRoyaleFightersList()
        {
            Character jojo = new Zombie("JOJO zobie");
            Character jiji = new Zombie("JIJI zobie");
            Character jaja = new Zombie("JAJA zobie");
            Character juju = new Vampire("juju le mort-vivant vampire");
            Character test = new Priest("test");
            Character bobby = new Priest("bobby");
            Character billy = new Priest("billy");

            List<Character> fightersList = new List<Character>
            {
                jojo,
                jiji,
                jaja
            };
            //fightersList.Add(jaja);
            //fightersList.Add(juju);
            //fightersList.Add(test);

            return fightersList;
        }

        public List<Character> BattleRoyaleFightersInitiative(List<Character> fightersList)
        {

            Dictionary<Character, int> fightersUnsorted = new Dictionary<Character, int>();

            foreach (Character fighter in fightersList)
            {
                if (fighter.IsAlive())
                {
                    fightersUnsorted.Add(fighter, fighter.Fight_initiative());
                }

            }

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Fighters list :");
            foreach (KeyValuePair<Character, int> fighters in fightersUnsorted)
            {
                Console.WriteLine("Character name: {0}, Initiative: {1}",
                    fighters.Key.GetName(), fighters.Value);

            }
            Console.ResetColor();

            var fightersSorted = from entry in fightersUnsorted orderby entry.Value descending select entry;
            Console.WriteLine("-----------");

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Fighters list By Initiative :");
            foreach (KeyValuePair<Character, int> fighters in fightersSorted)
            {
                Console.WriteLine("Character name: {0}, Initiative: {1}",
                    fighters.Key.GetName(), fighters.Value);

            }
            Console.ResetColor();

            List<Character> fightersListInitiative = fightersSorted.Select(kvp => kvp.Key).ToList();

            return fightersListInitiative;
        }

        public void BattleRoyaleRound(List<Character> fightersList)
        {
            //si les combattants sont vivants à tester ?
            List<Character> fightersListSortedByInitiative = BattleRoyaleFightersInitiative(fightersList);

            foreach (Character fighter in fightersListSortedByInitiative)
            {
                Console.WriteLine("ATTAQUE DE {0}", fighter.GetName());

                //KAMIKAZE ATTACK
                if (fighter.GetCharacterType() == "Kamikaze")
                {
                    KamikazeAttack(fighter, fightersListSortedByInitiative);
                }
                else
                {
                    Character opponent = ChooseOpponent(fightersListSortedByInitiative, fighter);
                    BattleRoyaleAttackAndDefend(fighter, opponent);
                }
            }
            Scavenging(fightersListSortedByInitiative);
            BattleRoyaleResetAttackNumber(fightersListSortedByInitiative);


            //SCAVENGER GET LIFEPOINTS ONLY AT THE END OF THE ROUND

        }

        public void BattleRoyaleFight(List<Character> fightersList)
        {
            int roundNumber = 1;
            while (AreFightersStillAlive(fightersList))
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("LETS START THE ROUND {0} ? (push enter key)", roundNumber);
                Console.ResetColor();
                Console.ReadLine();
                BattleRoyaleRound(fightersList);
                roundNumber++;
            }

            //TODO: Do I need to return a value ?
        }

        public bool AreFightersStillAlive(List<Character> fightersList)
        {
            List<Character> aliveFighters = new List<Character>();

            foreach (Character fighter in fightersList)
            {
                if (fighter.GetCurrentLife() > 0)
                {
                    aliveFighters.Add(fighter);
                }
                else
                {
                    Console.WriteLine("{0} is dead", fighter.GetName());
                }
            }

            if (aliveFighters.Count() >= 2)
            {
                Console.WriteLine("{0} still on the fight", aliveFighters.Count());
                return true;
            }
            else
            {
                Console.WriteLine("only one fighter is left : {0} is the winner", aliveFighters[0].GetName());
                return false;
            }
        }

        public void BattleRoyale()
        {
            List<Character> allFighters = BattleRoyaleFightersList();
            BattleRoyaleFight(allFighters);
        }

        public Character ChooseOpponent(List<Character> fighterList, Character attacker)
        {
            List<Character> opponentsList = new List<Character>(fighterList);
            opponentsList.Remove(attacker);

            List<Character> opponentsListAlive = new List<Character>();

            foreach (Character opponent in opponentsList)
            {
                if (opponent.IsAlive())
                {
                    opponentsListAlive.Add(opponent);
                }
            }

            //PRIEST RULE
            if (attacker.GetCharacterType() == "Priest")
            {
                List<Character> opponentsUndeadList = new List<Character>();
                foreach (Character opponent in opponentsListAlive)
                {
                    if (!opponent.GetIsLiving())
                    {
                        Console.WriteLine("{0} is a priest and attack living fighters in priority so {1} is added to a new opponents list", attacker.GetName(), opponent.GetName());
                        opponentsUndeadList.Add(opponent);
                    }
                    else
                    {
                        Console.WriteLine("{0} is a priest and attack living fighters in priority so {1} is NOT added to a new opponents list", attacker.GetName(), opponent.GetName());
                    }
                }
                return PickRandomFighter(attacker, opponentsUndeadList);
            }
            else
            {
                return PickRandomFighter(attacker, opponentsListAlive);
            }
        }

        public Character PickRandomFighter(Character attacker, List<Character> opponentsList)
        {
            int randomFighterIndex = random.RandomNumber(0, opponentsList.Count() - 1);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("{0} is attacking {1}", attacker.GetName(), opponentsList[randomFighterIndex].GetName());
            Console.ResetColor();
            return opponentsList[randomFighterIndex];
        }

        public void KamikazeAttack(Character kamikaze, List<Character> fightersList)
        {
            List<Character> opponentsList = new List<Character>(fightersList);
            opponentsList.Remove(kamikaze);

            int attacking = kamikaze.Fight_attack();

            foreach (Character fighter in opponentsList)
            {
                if (!fighter.LuckyRoll())
                {
                    Console.WriteLine("{0} is not lucky and so {1} the {2} attacks him", fighter.GetCharacterType(), kamikaze.GetName(), kamikaze.GetCharacterType());
                    kamikaze.SetCurrentAttackNumber(kamikaze.GetCurrentAttackNumber() - 1);
                    int defending = fighter.Fight_defense();
                    int attack_margin = attacking - defending;
                    if (attack_margin > 0)
                    {
                        Console.WriteLine("{0} attacks is successfull", kamikaze.GetCharacterType());
                        int damage = attack_margin * kamikaze.GetDamages() / 100;
                        int damageGiven = DamageModifier(kamikaze, fighter, damage);
                        Console.WriteLine("DamageGiven ({0}) = {1} * {2} /100", damageGiven, attack_margin, kamikaze.GetDamages());
                        fighter.SetCurrentLife(fighter.GetCurrentLife() - damageGiven);
                        Console.WriteLine("{0} **attacks** removes {1} life points to {2}", kamikaze.GetName(), damageGiven, fighter.GetName());
                        Pain(fighter, damage, fighter.GetCurrentLife());
                    }
                    else
                    {
                        Console.WriteLine("{0} attacks is not successfull", kamikaze.GetCharacterType());
                    }
                }
                else
                {
                    Console.WriteLine("{0} is lucky and avoids attack from {1} the {2}", fighter.GetCharacterType(), kamikaze.GetName(), kamikaze.GetCharacterType());
                }
            }
        }

        public void Scavenging(List<Character> fighters)
        {
            List<Character> scavengers = new List<Character>();

            foreach (Character character in fighters)
            {
                if (character.GetCharacterType() == "Zombie" && character.GetCurrentLife() > 0)
                {
                    scavengers.Add(character);
                }
            }

            foreach (Character character in fighters)
            {
                if (!character.IsAlive())
                {
                    foreach (Character scavenger in scavengers)
                    {
                        int scavengerAddedLife = random.RandomNumber(50, 100);
                        Console.WriteLine("{0} is eating {1} and gain {2} lifepoints", scavenger.GetName(), character.GetName(), scavengerAddedLife);
                        scavenger.SetCurrentLife(scavenger.GetCurrentLife() + scavengerAddedLife);
                        if (scavenger.GetCurrentLife() > scavenger.GetMaximumLife())
                        {
                            scavenger.SetCurrentLife(scavenger.GetMaximumLife());
                        }
                    }
                }
            }
        }
    }
}
