using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using SportStore.Domain.Abstract;
using SportStore.Domain.Concrete;

namespace SportStore.WebUI.Modules
{
    public class BindManager
    {
        private static BindManager _instance;

        public static BindManager Instance
        {
            get { return _instance; }
        }

        static BindManager()
        {
            _instance = new BindManager();
        }

        //public static IProductRepository GetProduct()
        //{
        //    return Instance.Products;
        //}

        public static void SetProduct(ref IProductRepository product)
        {
            product = Instance.repository;
        }

        public static void SetProduct(ref IOrderProcessor proc)
        {
            proc = Instance.orderProcessor;
        }

        private IProductRepository repository;
        private IOrderProcessor orderProcessor;

        public BindManager()
        {
            repository = new EFProductRepository();
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };
            orderProcessor = new EmailOrderProcessor(emailSettings);
        }
    }
}