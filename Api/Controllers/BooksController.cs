using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Exceptions;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IGetBooksCommand _command;
        private IGetBookCommand _command2;
        private IAddBookCommand _addCommand;
        private IDeleteBookCommand _deleteCommand;
        private IUpdateBookCommand _updateBookCommand;
        private IGetPagedBooksCommand _getPagedBooksCommand;

        public BooksController(IGetBooksCommand command, IGetBookCommand command2, IAddBookCommand addCommand, IDeleteBookCommand deleteCommand, IUpdateBookCommand updateBookCommand, IGetPagedBooksCommand getPagedBooksCommand)
        {
            _command = command;
            _command2 = command2;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
            _updateBookCommand = updateBookCommand;
            _getPagedBooksCommand = getPagedBooksCommand;
        }





        // GET: api/Books
        [HttpGet]
        public IActionResult Get([FromQuery] BookSearch search)
        {
            var result = _getPagedBooksCommand.Execute(search);
            return Ok(result);
        }

        // old - without navigation

        //[HttpGet]
        //public IActionResult Get([FromQuery] BookSearch search)
        //{
        //    var result = _command.Execute(search);
        //    return Ok(result);
        //}

        // GET: api/Books/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var BookDto = _command2.Execute(id);
                return Ok(BookDto);
            }
            catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult Post([FromBody] BookDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return StatusCode(201, "Success!");
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error has occurred, please try later");
            }
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookDto dto)
        {
            try
            {
                dto.Id = id;
                _updateBookCommand.Execute(dto);
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
                return StatusCode(204, "Success!");
            }
            catch(EntityNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
