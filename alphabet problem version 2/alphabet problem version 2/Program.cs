using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alphabet_problem_version_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string userAttempt = "";
            int x = 0;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Console.WriteLine("when you are ready input the alphabet as fast as you can");            
            userAttempt = Console.ReadLine();
            stopwatch.Stop();

            Console.WriteLine("you attempt was {0}", userAttempt);

            for (int i = 0; i < alphabet.Length; i++)
            {
                Console.WriteLine(alphabet[i]);
                Console.WriteLine(userAttempt[x]);

                if (alphabet[i] == userAttempt[x])
                {
                    Console.WriteLine("well done you input the alphabet correctly!");
                                        
                }
                else
                {
                    Console.WriteLine("you wrote the alphabet wrong please try again!");
                }
                x = x + 1;
            }
            Console.WriteLine("it took you {0} to enter the alphabet", stopwatch.Elapsed);



            Console.Read();
        }
    }
}
