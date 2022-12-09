namespace day7
{
  class Program
  {

    public class Node {

      string name;
      List<Tuple<int, string>> files;
      List<Node> dirs;
      Node? parent;

      public Node (string name, List<Tuple<int, string>> files, List<Node> dirs, Node? parent) //? lets the value be assigned null
      {
        this.name = name;
        this.files = files;
        this.dirs = dirs;
        this.parent = parent ?? null; 
      }

      public void insertDir (Node n)
      {
        this.dirs.Add(n);
      }
      public void insertFile (Tuple<int, string> f)
      {
        this.files.Add(f);
      }
      public Node? getParent ()
      {
        return parent; 
      }
      public List<Node> getDirs ()
      {
        return dirs; 
      }
      public List<Tuple<int, string>> getFiles ()
      {
        return files; 
      }
      ////
      public override string ToString()
      {
        string s = $"Name:{this.name}, Files:{this.files.Count}, Dirs:{this.dirs.Count}, Parent:{this.parent?.name}"; 
        if (this.dirs.Any())
        {
          s += "\n";
          foreach (var thingy in this.dirs) s += $"   {thingy.ToString()}"; 
        }
        return s;
      }
    }

    static int Part1 (string[] input)
    {
      Node root = getRoot(input);
      int res=0;
      for (int i=0; i<root.getDirs().Count(); i++){
        res+=getDirSize(root.getDirs());
      }
      return 0;
    }

    static int Part2 (string[] input)
    {

      return 0;
    }

    static Node getRoot (string[] input)
    {
      Node root = new Node("/", new List<Tuple<int, string>>(), new List<Node>(), null);
      Node nodeIn = root;
      for (int i = 1; i < input.Length; i++)
      {
        if (input[i].Contains("dir"))
        {
          Node aux = new Node(input[i].Split(" ")[^1], new List<Tuple<int, string>>(), new List<Node>(), nodeIn); //takes this position -omitting 0- from the last
          nodeIn.insertDir(aux);
          nodeIn = aux;
        }

        else if (!input[i].Contains("$") && !input[i].Contains("dir"))
        {
          nodeIn.insertFile(new Tuple<int, string>(int.Parse(input[i].Split(" ")[0]), input[i].Split(" ")[1]));
        }

        else if (input[i].Contains("$ cd"))
        {
          nodeIn = nodeIn.getParent();
        }
      }
      return root;
    }

    static int getDirSize (Node dir)
    {
      int size=0;
      for (int i=0; i<dir.getFiles().Count(); i++)
      {
        size+=dir.getFiles().ElementAt(i).Item1;
      }
      return size > 100000 ? 0 : size;
    }

    public static void Main (string[] args)
    {
      string[] input = File.ReadAllLines("input.txt");
      Console.WriteLine(Part1(input));
      Console.WriteLine(Part2(input));
    }
  }
}
