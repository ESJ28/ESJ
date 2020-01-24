using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ceaser_cipher
{
    class Program
    {
        static void Main(string[] args)
        {            
            string usershift = "";
            int numnum;
            string userinput = "";
            string decode = "";

            Console.WriteLine("enter your message that you want to encode");
            userinput = Console.ReadLine();
            userinput = userinput.ToUpper();

            Console.WriteLine("how much do you want to shift?");
            numnum = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < userinput.Length; i++)
            {
                int letter = Convert.ToInt32(userinput[i]);
                int addy = letter + numnum;
                string ans = Char.ConvertFromUtf32(addy);
                usershift = usershift + ans;
                usershift = usershift.ToLower();
            }
           
            Console.WriteLine(usershift);

            Console.WriteLine("enter the phrase that you want to encode");
            string encodedphrase = Console.ReadLine();
            encodedphrase = encodedphrase.ToUpper();

            Console.WriteLine("What was your shift?");
            numnum = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < encodedphrase.Length; i++)
            {
                int number = Convert.ToInt32(encodedphrase[i]);
                int addy = number - numnum;
                string ans = Char.ConvertFromUtf32(addy);
                decode = decode + ans;
                decode = decode.ToLower();
            }
            Console.WriteLine(decode);
            Console.Read();
        }         
                
    }
}
   


           

       
       
   
 
