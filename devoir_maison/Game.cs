using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using devoir_maison.CharacterTypes;


namespace devoir_maison
{
    //TODO CHANGE CONSOLEWRITELINE AVEC OPERATORS
    class Game
    {
        public int roll()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 100);
            //WITHOUT DELAY ADDED THE ROLLS ALWAYS SEND THE SAME NUMBERS
            Thread.Sleep(100);
            return randomNumber;
        }

        public bool luckyRoll()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 100);
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

        public int rollOf(string typeOfRoll, int rollValue, Character character)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            int rollResult;

            //ROBOT RULES
            if(character.GetCharacterType() == "Robot")
            {
                if (typeOfRoll == "attack")
                {
                    rollResult = 50 + character.GetAttack();
                    Console.WriteLine("/!/ROLL/!/ => {0} attack = {1} (50 + attack:{2})", character.GetName(), rollResult, character.GetAttack());
                }
                else if (typeOfRoll == "initiative")
                {
                    rollResult = 50 + character.GetInitiative();
                    Console.WriteLine("/!/ROLL/!/ => {0} initiative = {1} (50 + initiative:{2})", character.GetName(), rollResult, character.GetInitiative());

                }
                else if (typeOfRoll == "defense")
                {
                    rollResult = 50 + character.GetDefense();
                    Console.WriteLine("/!/ROLL/!/ => {0} defense = {1} (50 + defense:{2})", character.GetName(), rollResult, character.GetDefense());
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
                    //ZOMBIE RULE
                    if (character.GetCharacterType() == "Zombie")
                    {
                        Console.WriteLine("{0} defense roll is always 0", character.GetCharacterType());
                        rollResult = character.GetDefense();
                    }
                    else
                    {
                        rollResult = rollValue + character.GetDefense();
                    }

                    Console.WriteLine("/!/ROLL/!/ => {0} defense = {1} (roll:{2}+defense:{3})", character.GetName(), rollResult, rollValue, character.GetDefense());
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

        public int initiative(Character character)
        {
            int rollValue = roll();
            int initiativeRollValue = rollOf("initiative", rollValue, character);
            return initiativeRollValue;
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

        public bool hasAttacks(Character attacker) 
        {
            if(attacker.GetCurrentAttackNumber() > 0)
            {
                Console.WriteLine("{0} attacks ({1}/{2})", attacker.GetName(), attacker.GetCurrentAttackNumber(), attacker.GetTotalAttackNumber());
                return true;
            }
            else
            {
                Console.WriteLine("Attacking is cancelled : {0} has no more attacks ({1}/{2})", attacker.GetName(), attacker.GetCurrentAttackNumber(), attacker.GetTotalAttackNumber());
                return false;
            }
        }

        //PAIN RULES
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

        //PAIN RULES
        public void attenuatePain(Character character)
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

        public void checkCharacterType(Character character)
        {
            //ROBOT RULES
            if(character.GetCharacterType() == "Robot")
            {
                Console.WriteLine("Robot attack was {0}", character.GetAttack());
                character.SetAttack(Convert.ToInt32(character.GetAttack() * 1.5));
                Console.WriteLine("Robot attack is now {0}", character.GetAttack());
            }

            //PRIEST RULES
            if(character.GetCharacterType() == "Priest")
            {
                Console.WriteLine("Priest rule");
                Console.WriteLine("{1} life before : {0}", character.GetCurrentLife(), character.GetName());
                lifeModifier(character, (Convert.ToInt32(character.GetMaximumLife() * 0.1)));
                Console.WriteLine("{1} life after : {0}", character.GetCurrentLife(), character.GetName());
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
                    int counterAttacking;

                    //GUARDIAN RULES
                    if (counterAttacker.GetCharacterType() == "Guardian")
                    {
                        Console.WriteLine("The {0} has a double counter-attack : counter-attacke value original ({1}) and now doubled ({2})", counterAttacker.GetCharacterType(), counterAttackValue, counterAttackValue * 2);
                        counterAttacking = attack(counterAttacker) + (counterAttackValue * -2);
                    }
                    else
                    {
                        counterAttacking = attack(counterAttacker) + (counterAttackValue * -1);
                    }
                    int counterDefending = defense(counterDefender);

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

                        int damageGiven = damageModifier(counterAttacker, counterDefender, damage);
                        Console.WriteLine("DamageGiven ({0}) = {1} * {2} /100", damageGiven, attack_margin, counterAttacker.GetDamages());

                        //VAMPIRE RULE
                        if (counterAttacker.GetCharacterType() == "Vampire")
                        {
                            Console.WriteLine("VAmpire life modifier");
                            lifeModifier(counterAttacker, (counterAttacker.GetCurrentLife() + (damageGiven / 2)));
                        }

                        counterDefender.SetCurrentLife(counterDefender.GetCurrentLife() - damageGiven);
                        Console.WriteLine("{0} **attacks** removes {1} life points to {2}", counterAttacker.GetName(), damageGiven, counterDefender.GetName());
                        pain(counterDefender, damage, counterDefender.GetCurrentLife());
                    }
                    //Delta negative = defender counter-attack
                    else if (attack_margin <= 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("{0} has failded so {1} counter-attack BACK", counterAttacker.GetName(), counterDefender.GetName());
                        Console.WriteLine("Counter-Attack value = {0}", attack_margin);
                        Console.ResetColor();
                        counterAttack(counterDefender, counterAttacker, attack_margin);
                    }
                }
            }
        }

        public void simpleAttack(Character attacker, Character defender)
        {
            int damage;

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
                    int attack_margin = attacking - defending;

                    if (attack_margin > 0)
                    {
                        //BERSERKER RULE : add lost life points of Berserker to his damage during an attack
                        if (attacker.GetCharacterType() == "Berserker")
                        {
                            int berserkerLostLifePoints = attacker.GetMaximumLife() - attacker.GetCurrentLife();
                            damage = attack_margin * (attacker.GetDamages()+berserkerLostLifePoints) / 100;
                            Console.WriteLine("Berserker type of attack , lost live points : {0} = {1} - {2}", berserkerLostLifePoints, attacker.GetMaximumLife(), attacker.GetCurrentLife());
                        }
                        else
                        {
                            damage = attack_margin * attacker.GetDamages() / 100;
                        }

                        int damageGiven = damageModifier(attacker, defender, damage);

                        Console.WriteLine("DamageGiven ({0}) = {1} * {2} /100", damageGiven, attack_margin, attacker.GetDamages());

                        //VAMPIRE RULE
                        if (attacker.GetCharacterType() == "Vampire")
                        {
                            Console.WriteLine("Vampire life modifier");
                            lifeModifier(attacker, (attacker.GetCurrentLife() + (damageGiven / 2)));
                        }

                        defender.SetCurrentLife(defender.GetCurrentLife() - damageGiven);
                        Console.WriteLine("{0} **attacks** removes {1} life points to {2}", attacker.GetName(), damageGiven, defender.GetName());
                        pain(defender, damage, defender.GetCurrentLife());
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
                            counterAttack(defender, attacker, attack_margin);
                        }
                        else
                        {
                            Console.WriteLine("{0} can't counter attack, he is a {1}", attacker.GetName(), attacker.GetCharacterType());
                        }
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


        public void battleRoyaleAttackAndDefend(Character attacker, Character defender)
        {
            if (attacker.GetCurrentLife() > 0 && defender.GetCurrentLife() > 0)
            {
                Console.WriteLine("---------------");
                Console.WriteLine("{0} attack BEGINS", attacker.GetName());

                for (int i = 1; i <= attacker.GetTotalAttackNumber(); i++)
                {
                    if (isAlive(attacker) && isAlive(defender))
                    {



                        simpleAttack(attacker, defender);
                    }
                }
                Console.WriteLine("{0} attack is OVER", attacker.GetName());
                showLife(attacker);
                showLife(defender);
            }
        }

        public void round(Character character1, Character character2)
        {
            if (isAlive(character1) && isAlive(character2))
            {
                checkCharacterType(character1);
                checkCharacterType(character2);

                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("===================");
                Console.WriteLine("A NEW ROUND STARTS : {0} LIFEPOINTS : {1} --- {2} LIFEPOINTS : {3}", character1.GetName(), character1.GetCurrentLife(), character2.GetName(), character2.GetCurrentLife());
                Console.WriteLine("===================");
                Console.ResetColor();

                //RESET CURENT ATTACK NUMBER (BERSERKER RULE)
                resetAttackNumber(character1);
                resetAttackNumber(character2);

                //INITIATIVE
                int initiativeRollCharacter1 = initiative(character1);
                int initiativeRollCharacter2 = initiative(character2);
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
                    if(luckyRoll())
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
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("LET'S START THE ROUND {0} ? (push enter key)", roundNumber);
                Console.ResetColor();
                Console.ReadLine();
                round(character1, character2);
                roundNumber++;
            }
            return isAlive(character1) ? character1.GetName() + " won" : character2.GetName();
        }

        //PAIN RULES
        public void pain(Character character, int damage, int defenderLifePointsLeft)
        {
            if (isAlive(character))
            {
                if(character.GetIsLiving() || character.GetCharacterType() == "Ghoul"){
                    Console.WriteLine("{0} is a {1}", character.GetName(), character.GetCharacterType());
                    //BERSERKER AND PAIN RULE
                    if (character.GetCharacterType() != "Berserker")
                    {
                        Console.WriteLine("{0} is a living character sensitive to pain, damage {1}, lifePointsLeft {2}", character.GetName(), damage, character.GetCurrentLife());
                        if (damage > defenderLifePointsLeft)
                        {
                            double painPercentage = ((Convert.ToDouble(damage) - Convert.ToDouble(defenderLifePointsLeft)) * 2) / (Convert.ToDouble(defenderLifePointsLeft) + Convert.ToDouble(damage));

                            Random random = new Random();
                            int roll = random.Next(1, 100);
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
                                    Random pain = new Random();
                                    roundsToSkip = pain.Next(0, 2);
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
        public int damageModifier(Character attacker, Character defender, int damage)
        {
            // if defender = blessed AND attacker = cursed OR defender = cursed AND attacker = blessed, life points lost after attack multiplied by 2
            if( (defender.GetIsBlessed() && attacker.GetCursedDamage()) || (defender.GetIsCursed() && attacker.GetBlessedDamage()) ){
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

        public void lifeModifier(Character character, int lifeModifier)
        {
            int newLifeValue = character.GetCurrentLife() + lifeModifier;

            if (newLifeValue > character.GetMaximumLife())
            {
                Console.WriteLine("new life value is maxed");
                character.SetCurrentLife(character.GetMaximumLife());
            }
            else
            {
                Console.WriteLine("Life has been changed");
                character.SetCurrentLife(newLifeValue);
            }
        }

        public void resetAttackNumber(Character character)
        {
            //BERSERKER RULE
            if (character.GetCharacterType() == "Berserker" && character.GetCurrentLife() < (character.GetMaximumLife()/2))
            {
                Console.WriteLine("{0} is a {1} with less than half of its total life points {2}/{3}", character.GetName(), character.GetCharacterType(), character.GetCurrentLife(), character.GetMaximumLife());
                character.SetCurrentAttackNumber(4);
                character.SetTotalAttackNumber(4);
                Console.WriteLine("Attack number is set at {0}", character.GetCurrentAttackNumber());
            }
            else
            {
                character.SetCurrentAttackNumber(character.GetTotalAttackNumber());
            }
        }

        public void battleRoyaleResetAttackNumber(List<Character> fightersList)
        {
            foreach(Character fighter in fightersList){
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

        public List<Character> battleRoyaleFightersList()
        {
            Character jojo = new Testing_character("JoJo le PRIEST");
            Character jiji = new Testing_character("jiji testing");
            Character jaja = new Kamikaze("jaja kamikaze");
            Character juju = new Vampire("juju le mort-vivant vampire");
            Character test = new Priest("test");
            Character bobby = new Priest("bobby");
            Character billy = new Priest("billy");

            List<Character> fightersList = new List<Character>();

            fightersList.Add(jojo);
            fightersList.Add(jiji);
            fightersList.Add(jaja);
            //fightersList.Add(juju);
            //fightersList.Add(test);

            return fightersList;
        }

        public List<Character> battleRoyaleFightersInitiative(List<Character> fightersList)
        {
            
            Dictionary<Character, int> fightersUnsorted = new Dictionary<Character, int>();

            foreach (Character fighter in fightersList)
            {
                fightersUnsorted.Add(fighter, initiative(fighter));
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

        public void battleRoyaleRound(List<Character> fightersList)
        {
            //si les combattants sont vivants à tester ?
            List<Character> fightersListSortedByInitiative = battleRoyaleFightersInitiative(fightersList);

            foreach (Character fighter in fightersListSortedByInitiative)
            {
                Console.WriteLine("ATTAQUE DE {0}", fighter.GetName());

                //KAMIKAZE ATTACK
                if(fighter.GetCharacterType() == "Kamikaze")
                {
                    kamikazeAttack(fighter, fightersList);
                }
                else
                {
                    Character opponent = chooseOpponent(fightersList, fighter);
                    battleRoyaleAttackAndDefend(fighter, opponent);
                }
            }

            battleRoyaleResetAttackNumber(fightersList);
        }




        public void battleRoyaleFight(List <Character> fightersList)
        {
            int roundNumber = 1;
            while (areFightersStillAlive(fightersList))
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("LETS START THE ROUND {0} ? (push enter key)", roundNumber);
                Console.ResetColor();
                Console.ReadLine();
                battleRoyaleRound(fightersList);
                roundNumber++;
            }
            
            //TODO: Do I need to return a value ?
        }
        
        public bool areFightersStillAlive(List<Character> fightersList)
        {
            List<Character> aliveFighters = new List<Character>();
            
            foreach (Character fighter in fightersList)
            {
                if(fighter.GetCurrentLife() > 0)
                {
                    aliveFighters.Add(fighter);
                }
                else
                {
                    Console.WriteLine("{0} is dead", fighter.GetName());
                }
            }

            if(aliveFighters.Count() >= 2)
            {
                Console.WriteLine("{0} still on the fight", aliveFighters.Count());
                return true;
            }
            else
            {
                Console.WriteLine("only one fighter is left : {0} is the winner", aliveFighters[0]);
                return false;
            }
        }

        public void battleRoyale()
        {
            List<Character> allFighters = battleRoyaleFightersList();
            battleRoyaleFight(allFighters);
        }

        public Character chooseOpponent(List<Character> fighterList, Character attacker)
        {
            List<Character> opponentsList = new List<Character>(fighterList);
            opponentsList.Remove(attacker);

            //PRIEST RULE
            if(attacker.GetCharacterType() == "Priest")
            {
                List<Character> opponentsUndeadList = new List<Character>();
                foreach (Character opponent in opponentsList)
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
                return pickRandomFighter(attacker, opponentsUndeadList);
            }
            else
            {
                return pickRandomFighter(attacker, opponentsList);
            }
            
        }

        public Character pickRandomFighter(Character attacker, List<Character> opponentsList)
        {
            Random random = new Random();
            Thread.Sleep(100);
            int randomFighterIndex = random.Next(0, opponentsList.Count() - 1);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("{0} is attacking {1}", attacker.GetName(), opponentsList[randomFighterIndex].GetName());
            Console.ResetColor();
            return opponentsList[randomFighterIndex];
        }

        public void kamikazeAttack(Character kamikaze, List<Character> fightersList)
        {
            List<Character> opponentsList = new List<Character>(fightersList);
            opponentsList.Remove(kamikaze);

            int attacking = attack(kamikaze);

            foreach (Character fighter in opponentsList)
            {
                if (!luckyRoll())
                {
                    Console.WriteLine("{0} is not lucky and so {1} the {2} attacks him", fighter.GetCharacterType(), kamikaze.GetName(), kamikaze.GetCharacterType());
                    kamikaze.SetCurrentAttackNumber(kamikaze.GetCurrentAttackNumber() - 1);
                    int defending = defense(fighter);
                    int attack_margin = attacking - defending;
                    if(attack_margin > 0)
                    {
                        Console.WriteLine("{0} attacks is successfull", kamikaze.GetCharacterType());
                        int damage = attack_margin * kamikaze.GetDamages() / 100;
                        int damageGiven = damageModifier(kamikaze, fighter, damage);
                        Console.WriteLine("DamageGiven ({0}) = {1} * {2} /100", damageGiven, attack_margin, kamikaze.GetDamages());
                        fighter.SetCurrentLife(fighter.GetCurrentLife() - damageGiven);
                        Console.WriteLine("{0} **attacks** removes {1} life points to {2}", kamikaze.GetName(), damageGiven, kamikaze.GetName());
                        pain(fighter, damage, fighter.GetCurrentLife());
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
                Thread.Sleep(100);
            }
        }
    }
}
