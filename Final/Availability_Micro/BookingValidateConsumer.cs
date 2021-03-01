using MassTransit;
using rabbitmq_message.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Availability_Micro
{
    public class BookingValidateConsumer : IConsumer<IBookingValidateEvent>
    {
        public async Task Consume(ConsumeContext<IBookingValidateEvent> context)
        {
            var data = context.Message;

            if (data.CardDetails.Contains("NotValid"))
            {
                await context.Publish<IBookingCancelEvent>(
          new { BookingId = context.Message.BookingId, CardDetails = context.Message.CardDetails });
            }
            else
            {
                // send to next microservice
            }

        }
    }
}
