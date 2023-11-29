using Discount.Grpc.Configurations;
using Discount.Grpc.Data.Configurations;
using Discount.Grpc.Services;

namespace Discount.Grpc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.ConfigureBusinessServices();
            builder.Services.ConfigureRepositorySettings(builder.Configuration);
            builder.Services.AddGrpc();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<DiscountServiceService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}