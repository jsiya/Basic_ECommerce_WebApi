﻿using ECommerce.Application.Repositories;
using ECommerce.Persistence.DbContexts;
using ECommerce.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Persistence;

public static class RegisterServices
{
    public static void AddPersistenceRegister(this IServiceCollection services)
    {
        services.AddDbContext<ECommerceDbContext>(options =>
        {
            ConfigurationBuilder configurationBuilder = new();
            var builder = configurationBuilder.AddJsonFile("appsettings.json").Build();

            options.UseLazyLoadingProxies()
                   .UseSqlServer(builder.GetConnectionString("default"));
        });


        // Register all Repository in Persistence

        // All Read Repository
        services.AddScoped<IReadOrderRepository, ReadOrderRepository>();
        services.AddScoped<IReadCustomerRepository, ReadCustomerRepository>();
        services.AddScoped<IReadProductRepository, ReadProductRepository>();
        services.AddScoped<IReadCategoryRepository, ReadCategoryRepository>();

        // All Write Repository
        services.AddScoped<IWriteOrderRepository, WriteOrderRepository>();
        services.AddScoped<IWriteCustomerRepository, WriteCustomerRepository>();
        services.AddScoped<IWriteProductRepository, WriteProductRepository>();
        services.AddScoped<IWriteCategoryRepository, WriteCategoryRepository>();
    }
}
