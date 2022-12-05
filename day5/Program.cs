using System.Text.RegularExpressions;

namespace day5
{
  static class Program
  {
    
    public static int Part1 (string[] input)
    {

      return 0;
    }
  
    public static int Part2 (string[] input)
    {
    
      return 0;
    }

    public static List<char>[] crateArrangement (string[] input)
    {
      List<char>[] crates = new List<char>[8];
      Regex regex = new Regex("[0-9]");
      int guide=0;
      while (!string.IsNullOrWhiteSpace(input[guide+1])) guide++;
      for (int i=0; i<input[guide].Length; i++)
      {
        if (input[guide][i] != ' ')
        {
          for (int j=guide-1; j<=0; j--)
          {
            crates[(int)Char.GetNumericValue(input[guide][i])].Add(input[j][i]);
          }
        }
      }
      return crates;
    }

    public static void Main (string[] args)
    {
      string[] input = File.ReadAllLines("input.txt");
      Console.WriteLine(Part1(input));
      Console.WriteLine(Part2(input));

    }
  }
}
