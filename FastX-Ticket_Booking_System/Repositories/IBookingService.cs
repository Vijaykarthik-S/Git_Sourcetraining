using FastX_Ticket_Booking_System.Models;

namespace FastX_Ticket_Booking_System.Repositories
{
    public interface IBookingService
    {
        List<Booking> GetallBookings();
        Booking ViewBookingHistorybyId(int id);
        int AddBooking(Booking booking);
         
        string UpdateBooking (Booking booking);
        string CancelBooking (int id);
        string DeleteBooking(int id);
    }
}
