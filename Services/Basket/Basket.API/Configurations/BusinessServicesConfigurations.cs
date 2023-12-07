using Asp.Versioning;
using Basket.API.Business;
using Basket.API.Data.Interfaces;
using Basket.API.GrpcServices;
using Discount.Grpc.Protos;

namespace Basket.API.Configurations
{
    public static class BusinessServicesConfigurations
    {
        public static IServiceCollection ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IBasketService, BasketService>();
            services.AddScoped<DiscountGrpcService>();
            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(c => {
            c.Address = new Uri(configuration.GetValue<string>("GrpcSettings:DiscountGrpcUrl")!);
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.ConfigureApiVersioning();
            return services;
        }

        public static IServiceCollection ConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ReportApiVersions = true;
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            return services;
        }
    }
}
