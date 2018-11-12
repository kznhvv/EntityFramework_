using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();
            Console.ReadLine();
        }
    }
    public class LoggerFactory :ILoggerFactory
    {
        public ILogger CreateLogger() 
        {
            return new EdLogger();
        }
    }
    public interface ILogger 
    {
        void Log();
    }
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }
   
    public class LoggerFactory:ILoggerFactory
    {
        //business to decide factory
        public ILogger CreatedLogger()
        {
            return new EdLogger();
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        //business to decide factory
        public ILogger CreatedLogger()
        {
            return new LogfNetLogger();
        }
    }
    public class LogfNetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with LogfNetLogger");
        }
    }
    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EdLogger");
        }
    }
    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save() 
        {
            Console.WriteLine("Saved");
            //ILogger logger = new EdLogger(); yerine
            //ILogger logger = new LoggerFactory().CreatedLogger();
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
