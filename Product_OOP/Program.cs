using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_OOP
{
   public enum ProducctType
    {
        Food = 1, Beverages, Canned
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product
            {
                Name = "P1",
                PType = ProducctType.Beverages,
                BulkPrice = 10,
                UnitPrice = 13,
                BulkQty = 5,
                Id = 1

            };
            var c = new ProductCal();
             Console.WriteLine($"Payable : {c.PayableAmount(product, 15)}");
            Console.WriteLine($"Payable Vat: {c.PayableVat(product, 15)}"); 
            Console.ReadKey();
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int UnitPrice { get; set; }
        public int BulkQty { get; set; }
        public int BulkPrice { get; set; }
        public ProducctType PType { get; set; }
    }
    public class ProductCal
    {
        public double PayableAmount(Product product, int orderQty)
        {
            if (orderQty > product.BulkQty)
                return orderQty * product.BulkPrice;
            else
                return orderQty * product.UnitPrice;
        }
        public double PayableVat(Product product, int orderQty)
        {
            double totalPrice = 0.0;
            double vatAmount = 0.0;
            if (orderQty > product.BulkQty)
                totalPrice = orderQty * product.BulkPrice;
            else
                totalPrice = orderQty * product.UnitPrice;
            switch (product.PType)
            {
                case ProducctType.Beverages:
                    vatAmount = totalPrice * (4.5 / 100);
                    break;
                case ProducctType.Food:
                    vatAmount = totalPrice * (1 / (double)100);
                    break;
                case ProducctType.Canned:
                    vatAmount = totalPrice * (7.00 / 100);
                    break;

            }
            return vatAmount;
        }
    }
}
