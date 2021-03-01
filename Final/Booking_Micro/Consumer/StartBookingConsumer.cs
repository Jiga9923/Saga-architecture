using MassTransit;
using Microsoft.Extensions.Logging;
using rabbitmq_message;
using rabbitmq_message.StateMachine.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Micro.Consumer
{
    public class StartBookingConsumer : IConsumer<IStartBooking>
    {
        readonly ILogger<StartBookingConsumer> _logger;
        public StartBookingConsumer()
        {
        }

        public StartBookingConsumer(ILogger<StartBookingConsumer> logger)
        {
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<IStartBooking> context)
        {
            //_logger.LogInformation("--Application Event-- Booking Transation Started and event published: {BookingId}", context.Message.BookingId);
            await context.Publish<IBookingStartedEvent>(new
            {
                context.Message.BookingId,
                context.Message.CardDetails,
                context.Message.FlightDetails
            });

        }
    }
}
