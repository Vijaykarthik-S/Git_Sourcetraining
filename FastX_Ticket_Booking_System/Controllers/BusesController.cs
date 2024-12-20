﻿using AutoMapper;
using FastX_Ticket_Booking_System.DTO;
using FastX_Ticket_Booking_System.Models;
using FastX_Ticket_Booking_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastX_Ticket_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly IBusService _service;
        private readonly IMapper _mapper;
        public BusesController(IBusService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //[HttpGet]
        //public IActionResult GetAllBuses()
        //{
        //    List<bus> buses = _service.GetAllBuses();
        //    return Ok(buses);
        //}
        [HttpGet]
        public async Task<ActionResult<List<BusDTO>>> GetAllBus()
        {
            List<bus> buses = _service.GetAllBuses();
            if (buses != null)
            {

                List<BusDTO> busDtos = _mapper.Map<List<BusDTO>>(buses);
                return busDtos;
            }
            else
            { return NotFound(); }
        }

        [HttpGet("{id}")]
        public IActionResult GetBusById(int id)
        {
            bus buses = _service.GetBusById(id);
            return Ok(buses);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post(bus buses)
        {
            int Result = _service.AddNewBus(buses);
            return Ok(Result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Put(bus buses)
        {
            string result = _service.UpdateBus(buses);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string result = _service.DeleteBus(id);
            return Ok(result);
        }

    }
}