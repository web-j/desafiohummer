using Commons.ValueObjects;

namespace DTO.DTO
{
    public class UserEventDTO
    {
        public int UserId { get; set; }
        public virtual UserDTO User { get; set; }

        public int EventId { get; set; }
        public virtual EventDTO Event { get; set; }

        public Guest Guest { get; set; }
        public bool GuestDrink { get; set; }
        public bool ParticipantDrink { get; set; }
    }
}
