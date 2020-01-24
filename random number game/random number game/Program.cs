using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomnumbergameversion1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            int useremoved;
            int compgone;
            int startnum;
            string userdecision = "";

            Random random = new Random();
            startnum = random.Next(20, 20);
            number = startnum;

            Console.WriteLine("Welcome to the random number game, to play type play else type quit!");
            userdecision = Console.ReadLine();
            while (userdecision != "play" && userdecision != "quit")
            {
                Console.WriteLine("invalid input please chose either' play' or 'quit'");
                userdecision = Console.ReadLine();
            }

            while (userdecision == "play")
            {
                while (number > 0)
                {

                    Console.WriteLine("How much would you like to remove?");
                    useremoved = Convert.ToInt32(Console.ReadLine());
                    while (useremoved > number)
                    {
                        Console.WriteLine("This number is to big please chose another input");
                        useremoved = useremoved = Convert.ToInt32(Console.ReadLine());
                    }

                    number = number - useremoved;
                    if (number <= 0)
                    {
                        Console.WriteLine("Congratualtions! you have won");
                    }
                    else
                    {
                        Console.WriteLine("there is {0} left", number);
                        compgone = random.Next(0, startnum);
                        while (compgone > number)
                        {
                            compgone = random.Next(0, startnum);
                        }

                        Console.WriteLine("the computer is removing {0} from {1}", compgone, number);
                        number = number - compgone;
                        if (number == 0)
                        {
                            Console.WriteLine("Sorry! you lost and the computer won!");

                        }
                        else
                        {
                            Console.WriteLine("there is {0} left", number);
                        }
                    }

                }
                Console.WriteLine("thank you for playing to play again type play, else type quit");
                userdecision = Console.ReadLine();
            }
            Console.WriteLine("Goodbye!");

            Console.Read();
        }
    }
}
