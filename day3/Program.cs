﻿namespace day3
{
  class Program
  {
    public static void Main (string[] args)
    {
      string[] input = File.ReadAllLines("input.txt");

      //Part 1
      int r = 0;
      foreach (string x in input)
      {
        char item=' ';
        char[] data = x.Substring(x.Length/2).ToCharArray();
        for(int i=0; i<x.Length/2; i++)
        {
          if (x.Substring(0,x.Length/2).Contains(data[i]))
          {
            item = data[i];
            break;
          }
        }
        r += (int)item > 90 ? (int)item - 96 : (int)item - 38; 
      }
      Console.WriteLine(r);

      //Part 2
      int res = 0;
      for (int x=0; x<input.Count()-2; x+=3)
      {
        char item=' ';
        char[] data = input[x].ToCharArray();
        for(int i=0; i<data.Count(); i++)
        {
          if (input[x+1].Contains(data[i]) && input[x+2].Contains(data[i]))
          {
            item = data[i];
            break;
          }
        }
        res += (int)item > 90 ? (int)item - 96 : (int)item - 38; 
      }
      Console.WriteLine(res);
    }
  }
} 
