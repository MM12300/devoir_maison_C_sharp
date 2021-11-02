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

            double test = (1.0 / 4.0);
            Console.WriteLine(test);


            Game game = new Game();
            Character billy = new Warrior("billy the warrior");
            Character bobby = new Warrior("bobby the warrior");

            Console.WriteLine("FIGHT BEGINS!");
            game.fight(billy, bobby);
        }
    }
}
