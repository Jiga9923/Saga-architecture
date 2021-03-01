using Booking_Micro.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Micro.Infra
{
    public class BookingDbContext : DbContext
    {
        public DbSet<BookingModel> BookingData { get; set; }

        public BookingDbContext()
        {
        }

        public BookingDbContext(DbContextOptions
<BookingDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.; initial catalog=ADSM;integrated security=true;");
        }
    }
}
