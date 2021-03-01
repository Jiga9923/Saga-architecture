using Booking_Micro.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking_Micro.Infra
{
    public class BookingDataAccess : IBookingDataAccess
    {
        public List<BookingModel> GetAllBooking()
        {
            using (var context = new BookingDbContext())
            {
                return context.BookingData.ToList();
            }
        }
        public void SaveBooking(BookingModel booking)
        {
            using (var context = new BookingDbContext())
            {
                context.Add<BookingModel>(booking);
                context.SaveChanges();
            }
        }

        public bool DeleteBooking(Guid bookingId)
        {
            using (var context = new BookingDbContext())
            {
                BookingModel booking = context.BookingData.Where(x => x.BookingId == bookingId).FirstOrDefault();

                if (booking != null)
                {
                    context.Remove(booking);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public BookingModel GetBooking(Guid bookingId)
        {
            using (var context = new BookingDbContext())
            {
                return context.BookingData.Where(x => x.BookingId == bookingId).FirstOrDefault();
            }
        }

    }
}
