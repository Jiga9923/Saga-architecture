using System;

namespace rabbitmq_message.StateMachine.Messages
{
    public interface IBookingStartedEvent
    {
        public Guid BookingId { get; }
        public string CardDetails { get; }
        public string FlightDetails { get; }
    }
}
