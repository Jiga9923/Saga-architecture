using MassTransit.EntityFrameworkCoreIntegration.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rabbitmq_saga.StateMachine;
using System;
using System.Collections.Generic;
using System.Text;

namespace rabbitmq_saga.DbConfiguration
{
    public class BookingStateMap :
   SagaClassMap<BookingStateData>
    {
        protected override void Configure(EntityTypeBuilder<BookingStateData> entity, ModelBuilder model)
        {
            entity.Property(x => x.CurrentState).HasMaxLength(64);
            entity.Property(x => x.BookingCreationDateTime);
        }
    }
}
