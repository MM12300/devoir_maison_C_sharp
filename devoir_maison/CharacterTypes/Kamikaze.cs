namespace devoir_maison.CharacterTypes
{
    class Kamikaze : Character
    {
        public Kamikaze(string name)
        {
            this.name = name;
            attack = 50;
            defense = 125;
            initiative = 20;
            damages = 75;
            maximumLife = 500;
            currentLife = 500;
            totalAttackNumber = 6;
            currentAttackNumber = 6;
            characterType = "Kamikaze";
            isLiving = true;
            isCursed = false;
            isBlessed = false;
            blessedDamage = false;
            cursedDamage = false;
        }
    }
}
