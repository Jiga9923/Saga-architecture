using MassTransit.EntityFrameworkCoreIntegration;
using MassTransit.EntityFrameworkCoreIntegration.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace rabbitmq_saga.DbConfiguration
{
    public class BookingStateDbContext :
    SagaDbContext
    {
        public BookingStateDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override IEnumerable<ISagaClassMap> Configurations
        {
            get { yield return new BookingStateMap(); }
        }
    }
}
