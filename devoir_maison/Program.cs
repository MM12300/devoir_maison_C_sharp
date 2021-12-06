using System;
using devoir_maison.CharacterTypes;

namespace devoir_maison
{
    class Program
    {
        static void Main(string[] args)
        {
            Testing_character test = new Testing_character("bob");
            Console.WriteLine("bob life is {0}", test.GetCurrentLife());
            test.SetCurrentLife(1);
            Console.WriteLine("bob life is {0}", test.GetCurrentLife());
            test.SetCurrentLife(10000);
            Console.WriteLine("bob life is {0}", test.GetCurrentLife());
            test.SetCurrentLife(12);
            Console.WriteLine("bob life is {0}", test.GetCurrentLife());
            test.LifeModifier(11);
            Console.WriteLine("bob life is {0}", test.GetCurrentLife());
            test.LifeModifier(111111);
            Console.WriteLine("bob life is {0}", test.GetCurrentLife());


            Game game = new Game();
            //Character billy = new Priest("priest");
            //Character bobby = new Lich("lich");
            
            //Console.WriteLine("FIGHT BEGINS!");
            //game.fight(billy, bobby);

            game.BattleRoyale();
        }
    }
}
