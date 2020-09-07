using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
/*С помощью класса XmlTextWriter напишите приложение, сохраняющее в XML-файл информацию о заказах.
Каждый заказ представляет собой несколько товаров. Информацию, характеризующую заказы и товары
необходимо разработать самостоятельно.
Считайте информацию из XML-документа, полученного в первом задании с помощью классов XmlDocument
и XmlTextReader и выведите полученную информацию на экран.*/
namespace C_sharp_DZ_11_1
{
    public class Food        //Товары
    {
        int Article { get; set; }
        string Name { get; set; }
        public int Balance { get; set; }
        public Food() { }
        public Food(int article, string name, int balance)
        {
            Article = article;
            Name = name;
            Balance = balance;
        }
        public void ProductReport()
        {
            WriteLine($"Артикул: {Article:D4}");
            WriteLine($"Наименование: {Name}");
            WriteLine($"Остаток: {Balance}\n");
        }
    }
    
    


    class Program
    {


        static void Main(string[] args)
        {
            Title = "C_sharp_DZ_11_1";
            Food[] Foods = {
                new Food(001,"Хлеб", 3),
                new Food(002,"Масло", 12),
                new Food(003,"Молоко", 4),
                new Food (004, "Яблоко", 8)
            };


            
            XmlTextWriter writer = null;

            try
            {
                writer = new XmlTextWriter("foods.xml", System.Text.Encoding.Unicode);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();


                writer.WriteStartElement("Cars");
                writer.WriteStartElement("Car");

                writer.WriteElementString("Manufactured", "La Hispano Suiza de Automovils");
                writer.WriteElementString("Model", "Alfonso");
                writer.WriteElementString("Year", "1912");

                writer.WriteEndElement();
                writer.WriteEndElement();

               


                

                WriteLine("The foods.xml file is generated!");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                if (writer != null) writer.Close();
            }


            ReadKey();
        }
    }
}
