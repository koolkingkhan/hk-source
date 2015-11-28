using System;
using System.Collections.Generic;
using System.IO;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
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
            args = new[]
            {
                @"K:\My Documents\_x",
                ".bak,.log,.settings,.exe,.zip,.wmv,.doc,.pdf,.cs,.dll,.sln,.csproj,.resx,.bak,.part,.msi,.rar,.pdb,.resources,.txt,.xls",
                "run"
            };
            if (args.Length < 2)
            {
                return;
            }

            var p = args[0];
            var f = args[1];


            if (!Directory.Exists(p))
            {
                Console.Write("Not found - {0}", p);
                return;
            }
            Console.Write("Start - {0}, Filter - {1}, Continue ?", p, f);
            Console.ReadLine();
            var items = f.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
            IDictionary<string, string> di = new SortedDictionary<string, string>();
            foreach (var a in items)
            {
                if (!di.ContainsKey(a))
                {
                    di.Add(a, a);
                }
            }
            Scan(p, di, args.Length >= 3);
        }

        private static void Scan(string p, IDictionary<string, string> ext, bool auto)
        {
            var r = new Random(10);

            var files = Directory.EnumerateFileSystemEntries(p, "*.*", SearchOption.AllDirectories);
            var x = 0;
            var y = 0;
            foreach (var i in files)
            {
                x++;
                y++;
                if (x%100 == 0)
                {
                    Console.WriteLine(y);
                    x = 0;
                }
                var e = Path.GetExtension(i);
                if (ext.ContainsKey(e) && File.Exists(i) && new FileInfo(i).Length != 0)
                {
                    //   System.Console.WriteLine(i);

                    //   System.Console.Write(String.Format("Change {0}", i));
                    var cnt = auto;
                    if (!auto)
                    {
                        var k = Console.ReadKey(false);
                        if (k.Key == ConsoleKey.Y)
                        {
                            cnt = true;
                        }
                    }
                    if (cnt)
                    {
                        try
                        {
                            var ff = File.Create(i, 1, FileOptions.None);
                            ff.SetLength(0L);
                            ff.Close();
                            var v = r.Next(10);
                            var ct = File.GetCreationTime(i);
                            if (File.GetLastWriteTime(i) < File.GetCreationTime(i))
                            {
                                ct = File.GetLastWriteTime(i);
                            }
                            if (v <= 5)
                            {
                                var newFile = string.Format("~{0}.tmp", Path.GetFileName(i));
                                var newPath = string.Format("{0}\\{1}", Path.GetDirectoryName(i), newFile);


                                if (!string.IsNullOrEmpty(newFile))
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
                            Console.WriteLine(" ** In Use {0} **", i);
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}