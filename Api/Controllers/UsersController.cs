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

        /// <summary>
        /// returns all Users, also can add query to filter result
        /// 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///  
        ///  GET api/users
        ///  {
        ///      "firstName" : "Mirko",
        ///      "lastName" : "Cvetkovic",
        ///      "userName" : "mirkoCvetkan78"
        ///  }
        /// 
        /// </remarks>
        /// 
        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get([FromQuery]UserSearch search)
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

        /// <summary>
        /// Adds a single user with provided parameters
        /// 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST api/users 
        /// {
        ///     "userName" : "mirko",
        ///     "firstName" : "Mirko",
        ///     "lastName" : "Mirkovic",
        ///     "password" : "sifra123",
        ///     "roleId" : 2
        /// }
        /// 
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        // POST: api/Users
        [HttpPost]
        public ActionResult Post([FromBody] UserDto dto)
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

        /// <summary>
        /// Updates a single user with provided parameters
        /// 
        /// </summary>
        /// <remarks>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// Sample request:
        /// PUT api/users/2
        /// {
        ///     "userName" : "mirko",
        ///     "firstName" : "Mirko",
        ///     "lastName" : "Mirkovic",
        ///     "password" : "sifra123",
        ///     "roleId" : 2
        /// }
        /// 
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserDto dto)
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
        /// deletes a user with provided id
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <param name="id"></param>
        /// Sample request:
        ///  
        ///  DELETE api/users/4
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
