using Booking_Micro.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Micro.Infra
{
    public interface IBookingDataAccess
    {
        List<BookingModel> GetAllBooking();

        void SaveBooking(BookingModel booking);

        BookingModel GetBooking(Guid bookingId);
        bool DeleteBooking(Guid bookingId);
    }
}
