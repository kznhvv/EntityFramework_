using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NortwindEntity.Context;
using NortwindEntity.Entitiess;

namespace NortwindEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            //OneMethod();
            //CustomerAdded();
            //CustomerOrdersAdd();
            //OrdersRemove();

            using (var nortwind = new NorthwindContext())
            {
                var customer = nortwind.Customers.Find("Engin");
                customer.CompanyName = "BilsemHolding";
                nortwind.SaveChanges();
            }

            Console.ReadLine();
        }

        private static void OrdersRemove()
        {
            using (var nortwind = new NorthwindContext())
            {
                Order order = nortwind.Orders.Find(1);
                nortwind.Orders.Remove(order);
                nortwind.SaveChanges();
            }
        }

        private static void CustomerOrdersAdd()
        {
            using (var nortwind = new NorthwindContext())
            {
                var customer = nortwind.Customers.Find("Engin");
                customer.Orders.Add(new Order { OrderID = 1, OrderDate = DateTime.Now, ShipCity = "Ankara", ShipCountry = "Türkiye" });
                nortwind.SaveChanges();
            }
        }

        private static void CustomerAdded()
        {
            using (var nortwind = new NorthwindContext())
            {
                Customer customer = new Customer { CustomerID = "Engin", ContactName = "Engin demiroğ", City = "Ankara", CompanyName = "test.com", Country = "Turkiye" };
                nortwind.Customers.Add(customer);
                nortwind.SaveChanges();
            }
           
        }

        private static void OneMethod()
        {
            using (NorthwindContext nort = new NorthwindContext())
            {
                foreach (var customer in nort.Customers)
                {
                    Console.WriteLine("Customer name {0}", customer.ContactName);
                }
            }
        }
    }
}
