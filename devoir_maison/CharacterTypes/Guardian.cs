namespace devoir_maison.CharacterTypes
{
    class Guardian : Character
    {
        public Guardian(string name)
        {
            this.name = name;
            attack = 50;
            defense = 150;
            initiative = 50;
            damages = 50;
            maximumLife = 150;
            currentLife = 150;
            totalAttackNumber = 3;
            currentAttackNumber = 3;
            characterType = "Guardian";
            isLiving = true;
            isCursed = false;
            isBlessed = true;
        }
    }
}
