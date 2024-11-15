using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using FastX_Ticket_Booking_System.Models;
using FastX_Ticket_Booking_System.Repositories;
using FastX_Ticket_Booking_System.Exceptions;

namespace API_Code_First_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusRouteController : ControllerBase
    {
        private readonly IBusRoute _service;


        public BusRouteController(IBusRoute service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult BrowseRoutes(string source, string destination)
        {
            try
            {
                var routes = _service.BrowseRoutes(source, destination);
                return Ok(routes);
            }
            catch (SourcetoDestinationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, " " + ex.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetRouteDetails(int id)
        {
            var route = _service.GetRouteDetails(id);
            if (route == null)
            {
                return NotFound($"Route with ID {id} not found.");
            }
            return Ok(route);
        }


        [HttpPost]
        public IActionResult AddRoute(BusRoute routeData)
        {
            if (routeData == null)
            {
                return BadRequest("Route data is required.");
            }

            int routeId = _service.AddRoute(routeData);
            return Ok(routeId);
        }

        [HttpPut]
        public IActionResult UpdateRoute(int id, BusRoute routeData)
        {
            if (routeData == null)
            {
                return BadRequest("Route data is required.");
            }

            string result = _service.UpdateRoute(id, routeData);
            return Ok(result);

        }


        [HttpDelete]
        public IActionResult DeleteRoute(int id)
        {
            string result = _service.DeleteRoute(id);

            return Ok(result);


        }
    }
}