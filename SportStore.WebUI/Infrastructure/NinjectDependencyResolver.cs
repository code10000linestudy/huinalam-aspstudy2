using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using Ninject.Web.Mvc;
using SportStore.Domain.Abstract;
using SportStore.Domain.Concrete;
using SportStore.Domain.Entities;

namespace SportStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParm)
        {
            kernel = kernelParm;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            /*
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product { Name = "Football", Price = 25},
                new Product { Name = "Surf board", Price = 179},
                new Product { Name = "Running shoes", Price = 95}
            });

            // ToConstant를 이용하여 Ninject의 범위를 지정하고 있다.
            // 그 결과 매번 인터페이스 구현 개체의 인스턴스를 새로 생성하는 대신,
            // 항상 동일한 Mock 개체를 사용하여 IProductRepository 인터페이스에 대한 요청을 만족시키게 된다.
            kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            */

            // Debug : ninject 삭제
            //EmailSettings emailSettings = new EmailSettings
            //{
            //    WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            //};

            //kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
            //    .WithConstructorArgument("settings", emailSettings);
            //kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}