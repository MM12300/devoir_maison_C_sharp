using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison
{
    public class Randomizer
    {
        private Random Generator { get; set; }
        public Randomizer()
        {
            this.Generator = new Random();
        }
        public int randomNumber(int min, int max)
        {
            return this.Generator.Next(min, max);
        }
    }
}
