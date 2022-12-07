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

      public void setSize (int n){
        this.size=n;
      }
      public int getSize()
      {
        return size;
      }
      public bool getIsDir()
      {
        return isDir;
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

    static long Part1 (string[] input)
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
        else if (input[x].Contains("$ ls")) //ls indicates where were creating files 
        {
          x++;
          while (!(input[x].Contains("$")) && x+1<input.Count()) // && to avoid out of bounds on last items
          {
            if(!(input[x].Contains("dir"))) // we ignore dir since we create them with cd commands, therefore only files are created after ls command
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
      // Sanity check
      foreach (var t in Root) t.printNode();
      return sizeCalc(Root);
    }

    static int Part2 (string[] input)
    {

      return 0;
    }

    static long sizeCalc (List<Node> Root)
    {
      for (int i=Root.Count()-1; i>=0; i--)
      {
          Console.WriteLine("here");
        int size=0;
        string last = Root.ElementAt(i).getParent();
        bool refIndex = false;
        while (!Root.ElementAt(i).getIsDir() && Root.ElementAt(i).getParent() == last)
        {
          size+=Root.ElementAt(i).getSize();
          last = Root.ElementAt(i).getParent();
          i--;
          refIndex=true;
        }
        if (refIndex) i++;
        for(int j=0; j<Root.Count(); j++)
        {
          if (Root.ElementAt(j).getName() == last) Root.ElementAt(j).setSize(size);
        }
      }
      //now we sum the folders properly
      long result=0;
      for (int i=0; i<Root.Count(); i++)
      {
        if (Root.ElementAt(i).getIsDir() && Root.ElementAt(i).getSize() < 100000)
        {
          result += Root.ElementAt(i).getSize();
        }
      }
      return result;
    }

    public static void Main (string[] args)
    {
      string[] input = File.ReadAllLines("input.txt");
      
      Console.WriteLine(Part1(input));
      Console.WriteLine(Part2(input));
    }
  }
}
