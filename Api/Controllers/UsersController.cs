using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IGetUsersCommand _getCommand;
        private IUpdateUserCommand _updateCommand;
        private IDeleteUserCommand _deleteCommand;
        private IAddUserCommand _addCommand;

        public UsersController(IGetUsersCommand getCommand, IUpdateUserCommand updateCommand, IDeleteUserCommand deleteCommand, IAddUserCommand addCommand)
        {
            _getCommand = getCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
            _addCommand = addCommand;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get([FromQuery]UserSearch search)
        {
            try
            {
                var result = _getCommand.Execute(search);
                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, "An error has occurred");
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] UserDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return StatusCode(201, "Success!");
            }
            catch(Exception e)
            {
                return StatusCode(500, "An error has occurred");
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto dto)
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
                return StatusCode(204, "Success!");
            }
            catch(Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
