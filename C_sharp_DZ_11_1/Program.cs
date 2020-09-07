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
    public class Product        //Товары
    {
        int _article;
        string _name;
        double _price;
        public int _balance { get; set; }
        public Product() { }
        public Product(int _article, string _name, double _price, int _balance)
        {
            this._article = _article;
            this._name = _name;
            this._price = _price;
            this._balance = _balance;
        }
        public virtual void ProductReport()
        {
            WriteLine($"Артикул: {_article:D4}");
            WriteLine($"Наименование: {_name}");
            WriteLine($"Цена: {_price:C2}");
            WriteLine($"Остаток: {_balance}\n");
        }
    }
    class HouseholdChemicals : Product      //Бытовая химия
    {
        string _categoryHoushold;
        public HouseholdChemicals(int _article, string _name, double _price, int _balance, string _categoryHoushold = "Бытовая химия")
            : base(_article, _name, _price, _balance)
        {
            this._categoryHoushold = _categoryHoushold;
        }
        public override void ProductReport()
        {
            WriteLine($"Категория: {_categoryHoushold}");
            base.ProductReport();
        }
    }
    class Food : Product        //Продукты питания
    {
        string _categoryFood;
        public Food(int _article, string _name, double _price, int _balance, string _categoryFood = "Продукты питания")
            : base(_article, _name, _price, _balance)
        {
            this._categoryFood = _categoryFood;
        }
        public override void ProductReport()
        {
            WriteLine($"Категория: {_categoryFood}");
            base.ProductReport();
        }
    }


    class Program
    {


        static void Main(string[] args)
        {

            Product[] HousholdTest = {
                new HouseholdChemicals(001,"Порошок", 38.66, 1457),
                new HouseholdChemicals(002,"Зубная паста", 73.26, 2357),
                new HouseholdChemicals(003,"Мыло", 18.28, 4330)
            };
            Product[] FoodTest = {
                new Food(001,"Хлеб", 18.34, 5347),
                new Food(002,"Масло", 52.61, 3712),
                new Food(003,"Молоко", 25.28, 6743),
                new Food (004, "Яблоко", 35.92, 9847)
            };



            XmlTextWriter writer = null;

            try
            {
                writer = new XmlTextWriter("Cars.xml", System.Text.Encoding.Unicode);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Cars");
                writer.WriteStartElement("Car");
                writer.WriteAttributeString("Image", "MyCar.jpeg");
                writer.WriteElementString("Manufactured", "La Hispano Suiza de Automovils");
                writer.WriteElementString("Model", "Alfonso");
                writer.WriteElementString("Year", "1912");
                writer.WriteElementString("Color", "Black");
                writer.WriteElementString("Speed", "130");
                writer.WriteEndElement();
                writer.WriteEndElement();

                WriteLine("The Cars.xml file is generated!");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }



        }
    }
}
