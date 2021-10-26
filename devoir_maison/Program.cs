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
            //Games game = new Games();
            //Character billy = game.CreateCharacter(10, 10, 10, 10, 10, 10, 10, 10);
            //Console.WriteLine("Bienvenue");
            //int attack = billy.GetAttack();
            //Console.WriteLine(attack.ToString());

            //int rollValue = billy.roll(billy.GetAttack());
            //Console.WriteLine(rollValue.ToString());

            //Warrior warrior = new Warrior();
            //Console.WriteLine(warrior.GetAttack());
            //Console.WriteLine(warrior.GetCharacterType());


            GameCopy game = new GameCopy();
            Character billy = new Warrior("billy");
            Character bobby = new Berserker("bobby");
            Console.WriteLine("FIGHT BEGINS!");
            game.fight(billy, bobby);
        }
    }
}
