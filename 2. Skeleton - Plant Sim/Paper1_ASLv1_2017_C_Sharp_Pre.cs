using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace skeleton_re_do
{
    class Program
    {
        const char SOIL = '.';
        const char SEED = 'S';
        const char PLANT = 'P';
        const char ROCKS = 'R';
        const char plantsThatThriveInFrost = 'F';
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
            // validation added:
            while (Years < 0 && Years > 5 && Years != -1)
            {
                Console.WriteLine("we can not simulate this number please enter a number between 0 and 5 or'-1' to step through years");
                Years = Convert.ToInt32(Console.ReadLine());
            }
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
            Row = FIELDLENGTH / 3;
            Column = FIELDWIDTH / 3;
            Field[Row, Column] = ROCKS;
        }

        static void storedFile(char[,] Field)  //task - use of a stored file
        {
            string FileName = "TestCase.TXT";
            string FieldRow = "";
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

        static void ReadFile(char[,] Field)
        {
            string FileName = "";
            string FieldRow = "";
            string txtAddition = ".TXT";
            string inputFile = "";
            Console.Write("Enter file name: ");
            inputFile = Console.ReadLine();

            FileName = inputFile + txtAddition; //addition - stops the user from having to add the TXT additiobn every time
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
            while (Response != "y" && Response != "Y" && Response != "n" && Response != "N")
            {
                Console.WriteLine("invalid input, please select either 'n' or 'y'");

            }

            if (Response == "Y" || Response == "y") // changed to avoid error
            {
                Console.WriteLine("Would you like to open the stored file: TestCase.TXT, if yes input 'yes' else type 'no'"); //ability to use a stored file
                Response = Console.ReadLine();
                while (Response != "yes" && Response != "Yes" && Response != "no" && Response != "No")
                {
                    Console.WriteLine("This is an invalid response, please input either yes or no");
                    Response = Console.ReadLine();
                }

                if (Response == "yes" || Response == "Yes")
                {
                    storedFile(Field);
                }
                else
                {
                    Console.WriteLine("would you like to open a diffrent file? type yes if yes type no if not");
                    Response = Console.ReadLine();
                    while (Response != "yes" && Response != "Yes" && Response != "no" && Response != "No")
                    {
                        Console.WriteLine("This is an invalid response, please input either yes or no");
                        Response = Console.ReadLine();
                    }

                    if (Response == "yes" || Response == "Yes")
                    {
                        ReadFile(Field);
                    }
                    else
                    {
                        CreateNewField(Field);
                    }

                }
            }

        }

        static void Display(char[,] Field, string Season, int Year)
        {
            Console.WriteLine("Season: " + Season + " Year number: " + Year);
            for (int Row = 0; Row < FIELDLENGTH; Row++)
            {
                for (int Column = 0; Column < FIELDWIDTH; Column++)
                {
                    Console.Write(Field[Row, Column]);
                }
                Console.WriteLine("| " + String.Format("{0,3}", Row));
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
            if (NumberOfPlants == 1)
            {
                Console.WriteLine("There is 1 plant growing");
            }
            else
            {
                Console.WriteLine("There are " + NumberOfPlants + " plants growing");
            }
        }

        //task 1 adding wind
        static void simulateWind(char[,] Field)
        {
            int PlantCount = 0;
            bool cropVirus = false;
            CountPlants(Field);
            Random RandomInt = new Random();
            if (RandomInt.Next(0, 2) == 1)
            {
                cropVirus = true;
            }

            if (cropVirus)
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
                Console.WriteLine("The conditions were very windy");
                CountPlants(Field);
            }

        }

        //Crop virus addition - 
        static void simulateCropVirus(char[,] Field)
        {
            int PlantCount = 0;
            bool cropVirus = false;
            CountPlants(Field);
            Random RandomInt = new Random();
            if (RandomInt.Next(0, 2) == 1)
            {
                cropVirus = true;
            }
            if (cropVirus)
            {
                PlantCount = 0;
                for (int Row = 0; Row < FIELDLENGTH; Row++)
                {
                    for (int Column = 0; Column < FIELDWIDTH; Column++)
                    {
                        if (Field[Row, Column] == PLANT)
                        {
                            PlantCount++;
                            if (PlantCount % 1 == 0)
                            {
                                Field[Row, Column] = SOIL;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("There has been a crop virus");
            CountPlants(Field);
        }


        static void SimulateSpring(char[,] Field)
        {
            int PlantCount = 0;
            bool Frost = false;
            for (int Row = 0; Row < FIELDLENGTH; Row++)
            {
                for (int Column = 0; Column < FIELDWIDTH; Column++)
                {
                    if (Field[Row, Column] == SEED)
                    {
                        Field[Row, Column] = PLANT;
                    }
                }
            }
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
                            if (PlantCount % 2 == 0) //task where plants that thrive in frost are added
                            {
                                Field[Row, Column] = plantsThatThriveInFrost;
                                PlantCount++;
                            }
                        }
                    }
                }
                Console.WriteLine("There has been a frost");
                CountPlants(Field);
            }
            simulateWind(Field);
            simulateCropVirus(Field);
        }

        static void SimulateSummer(char[,] Field)
        {
            Random RandomInt = new Random();
            int RainFall = RandomInt.Next(0, 3);
            int PlantCount = 0;
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
                            }
                        }
                    }
                }
                Console.WriteLine("There has been a severe drought");
                CountPlants(Field);
            }
            simulateWind(Field);
            simulateCropVirus(Field);
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
            int proximityToPlant; //added in to allow a change in the seedfall position
            Console.WriteLine("using the numbers 1 - 5, where 1 is right next to and 5 is very far away, How close to the plant do the seeds commonly fall?");
            proximityToPlant = Convert.ToInt32(Console.ReadLine());

            while (proximityToPlant < 0 || proximityToPlant > 5)
            {
                Console.WriteLine("this is an invalid input, please enter a number between 1 - 5");
                proximityToPlant = Convert.ToInt32(Console.ReadLine());
            }

            for (int Row = 0; Row < FIELDLENGTH; Row++)
            {
                for (int Column = 0; Column < FIELDWIDTH; Column++)
                {
                    if (Field[Row, Column] == PLANT)
                    {
                        if (Field[Row, Column] != ROCKS) // added in - solves problem of lack of check for rock
                        {
                            SeedLands(Field, Row - proximityToPlant, Column - proximityToPlant);
                            SeedLands(Field, Row - proximityToPlant, Column);
                            SeedLands(Field, Row - proximityToPlant, Column + proximityToPlant);
                            SeedLands(Field, Row, Column - proximityToPlant);
                            SeedLands(Field, Row, Column + proximityToPlant);
                            SeedLands(Field, Row + proximityToPlant, Column - proximityToPlant);
                            SeedLands(Field, Row + proximityToPlant, Column);
                            SeedLands(Field, Row + proximityToPlant, Column + proximityToPlant);

                        }

                    }
                }
            }
            simulateWind(Field);
            simulateCropVirus(Field);
        }

       static void birdEatsSeed(char[,] Field)
        {
            Random RandomInt = new Random();
            int Row = RandomInt.Next(0,5);            
            int Column = RandomInt.Next(0, 5);

            if (Field[Row, Column] == SEED)
            {
                Field[Row, Column] = SOIL;
            }

            Console.WriteLine("A bird has eaten all of the seed on row {0}, column {1}", Row, Column);


        } 

        static void SimulateWinter(char[,] Field)
        {
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
            birdEatsSeed(Field);
            simulateWind(Field);
            simulateCropVirus(Field);
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
                        SimulateOneYear(Field, Year);
                    }
                }
                else
                {
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
