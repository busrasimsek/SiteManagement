using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SiteManagement.Data.Context;
using SiteManagement.Data.Core.UnitOfWork.Abstract;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data
{
    public static class ServiceRegistration
    {
        public static void AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("EfDbContext");
            services.AddDbContext<EfDbContext>(x =>
            {
                x.UseNpgsql(connString, opt =>
                {
                    opt.CommandTimeout(Convert.ToInt32(100));
                });
                x.UseLazyLoadingProxies(false);
                x.EnableSensitiveDataLogging();
            });
            services.TryAddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<EfDbContext>));
            services.TryAddScoped<DbContext, EfDbContext>();
        }

    }
}
