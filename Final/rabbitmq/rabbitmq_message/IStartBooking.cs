using System;
using System.Collections.Generic;
using System.Text;

namespace rabbitmq_message
{
    public interface IStartBooking
    {
        public Guid BookingId { get; }
        public string CardDetails { get; }
        public string FlightDetails { get; }
    }
}
