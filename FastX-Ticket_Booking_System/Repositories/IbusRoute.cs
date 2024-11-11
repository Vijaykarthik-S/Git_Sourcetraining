using System.Collections.Generic;
using FastX_Ticket_Booking_System.Models;

namespace FastX_Ticket_Booking_System.Repositories
{
    public interface IBusRoute
    {
        List<BusRoute> BrowseRoutes(string source, string destination);


        BusRoute GetRouteDetails(int routeId);

        int AddRoute(BusRoute routeData);

       
        string UpdateRoute(int routeId, BusRoute routeData);

       
        string DeleteRoute(int routeId);

       
      
    }
}
