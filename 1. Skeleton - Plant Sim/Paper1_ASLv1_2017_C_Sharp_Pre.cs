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
        const Char BIRDS = 'B';
    const int FIELDLENGTH = 20;
    const int FIELDWIDTH = 35;
        

    static int GetHowLongToRun() //determines how the code will run e.g will only one year be generated, 5 years, etc
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

    static void CreateNewField(char[,] Field) //this sets up the feild as a grid - this allows you to carry out mathmatical equations - e.g determine where to plant seeds
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
      Console.Write("Enter file name: ");  //this is testCase.TXT  - the name of the file is given in the context PDF
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
      Console.Write("Do you want to load a file with seed positions? (Y/N): "); // this lets you read in the given data - if you select no it will  create a random feild
      Response = Console.ReadLine();
      if (Response == "Y" || Response == "y")
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

    static void CountPlants(char[,] Field) // this determines the number of plants in the feild or grid
    {
      int NumberOfPlants = 0;
      for (int Row = 0; Row < FIELDLENGTH; Row++)
      {
        for (int Column = 0; Column < FIELDWIDTH; Column++)
        {
          if (Field[Row, Column] == PLANT)  // this ensures that rocks or seeds do not effect plant count
          {
            NumberOfPlants++; //adds 1 to the plant num
          }
        }
      }
      if (NumberOfPlants == 1)
      {
        Console.WriteLine("There is 1 plant growing");
      }
      else
      {
        Console.WriteLine("There are " + NumberOfPlants + " plants growing");  // called if there is more than 1 plant in the feild
      }
    }

    static void SimulateSpring(char[,] Field)
    {
      int PlantCount = 0;
      bool Frost = false;  //the weather condition that could effect the plant num in spring is set as frost, being set as false means that there is none at the min
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
      if (RandomInt.Next(0, 2) == 1) // this  sets up a 50:50 chance that there will be a frost
      {
        Frost = true;
      }
      else
      {
        Frost = false;
      }
      if (Frost) //if there is a frost
      {
        PlantCount = 0;
        for (int Row = 0; Row < FIELDLENGTH; Row++) //sets up to check each row
        {
          for (int Column = 0; Column < FIELDWIDTH; Column++) //sets up to check each colum
          {
            if (Field[Row, Column] == PLANT)
            {
              PlantCount++;
              if (PlantCount % 3 == 0) //if the plant count when divded by 3 gives no remainder then the plant in that position is removed - frost kills plants
              {
                Field[Row, Column] = SOIL; //plant becomes only soil
              }
            }
          }
        }
        Console.WriteLine("There has been a frost");
        CountPlants(Field);
      }
    }

    static void SimulateSummer(char[,] Field) // this will produce a new image labled summer
    {
      Random RandomInt = new Random();
      int RainFall = RandomInt.Next(0, 3); //rainfall is the random weather event in summer that could effect plant count - 1/3 chance it could rain
      int PlantCount = 0; //resets plant count to 0
      if (RainFall == 0) //if the random num generated is 0 than it has no rained
      {
        PlantCount = 0;
        for (int Row = 0; Row < FIELDLENGTH; Row++) // sets up to check all rows
        {
          for (int Column = 0; Column < FIELDWIDTH; Column++) //sets up to check all colums
          {
            if (Field[Row, Column] == PLANT)  
            {
              PlantCount++;
              if (PlantCount % 2 == 0) // if the overal plant count after all colums are checked, when divided by 2 gives no remainder then the grid position becomes soil
              {
                Field[Row, Column] = SOIL;
              }
            }
          }
        }
        Console.WriteLine("There has been a severe drought");
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

    static void SimulateAutumn(char[,] Field) //determines where the seed falls
    {
      for (int Row = 0; Row < FIELDLENGTH; Row++)
      {
        for (int Column = 0; Column < FIELDWIDTH; Column++)
        {
          if (Field[Row, Column] == PLANT) //the seed should fall exactly around the plant
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
    }
        static void birdEatsSeed(char[,] Field)
        {
            Random RandomInt = new Random();            
            int Row = RandomInt.Next(1, 10);           

            for (int Column = 0; Column < FIELDWIDTH; Column++)
            {
                if (Field[Row, Column] == SEED)
                {
                    Field[Row, Column] = BIRDS;
                }

            }

            Console.WriteLine("A bird has eaten all of the seeds");


        }


        static void SimulateWinter(char[,] Field)
    {
      for (int Row = 0; Row < FIELDLENGTH; Row++) //checks each row
      {
        for (int Column = 0; Column < FIELDWIDTH; Column++)// checks each column
        {
          if (Field[Row, Column] == PLANT)
          {
            Field[Row, Column] = SOIL;  //sets any plant found to soil - in winter plants die
          }
        }
      }
            birdEatsSeed(Field);
    }

    static void SimulateOneYear(char[,] Field, int Year) //this calls the subroutine for each season and assigns it to a year
    {
      SimulateSpring(Field);
      Display(Field, "spring", Year);
      SimulateSummer(Field);
      Display(Field, "summer", Year); //displays the feild for that season as a seperate entity
      SimulateAutumn(Field);
      Display(Field, "autumn", Year);
      SimulateWinter(Field);
      Display(Field, "winter", Year);
    }

    private static void Simulation() //this does everything
    { // variables set up
      int YearsToRun;
      char[,] Field = new char[FIELDLENGTH, FIELDWIDTH];
      bool Continuing;
      int Year;
      string Response;
      YearsToRun = GetHowLongToRun();
      if (YearsToRun != 0) // if the user wants to run the code the following is run
      {
        InitialiseField(Field);
        if (YearsToRun >= 1)
        {
          for (Year = 1; Year <= YearsToRun; Year++) 
          {
            SimulateOneYear(Field, Year); //calls the year subroyutine and passes the created feild and year in
          }
        }
        else
        {
          Continuing = true; //booleans variable - this is set if the user has put in a year num greater than 1
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
      Simulation(); //this calls the simulation subroutine
    }

  }
}