using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOPractice.JSonDataFormat
{
    public class JsonIODataOperations
    {
        public static string jsonFilePath = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\JSonDataFormat\JsonData.json";

        public static void JsonSerialize()
        {
            List<Student> students = new List<Student>() 
            {
                new Student { FName = "Guru", LName = "Kumbar", Address = "BLR", ZipCode = 123456 },
                new Student { FName = "ABCD", LName = "XYZZZ", Address = "CKD", ZipCode = 102102 }
            };
            
            //Converting object to JSON string format
            string jSonData = JsonConvert.SerializeObject(students);      
            File.WriteAllText(jsonFilePath, jSonData);
            Console.WriteLine("\nJson Serialize competed");
        }

        public static void JsonDeSerialize()
        {
            string json = File.ReadAllText(jsonFilePath);

            //Converting JSON string format to list of objects
            List<Student> list = JsonConvert.DeserializeObject<List<Student>>(json);
            Console.WriteLine("\nJson DeSerialize competed");
            foreach (var st in list)
            {
                Console.WriteLine(st.FName +" "+ st.LName +" "+ st.Address +" "+ st.ZipCode);
            }
        }

        class Student
        {
            public string FName { get; set; }
            public string LName { get; set; }
            public string Address { get; set; }
            public int ZipCode { get; set; }

            public string Tostring()
            {
                return $"{FName} {LName} {Address} {ZipCode}";
            }
        }
    }
}
