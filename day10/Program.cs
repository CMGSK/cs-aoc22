namespace day10
{
  class Program
  {
    static int Part1 (string[] input)
    {
      int cycles = 1;
      int result = 0;
      int X = 1;
      foreach (string s in input)
      {
        if (s.Contains("noop"))
        {
          if (cycles % 40 == 20)
          {
            result += cycles * X;
            Console.WriteLine(cycles * X);
          }
          cycles++;
        }
        else{
          if (cycles % 40 == 20)
          {
            result += cycles * X;
            Console.WriteLine(cycles * X);
          }
          cycles++;
          if (cycles % 40 == 20)
          {
            result += cycles * X;
            Console.WriteLine(cycles * X);
          }
          cycles++;
          X += int.Parse(s.Substring(5));
        }
      }
      return result;
    }

    static string Part2 (string[] input)
    {
      string[] CTR = new string[6]{"", "", "", "", "", ""};
      int cycles=0;
      int X=1;
      int i=0;
      foreach (string s in input)
      {
        if (s.Contains("noop"))
        {
          cycles++;
          if(CTR[i].Length <39) CTR[i] += Draw(cycles, X) ? "#" : " ";
          else i++;
        }
        else
        {
          cycles++;
          if (CTR[i].Length <39) CTR[i] += Draw(cycles, X) ? "#" : " ";
          else i++;
          cycles++;
          if (CTR[i].Length <39) CTR[i] += Draw(cycles, X) ? "#" : " ";
          else i++;
          X += int.Parse(s.Substring(5));
          Console.WriteLine(X);
        }
      }
      foreach (string s in CTR) Console.WriteLine(s);
      return "lol";
    }

    static bool Draw (int cycles, int X)
    {
      return cycles%40 == X || cycles%40 == X+1 || cycles%40 == X+2;
    }

    public static void Main (string[] args)
    {
      string[] input = File.ReadAllLines("input.txt");
      Console.WriteLine(Part1(input));
      Console.WriteLine(Part2(input));
    }
  }
}
