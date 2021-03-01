using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Micro.ViewModel
{
    public class BookingModel
    {
        [Key]
        public Guid BookingId { get; set; }
        public string FlightDetails { get; set; }
        public string CardDetails { get; set; }
        public string CustomerId { get; set; }
    }
}
