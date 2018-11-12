using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager=CustomerManager.CreateAsSingleton();
            customerManager.Save();

        }
    }
    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();

        //dış erişimi engellemek için bu şekilde tanımlıyoruz.
        private CustomerManager() 
        {
        }
        public static CustomerManager CreateAsSingleton() 
        {
            //lock aynı anda birden fazla üretilmesini engeller.
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;

            //kısa yazılımı
            //return _customerManager ??(_customerManager=new CustomerManager());
        }
        //static diye tanımlarsak yukarıda çağıramıyoruz.
        public void Save()
        {
            Console.WriteLine("saved");
        }
    }
}
