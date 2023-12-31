﻿using System;
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
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductInventoryService>().As<IProductInventoryService>().InstancePerLifetimeScope();
            builder.RegisterType<CabinStoreService>().As<ICabinStoreService>().InstancePerLifetimeScope();

        }
    }
}
