using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileIOPractice.BinaryDataFormat;
using FileIOPractice.JSonDataFormat;
using FileIOPractice.XMLDataFormat;

namespace FileIOPractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\Files\Sample.txt";
            //ReadLineByLine(path);
            //ReadAtOnce(path);
            //FileCopy(path);
            //FileDelete();
            //ReadDataUsingStreamReader(path);
            //WriteDataUsingStreamReader(path);

            Console.WriteLine("\nBinary IO Data Operations");
            BinaryIODataOperations.BinarySerialize();
            BinaryIODataOperations.BinaryDeSerialize();

            Console.WriteLine("\nJson IO Data Operations");
            JsonIODataOperations.JsonSerialize();
            JsonIODataOperations.JsonDeSerialize();

            Console.WriteLine("\nXML IO Data Operations");
            XMLdataOperations.XMLSerialize();
            
            Console.ReadLine();
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
