using System.Drawing;

namespace day9
{
  class Program
  {

    static private Dictionary<char, Size> moves = new() 
    {
      {'L', new Size(-1, 0)},
      {'R', new Size(1, 0)},
      {'U', new Size(0, -1)},
      {'D', new Size(0, 1)}
    };
    
    static int SolveNKnots (IEnumerable<(char,int)> input, int knots)
    {
      HashSet<Point> visitedPos = new(){new Point(0,0)};
      var rope = Enumerable.Range(0, knots).Select(x => new Point()).ToArray();
      foreach (var(dir, dist) in input)
      {
        for (int i=0; i<dist; i++)
        {
          rope[0] += moves[dir]
        }
      }
    }

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
