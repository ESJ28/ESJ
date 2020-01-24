using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace number_to_ascii_character
{
    class Program
    {
        static void Letter(int usernum )
        {
            char[] lowercase = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] uppercase = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char userletter = ' ';            
            if (usernum < 26)
            {
                userletter = lowercase[usernum - 1];                
            }
            else
            {
                userletter = uppercase[usernum - 27];
            }
            Console.WriteLine(userletter);
        }
        static void Main(string[] args)
        {
            
            int usernum;                        
            string userword = "";
            string userchoice = "";
            Console.WriteLine("welcome to the number ascii converter, to begin type p, else type e");
            userchoice = Console.ReadLine();

            while (userchoice != "p" && userchoice != "e")
            {
                Console.WriteLine("invalid input please try again");
                userchoice = Console.ReadLine();
            }

            while (userchoice == "p")
            {
                Console.WriteLine("enter the number which you would like to convert to an ascii character, to generate lowercase letters enter 1- 26 else enter a number between 27 and 52");
                usernum = Convert.ToInt32(Console.ReadLine());

                Letter(usernum);

                Console.WriteLine("type in the numbers of the ascii characters you would like to represent serperated by a ',' to form a word ");
                userword = Console.ReadLine();

                string[] userwords = userword.Split(',');

                for (int i = 0; i < userwords.Length; i++)
                {

                    usernum = Convert.ToInt32(userwords[i]);

                    Letter(usernum);
                }
                Console.WriteLine("to convert again type p else type e");
                userchoice = Console.ReadLine();
            }
            Console.WriteLine("goodbye");            

            Console.Read();           

        }
    }
}
