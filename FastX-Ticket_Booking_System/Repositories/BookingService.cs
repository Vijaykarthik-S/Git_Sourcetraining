using FastX_Ticket_Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace FastX_Ticket_Booking_System.Repositories
{
    public class BookingService : IBookingService
    {
        private readonly BusBookingContext _bookingContext;
        public BookingService( BusBookingContext bookingContext)
        {
            _bookingContext = bookingContext;
            
        }
        public List<Booking> GetallBookings()
        {
            var booking = _bookingContext.Bookings.ToList();
            if (booking.Count > 0) { 
                return booking;
            }
            return null;
        }
        public Booking ViewBookingHistorybyId(int id)
        {
            if (id != 0 || id != null)
            {
                var booking = _bookingContext.Bookings.FirstOrDefault(b => b.BookingId == id);
                if (booking != null) { 
                    return booking;
                }
                return null;
            }
            return null;
        }
        public int AddBooking(Booking booking)
        {
            try
            {
                if (booking != null)
                {
                    _bookingContext.Bookings.Add(booking);
                    _bookingContext.SaveChanges();
                    return booking.BookingId;

                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UpdateBooking(Booking booking)
        {
            var existingBooking = _bookingContext.Bookings.FirstOrDefault(x => x.BookingId == booking.BookingId);
            if (existingBooking != null)
            {
                existingBooking.BookingId = booking.BookingId;
                existingBooking.UserId = booking.UserId;
                existingBooking.RouteId= booking.RouteId;
                existingBooking.NumberofSeats = booking.NumberofSeats;
                existingBooking.TotalPrice = booking.TotalPrice;
                existingBooking.BookingDate = booking.BookingDate;
                existingBooking.BookingStatus = booking.BookingStatus;
                _bookingContext.Entry(existingBooking).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _bookingContext.SaveChanges();
                return "Record Updated successfully";
            }
            else
            {
                return "Something went wrong";
            }
        }


        public string CancelBooking(int id)
        {
            var booking = _bookingContext.Bookings.FirstOrDefault(b => b.BookingId == id);
            if (booking != null)
            {
                booking.BookingStatus = "Cancelled";
                _bookingContext.Entry(booking).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _bookingContext.SaveChanges();
                return "Booking cancelled successfully";
            }
            else
            {
                return "Booking not found";
            }

        }
        public string DeleteBooking(int id) {
            var booking = _bookingContext.Bookings.FirstOrDefault(b => b.BookingId == id);
            if (booking != null && booking.BookingStatus == "Cancelled")
            {
               
                bool isRefunded = RefundPayment(booking); 

                if (isRefunded)
                {
                    _bookingContext.Bookings.Remove(booking);
                    _bookingContext.SaveChanges();
                    return "Booking deleted after refund";
                }
                else
                {
                    return "Refund not processed yet, cannot delete booking";
                }
            }
            else
            {
                return "Booking not found or not cancelled";
            }
        }

       
    }
}
