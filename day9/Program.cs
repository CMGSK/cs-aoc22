namespace day9
{
  class Program
  {

    class knot
    {
      int X=0;
      int Y=0;

      public knot(int X, int Y)
      {
        this.X=X;
        this.Y=Y;
      }

      public Tuple<int, int> getPos()
      {
        return new Tuple<int, int>(X, Y);
      }

      public void adjust (int X, int Y)
      {
        this.X=X;
        this.Y=Y;
      }

      public void move (string s)
      {
        switch (s[0])
        {
          case 'U':
            this.Y++;
            break;
          case 'D':
            this.Y--;
            break;
          case 'R':
            this.X++;
            break;
          case 'L':
            this.X--;
            break;
        }
      }
    }

    static void printPos (HashSet<Tuple<int, int>> a)
    {
      foreach (var t in a)
      {
        Console.WriteLine(t.Item1+","+t.Item2);
      }
    }

    static void Ex (string[] input, int numberOfKnots)
    {
      HashSet<Tuple<int, int>> positions = new();
      Dictionary<int, knot> knots = new();
      for (int i=0; i<numberOfKnots; i++) knots.Add(i, new knot(0,0));

      foreach (string x in input)
      {
        int m = int.Parse(x[2..]);
        for (int i=0; i<m; i++)
        {
          knots[0].move(x);
          for (int j=1; j<knots.Count(); j++)
          {
            if (Math.Abs(knots[j].getPos().Item1 - knots[j-1].getPos().Item1) > 1 ) // X axis for the whole if
            {
              if (knots[j].getPos().Item1 - knots[j-1].getPos().Item1 < 0) // if head axis pos is bigger than tail
              {
                knots[j].adjust(knots[j-1].getPos().Item1-1, knots[j-1].getPos().Item2);
              }
              else
              {
                knots[j].adjust(knots[j-1].getPos().Item1+1, knots[j-1].getPos().Item2);
              }
            }
            else if (Math.Abs(knots[j].getPos().Item2 - knots[j-1].getPos().Item2) > 1) // Y axis for the whole if
            {
              if (knots[j].getPos().Item2 - knots[j-1].getPos().Item2 < 0) // if head axis pos is bigger than tail
              {
                knots[j].adjust(knots[j-1].getPos().Item1, knots[j-1].getPos().Item2-1);
              }
              else
              {
                knots[j].adjust(knots[j-1].getPos().Item1, knots[j-1].getPos().Item2+1);
              }
            }
            positions.Add(knots[j].getPos());
          }
        }
      }
      // printPos(positions);
      Console.WriteLine(positions.Count());
    }


    public static void Main (string[] args)
    {
       string[] input = File.ReadAllLines("input.txt");
       Ex(input, 2);
       Ex(input, 10);
    }
  }
}
