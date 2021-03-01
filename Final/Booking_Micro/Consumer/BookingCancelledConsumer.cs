using Booking_Micro.Infra;
using MassTransit;
using rabbitmq_message.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Micro.Consumer
{
    public class BookingCancelledConsumer : IConsumer<IBookingCancelEvent>
    {
        private readonly IBookingDataAccess _bookingDataAccess;

        public BookingCancelledConsumer(IBookingDataAccess bookingDataAccess)
        {
            _bookingDataAccess = bookingDataAccess;
        }

        public async Task Consume(ConsumeContext<IBookingCancelEvent> context)
        {
            var data = context.Message;
            _bookingDataAccess.DeleteBooking(data.BookingId);
        }
    }
}
