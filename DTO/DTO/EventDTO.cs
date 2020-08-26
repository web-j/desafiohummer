using DTO.DTO.Base;
using System;
using System.Collections.Generic;

namespace DTO.DTO
{
    public class EventDTO : BaseDTO
    {
        public EventDTO()
        {
            UserDTO = new HashSet<UserDTO>();
        }

        public virtual ICollection<UserDTO> UserDTO { get; set; }

        public string EventName { get; set; }
        public DateTimeOffset EventDate { get; set; }
    }
}
