using Ambev.DeveloperEvaluation.Application;
using Ambev.DeveloperEvaluation.Common.HealthChecks;
using Ambev.DeveloperEvaluation.Common.Logging;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.IoC;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.WebApi.Consumer;
using Ambev.DeveloperEvaluation.WebApi.Features.ProductSale.AddProductSale;
using Ambev.DeveloperEvaluation.WebApi.Middleware;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Ambev.DeveloperEvaluation.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Log.Information("Starting web application");

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.AddDefaultLogging();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.AddBasicHealthChecks();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DefaultContext>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
                )
            );

            builder.Services.AddJwtAuthentication(builder.Configuration);

            builder.RegisterDependencies();

            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(
                    typeof(ApplicationLayer).Assembly,
                    typeof(Program).Assembly
                );
            });

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            builder.Services.AddMassTransit(bussConfigurator =>
            {
                
                bussConfigurator.SetKebabCaseEndpointNameFormatter();
                bussConfigurator.UsingRabbitMq((rabbitmq, busFactoryConfigurator) => 
                {
                    busFactoryConfigurator.Host(builder.Configuration.GetConnectionString("RabbitMq"), "/" ,hostconfigurator =>
                    {
                        hostconfigurator.Username(builder.Configuration.GetConnectionString("RabbitMqUser"));
                        hostconfigurator.Password(builder.Configuration.GetConnectionString("RabbitMqPassword"));
                    });
                    busFactoryConfigurator.Publish<Message>(e =>
                    {
                        e.ExchangeType = "topic";
                        
                    });
                    busFactoryConfigurator.ReceiveEndpoint("MSFT", e =>
                    {
                        e.ConfigureConsumeTopology = false;
                        e.ExchangeType = "topic";
                        e.Consumer<BrokerConsumer>();
                        e.Bind<Message>(e => 
                        {
                            e.ExchangeType="topic";
                        });
                    });
                    

                });
            });
            builder.Services.AddScoped<ActionFilterMessageBroker>();
            var app = builder.Build();
            
            app.UseMiddleware<ValidationExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseBasicHealthChecks();

            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
