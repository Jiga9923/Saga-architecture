using System;

namespace rabbitmq_message.Messages
{
    public interface IBookingValidateEvent
    {
        public Guid BookingId { get; }
        public string CardDetails { get; }
        public string FlightDetails { get; }

    }
}
