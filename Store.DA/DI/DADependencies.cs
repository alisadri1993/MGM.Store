using Microsoft.Extensions.DependencyInjection;
using Store.Business.Interfaces;
using Store.DA.Repositories;

namespace Store.DA.DI;
public static class DADependencies
{
    public static void AddDADependency(this IServiceCollection sevice)
    {
        //sevice.AddSingleton<IProductRepository, ProductRepository>();
        sevice.AddSingleton<IProductRepository, DapperProductRepository>();
    }
};
