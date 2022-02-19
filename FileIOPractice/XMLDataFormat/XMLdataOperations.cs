using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static FileIOPractice.JSonDataFormat.JsonIODataOperations;

namespace FileIOPractice.XMLDataFormat
{
    public class XMLdataOperations
    {
        public static void XMLSerialize(string path, List<Student> students)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Student>));
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
            xml.Serialize(stream, students);
            Console.WriteLine("\nXML Serialize completed");
            stream.Close();
        }
        public static List<Student> XMLDeSerialize(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Student>));
            FileStream stream = new FileStream(path,FileMode.Open);
            List<Student> st =(List<Student>)xml.Deserialize(stream);
            Console.WriteLine("\nXML DeSerialize completed");
            foreach (Student pn in st)
            {
                Console.WriteLine(pn.Tostring());
            }
            stream.Close();
            return st;
        }
    }
}
