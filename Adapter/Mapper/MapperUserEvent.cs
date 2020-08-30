using Adapter.Interfaces;
using Domain.Models;
using DTO.DTO;
using System.Collections.Generic;

namespace Adapter.Mapper
{
    public class MapperUserEvent : IMapperUserEvent
    {
        readonly List<UserEventDTO> userEventDTOs = new List<UserEventDTO>();

        public UserEvent MapperToEntity(UserEventDTO item)
        {
            UserEvent userEvent = new UserEvent
            {
                EventId = item.EventId,
                UserId = item.UserId,
                Guest = item.Guest,
                GuestDrink = item.GuestDrink,
                ParticipantDrink = item.ParticipantDrink
            };

            return userEvent;
        }

        public IEnumerable<UserEventDTO> MapperToList(IEnumerable<UserEvent> userEvents)
        {
            foreach (var item in userEvents)
            {
                UserEventDTO userEventDTO = new UserEventDTO
                {
                    EventId = item.EventId,
                    UserId = item.UserId,

                    User = new UserDTO
                    {
                        Id = item.User.Id,
                        Name = item.User.Name,
                        Email = item.User.Email
                    },

                    Event = new EventDTO
                    {
                        Id = item.Event.Id,
                        EventName = item.Event.EventName,
                        EventDate = item.Event.EventDate
                    },

                    Guest = item.Guest,
                    GuestDrink = item.GuestDrink,
                    ParticipantDrink = item.ParticipantDrink
                };

                userEventDTOs.Add(userEventDTO);
            }

            return userEventDTOs;
        }

        public UserEventDTO MapperToDTO(UserEvent item)
        {
            UserEventDTO userEventDTO = new UserEventDTO
            {
                EventId = item.EventId,
                UserId = item.UserId,

                User = new UserDTO
                {
                    Id = item.User.Id
                },

                Event = new EventDTO
                {
                    Id = item.Event.Id
                },

                Guest = item.Guest,
                GuestDrink = item.GuestDrink,
                ParticipantDrink = item.ParticipantDrink
            };

            return userEventDTO;
        }
    }
}
