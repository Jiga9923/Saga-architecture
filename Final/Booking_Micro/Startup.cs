using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking_Micro.Consumer;
using Booking_Micro.Infra;
using MassTransit;
using MassTransit.Definition;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using rabbitmq_message;
using rabbitmq_message.BusConfigurations;

namespace Booking_Micro
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);
            services.AddMassTransit(cfg =>
            {
                cfg.AddRequestClient<IStartBooking>();
                cfg.AddConsumer<StartBookingConsumer>();
                cfg.AddConsumer<BookingCancelledConsumer>();

                cfg.AddBus(provider => RabbitMqBus.ConfigureBus(provider));

            });

            services.AddMassTransitHostedService();
            services.AddDbContext<BookingDbContext>(a => a.UseSqlServer(Configuration.GetConnectionString("BookingDatabase")));

            services.AddSingleton<IBookingDataAccess, BookingDataAccess>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
