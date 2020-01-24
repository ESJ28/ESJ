using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime_number_checker
{
    class Program
    {     
        static void Main(string[] args)
        {
            int usernum;
            string userchoice = "";

            Console.WriteLine("To play and test a number type play else type quit");
            userchoice = Console.ReadLine();
            while (userchoice != "play" && userchoice != "quit")
            {
                Console.WriteLine("invalid input please enter either play or quit");
                userchoice = Console.ReadLine();
            }

            while (userchoice == "play")
            {
                Console.WriteLine("enter the number that you would like to check");
                usernum = Convert.ToInt32(Console.ReadLine());

                if (usernum <= 1)
                {
                    Console.WriteLine("Not greater than 1");
                }

                if (usernum % 2 != 0 && usernum % 3 != 0 && usernum % 4 != 0 && usernum % 5 != 0)
                { 
                    Console.WriteLine("is prime");
                }
                else if (usernum == 3 || usernum == 5)
                {
                    Console.WriteLine("is prime");
                }
                
                else
                {
                    Console.WriteLine("Is not prime");
                }

                Console.WriteLine("to test another number type play, else type quit");
                userchoice = Console.ReadLine();
            }
            Console.WriteLine("Goodbye!");
            Console.Read();

        }
    }
}
