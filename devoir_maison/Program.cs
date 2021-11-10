using System;
using devoir_maison.CharacterTypes;

namespace devoir_maison
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Character billy = new Priest("priest1");
            Character bobby = new Priest("priest2");

            Console.WriteLine("FIGHT BEGINS!");
            game.fight(billy, bobby);

            //game.battleroyale();
        }
    }
}
