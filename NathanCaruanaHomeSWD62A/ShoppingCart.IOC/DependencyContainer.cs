using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ShoppingCart.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            //when are the instances trigerred??
            //as soon as the application starts?
            //as soon as the user makes the first call?
            //as soon as the user makes the second call? and so on and forth..
            //...

            //answer: https://www.tutorialsteacher.com/core/dependency-injection-in-aspnet-core

            /*Singleton: IoC container will create and share a single instance of a service throughout the application's lifetime.
            Transient: The IoC container will create a new instance of the specified service type every time you ask for it.
            Scoped: IoC container will create an instance of the specified service type once per request and will be shared in a single request.
            */

            services.AddDbContext<ShoppingCartDBContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();

            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICategoriesService, CategoriesService>();

            services.AddScoped<IMembersRepository, MembersRepository>();
            services.AddScoped<IMembersService, MembersService>();

   


        }
    }
}
