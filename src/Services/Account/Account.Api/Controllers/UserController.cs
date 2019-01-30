using System.Collections.Generic;
using System.Linq;
using Account.Domain.Entity;
using Account.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Account.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _userService.All().ToList();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<User>> GetById(int id)
        {
            var user = _userService.FindById(id);

            if (user == null) { return NotFound(); }

            return Ok(user);
        }

        // POST api/user
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(User))]
        public ActionResult<IEnumerable<User>> Post([FromBody] User user)
        {
            _userService.Add(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (id != user.Id) { return NotFound(); }

            _userService.Update(user);

            return NoContent();
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            var user = _userService.FindById(id);

            if (user == null) { return NotFound(); }

            _userService.Remove(user);

            return NoContent();
        }
    }
}
