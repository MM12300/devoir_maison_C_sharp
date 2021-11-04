namespace devoir_maison.CharacterTypes
{
    class Warrior : Character
    {
        public Warrior(string name)
        {
            this.name = name;
            attack = 100;
            defense = 100;
            initiative = 50;
            damages = 100;
            maximumLife = 200;
            currentLife = 200;
            totalAttackNumber = 2;
            currentAttackNumber = 2;
            characterType = "Warrior";
            isLiving = true;
            isCursed = false;
            isBlessed = false;
            blessedDamage = false;
            cursedDamage = false;
        }
    }
}
