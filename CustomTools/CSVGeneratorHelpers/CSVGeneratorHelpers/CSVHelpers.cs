using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVGeneratorHelpers
{
    public class CSVHelpers
    {
        private readonly string path;

        public CSVHelpers(string path)
        {
            this.path = path;
        }

        public bool AppendGeneratedColumn(string header, Func<int, string> valueGenerator)
        {
            try
            {
                StreamReader textReader = new StreamReader(path);
                StreamWriter textWriter = new StreamWriter(path.Replace(".csv", "New.csv"));

                CsvParser reader = new CsvParser(textReader, new CsvHelper.Configuration.Configuration() { Delimiter = ",", HasHeaderRecord = false });
                //CsvWriter writer = new CsvWriter(textWriter);

                string buffer = string.Empty;

                // Add new header column
                List<string> headerCols = reader.Read().ToList();
                headerCols.Add(header);
                textWriter.WriteLine(string.Join(",", headerCols));

                // Add Values
                int index = 0;
                string[] fileLine;
                while ((fileLine = reader.Read()) != null)
                {
                    var temp = fileLine.ToList();
                    temp.Add(valueGenerator(index));
                    textWriter.WriteLine(string.Join(",", temp));
                    index++;
                }


                textReader.Close();
                textWriter.Flush();

                textWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }
    }
}
