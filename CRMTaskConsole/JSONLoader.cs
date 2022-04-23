using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTaskConsole
{
    public static class JSONLoader
    {
        public static List<T> LoadFromFile<T>(string file) where T: class, new()
        {
            var line = System.IO.File.ReadAllLines(file).ToList();
            List<T> output = new List<T>();
            T entry = new T();
            var cols = entry.GetType().GetProperties();

            if(line.Count < 2)
            {
                throw new IndexOutOfRangeException("File is empty.");
            }


            var headers = line[0].Split(',');

            line.RemoveAt(0);

            foreach(var row in line)
            {
                entry = new T();

                var vals = row.Split(',');  

                for(var i = 0; i < headers.Length; i++)
                {
                    foreach(var col in cols)
                    {
                        if(col.Name == headers[i])
                        {
                            col.SetValue(entry, Convert.ChangeType(vals[i],col.PropertyType));
                        }
                    }
                }

                output.Add(entry);
            }

            return output;  
        }

        public static void SaveToFile<T>(List<T> info, string file) where T: class, new()
        {
            List<string> lines = new List<string>();
            StringBuilder line = new StringBuilder();   
            if(info == null || info.Count == 0)
            {
                throw new ArgumentException("info", "Need to add info parameter");
            }

            var column = info[0].GetType().GetProperties();


            foreach (var col in column)
            {
                line.Append(col.Name);
                line.Append(",");
            }

            lines.Add(line.ToString().Substring(0,line.Length-1));


            foreach(var row in info)
            {
                line = new StringBuilder();

                foreach(var col in column)
                {
                    line.Append(col.GetValue(row));
                    line.Append(",");
                }
                lines.Add(line.ToString().Substring(0,line.Length-1));

            }
            System.IO.File.WriteAllText(file, lines.ToString());
        }



        
    }
}
