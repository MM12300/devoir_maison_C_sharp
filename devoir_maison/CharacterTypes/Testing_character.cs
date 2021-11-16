namespace devoir_maison.CharacterTypes
{
    class Testing_character : Character
    {
        public Testing_character(string name)
        {
            this.name = name;
            attack = 150;
            defense = 100;
            initiative = 80;
            damages = 150;
            maximumLife = 100;
            currentLife = 100;
            totalAttackNumber = 2;
            currentAttackNumber = 2;
            characterType = "Testing_character";
            isLiving = true;
            isCursed = false;
            isBlessed = false;
            blessedDamage = false;
            cursedDamage = false;
        }
    }
}
