using System;
using devoir_maison.CharacterTypes;

namespace devoir_maison
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine("Welcome to Battle-Royale Versus Fighting Limited 2021");
            Console.WriteLine("Between 2 and 8 fighters can compete into the Battle-Royale Arena");
            string mode = game.GameMode();




            Console.WriteLine("How many fighters would like to confront ?");
            string fightersNumber = Console.ReadLine();
            game.fightersNumberChoice(fightersNumber);




            
            //Character billy = new Priest("priest");
            //Character bobby = new Lich("lich");
            
            //Console.WriteLine("FIGHT BEGINS!");
            //game.fight(billy, bobby);

            game.BattleRoyale();
        }


    }
}
