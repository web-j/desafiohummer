﻿namespace Domain.Models
{
    public class UserEvent
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
