using MassTransit;
using MassTransit.RabbitMqTransport;
using System;
using System.Collections.Generic;
using System.Text;

namespace rabbitmq_message.BusConfigurations
{
    public class RabbitMqBus
    {
        public static IBusControl ConfigureBus(IServiceProvider provider, Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost>
        registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(BusConstants.RabbitMqUri), hst =>
                {
                    hst.Username(BusConstants.UserName);
                    hst.Password(BusConstants.Password);
                });

                cfg.ConfigureEndpoints(provider);

                registrationAction?.Invoke(cfg, host);
            });
        }
    }
}
