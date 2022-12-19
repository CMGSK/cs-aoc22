namespace day11
{
  class Program
  {
    class Monkey
    {
      
      int count = 0;
      List<int> objects = new List<int>();
      
      public void countUp (int n)
      {
        this.count+=n;
      }
      public int getCount ()
      {
        return this.count;
      }
      public List<int> getItems()
      {
        return this.objects;
      }
      public void addToList (int n)
      {
        this.objects.Add(n);
      }
      public void delFromList (int n)
      {
        this.objects.RemoveAt(n);
      }
    } 

    static int getBusiness (Dictionary<int, Monkey> monkeys)
    {
      int top1=0;
      int top2=0;
      for (int i=0; i<monkeys.Count(); i++)
      {
        // Console.WriteLine(monkeys[i].getCount());
        if (monkeys[i].getCount() > top1)
        {
          top2 = top1;
          top1 = monkeys[i].getCount();
        }
        else if (monkeys[i].getCount() > top2) top2 = monkeys[i].getCount();
      }
      Console.WriteLine(top1 + " " + top2);
      return top1 * top2;
    }

    static int Inspect (string input, int worry)
    {
      int A=0;
      int B=0;
      string temp = input.Substring(input.IndexOf("=")+2);
      string[] instructions = temp.Split(" ").ToArray();
      if (instructions[0]==instructions[2])
      {
        A=worry;
        B=worry;
      }
      else
      {
        A = instructions[0] == "old" ?  worry : int.Parse(instructions[2]);
        B = A!=worry ? worry : int.Parse(instructions[2]); 
      }
      return instructions[1] == "+" ? Math.Abs((A+B)/3) : Math.Abs((A*B)/3);
    }

    static Dictionary<int, Monkey> getMonkeys (string[] input)
    {
      Dictionary<int, Monkey> monkeys = new Dictionary<int, Monkey>();
      for (int i=0; i<input.Length; i++)
      {
        int tag = int.Parse(input[i][^2].ToString());
        i++;
        string temp = input[i].Substring(input[i].IndexOf(":")+1).Replace(" ", "");
        int[] n = temp.Split(",").Select(x => int.Parse(x)).ToArray();
        Monkey monkey = new Monkey();
        foreach (int x in n) monkey.addToList(x);
        i+=5;
        monkeys.Add(tag, monkey);
      }
      return monkeys;
    }

    static void prinMonkey (Monkey x)
    { 
      Console.WriteLine("count " + x.getItems().Count());
      foreach (int n in x.getItems()) Console.WriteLine(n);
    }

    static void Part1 (string[] input)
    {
      Dictionary<int, Monkey> monkeys = getMonkeys(input);
      for (int round=0; round<20; round++)
      {
        Console.WriteLine("//// Round" + round);
        for (int i=0; i<input.Length; i++)
        {
          int tag = int.Parse(string.Join("", input[i].ToCharArray().Where(Char.IsDigit)));
          i+=2;
          monkeys[tag].countUp(monkeys[tag].getItems().Count()); //this freaking instruction inside the for got me stucked for 7 hours
          for (int item=0; item<monkeys[tag].getItems().Count(); item++)
          {
            Console.WriteLine(monkeys[tag].getItems().Count() + " ITEMS HOLDED BY MONKEY " + tag);
            int worry = Inspect(input[i],monkeys[tag].getItems().ElementAt(item));
            int rule = int.Parse(string.Join("", input[i+1].ToCharArray().Where(Char.IsDigit)));
              if (worry%rule==0)
              {
                int dest = int.Parse(string.Join("", input[i+2].ToCharArray().Where(Char.IsDigit)));
                monkeys[dest].addToList(worry);
                monkeys[tag].delFromList(item);
                item--;
              }
              else
              {
                int dest = int.Parse(string.Join("", input[i+3].ToCharArray().Where(Char.IsDigit)));
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

    static void Part2 (string[] input)
    {

    }

    public static void Main (string[] args)
    {
      string[] input = File.ReadAllLines("input.txt");
      Part1(input);
      Part2(input);
    }
  }
}
