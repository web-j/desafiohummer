using Commons.ValueObjects;

namespace Domain.Models
{
    public class UserEvent
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public Guest Guest { get; set; }
        public bool? GuestDrink { get; set; }
        public bool? ParticipantDrink { get; set; }
    }
}
