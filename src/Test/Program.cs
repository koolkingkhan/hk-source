using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
/*
Remove the next line 'args' if you want to specifiy command lines via DOS
Otherwise you just have to change [0] for your path, and delete [2] if you don't want just DIRECTORIES to be amended....

Also >=3 command lines args means run in AUTO MODE (NO PAUSING)
/*

// Usage :
// [0] = path you want to scan
// [1] = file types you want to change
// [2] = any non null -> Means only change creation date/modified date of directories and not files.
*/
            args = new string[] { @"K:\My Documents\_x", ".bak,.log,.settings,.exe,.zip,.wmv,.doc,.pdf,.cs,.dll,.sln,.csproj,.resx,.bak,.part,.msi,.rar,.pdb,.resources,.txt,.xls", "run" };
            if (args.Length < 2)
            {
                return;
            }

            var p=args[0];
            var f=args[1];
            
          
            if (!Directory.Exists(p))
            {
                System.Console.Write(String.Format("Not found - {0}",p));
                return;
            }
            System.Console.Write(String.Format("Start - {0}, Filter - {1}, Continue ?",p,f));
            System.Console.ReadLine();
            string[] items=f.Split(new String[] {"," },StringSplitOptions.RemoveEmptyEntries);
            IDictionary<string, string> di = new SortedDictionary<string, string>();
            foreach (string a in items)
            {
                if (!di.ContainsKey(a))
                {
                    di.Add(a, a);
                }
                
            }
            Scan(p, di,args.Length>=3);
            
                
        }

        private static void Scan(string p, IDictionary<string,string> ext,bool auto)
        {
            Random r = new Random(10);
            
           var files = Directory.EnumerateFileSystemEntries(p, "*.*", SearchOption.AllDirectories);
           int x = 0;
            int y=0;
            foreach (var i in files)
            {
                x++;
                y++;
                if (x % 100 == 0)
                {
                    System.Console.WriteLine(y);
                    x = 0;
                }
                var e=Path.GetExtension(i);
                if (ext.ContainsKey(e) && File.Exists(i) && new FileInfo(i).Length != 0)
                {
                 //   System.Console.WriteLine(i);

                 //   System.Console.Write(String.Format("Change {0}", i));
                    bool cnt = auto;
                    if (!auto)
                    {
                        var k = System.Console.ReadKey(false);
                        if (k.Key == ConsoleKey.Y)
                        {
                            cnt = true;
                        }
                    }
                    if (cnt)
                    {
                        try
                        {
                            FileStream ff = File.Create(i, 1, FileOptions.None);
                            ff.SetLength(0L);
                            ff.Close();
                            int v = r.Next(10);
                            var ct = File.GetCreationTime(i);
                            if (File.GetLastWriteTime(i) < File.GetCreationTime(i))
                            {
                                ct = File.GetLastWriteTime(i);
                            }
                            if (v <= 5)
                            {

                                string newFile = String.Format("~{0}.tmp", Path.GetFileName(i));
                                string newPath = String.Format("{0}\\{1}", Path.GetDirectoryName(i), newFile);


                                if (!String.IsNullOrEmpty(newFile))
                                {

                                    File.Move(i, newPath);
                                    File.SetLastWriteTime(newPath, ct);
                                }
                            }
                            else
                            {
                                File.SetLastWriteTime(i, ct);
                            }
                        }
                        catch (Exception _e)
                        {
                            System.Console.WriteLine(String.Format(" ** In Use {0} **", i));
                        }
                    }
                }
                else
                {
                 //   System.Console.WriteLine(String.Format(" - Skipping {0} ", i));
                }
            }
            System.Console.ReadKey();
        }
    }
}
