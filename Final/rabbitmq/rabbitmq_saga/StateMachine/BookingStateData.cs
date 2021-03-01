using Automatonymous;
using System;
using System.Collections.Generic;
using System.Text;

namespace rabbitmq_saga.StateMachine
{
    public class BookingStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public DateTime? BookingCreationDateTime { get; set; }
        public DateTime? BookingCancelDateTime { get; set; }
        public Guid BookingId { get; set; }
        public string CardDetails { get; set; }
        public string FlightDetails { get; set; }
    }
}
