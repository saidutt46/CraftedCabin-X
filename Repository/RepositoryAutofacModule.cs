using System;
using Autofac;
using Repository.Implementation;
using Repository.Interfaces;

namespace Repository
{
	public class RepositoryAutofacModule : Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductCategoryRepository>().As<IProductCategoryRepository>().InstancePerLifetimeScope();
        }
    }
}