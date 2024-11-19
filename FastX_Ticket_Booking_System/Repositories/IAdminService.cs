
using FastX_Ticket_Booking_System.Models;

namespace FastX_Ticket_Booking_System.Repository
{
    public interface IAdmin
    {
        List<User> GetAllUsers();
        List<User> DisplayAdmin();
        List<BusOperator> GetAllOperators();

        User GetUserDetails(int userid);
        BusOperator GetOperatorDetails(int opid);

        int AddUser(User userData);

        int AddOperator(BusOperator op);

        string UpdateUser(int userid, User userdata);
        string UpdateOperator(int opid, BusOperator op);

        string DeleteUser(int userId);
        string DeleteOperator(int opid);
    }
}