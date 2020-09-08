using System;
using static System.Console;
using System.Collections.Generic;
using System.Xml;
/*С помощью класса XmlTextWriter напишите приложение, сохраняющее в XML-файл информацию о заказах.
Каждый заказ представляет собой несколько товаров. Информацию, характеризующую заказы и товары
необходимо разработать самостоятельно.*/
namespace C_sharp_DZ_11_1
{
    public class Goods
    {
        public int Article { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public double Cost
        {
            get { return Price * Count; }
            set { }
        }
        public Goods() { }
        public Goods(int article, string name, double price, int count)
        {
            Article = article;
            Name = name;
            Price = price;
            Count = count;
        }
        public void GoodsReport()
        {
            WriteLine($"Артикул: {Article:D4}");
            WriteLine($"Наименование: {Name}");
            WriteLine($"Цена: {Price}");
            WriteLine($"Количество: {Count}");
            WriteLine($"Стоимость: {Cost}\n");
        }
    }
    public class Order
    {
        public List<Goods> List { get; set; }
        public int OrderNumber { get; set; }
        public Order() { }
        public Order(List<Goods> list, int orderNumber)
        {
            List = list;
            OrderNumber = orderNumber;
        }
        public void WriteOrder(string orderFileName)
        {
            XmlTextWriter order = null;
            try
            {
                order = new XmlTextWriter(orderFileName, System.Text.Encoding.Unicode);
                order.Formatting = Formatting.Indented;
                order.WriteStartDocument();
                order.WriteStartElement("Заказ");
                order.WriteStartElement("Номер" + OrderNumber.ToString());
                foreach (Goods goods in List)
                {
                    order.WriteStartElement("Товар");
                    order.WriteAttributeString("Артикул", goods.Article.ToString());
                    order.WriteElementString("Наименование", goods.Name);
                    order.WriteElementString("Цена", goods.Price.ToString());
                    order.WriteElementString("Количество", goods.Count.ToString());
                    order.WriteElementString("Стоимость", goods.Cost.ToString());
                    order.WriteEndElement();
                }
                order.WriteEndElement();
                order.WriteEndElement();
                WriteLine($"\nThe {orderFileName} file is generated!\n");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                if (order != null) order.Close();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Title = "C_sharp_DZ_11_1";
            List<Goods> OrderList1 =new List<Goods>();
            OrderList1.Add(new Goods(123, "Товар1", 12.65, 12));
            OrderList1.Add(new Goods(234, "Товар2", 14.34, 73));
            OrderList1.Add(new Goods(345, "Товар3", 45.98, 39));
            OrderList1.Add(new Goods(456, "Товар4", 78.12, 83));
            Order Order1 = new Order(OrderList1, 1);
            WriteLine($"Заказ номер {Order1.OrderNumber}\n");
            foreach (Goods goods in OrderList1) goods.GoodsReport();
            Order1.WriteOrder("Order1.xml");
            ReadKey();
        }
    }
}
