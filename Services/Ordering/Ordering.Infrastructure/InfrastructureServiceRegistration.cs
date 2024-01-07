using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Models;
using Ordering.Infrastructure.Mail;
using Ordering.Infrastructure.Persistance;
using Ordering.Infrastructure.Persistence;
using CrossCutting.Persistance.SQL.Configurations;

namespace Ordering.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigurePersistanceInfra();

            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(nameof(OrderContext))));

            services.AddTransient<IOrderUnitOfWork, OrderUnitOfWork>();
            services.AddScoped<DbContext, OrderContext>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailServices, EmailService>();

            return services;
        }

        public static IApplicationBuilder CreateDB(
           this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            using (var dbcontext = scope.ServiceProvider.GetRequiredService<OrderContext>())
                dbcontext.Database.EnsureCreated();

            return app;
        }
    }
}
