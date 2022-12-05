using System.Text.RegularExpressions;

namespace day5
{
  static class Program
  {
    
    public static string Part1 (string[] input)
    {
      List<char>[] crates = crateArrangement(input);
      int guide = getGuide(input);
      string pattern = "[a-z]*";
      Regex regex = new Regex(@"\s+");
      for (int i=guide+2; i<input.Count(); i++)
      {
        input[i] = Regex.Replace(input[i], pattern, "");
        input[i] = input[i].Trim(' ');
        string[] rules = regex.Split(input[i]).ToArray();
        for (int j=0; j<int.Parse(rules[0]); j++)
        {
          int fr = int.Parse(rules[1])-1;
          int to = int.Parse(rules[2])-1; 
          char c = crates[fr].Last();
          crates[to].Add(c);
          crates[fr].RemoveAt(crates[fr].Count()-1);
        }
      }
      string result = "";
      for (int i=0; i<9; i++)
      {
        result += crates[i][crates[i].Count()-1];
      }
      return result;
    }
  
    public static string Part2 (string[] input)
    {
      List<char>[] crates = crateArrangement(input);
      int guide = getGuide(input);
      string pattern = "[a-z]*";
      Regex regex = new Regex(@"\s+");
      for (int i=guide+2; i<input.Count(); i++)
      {
        input[i] = Regex.Replace(input[i], pattern, "");
        input[i] = input[i].Trim(' ');
        string[] rules = regex.Split(input[i]).ToArray();
        int fr = int.Parse(rules[1])-1;
        int to = int.Parse(rules[2])-1; 
        for (int j=int.Parse(rules[0]); j>0; j--)
        {
          char c = crates[fr][crates[fr].Count()-j];
          crates[to].Add(c);
          crates[fr].RemoveAt(crates[fr].Count()-j);
        }
      }
      string result = "";
      for (int i=0; i<9; i++)
      {
        result += crates[i][crates[i].Count()-1];
      }
      return result;
    }

    public static int getGuide (string[] input)
    {
      int guide=0;
      while (!string.IsNullOrWhiteSpace(input[guide+1])) guide++;
      return guide;
    }

    public static List<char>[] crateArrangement (string[] input)
    {
      List<char>[] crates = new List<char>[9];
      int guide = getGuide(input);
      for (int i=0; i<input[guide].Length; i++)
      {
        if (input[guide][i] != ' ')
        {
          int k = (int)Char.GetNumericValue(input[guide][i])-1;
          crates[k] = new List<char>();
          for (int j=guide-1; j>=0; j--)
          {
            char c = input[j][i];
            if (c != ' ' && c != '\n')
            {
              crates[k].Add(c);
            }
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
