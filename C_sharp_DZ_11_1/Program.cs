using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.WriteLine($"Артикул: {_article:D4}");
            Console.WriteLine($"Наименование: {_name}");
            Console.WriteLine($"Цена: {_price:C2}");
            Console.WriteLine($"Остаток: {_balance}\n");
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
            Console.WriteLine($"Категория: {_categoryHoushold}");
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
            Console.WriteLine($"Категория: {_categoryFood}");
            base.ProductReport();
        }
    }


    class Program
    {


        static void Main(string[] args)
        {



        }
    }
}
