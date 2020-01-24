using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizz_buzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int howfar;

            Console.WriteLine("how far to count?");
            howfar = Convert.ToInt32(Console.ReadLine());

            while (howfar < 1)
            {
                Console.WriteLine("not a valid number, please try again");
                howfar = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < howfar; i++)
            {
                if (i % 3 == 0 && i % 5 == 0 )
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }

            Console.Read();            
            
        }
    }
}
