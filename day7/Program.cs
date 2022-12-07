namespace day7
{
  class Program
  {
    
    public class Node
    {
      bool isDir;
      int size;
      string name;
      string parent;

      public Node(bool isDir, int size, string name, string parent)
      {
        this.isDir = isDir;
        this.size = size;
        this.name = name;
        this.parent = parent;
      }

      public string getName()
      {
        return name;
      }
      public string getParent()
      {
        return parent;
      }
      public void printNode()
      {
        Console.WriteLine("{0} {1} {2} {3}", isDir, size, name, parent);
      }
    }

    static int Part1 (string[] input)
    {
      List<Node> Root = new List<Node>();
      Root.Add(new Node(true, 0, "/", "//"));
      string LastDir = "/";
      Node LastNode = Root.Last();
      for (int x=0; x<input.Count(); x++) //parse all instructions
      {
        if (input[x].Contains("$ cd")) // checks if its a cd command
        {
          if (input[x] == "$ cd /") continue; //for cd command / do nothing
          else if (!(input[x].Contains(".."))) //for cd command with name, create a dir node
          {
            Root.Add(new Node (true, 0, input[x].Substring(5), LastDir));
            LastDir = input[x].Substring(5);
            LastNode = Root.Last();
          }
          else //for cd command with .. set last dir to its last node parent and last node to its last node parent
          {
            LastDir = LastNode.getParent();
            for (int i=0; i<Root.Count(); i++)
            {
              if (Root.ElementAt(i).getName() == LastNode.getParent())
              {
                LastNode=Root.ElementAt(i);
                break;
              }
            }
          }
        }
        else if (input[x].Contains("$ ls"))
        {
          x++;
          while (!(input[x].Contains("$")) && x+1<input.Count())
          {
            if(!(input[x].Contains("dir")))
            {
              Root.Add(new Node(false, 
                    int.Parse(input[x].Substring(0, input[x].IndexOf(" "))), 
                    input[x].Substring(input[x].IndexOf(" ")),
                    LastDir));
            }
            x++;
          }
        }
      }
      foreach (var t in Root) t.printNode();
      return 0;
    }

    static int Part2 (string[] input)
    {

      return 0;
    }

    static int sizeCalc (List<Node> Root)
    {



      return 0;
    }

    public static void Main (string[] args)
    {
      string[] input = File.ReadAllLines("input.txt");
      
      Console.WriteLine(Part1(input));
      Console.WriteLine(Part2(input));
    }
  }
}
