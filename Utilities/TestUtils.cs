using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class TestUtils
    {
        public static int[] RandomInts(int amount, int min, int max)
        {
            int[] randomInts = new int[amount];
            Random random = new Random();
            for (int i = 0; i < randomInts.Length; i++)
            {
                randomInts[i] = random.Next(min, max);
            }
            return randomInts;
        }
    }
}
