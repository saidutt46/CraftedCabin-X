using System;
using Autofac;
using Repository.Implementation;
using Repository.Interfaces;
using Services.Implementation;
using Services.Interfaces;

namespace Services
{
	public class ServicesAutofacModule : Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductCategoryService>().As<IProductCategoryService>().InstancePerLifetimeScope();
        }
    }
}

