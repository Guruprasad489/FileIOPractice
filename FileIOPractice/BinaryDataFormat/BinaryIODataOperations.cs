using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace FileIOPractice.BinaryDataFormat
{
    public class BinaryIODataOperations
    {
        public static string binaryFilePath = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\BinaryDataFormat\BinaryData";

        public static void BinarySerialize()
        {
            Contact contact = new Contact() { FName = "ABC", LName = "XYZ", Address = "BLR", ZipCode = 123456 };
            FileStream stream = new FileStream(binaryFilePath, FileMode.OpenOrCreate);
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(stream, contact);
            Console.WriteLine("Binary Serialize competed");
            stream.Close();
        }
        public static void BinaryDeSerialize()
        {
            FileStream stream = new FileStream(binaryFilePath, FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter();
            Contact contact = (Contact)binary.Deserialize(stream);
            Console.WriteLine("\nBinary DeSerialize competed");
            Console.WriteLine(contact.Tostring());
            stream.Close();
        }

        [Serializable]
        class Contact
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
