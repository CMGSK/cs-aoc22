namespace day11
{
  class Program
  {
    class Monkey
    {
      
      long count = 0;
      List<long> objects = new List<long>();
      
      public void countUp (long n)
      {
        this.count+=n;
      }
      public long getCount ()
      {
        return this.count;
      }
      public List<long> getItems()
      {
        return this.objects;
      }
      public void addToList (long n)
      {
        this.objects.Add(n);
      }
      public void delFromList (int n)
      {
        this.objects.RemoveAt(n);
      }
    } 

    static long getBusiness (Dictionary<long, Monkey> monkeys)
    {
      long top1=0;
      long top2=0;
      for (long i=0; i<monkeys.Count(); i++)
      {
        if (monkeys[i].getCount() > top1)
        {
          top2 = top1;
          top1 = monkeys[i].getCount();
        }
        else if (monkeys[i].getCount() > top2) top2 = monkeys[i].getCount();
      }
      return top1 * top2;
    }

    static long Inspect (string input, long worry)
    {
      long A=0;
      long B=0;
      string temp = input.Substring(input.IndexOf("=")+2);
      string[] instructions = temp.Split(" ").ToArray();
      if (instructions[0]==instructions[2])
      {
        A=worry;
        B=worry;
      }
      else
      {
        A = instructions[0] == "old" ?  worry : long.Parse(instructions[2]);
        B = A!=worry ? worry : long.Parse(instructions[2]); 
      }
      return instructions[1] == "+" ? Math.Abs((A+B)/3) : Math.Abs((A*B)/3);
    }

    static Dictionary<long, Monkey> getMonkeys (string[] input)
    {
      Dictionary<long, Monkey> monkeys = new Dictionary<long, Monkey>();
      for (long i=0; i<input.Length; i++)
      {
        long tag = long.Parse(input[i][^2].ToString());
        i++;
        string temp = input[i].Substring(input[i].IndexOf(":")+1).Replace(" ", "");
        long[] n = temp.Split(",").Select(x => long.Parse(x)).ToArray();
        Monkey monkey = new Monkey();
        foreach (long x in n) monkey.addToList(x);
        i+=5;
        monkeys.Add(tag, monkey);
      }
      return monkeys;
    }

    static void Part1 (string[] input)
    {
      Dictionary<long, Monkey> monkeys = getMonkeys(input);
      for (long round=0; round<20; round++)
      {
        for (long i=0; i<input.Length; i++)
        {
          long tag = long.Parse(string.Join("", input[i].ToCharArray().Where(Char.IsDigit)));
          i+=2;
          monkeys[tag].countUp(monkeys[tag].getItems().Count()); //this freaking instruction inside the for got me stucked for 7 hours
          for (int item=0; item<monkeys[tag].getItems().Count(); item++)
          {
            long worry = Inspect(input[i],monkeys[tag].getItems().ElementAt(item));
            long rule = long.Parse(string.Join("", input[i+1].ToCharArray().Where(Char.IsDigit)));
              if (worry%rule==0)
              {
                long dest = long.Parse(string.Join("", input[i+2].ToCharArray().Where(Char.IsDigit)));
                monkeys[dest].addToList(worry);
                monkeys[tag].delFromList(item);
                item--;
              }
              else
              {
                long dest = long.Parse(string.Join("", input[i+3].ToCharArray().Where(Char.IsDigit)));
                monkeys[dest].addToList(worry);
                monkeys[tag].delFromList(item);
                item--;
              }
            }
          i+=4;
        }
      }
      Console.WriteLine(getBusiness(monkeys)); 
    }

    static long InspectP2 (string input, long worry, long mod)
    {
      long A=0;
      long B=0;
      string temp = input.Substring(input.IndexOf("=")+2);
      string[] instructions = temp.Split(" ").ToArray();
      if (instructions[0]==instructions[2])
      {
        A=worry;
        B=worry;
      }
      else
      {
        A = instructions[0] == "old" ?  worry : long.Parse(instructions[2]);
        B = A!=worry ? worry : long.Parse(instructions[2]); 
      }
      return instructions[1] == "+" ? Math.Abs((A+B) % mod) : Math.Abs((A*B) % mod);
    }

    static void Part2 (string[] input)
    {
      long mod=1;
      List<long> tests = new List<long>();
      foreach (string x in input)
      {
        if (x.Contains("Test: divisible by "))
        {
          tests.Add(long.Parse(string.Join("", x.ToCharArray().Where(Char.IsDigit))));
        }
      }
      foreach (long n in tests)
      {
        mod*=n;
      }

      Dictionary<long, Monkey> monkeys = getMonkeys(input);
      for (long round=0; round<10000; round++)
      {
        for (long i=0; i<input.Length; i++)
        {
          long tag = long.Parse(string.Join("", input[i].ToCharArray().Where(Char.IsDigit)));
          i+=2;
          monkeys[tag].countUp(monkeys[tag].getItems().Count()); //this freaking instruction inside the for got me stucked for 7 hours
          for (int item=0; item<monkeys[tag].getItems().Count(); item++)
          {
            long worry = InspectP2(input[i],monkeys[tag].getItems().ElementAt(item), mod);
            long rule = long.Parse(string.Join("", input[i+1].ToCharArray().Where(Char.IsDigit)));
              if (worry%rule==0)
              {
                long dest = long.Parse(string.Join("", input[i+2].ToCharArray().Where(Char.IsDigit)));
                monkeys[dest].addToList(worry);
                monkeys[tag].delFromList(item);
                item--;
              }
              else
              {
                long dest = long.Parse(string.Join("", input[i+3].ToCharArray().Where(Char.IsDigit)));
                monkeys[dest].addToList(worry);
                monkeys[tag].delFromList(item);
                item--;
              }
            }
          i+=4;
        }
      }
      Console.WriteLine(getBusiness(monkeys)); 
    }

    public static void Main (string[] args)
    {
      string[] input = File.ReadAllLines("input.txt");
      Part1(input);
      Part2(input);
    }
  }
}
