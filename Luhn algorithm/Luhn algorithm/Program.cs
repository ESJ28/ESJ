using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luhn_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string cardnumber = "";
            List<int> numbers = new List<int>();
            int total = 0;

            Console.WriteLine("enter your 8 digit card number with each digit seperated by a space");
            cardnumber = Console.ReadLine();

            while (cardnumber.Length > 17)
            {
                Console.WriteLine("your card number is to long, please try again");
                cardnumber = Console.ReadLine();
            }            

            string[] splitcard = cardnumber.Split(' ');

            for (int i = 0; i < splitcard.Length; i++)
            {
                int num = Convert.ToInt32(splitcard[i]);
                numbers.Add(num);                

                if (i == 0 || i == 2 || i== 4 || i == 6)
                {
                    numbers[i] = numbers[i] * 2;
                }

                if (numbers[i] > 9)
                {
                    numbers[i] = numbers[i] - 9;
                }

                total = total + numbers[i];
                
            }

            if (total % 10 == 0)
            {
                Console.WriteLine("this is an acceptable number");
            }
            else
            {
                Console.WriteLine("this is an unacceptable number");
            }

            Console.Read();
           

                 
        }
    }
}
