namespace devoir_maison.CharacterTypes
{
    class Berserker : Character
    {
        public Berserker(string name)
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
            characterType = "Berserker";
            isLiving = true;
            isCursed = false;
            isBlessed = false;
            blessedDamage = false;
            cursedDamage = false;
        }
    }
}
