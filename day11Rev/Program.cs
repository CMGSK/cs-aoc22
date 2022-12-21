class Program
{
  static void Main(string[] args)
  {
    var input = File.ReadAllLines("input.txt")
      .Chunk(7)
      .Select(monkey => new Monkey(monkey));
    var mod = input.Aggregate(1, (current, monkey) => current * monkey.TestMod);

    Console.WriteLine(MonkeyBusiness(input.ToArray(), 20));
    Console.WriteLine(MonkeyBusiness(input.ToArray(), 10000, mod));
  }
  static long MonkeyBusiness(Monkey[] monkeys, int rounds, int mod=1)
  {
    for (var round=0; round<rounds; round++)
    {
      foreach (var monkey in monkeys)
      {
        while (monkey.Items.TryDequeue(out var item))
        {
          item = monkey.ItemNewValue(item, mod);
          var index = item % monkey.TestMod == 0 ? monkey.MonkeyIfTrue : monkey.MonkeyIfFalse;
          monkeys[index].Items.Enqueue(item);
          monkey.Inspected++;
        }
      }
    }
    return monkeys.Select(monkey => monkey.Inspected)
      .OrderByDescending(x => x)
      .Take(2)
      .Multiply();
  }
}

public static class Utils
{
  static public long Multiply(this IEnumerable<long> enumerable)
  {
    return enumerable.Aggregate((long) 1, (current, item) => current * item);
  }
}

class Monkey
{
  public Queue<long> Items = new();
  public char Op;
  public int? OpValue;
  public int TestMod;
  public int MonkeyIfTrue;
  public int MonkeyIfFalse;
  public long Inspected=0;

  public Monkey(string[] data)
  {
    Items = new Queue<long>(data[1][18..].Split(", ").Select(long.Parse));
    Op = data[2][23];
    OpValue = data[2][25] == 'o' ? null : int.Parse(data[2][25..]);
    TestMod = int.Parse(data[3][21..]);
    MonkeyIfTrue = int.Parse(data[4][^1].ToString());
    MonkeyIfTrue = int.Parse(data[5][^1].ToString());
  }

  public long ItemNewValue(long old, long mod=1)
  {
    var result = Op switch
    {
      '+' => old + (OpValue ?? old),
      '*' => old * (OpValue ?? old),
      _ => throw new NotImplementedException(),
    };
    return mod == 1 ? result / 3 : result % mod;
  }
}

