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

        private Random random = new Random();

        public Randomizer()
        {
            this.Generator = new Random();
        }
        public int randomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
