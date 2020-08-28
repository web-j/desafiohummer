using Commons.Enums;
using Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Event : BaseModel
    {
        public Event()
        {
            UserEvent = new HashSet<UserEvent>();
        }

        public virtual ICollection<UserEvent> UserEvent { get; set; }

        public string EventName { get; set; }
        public DateTimeOffset EventDate { get; set; }
        public EStatusEvent StatusEvent { get; set; }

    }
}
