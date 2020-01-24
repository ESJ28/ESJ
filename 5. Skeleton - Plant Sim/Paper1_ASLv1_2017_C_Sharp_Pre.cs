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
    const char ROCKS = 'X';
        const Char FIRE = 'F';
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
            String userInput= "";
      string FieldRow = "";
            string txtExtention = ".TXT";
      Console.Write("Enter file name without .TXT extention: ");
      userInput = Console.ReadLine();
            FileName = userInput + txtExtention;
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
          Console.Write(Field[Row, Column]);
        }
        Console.WriteLine("| " + String.Format("{0,3}", Row));
      }
    }

    static void CountPlants(char[,] Field) // called at the start oif every simulation to ensure that a meteor storm has not occured
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
        Console.WriteLine("There is are no plants growing, all life is dead");
      }
      else
      {
        Console.WriteLine("There are " + NumberOfPlants + " plants growing");
      }
    }

        static void meteorStorm(char[,] Field) // a constant char - 'Fire has been defined'
        {
            Random rand = new Random();
            int meteorChance = rand.Next(1, 101);

            if (meteorChance == 40)
            {
                Console.WriteLine("There has been a meteor storm - all life is dead");
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
            }
            CountPlants(Field);
        }

    static void SimulateSpring(char[,] Field)
    {
         CountPlants(Field);
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
            }
          }
        }
        Console.WriteLine("There has been a frost");
        CountPlants(Field);
                
      }
            meteorStorm(Field);
        }

    static void SimulateSummer(char[,] Field)
    {
            CountPlants(Field);
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
            meteorStorm(Field);
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
            int Wind;
            Console.WriteLine("enter a number between 1 and 5, 5 being the furtherst from the plant, 1 being directly around the plant, to detemine seed dirstribution");
            Wind = Convert.ToInt32(Console.ReadLine());
            while (Wind > 5 || Wind < 1)
            {
                Console.WriteLine("invalid input please input a number between 1 and 5 inclusive");
                Wind = Convert.ToInt32(Console.ReadLine());
            }

      for (int Row = 0; Row < FIELDLENGTH; Row++)
      {
        for (int Column = 0; Column < FIELDWIDTH; Column++)
        {
            // 1 in 2 chance of wind, if = 2 then wind re-distributes the seeds if not then wind will remain 1 and nothing will change
                   
             if (Field[Row, Column] == PLANT)
             {
                 SeedLands(Field, Row - Wind, Column - Wind);
                 SeedLands(Field, Row - Wind, Column);
                 SeedLands(Field, Row - Wind, Column + Wind);
                 SeedLands(Field, Row, Column - Wind);
                 SeedLands(Field, Row, Column + Wind);
                 SeedLands(Field, Row + Wind, Column - Wind);
                  SeedLands(Field, Row + Wind, Column);
                 SeedLands(Field, Row + Wind, Column + Wind);
               }                   
          
        }
      }
            meteorStorm(Field);
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
            meteorStorm(Field);
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