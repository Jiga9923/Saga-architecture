using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using rabbitmq_message.BusConfigurations;
using rabbitmq_saga.DbConfiguration;
using rabbitmq_saga.StateMachine;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace saga_machine
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server=.;Database=ADSM;Trusted_Connection=True;";

            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddMassTransit(cfg =>
                   {
                       cfg.AddSagaStateMachine<BookingStateMachine, BookingStateData>()

                        .EntityFrameworkRepository(r =>
                        {
                            r.ConcurrencyMode = ConcurrencyMode.Pessimistic; // or use Optimistic, which requires RowVersion

                            r.AddDbContext<DbContext, BookingStateDbContext>((provider, builder) =>
                            {
                                builder.UseSqlServer(connectionString, m =>
                                {
                                    m.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                                    m.MigrationsHistoryTable($"__{nameof(BookingStateDbContext)}");
                                });
                            });
                        });

                       cfg.AddBus(provider => RabbitMqBus.ConfigureBus(provider));
                   });

                   services.AddMassTransitHostedService();
               });

            await builder.RunConsoleAsync();
        }
    }
}
