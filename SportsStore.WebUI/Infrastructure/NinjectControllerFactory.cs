

namespace SportsStore.WebUI.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Moq;
    using Ninject;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Concrete;
    using SportsStore.Domain.Entities;

    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernal;

        public NinjectControllerFactory()
        {
            this.ninjectKernal = new StandardKernel();
            AddBindings();

        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)this.ninjectKernal.Get(controllerType);

        }

        private void AddBindings()
        {
            // Mock implementation of the IProductRepository Interface
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //        {
            //            new Product { Name = "Football", Price = 25 },
            //            new Product { Name = "Surf board", Price = 179 },
            //            new Product { Name = "Running shoes", Price = 95 }
            //        }.AsQueryable());

            //ninjectKernal.Bind<IProductRepository>().ToConstant(mock.Object);
            ninjectKernal.Bind<IProductRepository>().To<NHProductRepository>();



        }

    }
}