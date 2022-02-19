using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileIOPractice.CsvDataFormat;
using FileIOPractice.JSonDataFormat;
using static FileIOPractice.JSonDataFormat.JsonIODataOperations;

namespace FileIOPractice
{
    public class JsonCsvDataOperations
    {
        public static string csvFilePath = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\CsvDataFormat\CsvData.csv";
        public static string jsonFilePath = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\JSonDataFormat\JsonData.json";

        public static void JsonDataFromCsv()
        {
            string jsonFromCsv = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\JsonDataFromCsv.json";
            List<Student> students = CsvDataOperations.CsvDeSerialize(csvFilePath);
            JsonIODataOperations.JsonSerialize(jsonFromCsv, students);
        }
        public static void CsvDataFromJson()
        {
            string csvFromJson = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\CsvDataFromJson.csv";
            List<Student> students = JsonIODataOperations.JsonDeSerialize(jsonFilePath);
            CsvDataOperations.CsvSerialize(csvFromJson, students);
        }
    }
}
