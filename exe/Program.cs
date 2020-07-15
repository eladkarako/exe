using System;
using System.Diagnostics;

namespace exe{
  class Program{
    public static void Main(string[] args){
      Process process;
      if(args.Length == 0) Environment.Exit(111);
      
      process = new Process();
      process.StartInfo.UseShellExecute                 = true;
      process.StartInfo.CreateNoWindow                  = false;
      process.StartInfo.WindowStyle                     = ProcessWindowStyle.Maximized;
      process.StartInfo.FileName                        = args[0];
      if(args.Length > 1)  process.StartInfo.Arguments  = args[1];
      if(args.Length > 2)  process.StartInfo.Verb       = args[2];
      process.Start();

      Environment.Exit(0);
    }
  }
}