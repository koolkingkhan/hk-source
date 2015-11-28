using System;
using System.IO;
using System.Text;

namespace hk.Common
{
    public class CsvFormatter
    {
        public void CreateFormattedFile(string file)
        {
            var path = Path.GetDirectoryName(file);
            var fileName = string.Concat(Path.GetFileNameWithoutExtension(file), "-formatted", ".csv");
            var outputFile = Path.Combine(path, fileName);
            const int minimumCols = 6;

            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }

            using (var streamWriter = new StreamWriter(outputFile))
            {
                streamWriter.WriteLine("Logfile, Timestamp, Log Level, NID, Class, Output1, Output2");

                using (var reader = new StreamReader(file))
                {
                    var count = 0;
                    string s;
                    while ((s = reader.ReadLine()) != null)
                    {
                        var tokens = s.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                        var newArray = new string[tokens.Length > minimumCols ? tokens.Length : minimumCols];

                        var foundDash = false;
                        var pos = -1;
                        StringBuilder builder = null;
                        for (var i = 0; i < tokens.Length; i++)
                        {
                            if (!foundDash)
                            {
                                var next = i + 1;
                                if (next < tokens.Length && tokens[next].Trim().Equals("-"))
                                {
                                    foundDash = true;
                                    pos = next;
                                    newArray[i] = tokens[i];
                                }
                                else
                                {
                                    newArray[i] = tokens[i];
                                }
                            }
                            else if (i != pos)
                            {
                                if (null == builder)
                                {
                                    builder = new StringBuilder();
                                }
                                builder.AppendFormat("{0} ", tokens[i]);
                            }
                        }
                        if (foundDash)
                        {
                            newArray[pos] = builder != null ? builder.ToString() : string.Empty;
                        }
                        else
                        {
                            var startPos = !newArray[0].Contains("tradeauto-") ? 0 : 1;
                            var tempBuilder = new StringBuilder();

                            for (var i = startPos; i < newArray.Length; i++)
                            {
                                var temp = newArray[i];
                                newArray[i] = string.Empty;
                                tempBuilder.AppendFormat("{0} ", temp);
                            }
                            newArray[minimumCols - 1] = tempBuilder.ToString();
                        }

                        if (!string.IsNullOrEmpty(newArray[1]) && !string.IsNullOrEmpty(newArray[2]))
                        {
                            newArray[1] = string.Concat(newArray[1], ".", newArray[2]);
                            newArray[2] = string.Empty;
                        }

                        var formattedString = string.Join(",", newArray);

                        streamWriter.WriteLine(formattedString);

                        count++;
                    }
                }
            }
        }
    }
}