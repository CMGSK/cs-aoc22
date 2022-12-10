namespace day7
{
  class Program
  {

    public class Node {

      int size;
      string name;
      List<Tuple<int, string>> files; //Needn't tuple i know
      List<Node> dirs;
      Node? parent;

      public Node (int size, string name, List<Tuple<int, string>> files, List<Node> dirs, Node? parent) //? lets the value be assigned null
      {
        this.size = size;
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
      public string getName ()
      {
        return name; 
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
      public int getSize ()
      {
        return size; 
      }
      public void setSize (int n)
      {
        this.size = n; 
      }

      ////
      public override string ToString()
      {
        string s = $"Size: {this.size}, Name:{this.name}, Files:{this.files.Count}, Dirs:{this.dirs.Count}, Parent:{this.parent?.name}"; 
        if (this.dirs.Any())
        {
        s += "\n";
        foreach (var thingy in this.dirs) s += $"\n{thingy.ToString()}"; 
        }
        return s;
      }
    }


    static Node getRoot (string[] input)
    {
      Node root = new Node(0, "/", new List<Tuple<int, string>>(), new List<Node>(), null);
      Node nodeIn = root;
      for (int i = 1; i < input.Length; i++)
      {
        if (input[i].Contains("dir"))
        {
          Node aux = new Node(0, input[i].Split(" ")[^1], new List<Tuple<int, string>>(), new List<Node>(), nodeIn); //takes this position -omitting 0- from the last
          nodeIn?.insertDir(aux);
        }

        else if (!input[i].Contains("$") && !input[i].Contains("dir"))
        {
          nodeIn?.insertFile(new Tuple<int, string>(int.Parse(input[i].Split(" ")[0]), input[i].Split(" ")[1]));
        }

        else if (input[i].Contains("$ cd .."))
        {
          nodeIn = nodeIn?.getParent() == null ? null : nodeIn.getParent(); 
        }

        else if (input[i].Contains("$ cd") && !input[i].Contains(".."))
        {
          string toDir = input[i].Substring(5);
          foreach (Node to in nodeIn?.getDirs())
          {
            if (to.getName() == toDir) nodeIn = to;
          }
        }
      }
      return root;
    }

    static int setDirSize (Node dir)
    {
      int size=0;
      for (int i=0; i<dir.getFiles().Count(); i++)
      {
        size+=dir.getFiles().ElementAt(i).Item1;
      }
      if (dir.getDirs().Any())
      {
        foreach (var y in dir.getDirs())
        {
          size+=setDirSize(y);
        }
      }
      dir.setSize(size);
      return size;
    }

    static int getDirSize (Node dir)
    {
      int size=dir.getSize();
      if(size > 100000) size = 0;
      if (dir.getDirs().Any())
      {
        foreach (var y in dir.getDirs())
        {
          size += getDirSize(y);
        }
      }
      return size; 
    }

    static int getDelete (Node dir, int toFree, int lowest)
    {
      int size = dir.getSize();
      if (size < toFree) size=0;
      else if (size < lowest && size >= toFree) lowest = size;
      if (dir.getDirs().Any())
      {
        foreach (var y in dir.getDirs())
        {
          if (getDelete(y, toFree, lowest) < lowest && getDelete(y, toFree, lowest) >= toFree) lowest = getDelete(y, toFree, lowest);
        }
      }
      return lowest; 
    }

/////////////////////////////////////////////////////////////////////////

    static int Part1 (string[] input)
    {
      Node root = getRoot(input);
      setDirSize(root);
      // Console.WriteLine(root.ToString());
      return getDirSize(root);
    }

    static int Part2 (string[] input)
    {
      Node root = getRoot(input);
      setDirSize(root);
      int toFree = 30000000 - (70000000 - root.getSize());
      Console.WriteLine($"Space to free{toFree}");
      return getDelete(root, toFree, root.getSize());
    }

    public static void Main (string[] args)
    {
      string[] input = File.ReadAllLines("input.txt");
      Console.WriteLine(Part1(input));
      Console.WriteLine(Part2(input));
    }
  }
}
