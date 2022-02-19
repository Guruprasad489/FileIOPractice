using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FileIOPractice.JSonDataFormat.JsonIODataOperations;

namespace FileIOPractice.CsvDataFormat
{
    public class CsvDataOperations
    {
        public static void CsvSerialize(string csvFilePath, List<Student> students)
        {
            StreamWriter sw = new StreamWriter(csvFilePath);
            CsvWriter cw = new CsvWriter(sw,CultureInfo.InvariantCulture);
            cw.WriteRecords<Student>(students);
            Console.WriteLine("\nCsv Serialize completed");
            sw.Flush();
            sw.Close();
        }
        public static List<Student> CsvDeSerialize(string csvFilePath)
        {
            StreamReader sr = new StreamReader(csvFilePath);
            CsvReader cr = new CsvReader(sr,CultureInfo.InvariantCulture);
            List<Student> result = cr.GetRecords<Student>().ToList();
            Console.WriteLine("\nCSV DeSerialize completed");
            foreach (Student m in result)
            {
                Console.WriteLine(m.Tostring());
            }
            sr.Close();
            return result;
        }
    }
}
