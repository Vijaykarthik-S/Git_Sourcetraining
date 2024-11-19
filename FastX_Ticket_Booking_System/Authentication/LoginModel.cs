using System.ComponentModel.DataAnnotations;

namespace FastX_Ticket_Booking_System.Authentication
{
    public class LoginModel
    {

        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }
}