namespace devoir_maison.CharacterTypes
{
    class Testing_character : Character
    {
        public Testing_character(string name)
        {
            this.name = name;
            attack = 100;
            defense = 100;
            initiative = 80;
            damages = 20;
            maximumLife = 300;
            currentLife = 300;
            totalAttackNumber = 1;
            currentAttackNumber = 1;
            characterType = "Testing_character";
            isLiving = true;
            isCursed = false;
            isBlessed = false;
            blessedDamage = false;
            cursedDamage = false;
        }
    }
}
