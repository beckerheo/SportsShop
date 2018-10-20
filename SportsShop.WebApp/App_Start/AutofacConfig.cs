namespace SportsShop.WebApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Moq;
    using SportsShop.Domain.Abstract;
    using SportsShop.Domain.Concrete;
    using SportsShop.Domain.Entities;
    using SportsShop.Domain.Mock;
    using SportsShop.WebApp.Controllers;
    using SportsShop.WebApp.Infrastructure.Abstract;
    using SportsShop.WebApp.Infrastructure.Concrete;

    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            #region Mock Usage
            /*
             * using mock libaray directly
             */
            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product{Name="Football",Price=25 },
            //    new Product{Name="Baseball",Price=15 },
            //    new Product{Name="Running Shoes", Price=199 }
            //});

            //builder.RegisterInstance<IProductsRepository>(mock.Object);

            /*
             * mock class
             * builder.RegisterInstance<IProductsRepository>(new MockProductsRepository());
            */
            #endregion
            
            builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies());

            builder.RegisterInstance<IProductsRepository>(new EFProductsRepository()).PropertiesAutowired();
            builder.RegisterInstance<IOrderProcessor>(new EmailOrderProcessor(new EmailSettings()));
            builder.RegisterInstance<IAuthProvider>(new FormsAuthProvider()).PropertiesAutowired();

            builder.RegisterType<EFDbContext>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}