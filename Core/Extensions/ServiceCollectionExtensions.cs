using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    //Tek method'da birden fazla module eklemek için IServiceCollection'u genişlettik kendi methodumuzu yazdık.
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            //Verdiğimiz modulleri dönüp tek tek hepsini yüklüyoruz
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            //ve en son hepsini create ediyoruz. 
            return ServiceTool.Create(serviceCollection);
        }
    }
}
