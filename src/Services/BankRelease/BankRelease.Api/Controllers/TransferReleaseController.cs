using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BankRelease.Domain.Entity;
using BankRelease.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankRelease.Api.Controllers
{
    [Route("api/transfer-release")]
    public class TransferReleaseController : Controller
    {
        private readonly ITransferReleaseService _transferReleaseService;

        public TransferReleaseController(ITransferReleaseService transferReleaseService)
        {
            _transferReleaseService = transferReleaseService;
        }

        // GET: api/transfer-release
        [HttpGet]
        public ActionResult<IEnumerable<TransferRelease>> GetTransferReleases()
        {
            return _transferReleaseService.All().ToList();
        }

        // GET api/transfer-release/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TransferRelease))]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<TransferRelease>> GetById(int id)
        {
            var transferRelease = _transferReleaseService.FindById(id);

            if (transferRelease == null) { return NotFound(); }

            return Ok(transferRelease);
        }

        // POST api/transfer-release
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(TransferRelease))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<TransferRelease>>> Post([FromBody] TransferRelease transferRelease)
        {
            try
            {
                await _transferReleaseService.Add(transferRelease);
        
                return CreatedAtAction(nameof(GetById), new { id = transferRelease.Id }, transferRelease);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
