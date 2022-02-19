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
        public static void JsonSerialize(string path, List<Student> students)
        {
            //Converting object to JSON string format
            string jSonData = JsonConvert.SerializeObject(students);      
            File.WriteAllText(path, jSonData);
            Console.WriteLine("\nJson Serialize completed");
        }
        public static List<Student> JsonDeSerialize(string path)
        {
            string json = File.ReadAllText(path);
            //Converting JSON string format to list of objects
            List<Student> list = JsonConvert.DeserializeObject<List<Student>>(json);
            Console.WriteLine("\nJson DeSerialize completed");
            foreach (var st in list)
            {
                Console.WriteLine(st.Tostring());
            }
            return list;
        }
        public class Student
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
