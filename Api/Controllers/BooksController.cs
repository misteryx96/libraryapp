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




        /// <summary>
        /// returns all Books, also can add query to filter result
        /// 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///  
        ///  GET api/books
        ///  {
        ///      "bookName" = "Na driniCuprija",
        ///      "isAvailable" = true,
        ///      "genreId" = 2,
        ///      "perPage" = 4,
        ///      "pageNumber" = 1
        ///  }
        /// 
        /// </remarks>
        /// 
        // GET: api/Books
        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> Get([FromQuery] BookSearch search)
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


        /// <summary>
        /// returns a single Book
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <param name="id"></param>
        /// Sample request:
        ///  
        ///  GET api/books/4
        /// 
        /// </remarks>
        // GET: api/Books/5
        [HttpGet("{id}")]
        public ActionResult<BookDto> Get(int id)
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

        /// <summary>
        /// Adds a single book with provided parameters
        /// 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST api/books 
        /// {
        ///     "title" : "Na drini cuprija",
        ///     "writerId" : "2",
        ///     "decription" : "skksdkdskdsk",
        ///     "availableCount" : 2,
        ///     "count" : 2
        ///     "selectedGenres" : [
        ///         1, 2
        ///     ]
        /// }
        /// 
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        // POST: api/Books
        
        [HttpPost]
        public ActionResult Post([FromBody] BookDto dto)
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

        /// <summary>
        /// Updates a book with provided id
        /// 
        /// </summary>
        /// <remarks>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// Sample request:
        /// PUT api/books/3
        /// {
        ///     "title" : "Na drini cuprija",
        ///     "writerId" : "2",
        ///     "decription" : "skksdkdskdsk",
        ///     "availableCount" : 2,
        ///     "count" : 2
        ///     "selectedGenres" : [
        ///         1, 2
        ///     ]
        /// }
        /// 
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        // PUT: api/Books/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BookDto dto)
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

        /// <summary>
        /// deletes a book with provided id
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <param name="id"></param>
        /// Sample request:
        ///  
        ///  DELETE api/books/4
        /// 
        /// </remarks>
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
