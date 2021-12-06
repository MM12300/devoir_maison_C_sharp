namespace devoir_maison.CharacterTypes
{
    class Zombie : Character
    {
        public Zombie(string name)
        {
            this.name = name;
            attack = 100;
            defense = 0;
            initiative = 20;
            damages = 60;
            maximumLife = 100;
            currentLife = 100;
            totalAttackNumber = 1;
            currentAttackNumber = 1;
            characterType = "Zombie";
            isLiving = false;
            isCursed = true;
            isBlessed = false;
            blessedDamage = false;
            cursedDamage = false;
        }
    }
}
