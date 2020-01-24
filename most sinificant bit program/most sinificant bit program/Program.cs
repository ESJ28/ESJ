using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace most_sinificant_bit_program
{
    class Program
    {
        static void Main(string[] args)
        {
            string BinaryNum = "";
            bool foundone = false;
            List<char> finalnumber = new List<char>();            

            Console.WriteLine("please input your 8 bit binary number");
            BinaryNum = Console.ReadLine();          
            
                Console.WriteLine("your binary number is: {0}", BinaryNum);

                Console.WriteLine("Your binary number in most significant bit form is:");


                for (int i = BinaryNum.Length - 1; i >= 0; i--) // this will cycle through binary num backwards
                {

                    if (BinaryNum[i] == '1' && !foundone) //if the digit in the binary num is 1 and the first 1 has not been found
                    {
                        finalnumber.Add(BinaryNum[i]);
                        foundone = true;
                    }
                    else if (BinaryNum[i] == '0' && !foundone)
                    {
                        finalnumber.Add(BinaryNum[i]);
                    }
                    else if (BinaryNum[i] == '0' && foundone)
                    {
                        finalnumber.Add('1');

                    }
                    else if (BinaryNum[i] == '1' && foundone)
                    {
                        finalnumber.Add('0');
                    }



                }

                finalnumber.Reverse();
                finalnumber.ForEach(Console.Write);
            
            
            

            Console.Read();

        }
        
        
    }
}
