using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public class GenerateRandomNumber
    {
        public string SecretCode()
        {
            Random random = new Random();
            string secretCode = "";
            int i = 0;
            while (i < 4)
            {
                int num = random.Next(1, 8);
                secretCode += num.ToString();
                i++;
            }
            return secretCode;
        }
    }
}
