namespace day12
{
  class Program
  {

    class Position
    {
      char point;
      int distance;
      Tuple<int, int> XY;

      public Position(char point, Tuple<int, int> XY, int distance)
      {
        this.point=point;
        this.XY=XY;
        this.distance=distance;
      }
      
      public int getDistance () { return distance; }

      public Tuple<int, int> getPos () { return XY; }

      public char getPoint () { return point; }

      public List<Position> getOptions (char[][] input, Position back) 
      { //each if checks if +/-1 position of axis can be accesible and adds it to a list if so
        List<Position> list = new();
        if (XY.Item1-1 >= 0 &&
            back.getPos() != new Tuple<int, int>(XY.Item1-1, XY.Item2) &&
            (Math.Abs(input[XY.Item1-1][XY.Item2] - point) < 2 || ((point=='z' || point=='y') && input[XY.Item1-1][XY.Item2] == 'E')))
        {
        list.Add(new Position(input[XY.Item1-1][XY.Item2], 
              new Tuple<int, int>(XY.Item1-1, XY.Item2), 
              distance+1));
        }
        if (XY.Item1+1 < input.Count() &&
            back.getPos() != new Tuple<int, int>(XY.Item1+1, XY.Item2) &&
            (Math.Abs(input[XY.Item1+1][XY.Item2] - point) < 2 || ((point=='z' || point=='y') && input[XY.Item1+1][XY.Item2] == 'E')))
        {
        list.Add(new Position(input[XY.Item1+1][XY.Item2],
              new Tuple<int, int>(XY.Item1+1, XY.Item2), 
              distance+1));
        }
        if (XY.Item2-1 >= 0 &&
            back.getPos() != new Tuple<int, int>(XY.Item1, XY.Item2-1) &&

            (Math.Abs(input[XY.Item1][XY.Item2-1] - point) < 2 || ((point=='z' || point=='y') && input[XY.Item1][XY.Item2-1] == 'E')))
        {
        list.Add(new Position(input[XY.Item1][XY.Item2-1], 
              new Tuple<int, int>(XY.Item1, XY.Item2-1), 
              distance+1));
        }
        if (XY.Item2+1 < input[XY.Item1].Count() &&
            back.getPos() != new Tuple<int, int>(XY.Item1, XY.Item2+1) &&
            (Math.Abs(input[XY.Item1][XY.Item2+1] - point) < 2 || ((point=='z' || point=='y') && input[XY.Item1][XY.Item2+1] == 'E')))
        {
        list.Add(new Position(input[XY.Item1][XY.Item2+1], 
              new Tuple<int, int>(XY.Item1, XY.Item2+1), 
              distance+1));
        }
        return list;
      }

      public bool isVisited (HashSet<Tuple<int,int>> visited)
      {
        foreach(var t in visited)
        {
          if (XY.Equals(t)) return true;
        }
        return false;
      }

    }


    static void Ex1 (char[][] input)
    {
      Queue<Position> Q = new Queue<Position>();
      HashSet<Tuple<int, int>> visited = new();
      Position S = new Position ('a', new Tuple<int, int>(0,0), 0);
      Q.Enqueue(S);
      Position current = S;
      while (current.getPoint()!= 'E')
      {
        Position back = current;
        current = Q.Dequeue();
        visited.Add(current.getPos());
        List<Position> paths = current.getOptions(input, back);
        foreach (var p in paths) 
        {
          if (!p.isVisited(visited))
          {
            Q.Enqueue(p);
          }
        }
        
      }
      Console.WriteLine(current.getDistance());

    }

    public static void Main (string[] args)
    {
      char[][] input = File.ReadAllLines("input.txt").Select(l => l.ToCharArray()).ToArray();
      Ex1(input);
    }
  }
}
