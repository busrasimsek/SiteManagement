using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SiteManagement.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly()
                         .ExportedTypes
                         .Where(consumer => consumer.FullName != null && consumer.FullName.Contains("Handler") && consumer.IsClass)
                         .ToArray();
            services.AddMediatR(assembly);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFluentValidation(options =>
            {
                options.ImplicitlyValidateChildProperties = true;
                options.ImplicitlyValidateRootCollectionElements = true;

                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
        }
    }
}
