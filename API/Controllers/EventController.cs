using Application.Interfaces;
using DTO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class EventController : ControllerBase
    {
        public readonly IApplicationServiceEvent _applicationServiceEvent;

        public EventController(IApplicationServiceEvent applicationServiceEvent)
        {
            _applicationServiceEvent = applicationServiceEvent;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceEvent.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceEvent.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] EventDTO eventDTO)
        {
            try
            {
                if (eventDTO == null)
                    return NotFound();

                _applicationServiceEvent.Add(eventDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] EventDTO eventDTO)
        {
            try
            {
                if (eventDTO == null)
                    return NotFound();

                _applicationServiceEvent.Update(eventDTO);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public ActionResult Remove([FromBody] EventDTO eventDTO)
        {
            try
            {
                if (eventDTO == null)
                    return NotFound();

                _applicationServiceEvent.Remove(eventDTO);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
