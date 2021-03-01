using rabbitmq_message.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace rabbitmq_saga.StateMachine
{
    public class BookingValidateEvent : IBookingValidateEvent
    {
        private readonly BookingStateData bookingSagaState;
        public BookingValidateEvent(BookingStateData bookingStateData)
        {
            this.bookingSagaState = bookingStateData;
        }

        public Guid BookingId => bookingSagaState.BookingId;
        public string CardDetails => bookingSagaState.CardDetails;
        public string FlightDetails => bookingSagaState.FlightDetails;
    }
}
