using System;
using static System.Console;
using System.Xml;
/*Считайте информацию из XML-документа, полученного в первом задании с помощью классов
XmlDocument и XmlTextReader и выведите полученную информацию на экран.*/
namespace C_sharp_DZ_11_2
{
    class Program
    {
        static void OutputNode(XmlNode node)
        {
            WriteLine($"Type={node.NodeType}\tName={node.Name}\tValue={node.Value}");
            if (node.Attributes != null)
            {
                foreach (XmlAttribute attr in node.Attributes) 
                    WriteLine($"Type={attr.NodeType}\tName={attr.Name}\tValue={attr.Value}");
            }
            if (node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes)
                    OutputNode(child);
            }
        }
        static void Main(string[] args)
        {
            Title = "C_sharp_DZ_11_2";
            WriteLine("_________________Считывание с помощью класса XmlDocument_____________________\n");
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("../../../C_sharp_DZ_11_1/bin/Debug/Order1.xml");
                OutputNode(doc.DocumentElement);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            WriteLine("\n_________________Считывание с помощью класса XmlTextReader_____________________\n");
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader("../../../C_sharp_DZ_11_1/bin/Debug/Order1.xml");
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.Read())
                {
                    WriteLine($"Type={reader.NodeType}\t\tName={reader.Name}\t\tValue={reader.Value}");
                    if (reader.AttributeCount > 0)
                    {
                        while (reader.MoveToNextAttribute())
                        {
                            WriteLine($"Type={reader.NodeType}\tName={reader.Name}\tValue={reader.Value}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            ReadKey();
        }
    }
}
