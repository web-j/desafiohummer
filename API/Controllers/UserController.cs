using System;
using System.Collections.Generic;
using Application.Interfaces;
using DTO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IApplicationServiceUser _applicationServiceUser;

        public UserController(IApplicationServiceUser applicationServiceUser)
        {
            _applicationServiceUser = applicationServiceUser;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceUser.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceUser.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return NotFound();

                _applicationServiceUser.Add(userDTO);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        [Authorize]
        public ActionResult Put([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return NotFound();

                _applicationServiceUser.Update(userDTO);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Authorize]
        public ActionResult Remove([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return NotFound();

                _applicationServiceUser.Remove(userDTO);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
