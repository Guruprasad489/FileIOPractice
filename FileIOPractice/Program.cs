using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileIOPractice.BinaryDataFormat;
using FileIOPractice.JSonDataFormat;
using FileIOPractice.XMLDataFormat;
using FileIOPractice.CsvDataFormat;
using static FileIOPractice.JSonDataFormat.JsonIODataOperations;

namespace FileIOPractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\Files\Sample.txt";
            List<Student> students = new List<Student>()
            {
                new Student() { FName = "Guru", LName = "Kumbar", Address = "BLR", ZipCode = 123456 },
                new Student() { FName = "ABCD", LName = "XYZZZ", Address = "CKD", ZipCode = 102102 }
            };
            while (true)
            {
                Console.WriteLine("Choose option \n0. Basic operations \n1. Binary \n2. Json \n3. XML \n4. CSV \n5. JsonData From Csv \n6. CsvData From Json");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        ReadLineByLine(path);
                        ReadAtOnce(path);
                        FileCopy(path);
                        FileDelete();
                        ReadDataUsingStreamReader(path);
                        WriteDataUsingStreamReader(path);
                        break;
                    case 1:
                        Console.WriteLine("\nBinary IO Data Operations");
                        BinaryIODataOperations.BinarySerialize();
                        BinaryIODataOperations.BinaryDeSerialize();
                        break;
                    case 2:
                        Console.WriteLine("\nJson IO Data Operations");
                        string jsonFilePath = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\JSonDataFormat\JsonData.json";
                        JsonIODataOperations.JsonSerialize(jsonFilePath, students);
                        JsonIODataOperations.JsonDeSerialize(jsonFilePath);
                        break;
                    case 3:
                        Console.WriteLine("\nXML IO Data Operations");
                        string xmlFilePath = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\XMLDataFormat\XMLData.xml";
                        XMLdataOperations.XMLSerialize(xmlFilePath, students);
                        XMLdataOperations.XMLDeSerialize(xmlFilePath);
                        break;
                    case 4:
                        Console.WriteLine("\nCSV IO Data Operations");
                        string csvFilePath = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\CsvDataFormat\CsvData.csv";
                        CsvDataOperations.CsvSerialize(csvFilePath, students);
                        CsvDataOperations.CsvDeSerialize(csvFilePath);
                        break;
                    case 5:
                        Console.WriteLine("JsonData From Csv");
                        JsonCsvDataOperations.JsonDataFromCsv();
                        break;
                    case 6:
                        Console.WriteLine("CsvData From Json");
                        JsonCsvDataOperations.CsvDataFromJson();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.ReadLine();
            }
        }

        public static bool IsFileExist(string path)
        {
            if (File.Exists(path))
            {
                Console.WriteLine("File exist");
                return true;
            }
            else
            {
                Console.WriteLine("File not exist");
                return false;  
            }
        }

        public static void ReadLineByLine(string path)
        {
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("File not exist");
            }
        }

        public static void ReadAtOnce(string path)
        {
            if (File.Exists(path))
            {
                string line = File.ReadAllText(path);
                    Console.WriteLine(line);
            }
            else
            {
                Console.WriteLine("File not exist");
            }
        }

        public static void FileCopy(string path)
        {
            string destination = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\Files\Copied123.txt";
            if (File.Exists(path))
            {
                File.Copy(path, destination);
                Console.WriteLine("File Copied");
            }
        }

        public static void FileDelete()
        {
            string destination = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\Files\Copied123.txt";
            if (File.Exists(destination))
            {
                File.Delete(destination);
                Console.WriteLine("File deleted");
            }
        }

        public static void ReadDataUsingStreamReader(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                    sr.Close();
                }
            }
        }

        public static void WriteDataUsingStreamReader(string path)
        {
            if (File.Exists(path))
            {
                StreamWriter sw = File.AppendText(path);
                sw.WriteLine("Testing StreaWriter Operations \n.Net is Awesome");
                sw.Close();
                Console.WriteLine(File.ReadAllText(path));
            }
        }


    }
}
