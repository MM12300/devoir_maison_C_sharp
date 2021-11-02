﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using devoir_maison.CharacterTypes;

namespace devoir_maison
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Character billy = new Warrior("billy the warrior");
            Character bobby = new Guardian("bobby the guardian");

            bobby.SetCurrentLife(50);
            billy.SetCurrentLife(50);

            billy.SetAttack(500);
            Console.WriteLine("FIGHT BEGINS!");
            game.fight(billy, bobby);
        }
    }
}
