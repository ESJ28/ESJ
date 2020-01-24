using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace room_area_calculator__subroutine_practice_
{
    class Program
    {
        static int CalcArea(int length, int Width)
        {
            int area = length * Width;
            return area;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("area calculation program");

            string quit = ""; //assign a random value - this means nothing it just provided a code backstop
            int length = 0;
            int width = 0;
            int arearesult = 0;
            int totalarea = 0;

            while (quit != "q")
            {
                Console.Write("enter a length: ");
                length = int.Parse(Console.ReadLine());
                Console.Write("Enter width: ");
                width = int.Parse(Console.ReadLine());
                arearesult = CalcArea(length, width);
                Console.WriteLine("the area is currently {0}", arearesult);
                totalarea = totalarea + arearesult;
                Console.WriteLine("Enter q to quit, else press enter and put in more measurements");
                quit = Console.ReadLine();

            }
            Console.WriteLine("the total area is: {0} ", totalarea);
            Console.WriteLine("Goodbye");

        Console.Read();
        }
    }
}
