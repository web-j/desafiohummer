using System;
using System.Collections.Generic;
using Application.Interfaces;
using DTO.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserEventController : ControllerBase
    {
        public readonly IApplicationServiceUserEvent _applicationServiceUserEvent;

        public UserEventController(IApplicationServiceUserEvent applicationServiceUserEvent)
        {
            _applicationServiceUserEvent = applicationServiceUserEvent;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceUserEvent.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceUserEvent.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserEventDTO userEventDTO)
        {
            try
            {
                if (userEventDTO == null)
                    return NotFound();

                _applicationServiceUserEvent.Add(userEventDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] UserEventDTO userEventDTO)
        {
            try
            {
                if (userEventDTO == null)
                    return NotFound();

                _applicationServiceUserEvent.Update(userEventDTO);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("delete")]
        public ActionResult Remove([FromBody] UserEventDTO userEventDTO)
        {
            try
            {
                if (userEventDTO == null)
                    return NotFound();

                _applicationServiceUserEvent.Remove(userEventDTO);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
