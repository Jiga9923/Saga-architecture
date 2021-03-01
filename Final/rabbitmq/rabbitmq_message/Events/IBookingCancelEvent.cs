using System;

namespace rabbitmq_message.Messages
{
    public interface IBookingCancelEvent
    {
        public Guid BookingId { get; }
        public string CardDetails { get; }
        public string FlightDetails { get; }
    }
}
