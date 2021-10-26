﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison
{
    public class Character
    {
        protected int attack;

        protected int defense;

        protected int initiative;

        protected int damages;

        protected int maximumLife;

        protected int currentLife;

        protected int currentAttackNumber;

        protected int totalAttackNumber;

        protected string characterType;

        protected string name;

        protected bool isLiving;

        protected int pain;

        public Character()
        {
            this.pain = -1;
        }

        public int GetAttack()
        {
            return attack;
        }

        public void SetAttack(int attack)
        {
            this.attack = attack;
        }

        public int GetDefense()
        {
            return defense;
        }

        public void SetDefense(int defense)
        {
            this.defense = defense;
        }

        public int GetInitiative()
        {
            return initiative;
        }

        public void SetInitiative(int initiative)
        {
            this.initiative = initiative;
        }

        public int GetDamages()
        {
            return damages;
        }

        public void SetDamages(int damages)
        {
            this.damages = damages;
        }

        public int GetMaximumLife()
        {
            return maximumLife;
        }

        public void SetMaximumLife(int maximumLife)
        {
            this.maximumLife = maximumLife;
        }

        public int GetCurrentLife()
        {
            return currentLife;
        }

        public void SetCurrentLife(int currentLife)
        {
            this.currentLife = currentLife;
        }

        public int GetCurrentAttackNumber()
        {
            return currentAttackNumber;
        }

        public void SetCurrentAttackNumber(int currentAttackNumber)
        {
            this.currentAttackNumber = currentAttackNumber;
        }

        public int GetTotalAttackNumber()
        {
            return totalAttackNumber;
        }

        public void SetTotalAttackNumber(int totalAttackNumber)
        {
            this.totalAttackNumber = totalAttackNumber;
        }

        public string GetCharacterType()
        {
            return characterType;
        }

        public void SetCharacterType(string characterType)
        {
            this.characterType = characterType;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public bool GetIsLiving()
        {
            return isLiving;
        }

        public void SetIsLiving(bool isLiving)
        {
            this.isLiving = isLiving;
        }

        public int GetPain()
        {
            return pain;
        }
        
        public void SetPain(int pain)
        {
            this.pain = pain;
        }
    }
}
