namespace day8
{
  public class Program
  {
    static int Part1 (string[] input) // I also hate this its ok to curse me
    {
      int res=0;
      for (int inputline=1; inputline<input.Count()-1; inputline++)
      {
        for (int linechar=1; linechar<input[inputline].Count()-1; linechar++)
        {
          bool Hvisible=true;
          for (int hor=linechar+1; hor<input[inputline].Count(); hor++)
          {
            if ((input[inputline][linechar] - '0') <= (input[inputline][hor] - '0'))
            {
              for (int horBack=linechar-1; horBack>=0; horBack--)
              {
                if ((input[inputline][linechar] - '0') <= (input[inputline][horBack] - '0'))
                {
                    Hvisible=false;
                }
              }
            }
          }
          if (Hvisible) res++;
          else
          {
            bool Vvisible = true;
            for (int verUp=inputline+1; verUp<input.Count(); verUp++)
            {
              if ((input[inputline][linechar] - '0') <= (input[verUp][linechar] - '0'))
              {
                for (int verDown=inputline-1; verDown>=0; verDown--)
                {
                  if ((input[inputline][linechar] - '0') <= (input[verDown][linechar] - '0'))
                  {
                    Vvisible=false;
                  }
                }
              }
            }
            if(Vvisible) res++;
          }
        }
      }
      return res + (input.Count() * 2) + ((input[0].Count() - 2) * 2);
    }

    static int Part2 (string[] input)
    {
      int highscore = 0, score = 0, axis = 1;
      for (int i = 1; i<input.Count() - 1; i++)
      {
        for (int j = 1; j < input[0].Count() - 1; j++)
        {
          for (int hor = j + 1; hor < input[0].Count()-1; hor++)
          {
            if (input[i][j] - '0' > input[i][hor] - '0') axis++;
            else break;
          }
          score = axis;
          axis=1;
          for (int horBack = j - 1; horBack > 0; horBack--)
          {
            if (input[i][j] - '0' > input[i][horBack] - '0') axis++;
            else break;
          }
          score *= axis; 
          axis=1;
          for (int ver = i + 1; ver < input.Count()-1; ver++)
          {
            if (input[i][j] - '0' > input[ver][j] - '0') axis++;
            else break;
          }
          score *= axis; 
          axis=1;
          for (int verBack = i - 1; verBack > 0; verBack--)
          {
            if (input[i][j] - '0' > input[verBack][j] - '0') axis++;
            else break;
          }
          score *= axis; 
          axis=1;
          if (score > highscore) highscore = score;
          score=0;
        }
      }
      return highscore;
    }

    public static void Main (string[] args)
    {
      string[] input = File.ReadAllLines("input.txt");
      Console.WriteLine(Part1(input));
      Console.WriteLine(Part2(input));
    }
  }
}
