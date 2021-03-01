using Automatonymous;
using rabbitmq_message.Messages;
using rabbitmq_message.StateMachine.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace rabbitmq_saga.StateMachine
{
    public class BookingStateMachine :
       MassTransitStateMachine<BookingStateData>
    {
        public BookingStateMachine()
        {
            Event(() => BookingStartedEvent, x => x.CorrelateById(m => m.Message.BookingId));

            Event(() => BookingCancelledEvent, x => x.CorrelateById(m => m.Message.BookingId));

            InstanceState(x => x.CurrentState);

            Initially(
               When(BookingStartedEvent)
                .Then(context =>
                {
                    context.Instance.BookingCreationDateTime = DateTime.Now;
                    context.Instance.BookingId = context.Data.BookingId;
                    context.Instance.CardDetails = context.Data.CardDetails;
                    context.Instance.FlightDetails = context.Data.FlightDetails;
                })
               .TransitionTo(BookingStarted)
               .Publish(context => new BookingValidateEvent(context.Instance)));

            During(BookingStarted,
                When(BookingCancelledEvent)
                    .Then(context => context.Instance.BookingCancelDateTime =
                        DateTime.Now)
                     .TransitionTo(BookingCancelled)

              );
        }

        public State BookingStarted { get; private set; }
        public State BookingCancelled { get; private set; }
        public Event<IBookingStartedEvent> BookingStartedEvent { get; private set; }
        public Event<IBookingCancelEvent> BookingCancelledEvent { get; private set; }
    }
}
