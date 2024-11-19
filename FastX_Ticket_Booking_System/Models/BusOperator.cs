using System;
using System.Collections.Generic;

namespace FastX_Ticket_Booking_System.Models
{
    public partial class BusOperator
    {
        public int OperatorId { get; set; }
        public string? OperatorName { get; set; }
        public string? OperatorPhone { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? BusId { get; set; }

        public virtual bus? Bus { get; set; }
    }
}
