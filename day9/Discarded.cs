namespace day9
{
  class Program
  {
    static int Part1 (string[] Input)
    {
      var input = Input.Select(line => (dir:line[0], dist:int.Parse(line[2..])));
      HashSet<Tuple<int, int>> path = new HashSet<Tuple<int, int>>();
      Tuple<int, int> head = new Tuple<int, int>(0, 0);
      Tuple<int, int> tail = new Tuple<int, int>(0, 0);
      path.Add(tail);
      foreach (var(dir,dist) in input)
      {
        for (int i=0; i<dist; i++)
        {
          switch (dir)
          {
            case 'U':
              head = new Tuple<int, int>(head.Item1, head.Item2+1);
              break;
            case 'D':
              head = new Tuple<int, int>(head.Item1, head.Item2-1);
              break;
            case 'R':
              head = new Tuple<int, int>(head.Item1+1, head.Item2);
              break;
            case 'L':
              head = new Tuple<int, int>(head.Item1-1, head.Item2);
              break;
          }
        }
      }
      return 0;
    }
    static int Part2 (string[] input)
    {
      
      return 0;
    }
    public static void Main (string[] args)
    {
      string[] input = File.ReadAllLines("test.txt");
      Console.WriteLine(Part1(input));
      Console.WriteLine(Part2(input));
    }
  }
}
