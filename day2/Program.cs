namespace day2
{
  class Program
  {
    public static void Main (string[] args){
      string[] input = File.ReadAllLines("input.txt");

      // Part 1 
      // int points=0;
      // for (int i=0; i<input.Count(); i++)
      // {
      //   int choice=0;
      //   switch(input[i][input[i].Count()-1])
      //   {
      //     case 'X':
      //       choice += 1;
      //       break;
      //     case 'Y':
      //       choice += 2;
      //       break;
      //     case 'Z':
      //       choice += 3;
      //       break;
      //   }
      //   points += choice;
      //   switch(input[i][0])
      //   {
      //     case 'A':
      //       if (choice == 1)
      //       {
      //         points += 3;
      //       }
      //       else if (choice == 2)
      //       {
      //         points += 6;
      //       }
      //       break;
      //     case 'B':
      //       if (choice == 2)
      //       {
      //         points += 3;
      //       }
      //       else if (choice == 3)
      //       {
      //         points += 6;
      //       }
      //       break;
      //     case 'C':
      //       if (choice == 3)
      //       {
      //         points += 3;
      //       }
      //       else if (choice == 1)
      //       {
      //         points += 6;
      //       }
      //       break;
      //   }
      // }
      // Console.WriteLine(points);
      
      
      // Part 2
      int points=0;
      for (int i=0; i<input.Count(); i++)
      {
        int win=0;
        switch (input[i][input[i].Count()-1])
        {
          case 'Y':
            win = 3;
            break;
          case 'Z':
            win = 6;
            break;
        }
        points+=win;
        switch (input[i][0])
        {
          case 'A':
            if (win == 0)
            {
              points+=3;
            }
            else if (win == 3)
            {
              points+=1;
            }
            else points+=2;
            break;
          case 'B':
            if (win == 0)
            {
              points+=1;
            }
            else if (win == 3)
            {
              points+=2;
            }
            else points+=3;
            break;
          case 'C':
            if (win == 0)
            {
              points+=2;
            }
            else if (win == 3)
            {
              points+=3;
            }
            else points+=1;
            break;
        }
      }
      Console.WriteLine(points);
    }
  }
} 
