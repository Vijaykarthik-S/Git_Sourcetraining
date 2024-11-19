
using FastX_Ticket_Booking_System.Models;

namespace FastX_Ticket_Booking_System.Repository
{
    public interface IPayment
    {
        List<Payment> GetAllPayments();
        Payment GetPaymentById(int id);

        int AddPayment(Payment payment);
        string UpdatePayment(Payment payment);
        string DeletePayment(int id);


    }
}