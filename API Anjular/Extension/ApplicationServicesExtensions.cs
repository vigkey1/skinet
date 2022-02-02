using API_Anjular.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Anjular.Extension
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState.Where(e => e.Value.Errors.Count > 0)
                       .SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToArray();
                    var errorReposonse = new APIValidationError
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorReposonse);
                };
            });

            return services;

        }
    }
}
