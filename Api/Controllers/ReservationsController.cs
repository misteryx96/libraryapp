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

        /// <summary>
        /// returns all Reservations, also can add query to filter result
        /// 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///  
        ///  GET api/reservations
        ///  {
        ///      "userName" : "mirkoCvetkovic"
        ///  }
        /// 
        /// </remarks>
        /// 
        // GET: api/Reservations
        [HttpGet]
        public ActionResult<IEnumerable<ReservationDto>> Get([FromQuery]ReservationSearch search)
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

        /// <summary>
        /// returns a single Reservation
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <param name="id"></param>
        /// Sample request:
        ///  
        ///  GET api/reservations/4
        /// 
        /// </remarks>
        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public ActionResult<ReservationDto> Get(int id)
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


        /// <summary>
        /// Adds a single reservaton with provided parameters
        /// 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST api/reservations 
        /// {
        ///     "userId" : 2,
        ///     "bookReservations" : [
        ///         1, 2
        ///     ]
        /// }
        /// 
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        // POST: api/Reservations
        [HttpPost]
        public ActionResult Post([FromBody] ReservationDto dto)
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


        /// <summary>
        /// Updates a single reservaton with provided parameters
        /// 
        /// </summary>
        /// <remarks>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// Sample request:
        /// PUT api/reservations 
        /// {
        ///     "userId" : 2,
        ///     "bookReservations" : [
        ///         1, 2
        ///     ]
        /// }
        /// 
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ReservationDto dto)
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


        /// <summary>
        /// deletes a reservation with provided id
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <param name="id"></param>
        /// Sample request:
        ///  
        ///  DELETE api/reservations/4
        /// 
        /// </remarks>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
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
