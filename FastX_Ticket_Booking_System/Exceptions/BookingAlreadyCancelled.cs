namespace FastX_Ticket_Booking_System.Exceptions
{
    public class BookingAlreadyCancelled : Exception
    {
        public BookingAlreadyCancelled(string message) : base(message) { }

    }
}