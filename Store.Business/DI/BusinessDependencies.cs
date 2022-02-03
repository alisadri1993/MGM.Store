using Microsoft.Extensions.DependencyInjection;
using Store.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Business.DI
{
    public static class BusinessDependencies
    {
        public static string toMGMString(this string str)
        {
            return "mgm " + str;
        }

        public static void AddBusinessDependency(this IServiceCollection sevice)
        {
            sevice.AddSingleton<IProductService, ProductService>();
        }
    }
}
