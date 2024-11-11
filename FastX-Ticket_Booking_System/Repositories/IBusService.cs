
using FastX_Ticket_Booking_System.Models;

namespace FastX_Ticket_Booking_System.Repositories
{
    public interface IBusService
    {
        List<bus> GetAllBuses();
        bus GetBusById(int id);
        int AddNewBus(bus buses);
        string UpdateBus(bus buses);
        string DeleteBus(int id);
    }
}