using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_conversion_task
{
    class Program
    {
        static void Main(string[] args)
        {
            string userbinary = "";
            double denaryTotal = 0;
            string binrev = "";

            Console.WriteLine("input your binary number");
            userbinary = (Console.ReadLine());

            while (userbinary.Length > 8 || userbinary.Length< 8)
            {
                Console.WriteLine("incorrect binary input, please input an 8 digit binary");
                userbinary = Console.ReadLine();
            }

            for (int i = 0; i < userbinary.Length; i++)
            {
                if (userbinary[i] != '1' && userbinary[i] != '0')
                {
                    Console.WriteLine("Your binary number cotains digits other than 1 and 0, please re-input your binary number using only one's and zero's");
                    userbinary = Console.ReadLine();
                }                
            }

            Console.WriteLine("your binary total reversed is");

            for (int i = userbinary.Length -1; i >= 0 ; i--)
            {
                
                Console.Write(userbinary[i]);

                binrev = binrev + userbinary[i];

                if (binrev[0] == '1')
                {
                    denaryTotal = denaryTotal + Math.Pow(2, i);
                }
                else
                {
                    denaryTotal = denaryTotal + 1;
                }
            }

            Console.WriteLine(" your denary total is: {0}", denaryTotal);           
            Console.Read();
        }
    }
}
