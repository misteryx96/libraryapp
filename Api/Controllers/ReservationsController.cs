using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private IAddReservationCommand _addCommand;
        private IGetReserervationsCommand _getCommand;
        private IGetReservationCommand _getOne;
        private IUpdateReservationCommand _updateCommand;
        private IDeleteReservationCommand _deleteCommand;

        public ReservationsController(IAddReservationCommand addCommand, IGetReserervationsCommand getCommand, IGetReservationCommand getOne, IUpdateReservationCommand updateCommand, IDeleteReservationCommand deleteCommand)
        {
            _addCommand = addCommand;
            _getCommand = getCommand;
            _getOne = getOne;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
        }

        // GET: api/Reservations
        [HttpGet]
        public IActionResult Get([FromQuery]ReservationSearch search)
        {
            try
            {
                var result = _getCommand.Execute(search);
                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, "An error has occurred!!!");
            }
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var ReservationDto = _getOne.Execute(id);
                return Ok(ReservationDto);
            }
            catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Reservations
        [HttpPost]
        public IActionResult Post([FromBody] ReservationDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return StatusCode(201, "Success!");
            }
            catch(Exception e)
            {
                return StatusCode(500, "An error has occured!");
            }   
        }

        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReservationDto dto)
        {
            try
            {
                dto.Id = id;
                _updateCommand.Execute(dto);
                return StatusCode(204);
            }
            catch(Exception e)
            {
                return StatusCode(409);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return StatusCode(204, "Success");
            }
            catch(EntityNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
