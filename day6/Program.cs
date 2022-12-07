namespace day6
{
  class Program
  {
    static int Part1 (string input)
    {
      int res=0;
      for (int i=3; i<input.Count(); i++)
      {
        if (CheckDup(input.Substring(i-3, 4)).Count() == 4)
        {
          res=i+1; 
          break;
        }
      }
      return res;
    }

    static int Part2 (string input)
    {
      int res=0;
      for (int i=13; i<input.Count(); i++)
      {
        if (CheckDup(input.Substring(i-13, 14)).Count() == 14)
        {
          res=i+1; 
          break;
        }
      }
      return res;
    }

    static string CheckDup (string data)
    {
      return new string(data.ToCharArray().Distinct().ToArray());
    }

    public static void Main (string[] args)
    {
      string input = File.ReadAllText("input.txt");
      Console.WriteLine(Part1(input));
      Console.WriteLine(Part2(input));
    }
  }  
}
