using System;
using System.IO;
using System.Text;

namespace hk.Core
{
    public class CsvFormatter
    {
        public void CreateFormattedFile(string file)
        {
            string path = Path.GetDirectoryName(file);
            string fileName = String.Concat(Path.GetFileNameWithoutExtension(file),"-formatted", ".csv");
            string outputFile = Path.Combine(path, fileName);
            const int minimumCols = 6;
            
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }

            using (StreamWriter streamWriter = new StreamWriter(outputFile))
            {
                streamWriter.WriteLine("Logfile, Timestamp, Log Level, NID, Class, Output1, Output2");

                using (StreamReader reader = new StreamReader(file))
                {
                    int count = 0;
                    String s;
                    while ((s = reader.ReadLine()) != null)
                    {
                        string[] tokens = s.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        string[] newArray = new string[tokens.Length > minimumCols? tokens.Length : minimumCols];

                        bool foundDash = false;
                        int pos = -1;
                        StringBuilder builder = null;
                        for (int i = 0; i < tokens.Length; i++)
                        {
                            if (!foundDash)
                            {
                                int next = i + 1;
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
                            int startPos = !newArray[0].Contains("tradeauto-") ? 0 : 1;
                            StringBuilder tempBuilder = new StringBuilder();
                            
                            for (int i = startPos; i < newArray.Length; i++)
                            {
                                string temp = newArray[i];
                                newArray[i] = string.Empty;
                                tempBuilder.AppendFormat("{0} ", temp);
                            }
                            newArray[minimumCols - 1] = tempBuilder.ToString();
                        }

                        if (!string.IsNullOrEmpty(newArray[1]) && !string.IsNullOrEmpty(newArray[2]))
                        {
                            newArray[1] = String.Concat(newArray[1], ".", newArray[2]);
                            newArray[2] = string.Empty;
                        }

                        string formattedString = String.Join(",", newArray);

                        streamWriter.WriteLine(formattedString);

                        count++;
                    }
                }
            }
        }
    }
}
