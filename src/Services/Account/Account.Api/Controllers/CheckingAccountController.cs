using System.Collections.Generic;
using System.Linq;
using Account.Domain.Entity;
using Account.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Account.Api.Controllers
{
    [Route("api/checking-account")]
    [ApiController]
    public class CheckingAccountController : ControllerBase
    {
        private readonly ICheckingAccountService _checkingAccountService;

        public CheckingAccountController(ICheckingAccountService checkingAccountService)
        {
            _checkingAccountService = checkingAccountService;
        }

        // GET: api/checking-account
        [HttpGet]
        public ActionResult<IEnumerable<CheckingAccount>> GetCheckingAccounts()
        {
            return _checkingAccountService.All().ToList();
        }

        // GET api/checking-account/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CheckingAccount))]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<CheckingAccount>> GetById(int id)
        {
            var checkingAccount = _checkingAccountService.FindById(id);

            if(checkingAccount == null) { return NotFound(); }

            return Ok(checkingAccount);
        }

        // POST api/checking-account
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CheckingAccount))]
        public ActionResult<IEnumerable<CheckingAccount>> Post([FromBody] CheckingAccount checkingAccount)
        {
            _checkingAccountService.Add(checkingAccount);

            return CreatedAtAction(nameof(GetById), new { id = checkingAccount.Id }, checkingAccount);
        }

        // PUT api/checking-account/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody] CheckingAccount checkingAccount)
        {
            if(id != checkingAccount.Id) { return NotFound();  }

            _checkingAccountService.Update(checkingAccount);

            return NoContent();
        }

        // DELETE api/checking-account/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            var checkingAccount = _checkingAccountService.FindById(id);

            if(checkingAccount == null) { return NotFound(); }

            _checkingAccountService.Remove(checkingAccount);

            return NoContent();
        }

        // POST api/checking-account/5/credit/
        [HttpPost("{id}/credit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult PostCredit(int id, [FromBody] decimal value)
        {
            var checkingAccount = _checkingAccountService.FindById(id);

            if (checkingAccount == null) { return NotFound(); }

            _checkingAccountService.Credit(checkingAccount, value);

            return NoContent();
        }

        // POST api/checking-account/5/debit/
        [HttpPost("{id}/debit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult PostDebit(int id, [FromBody] decimal value)
        {
            var checkingAccount = _checkingAccountService.FindById(id);

            if (checkingAccount == null) { return NotFound(); }

            _checkingAccountService.Debit(checkingAccount, value);

            return NoContent();
        }

        // POST api/checking-account/5/transfer/6
        [HttpPost("{originId}/transfer/{destinationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult PostTransfer(int originId, int destinationId, [FromBody] decimal value)
        {
            var originAccount = _checkingAccountService.FindById(originId);
            var destinationAccount = _checkingAccountService.FindById(destinationId);

            if (originAccount == null || destinationAccount == null)
            {
                return NotFound();
            }

            _checkingAccountService.Transfer(originAccount, destinationAccount, value);

            return NoContent();
        }
    }
}
