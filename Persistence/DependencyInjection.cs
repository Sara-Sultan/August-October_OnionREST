using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersisteceDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //configure DB
            services.AddDbContext<ApplicationDbContext>(
                 m => m.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //For User & Auth optional requirement
            //// For Identity
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();
            return services;
        }
    }
}
