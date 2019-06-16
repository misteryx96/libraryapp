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


        // GET: api/Writers
        [HttpGet]
        public IActionResult Get([FromQuery] WriterSearch search) 
        {
            var result = _getCommand.Execute(search);
            return Ok(result);
        }

        // GET: api/Writers/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
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

        // POST: api/Writers
        [HttpPost]
        public IActionResult Post([FromBody] WriterDto dto)
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

        // PUT: api/Writers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WriterDto dto)
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
