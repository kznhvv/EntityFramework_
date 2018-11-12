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
            OneMethod();
            //CustomerAdded();
            //CustomerOrdersAdd();
            //OrdersRemove();

            //FindAndChangeMethod();
            //TumElemanlariListeleme();
            //SomeRowSelectList();
            //WhereMethod();
            using (var nortwind = new NorthwindContext())
            {
                ////c tüm kolonlar için kullanılır...

                var result = from c in nortwind.Customers
                                        group c by c.Country into g
                                         select g;

                var result1 = from c in nortwind.Customers
                              group c by new { c.Country, c.City } into g
                              select new { Sehir=g.Key.City, Ulke=g.Key.Country, Adet=g.Count()};
                foreach (var customer in result)
                {
                    //bu şekilde c.country i getirecek
                    Console.WriteLine(customer.Key);
                }
                foreach (var customer in result1)
                {
                    //bu şekilde c.country i getirecek
                    Console.WriteLine("Ulke:{0} , Sehir:{1} Adet:{2}", customer.Sehir, customer.Ulke, customer.Adet);

                }
            }


            Console.ReadLine();
        }

        private static void WhereMethod()
        {
            using (var nortwind = new NorthwindContext())
            {
                ////c tüm kolonlar için kullanılır...

                List<Customer> result = (from c in nortwind.Customers
                                         //where c.Country=="London" && c.City=="Cowes"
                                         where c.Country == "London" || c.City == "Cowes"
                                         select c).ToList();


                foreach (var customer in result)
                {
                    Console.WriteLine("Contact name:{0}, city:{1}", customer.ContactName, customer.City);
                }
            }
        }

        private static void SomeRowSelectList()
        {
            using (var nortwind = new NorthwindContext())
            {
                ////c tüm kolonlar için kullanılır...

                var result = from c in nortwind.Customers
                             select c.ContactName;
                var result1 = from c in nortwind.Customers
                              select new { c.ContactName, c.Country, c.CompanyName };
                var result2 = from c in nortwind.Customers
                              select new Musteri { Ulke = c.ContactName, Sirket = c.Country, Adi = c.CompanyName };

                foreach (var customer in result)
                {
                    Console.WriteLine(customer);
                }

                foreach (var customer in result1)
                {
                    Console.WriteLine(customer.CompanyName);
                    Console.WriteLine(customer.ContactName);
                    Console.WriteLine(customer.Country);
                }
                foreach (var customer in result2)
                {
                    Console.WriteLine(customer.Adi);
                    Console.WriteLine(customer.Sirket);
                    Console.WriteLine(customer.Ulke);
                }
            }
        }

        private static void TumElemanlariListeleme()
        {
            using (var nortwind = new NorthwindContext())
            {
                ////c tüm kolonlar için kullanılır...
                IQueryable<Customer> result = from c in nortwind.Customers
                                              select c;
                List<Customer> result1 = (from c in nortwind.Customers
                                          select c).ToList();


                foreach (var customer in result)
                {
                    Console.WriteLine(customer.ContactName);
                }
            }
        }

        private static void FindAndChangeMethod()
        {
            using (var nortwind = new NorthwindContext())
            {
                var customer = nortwind.Customers.Find("Engin");
                customer.CompanyName = "BilsemHolding";
                nortwind.SaveChanges();
            }
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
    internal class Musteri 
    {
        public string Ulke { get; set; }

        public string Sirket { get; set; }

        public string Adi { get; set; }
    }
}
