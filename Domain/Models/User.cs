using Commons.Enums;
using Commons.ValueObjects;
using Domain.Models.Base;
using System.Collections.Generic;

namespace Domain.Models
{
    public class User : BaseModel
    {
        public User()
        {
            UserEvent = new HashSet<UserEvent>();
        }

        public virtual ICollection<UserEvent> UserEvent { get; set; }
        //public List<Guest> Guest { get; set; }

        public string Name { get; set; }
        public string Sirname { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public EAccessRule AccessRole { get; set; }
        public EStatusEvent StatusEvent { get; set; }        


    } 
}
