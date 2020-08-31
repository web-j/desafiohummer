using Commons.Enums;
using Commons.ValueObjects;
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
            Guest = new HashSet<Guest>();
        }

        public virtual ICollection<UserDTO> UserDTO { get; set; }
        public virtual ICollection<Guest> Guest { get; set; }
        public double TotalSpent { get; set; }
        public double TotalSpentDrink { get; set; }
        public double TotalSpentFood { get; set; }
        public double Totalcollected { get; set; }

        public string EventName { get; set; }
        public DateTimeOffset EventDate { get; set; }
        public EStatusEvent StatusEvent { get; set; }
    }
}
