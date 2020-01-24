using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace run_length_encoding_mark_2___user_input
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1;

            String userInput = "";
            int lengthOfuserString;
            int upmostvalueinarray;
          

            Console.WriteLine("enter a phrase in  which each digit is split by a space");
            userInput = Console.ReadLine();

            Console.WriteLine("The given input is: {0}", userInput);

            lengthOfuserString = userInput.Length;          
            

            string[] splitInput = new string[lengthOfuserString];
            splitInput = userInput.Split(' ');

           
            upmostvalueinarray = lengthOfuserString - 1;

            for (int i = 1; i < splitInput.Length; i++)
            {
                if (i == upmostvalueinarray)
                {
                    if (splitInput[i] == splitInput[i - 1])
                    {
                        count = count + 1;
                        Console.WriteLine("{0}, {1}", splitInput[i], count);
                    }
                    else
                    {
                        Console.WriteLine("{0}, {1}", splitInput[i - 1], count);
                        Console.WriteLine("{0}, {1}", splitInput[i], 1);
                    }
                }
                else if (i != upmostvalueinarray && splitInput[i] == splitInput[i - 1])
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
