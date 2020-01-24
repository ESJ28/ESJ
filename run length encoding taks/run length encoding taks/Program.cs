using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace run_length_encoding_taks
{
    class Program
    {
        static void Main(string[] args)
        {           
            int count = 1;            

            String givenInput = "a a a a a a b b b c c c x";
            Console.WriteLine("The given input is: {0}", givenInput);

            string[] splitInput = new string[13];
            splitInput = givenInput.Split(' ');

            for (int i = 1; i < splitInput.Length; i++)
            {
                if (i == 12)
                {
                    if (splitInput[i] == splitInput[i - 1])
                    {
                        count = count + 1;
                        Console.WriteLine("{0}, {1}", splitInput[i], count);
                    }
                    else
                    {
                        Console.WriteLine("{0}, {1}", splitInput[11], count);
                        Console.WriteLine("{0}, {1}", splitInput[i], 1);
                    }
                }
                else if (i != 12 && splitInput[i] == splitInput[i - 1])
                {
                    count = count + 1;
                }
                else
                {

                    Console.WriteLine("{0}, {1}", splitInput[i - 1], count);
                    count = 1;
                }

            }
            
            Console.Read();
        }
       
    }
}
