namespace day12
{
  class Program
  {

    public class Position
    {
      public char point {get; set;}
      public int distance {get; set;}
      public Tuple<int, int> XY {get; set;}

      public Position(char point, Tuple<int, int> XY, int distance)
      {
        this.point=point;
        this.XY=XY;
        this.distance=distance;
      }
      
      public List<Position> getOptions (char[][] input) 
      { //each if checks if +/-1 position of axis can be accesible and adds it to a list if so
        bool goalReachable = (point == 'b'); //|| point=='a'); uncomment for part1
        List<Position> opt = new();
// change 'a' for 'S' for part1
        if (XY.Item2+1 < input[XY.Item1].Length) //Getting path East
        {
          char East = input[XY.Item1][XY.Item2+1];
          if (point - East < 2 || (goalReachable && East == 'a'))
          {
            opt.Add(new Position(East, new Tuple<int, int>(XY.Item1, XY.Item2+1), distance+1));
          }
        }
        if (XY.Item2-1 >= 0)
        {
          char West = input[XY.Item1][XY.Item2-1];
          if (point - West < 2 || (goalReachable && West == 'a'))
          {
            opt.Add(new Position(West, new Tuple<int, int>(XY.Item1, XY.Item2-1), distance+1));
          }
        }
        if (XY.Item1-1 >= 0)
        {
          char North = input[XY.Item1-1][XY.Item2]; 
          if (point - North < 2 || (goalReachable && North == 'a'))
          {
            opt.Add(new Position(North, new Tuple<int, int>(XY.Item1-1, XY.Item2), distance+1));
          }
        }
        if (XY.Item1+1 < input.Length)
        {
          char South = input[XY.Item1+1][XY.Item2];
          if (point - South < 2 || (goalReachable && South == 'a'))
          {
            opt.Add(new Position(South, new Tuple<int, int>(XY.Item1+1, XY.Item2), distance+1));
          }
        }

        return opt;
      }

    }

    static public bool isVisited (HashSet<Position> visited, Position position)
    {
      bool result = false;
      foreach(var t in visited)
      {
        if (t.XY.Equals(position.XY))
        {
          result = true;
          if (t.distance > position.distance) // if path is shorter then allow
          {
            result = false;
            t.distance = position.distance;
          }
        }
      }
      return result;
    }

    static void Ex1 (char[][] input)
    {
      Tuple<int,int> E = new(0,0);
      for (int i=0; i<input.Length; i++)
      {
        for (int j=0; j<input[i].Length; j++)
        {
          if (input[i][j] == 'E')
          {
            E = new Tuple<int, int>(i,j);
          }
        }
      }
      Queue<Position> Q = new Queue<Position>();
      HashSet<Position> visited = new();
      Position current = new Position ('z', E, 0);
      Q.Enqueue(current);
      while (current.point != 'a') //change to 'S' for part1
      {
        current = Q.Dequeue();
        List<Position> paths = current.getOptions(input);
        foreach (var path in paths) 
        {
          if (!isVisited(visited, path)) //also checks for shorter paths
          {
            Q.Enqueue(path);
          }
          visited.Add(path); // this gotta be here to avoid enqueuing duplicates
        }
      }
      Console.WriteLine(current.distance); // Result
    }

    public static void Main (string[] args)
    {
      char[][] input = File.ReadAllLines("input.txt").Select(l => l.ToCharArray()).ToArray();
      Ex1(input);
    }
  }
}


