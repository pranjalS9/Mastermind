using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public class GenerateRandomNumber
    {
        public string ComputerInput()
        {
            Random random = new Random();
            string compInput = "";
            int i = 0;
            while (i < 4)
            {
                int num = random.Next(1, 9);
                if (!compInput.Contains(num.ToString()))
                {
                    compInput += num.ToString();
                    i++;
                }
            }
            return compInput;
        }
    }
}
