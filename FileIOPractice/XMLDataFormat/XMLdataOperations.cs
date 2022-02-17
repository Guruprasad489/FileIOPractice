using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileIOPractice.XMLDataFormat
{
    public class XMLdataOperations
    {
        public static string XmlFilePath = @"C:\Users\Guruprasad\source\repos\FileIOPractice\FileIOPractice\XMLDataFormat\XMLData.XML";

        public static void XMLSerialize()
        {
            XmlSerializer ser = new XmlSerializer(typeof(OrderForm));
            FileStream stream = new FileStream(XmlFilePath, FileMode.Create);
            OrderForm orderForm = new OrderForm();
            DateTime dateTime = new DateTime(2015, 12, 31);
            orderForm.OrderDate = dateTime;
            ser.Serialize(stream, orderForm);
            Console.WriteLine("XML Serialize competed");
            stream.Close();
        }

        public static void XMLDeSerialize()
        {
            string xml = File.ReadAllText(XmlFilePath);


            Console.WriteLine("XML DeSerialize competed");
        }
    }

    public class OrderForm
    {
        public DateTime OrderDate; 
    }
}
