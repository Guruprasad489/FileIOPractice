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
        public static string binaryFilePath = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\BinaryDataFormat\BinaryData.bin";

        public static void BinarySerialize()
        {
            List<Contact> contacts = new List<Contact>(){
                new Contact() { FName = "ABC", LName = "XYZ", Address = "BLR", ZipCode = 123456 },
                new Contact() { FName = "ABC", LName = "XYZ", Address = "BLR", ZipCode = 123456 }
                };
            FileStream stream = new FileStream(binaryFilePath, FileMode.OpenOrCreate);
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(stream, contacts);
            Console.WriteLine("Binary Serialize competed");
            stream.Close();
        }
        public static void BinaryDeSerialize()
        {
            FileStream stream = new FileStream(binaryFilePath, FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter();
            List<Contact> contact = (List<Contact>)binary.Deserialize(stream);
            Console.WriteLine("\nBinary DeSerialize competed");
            foreach (var ct in contact)
            {
                Console.WriteLine(ct.FName + " " + ct.LName + " " + ct.Address + " " + ct.ZipCode);
            }
            stream.Close();
        }

        [Serializable]
        public class Contact
        {
            public string FName { get; set; }
            public string LName { get; set; }
            public string Address { get; set; }
            public int ZipCode { get; set; }
        }
    }
}
