using System;
using System.Collections.Generic;
using devoir_maison.CharacterTypes;

namespace devoir_maison
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            List<Character> fighters = game.GameIntro();
            game.BattleRoyaleOrDualFight(fighters);
                       
            //Character billy = new Priest("priest");
            //Character bobby = new Lich("lich");
            
            //Console.WriteLine("FIGHT BEGINS!");
            //game.fight(billy, bobby);

            //game.BattleRoyale();
        }
    }
}
