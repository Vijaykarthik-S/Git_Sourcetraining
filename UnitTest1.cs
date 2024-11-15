using FastX_Ticket_Booking_System.Models;
using FastX_Ticket_Booking_System.Repositories;
using FastX_Ticket_Booking_System.Repository;
using Moq;
using NUnit.Framework;

namespace FastX_Ticket_Booking_System.Tests
{
    [TestFixture]
    public class BusBookingTests
    {
        private Mock<IBusService> _busServiceMock;
        private Mock<IBookingService> _bookingServiceMock;
        private Mock<IAdmin> _adminServiceMock;

        [SetUp]
        public void Setup()
        {
            _busServiceMock = new Mock<IBusService>();
            _bookingServiceMock = new Mock<IBookingService>();
            _adminServiceMock = new Mock<IAdmin>();
        }

        // Testing BusService
        [Test]
        public void AddBus_Testing()
        {
            var newBus = new bus
            {
                BusId = 101,
                BusName = "Luxury Express",
                Bustype = "AC",
                Amenities = "WiFi, Recliner Seats",
                NumberofSeats = 40,
                PricePerSeat = 500
            };
            _busServiceMock.Setup(service => service.AddNewBus(newBus)).Returns(1);

            var result = _busServiceMock.Object.AddNewBus(newBus);

            Assert.AreEqual(1, result, "Bus was not added successfully.");
        }

        [Test]
        public void UpdateBus_Testing()
        {
            var updatedBus = new bus
            {
                BusId = 101,
                BusName = "Super Luxury Express",
                Bustype = "AC Sleeper",
                Amenities = "WiFi, Recliner Seats, Charging Points",
                NumberofSeats = 45,
                PricePerSeat = 600
            };
            _busServiceMock.Setup(service => service.UpdateBus(updatedBus)).Returns("Success");

            var result = _busServiceMock.Object.UpdateBus(updatedBus);

            Assert.AreEqual("Success", result, "Bus was not updated successfully.");
        }

        [Test]
        public void DeleteBus_Testing()
        {
            _busServiceMock.Setup(service => service.DeleteBus(101)).Returns("Success");

            var result = _busServiceMock.Object.DeleteBus(101);

            Assert.AreEqual("Success", result, "Bus was not deleted successfully.");
        }

        // Testing BookingService
        [Test]
        public void AddBooking_Test()
        {
            var newBooking = new Booking
            {
                BookingId = 201,
                UserId = 1,
                RouteId = 10,
                NumberofSeats = 2,
                TotalPrice = 1000,
                BookingDate = DateTime.Now,
                BookingStatus = "Confirmed"
            };
            _bookingServiceMock.Setup(service => service.AddBooking(newBooking)).Returns(1);

            var result = _bookingServiceMock.Object.AddBooking(newBooking);

            Assert.AreEqual(1, result, "Booking was not added successfully.");
        }

        [Test]
        public void UpdateBooking_Test()
        {
            var updatedBooking = new Booking
            {
                BookingId = 201,
                UserId = 1,
                RouteId = 10,
                NumberofSeats = 3,
                TotalPrice = 1500,
                BookingDate = DateTime.Now,
                BookingStatus = "Modified"
            };
            _bookingServiceMock.Setup(service => service.UpdateBooking(updatedBooking)).Returns("Success");

            var result = _bookingServiceMock.Object.UpdateBooking(updatedBooking);

            Assert.AreEqual("Success", result, "Booking was not updated successfully.");
        }

        [Test]
        public void DeleteBooking_Test()
        {
            _bookingServiceMock.Setup(service => service.DeleteBooking(201)).Returns("Success");

            var result = _bookingServiceMock.Object.DeleteBooking(201);

            Assert.AreEqual("Success", result, "Booking was not deleted successfully.");
        }

        // Testing AdminService
        [Test]
        public void AddUser_Test()
        {
            var newUser = new User
            {
                UserId = 301,
                UserName = "Rajesh",
                Role = "User"

            };
            _adminServiceMock.Setup(service => service.AddUser(newUser)).Returns(1);

            var result = _adminServiceMock.Object.AddUser(newUser);

            Assert.AreEqual(1, result, "Admin was not added successfully.");
        }

        [Test]
        [TestCase(301)]
        public void UpdateAdmin_Test(int id)
        {
            var updatedUser = new User
            {
                UserId = 301,
                UserName = "Sudip",
                Role = "User"
            };
            _adminServiceMock.Setup(service => service.UpdateUser(id, updatedUser)).Returns("Success");

            var result = _adminServiceMock.Object.UpdateUser(id, updatedUser);

            Assert.AreEqual("Success", result, "Admin was not updated successfully.");
        }

        [Test]
        public void DeleteAdmin_Test()
        {
            _adminServiceMock.Setup(service => service.DeleteUser(301)).Returns("Success");

            var result = _adminServiceMock.Object.DeleteUser(301);

            Assert.AreEqual("Success", result, "Admin was not deleted successfully.");
        }
    }
}
