using System;
using devoir_maison.CharacterTypes;

namespace devoir_maison
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Character billy = new Ghoul("ghoul1");
            Character bobby = new Ghoul("ghoul2");

            Console.WriteLine("FIGHT BEGINS!");
            game.fight(billy, bobby);

            //game.battleroyale();
        }
    }
}
