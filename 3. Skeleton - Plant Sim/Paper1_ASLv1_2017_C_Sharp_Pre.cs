// Skeleton Program for the AQA A1 Summer 2017 examination
// this code should be used in conjunction with the Preliminary Material
// written by the AQA AS1 Programmer Team
// developed in Visual Studio 2015

using System;
using System.IO;

namespace SeedSimulation
{
    class Program
    {
        const char SOIL = '.';
        const char SEED = 'S';
        const char PLANT = 'P';
        const char ROCKS = 'R';
        const Char WEED = 'W';
        const char FIRE = 'F';
        const char TORNADO = 'T';
        const int FIELDLENGTH = 20;
        const int FIELDWIDTH = 35;
        

        static int GetHowLongToRun()
        {
            int Years = 0;
            Console.WriteLine("Welcome to the Plant Growing Simulation");
            Console.WriteLine();
            Console.WriteLine("You can step through the simulation a year at a time");
            Console.WriteLine("or run the simulation for 0 to 5 years");
            Console.WriteLine("How many years do you want the simulation to run?");
            Console.Write("Enter a number between 0 and 5, or -1 for stepping mode: ");
            Years = Convert.ToInt32(Console.ReadLine());
            return Years;
        }

        static void CreateNewField(char[,] Field)
        {
            int Row = 0;
            int Column = 0;
            for (Row = 0; Row < FIELDLENGTH; Row++)
            {
                for (Column = 0; Column < FIELDWIDTH; Column++)
                {
                    Field[Row, Column] = SOIL;
                }
            }
            Row = FIELDLENGTH / 2;
            Column = FIELDWIDTH / 2;
            Field[Row, Column] = SEED;
        }

        static void ReadFile(char[,] Field)
        {
            string FileName = "";
            string FieldRow = "";
            Console.Write("Enter file name: ");
            FileName = Console.ReadLine();
            try
            {
                StreamReader CurrentFile = new StreamReader(FileName);
                for (int Row = 0; Row < FIELDLENGTH; Row++)
                {
                    FieldRow = CurrentFile.ReadLine();
                    for (int Column = 0; Column < FIELDWIDTH; Column++)
                    {
                        Field[Row, Column] = FieldRow[Column];
                       
                    }
                }
                CurrentFile.Close();
            }
            catch (Exception)
            {
                CreateNewField(Field);
            }
        }

        static void InitialiseField(char[,] Field)
        {
            string Response = "";
            Console.Write("Do you want to load a file with seed positions? (Y/N): ");
            Response = Console.ReadLine();
            if (Response == "Y")
            {                
                ReadFile(Field);
            }
            else
            {
                CreateNewField(Field);
            }
        }

        static void Display(char[,] Field, string Season, int Year)
        {
            Console.WriteLine("Season: " + Season + " Year number: " + Year);
           
            for (int Row = 0; Row < FIELDLENGTH; Row++)
            {
                for (int Column = 0; Column < FIELDWIDTH; Column++)
                {
                    if (Row == 0 || Row == 19)
                    {
                        Field[Row, Column] = ROCKS;  

                    }
                    
                    if (Column == 0 || Column == 34)
                    {
                        Field[Row, Column] = ROCKS;
                    }                                
                    
                        Console.Write(Field[Row, Column]);                                   
                   
                }
                Console.WriteLine("| " + String.Format("{0,3}", Row));
            }
        }
        // tornado - 

        static void tornado(char[,] Field) // to be called in autumn

        {

            Random rand = new Random();

            int Tornadorisk = rand.Next(1, 101);
            int posOrNeg;
            int newPos;

            if (Tornadorisk <= 10)

            {

                for (int Row = 0; Row < FIELDLENGTH; Row++)

                {

                    for (int Column = 0; Column < FIELDWIDTH; Column++)

                    {
                        posOrNeg = rand.Next(1, 2); //here if 1 is spawned then the random number becomes negative - seed will move left
                        newPos = rand.Next(1, 6);
                        if (posOrNeg == 1)
                        {
                            newPos = 0 - newPos;
                        }

                        if (Field[Row, Column] == PLANT) //destroys all plants
                        {
                            Field[Row, Column] = TORNADO;  //don't forget to add the tornado constant at the top
                        }
                        else if (Field[Row, Column] == SEED)
                        {
                            SeedLands(Field, Row - newPos, Column - newPos);

                            SeedLands(Field, Row - newPos, Column);

                            SeedLands(Field, Row - newPos, Column + newPos);

                            SeedLands(Field, Row, Column - newPos);

                            SeedLands(Field, Row, Column + newPos);

                            SeedLands(Field, Row + newPos, Column - newPos);

                            SeedLands(Field, Row + newPos, Column);

                            SeedLands(Field, Row + newPos, Column + newPos);

                        }
                        else
                        {
                            if (Field[Row, Column] == ROCKS)
                            {
                                Field[Row, Column] = SOIL;
                                Field[Row + newPos, Column + newPos] = ROCKS;
                            }
                        }


                    }

                }
                Console.WriteLine("There has been a tornado");

            }

        }



        // dont forget to add the fire constant
        static void meteorStorm(char[,] Field) // meteor storm
        {
            Random rand = new Random();
            int meteorRisk = rand.Next(1,41);
            if (meteorRisk == 33) // 33 generated with a random number generatro
            {
                for (int Row = 0; Row < FIELDLENGTH; Row++)
                {
                    for (int Column = 0; Column < FIELDWIDTH; Column++)
                    {
                        if (Field[Row, Column] != ROCKS)
                        {
                            Field[Row, Column] = FIRE;
                        }
                    }
                }
                Console.WriteLine("there has been a meteor");
               
            }
        }

        static void CountPlants(char[,] Field)
        {
            int NumberOfPlants = 0;
            for (int Row = 0; Row < FIELDLENGTH; Row++)
            {
                for (int Column = 0; Column < FIELDWIDTH; Column++)
                {
                    if (Field[Row, Column] == PLANT)
                    {
                        NumberOfPlants++;
                    }
                }
            }
            if (NumberOfPlants == 0)
            {
                Console.WriteLine("There has been a catastrophic event - all life is dead."); // change - provides scapegoat for meateor scenario
            }
            else
            {
                Console.WriteLine("There are " + NumberOfPlants + " plants growing");
            }
        }

        static void SimulateSpring(char[,] Field)
        {
            int PlantCount = 0;
            bool Frost = false;
            Random Randomint = new Random();
            CountPlants(Field);           
                  
             for (int Row = 0; Row < FIELDLENGTH; Row++)
                {
                 for (int Column = 0; Column < FIELDWIDTH; Column++)
                  {
                    int weed = Randomint.Next(0, 9);
                    if (weed == 6)
                    {
                        if (Field[Row, Column] == SOIL)
                        {
                            Field[Row, Column] = WEED;
                        }
                    }
                    int fortyPercentchance = Randomint.Next(0, 9); // this creates a 40% chance that the seed will become a plant
                    if (fortyPercentchance == 4) // 4/10 is equivilant to 40/100
                    {
                        if (Field[Row, Column] == SEED)
                        {
                            Field[Row, Column] = PLANT;

                        }
                    }
                    else  // if the 40% chance is not achived then the seed remains a seed
                    {
                        if (Field[Row, Column] == SEED)
                        {
                            Field[Row, Column] = SEED;

                        }
                    }
                        
                    }

                } // code for a frost lies below        
           
           
            CountPlants(Field);
            Random RandomInt = new Random();
            if (RandomInt.Next(0, 2) == 1)
            {
                Frost = true;
            }
            else
            {
                Frost = false;
            }
            if (Frost)
            {
                PlantCount = 0;
                for (int Row = 0; Row < FIELDLENGTH; Row++)
                {
                    for (int Column = 0; Column < FIELDWIDTH; Column++)
                    {
                        if (Field[Row, Column] == PLANT)
                        {
                            PlantCount++;
                            if (PlantCount % 3 == 0)
                            {
                                Field[Row, Column] = SOIL;
                            }
                        }
                    }
                }
                Console.WriteLine("There has been a frost");
                CountPlants(Field);
            }
            meteorStorm(Field); // risk of meteor storm
        }

        static void SimulateSummer(char[,] Field)
        {
            CountPlants(Field);
            Random RandomInt = new Random();
            int RainFall = RandomInt.Next(0, 3);
            int PlantCount = 0;
            int numberthatdied = 0;
            if (RainFall == 0)
            {
                PlantCount = 0;
                for (int Row = 0; Row < FIELDLENGTH; Row++)
                {
                    for (int Column = 0; Column < FIELDWIDTH; Column++)
                    {
                        if (Field[Row, Column] == PLANT)
                        {
                            PlantCount++;
                            if (PlantCount % 2 == 0)
                            {
                                Field[Row, Column] = SOIL;
                                numberthatdied = numberthatdied + 1;
                            }
                        }
                    }
                }
                Console.WriteLine("There has been a severe drought, {0} plants died", numberthatdied);
                CountPlants(Field);
            }
            
        }

        static void SeedLands(char[,] Field, int Row, int Column)
        {
            if (Row >= 0 && Row < FIELDLENGTH && Column >= 0 && Column < FIELDWIDTH)
            {
                if (Field[Row, Column] == SOIL)
                {
                    Field[Row, Column] = SEED;
                }
            }
        }

        static void SimulateAutumn(char[,] Field)
        {
            CountPlants(Field);
            for (int Row = 0; Row < FIELDLENGTH; Row++)
            {
                for (int Column = 0; Column < FIELDWIDTH; Column++)
                {
                    if (Field[Row, Column] == PLANT)
                    {
                        SeedLands(Field, Row - 1, Column - 1);
                        SeedLands(Field, Row - 1, Column);
                        SeedLands(Field, Row - 1, Column + 1);
                        SeedLands(Field, Row, Column - 1);
                        SeedLands(Field, Row, Column + 1);
                        SeedLands(Field, Row + 1, Column - 1);
                        SeedLands(Field, Row + 1, Column);
                        SeedLands(Field, Row + 1, Column + 1);
                    }
                }
            }
            tornado(Field);
        }

        static void SimulateWinter(char[,] Field)
        {
            CountPlants(Field);
            for (int Row = 0; Row < FIELDLENGTH; Row++)
            {
                for (int Column = 0; Column < FIELDWIDTH; Column++)
                {
                    if (Field[Row, Column] == PLANT)
                    {
                        Field[Row, Column] = SOIL;
                    }
                }
            }
            meteorStorm(Field); // risk of meteor storm
        }

        static void SimulateOneYear(char[,] Field, int Year)
        {
            SimulateSpring(Field);
            Display(Field, "spring", Year);
            SimulateSummer(Field);
            Display(Field, "summer", Year);
            SimulateAutumn(Field);
            Display(Field, "autumn", Year);
            SimulateWinter(Field);
            Display(Field, "winter", Year);
        }

        private static void Simulation()
        {
            int YearsToRun;
            char[,] Field = new char[FIELDLENGTH, FIELDWIDTH];
            bool Continuing;
            int Year;
            string Response;
            
            YearsToRun = GetHowLongToRun();
            if (YearsToRun != 0)
            {
                InitialiseField(Field);
                if (YearsToRun >= 1)
                {
                    for (Year = 1; Year <= YearsToRun; Year++)
                    {
                        Display(Field, "start", 0);
                        SimulateOneYear(Field, Year);
                    }
                }
                else
                {
                    Display(Field, "start", 0);
                    Continuing = true;
                    Year = 0;
                    while (Continuing)
                    {
                        Year++;
                        SimulateOneYear(Field, Year);
                        Console.Write("Press Enter to run simulation for another Year, Input X to stop: ");
                        Response = Console.ReadLine();
                        if (Response == "x" || Response == "X")
                        {
                            Continuing = false;
                        }
                    }
                }
                meteorStorm(Field); // risk of meteor storm
                Console.WriteLine("End of Simulation");
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Simulation();
        }

    }
}