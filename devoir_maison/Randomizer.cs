﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devoir_maison
{
    public class Randomizer
    {
        private Random random = new Random();

        public int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
