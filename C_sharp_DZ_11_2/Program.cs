using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
/*Считайте информацию из XML-документа, полученного в первом задании с помощью классов
XmlDocument и XmlTextReader и выведите полученную информацию на экран.*/
namespace C_sharp_DZ_11_2
{
    class Program
    {
        static void OutputNode(XmlNode node)
        {
            Console.WriteLine($"Type={node.NodeType}\tName={node.Name}\tValue={node.Value}");

            // Внесем изменения в метод OutputNode(), чтобы 
            // атрибуты выводились наравне с другими типами узлов.
            if (node.Attributes != null)
            {
                foreach (XmlAttribute attr in node.Attributes)
                    Console.WriteLine($"Type={attr.NodeType}\tName={attr.Name}\tValue={attr.Value}");
            }
            if (node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes)
                    OutputNode(child);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                doc.Load("../../../C_sharp_DZ_11_1/bin/Debug/Order1.xml");
                OutputNode(doc.DocumentElement);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }
    }
}
