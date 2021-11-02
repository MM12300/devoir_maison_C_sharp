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
            Character billy = new Priest("billy the priest");
            Character bobby = new Vampire("bobby the vampire");

            Console.WriteLine("FIGHT BEGINS!");
            game.fight(billy, bobby);
        }
    }
}
