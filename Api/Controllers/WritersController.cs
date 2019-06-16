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
    public class WritersController : ControllerBase
    {
        private IAddWriterCommand _addCommand;
        private IGetWritersCommand _getCommand;
        private IGetWriterCommand _getOne;
        private IUpdateWriterCommand _updateCommand;
        private IDeleteWriterCommand _deleteCommand;

        public WritersController(IAddWriterCommand addCommand, IGetWritersCommand getCommand, IGetWriterCommand getOne, IUpdateWriterCommand updateCommand, IDeleteWriterCommand deleteCommand)
        {
            _addCommand = addCommand;
            _getCommand = getCommand;
            _getOne = getOne;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
        }

        /// <summary>
        /// returns all Writers, also can add query to filter result
        /// 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///  
        ///  GET api/writers
        ///  {
        ///      "name" : "Ivo Andric"
        ///  }
        /// 
        /// </remarks>
        /// 
        // GET: api/Writers
        [HttpGet]
        public ActionResult<IEnumerable<WriterDto>> Get([FromQuery] WriterSearch search) 
        {
            var result = _getCommand.Execute(search);
            return Ok(result);
        }

        /// <summary>
        /// returns a single Writer
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <param name="id"></param>
        /// Sample request:
        ///  
        ///  GET api/writers/4
        /// 
        /// </remarks>
        // GET: api/Writers/5
        [HttpGet("{id}")]
        public ActionResult<WriterDto> Get(int id)
        {
            try
            {
                var WriterDto = _getOne.Execute(id);
                return Ok(WriterDto);
            }
            catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Adds a single writer with provided parameters
        /// 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST api/writers 
        /// {
        ///     "name" : "Ivo Andric"
        /// }
        /// 
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        // POST: api/Writers
        [HttpPost]
        public ActionResult Post([FromBody] WriterDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return StatusCode(201, "Success!");
            }
            catch(Exception)
            {
                return StatusCode(500, "An error has occured, pls try later!");
            }
        }

        /// <summary>
        /// Adds a single writer with provided parameters
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// Sample request:
        /// POST api/writers 
        /// {
        ///     "name" : "Ivo Andric"
        /// }
        /// 
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        // PUT: api/Writers/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] WriterDto dto)
        {
            try
            {
                dto.Id = id;
                _updateCommand.Execute(dto);
                return StatusCode(204, "Success!");
            }
            catch (Exception e)
            {
                return StatusCode(409, e.Message);
            }
        }


        /// <summary>
        /// deletes a writer with provided id
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <param name="id"></param>
        /// Sample request:
        ///  
        ///  DELETE api/writers/4
        /// 
        /// </remarks>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return StatusCode(204, "Success!");
            }
            catch(Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
