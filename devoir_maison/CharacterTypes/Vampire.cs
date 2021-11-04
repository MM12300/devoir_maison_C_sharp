namespace devoir_maison.CharacterTypes
{
    class Vampire : Character
    {
        public Vampire(string name)
        {
            this.name = name;
            attack = 100;
            defense = 100;
            initiative = 120;
            damages = 50;
            maximumLife = 300;
            currentLife = 300;
            totalAttackNumber = 2;
            currentAttackNumber = 2;
            characterType = "Vampire";
            isLiving = false;
            isCursed = true;
            isBlessed = false;
            blessedDamage = false;
            cursedDamage = false;
        }
    }
}
