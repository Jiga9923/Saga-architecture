using System;
using System.Collections.Generic;
using System.Text;

namespace rabbitmq_message.BusConfigurations
{
    public class BusConstants
    {
        public const string RabbitMqUri = "rabbitmq://localhost/"   ;
        public const string UserName = "guest";
        public const string Password = "guest";
        public const string BookingQueue = "validate-booking-queue";
        public const string SagaBusQueue = "saga-bus-queue";
        public const string StartBookingTranastionQueue = "start-booking";
    }
}
