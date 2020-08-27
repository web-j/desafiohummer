using Commons.Enums;
using DTO.DTO.Base;
using System.Collections.Generic;

namespace DTO.DTO
{
    public class UserDTO : BaseDTO
    {
        public UserDTO()
        {
            EventDTO = new HashSet<EventDTO>();
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public EAccessRule AccessRole { get; set; }
        public EStatusEvent StatusEvent { get; set; }

        // execution time
        public virtual ICollection<EventDTO> EventDTO { get; set; }
    }
}
