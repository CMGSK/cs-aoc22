namespace day4
{
  public class Program
  {

    static int[] pairs (string data)
    {
      //sorry for this couldnt debug the proper way to do it
      int[] result = new int[4];
      string[] separatedElfs = data.Split(",").ToArray();
      string[] first = separatedElfs[0].Split("-");
      string[] second = separatedElfs[1].Split("-");
      for (int i=0; i<2; i++)
      {
        result[i]=int.Parse(first[i]);
      }
      for (int i=0; i<2; i++)
      {
        result[i+2]=int.Parse(second[i]);
      }
      return result;
    }


    
    static int Part1 (string[] input)
    {
      int res=0;
      foreach (string x in input)
      {
        int[] data = pairs(x);
        if ((data[0]>=data[2] && data[1]<=data[3]) || (data[2]>=data[0] && data[3]<=data[1])) res++;
      }
      return res;
    }

    static int Part2 (string[] input)
    {
      int res=0;
      foreach (string x in input)
      {
        int[] data = pairs(x);
        if ((data[0]>=data[2] && data[0]<=data[3]) || (data[2]>=data[0] && data[2]<=data[1])) res++;
        else if ((data[1]>=data[2] && data[1]<=data[3]) || (data[3]>=data[0] && data[3]<=data[1])) res++;
      }
      return res;
    }

    public static void Main (string[] args)
    {
      string[] input = File.ReadAllLines("input.txt");

      Console.WriteLine(Part1(input));
      Console.WriteLine(Part2(input));
    }
  }
}
