using Microsoft.AspNetCore.Mvc;
using TalabatG02.APIs.Errors;
using TalabatG02.APIs.Helpers;
using TalabatG02.Core;
using TalabatG02.Core.Repositories;
using TalabatG02.Core.Services;
using TalabatG02.Repository;
using TalabatG02.Service;

namespace TalabatG02.APIs.Extentions
{
    public static class ApplicationServicesExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddAutoMapper(typeof(MappingProfiles));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(P => P.Value.Errors.Count() > 0)
                                                         .SelectMany(p => p.Value.Errors)
                                                         .Select(E => E.ErrorMessage).ToArray();

                    var ValidationErrorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(ValidationErrorResponse);
                };
            });

            services.AddScoped<IBasketRepository, BasketRepository>();  

            return services;
        }
    }
}
