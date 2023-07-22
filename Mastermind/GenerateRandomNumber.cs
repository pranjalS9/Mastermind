using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public class GenerateRandomNumber
    {
        public int[] ComputerInput()
        {
            Random random = new Random();
            //string compInput = "";
            int[] compInput = new int[4];
            int i = 0;
            while (i < 4)
            {
                int num = random.Next(1, 8);
                compInput[i] = num;
                i++;
            }
            return compInput;
        }
    }
}
