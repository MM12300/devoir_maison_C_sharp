using System;
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
            Character billy = new Guardian("guardian1");
            Character bobby = new Guardian("guardian2");

            Console.WriteLine("FIGHT BEGINS!");
            game.fight(billy, bobby);

            //game.battleroyale();
        }
    }
}
