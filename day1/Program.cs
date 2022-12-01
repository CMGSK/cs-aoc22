namespace day1
{
  class Program
  {
    public static IEnumerable<long> GroupedElf (string data)
    {
      return data.Split(Environment.NewLine + Environment.NewLine)
        .Select(elf => elf.Split(Environment.NewLine).Select(calories => long.Parse(calories)).Sum());
    }

    public static void Main (string[] args)
    {

      // string[] input = File.ReadAllLines("input.txt");

      //Part 1 cs
       IEnumerable<long> elfdata = GroupedElf(File.ReadAllText("input.txt"));
       Console.WriteLine(elfdata.Max());

      //Part 2 cs
      
       Console.WriteLine(elfdata.OrderByDescending(elf => elf).Take(3).Sum());



      //Part 1
      // int res = 0;
      // int block = 0;
      // for (int i = 0; i<input.Count(); i++)
      // {
      //   if (string.IsNullOrEmpty(input[i]))
      //   {
      //     if (block>res)
      //     {
      //       res = block;
      //     }
      //     block = 0;
      //   }
      //   else
      //   {
      //     if (int.TryParse(input[i], out int temp))
      //     {
      //     block += temp; 
      //     }
      //     else
      //     {
      //       Console.WriteLine(System.Convert.ToInt32(input[i][0]));
      //     }
      //   }
      // }

      // Console.WriteLine(res);



      

    }
  }
}
