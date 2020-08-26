using Adapter.Interfaces;
using Domain.Models;
using DTO.DTO;
using System.Collections.Generic;

namespace Adapter.Mapper
{
    public class MapperEvent : IMapperEvent
    {
        readonly List<EventDTO> eventDTOs = new List<EventDTO>();

        public Event MapperToEntity(EventDTO item)
        {
            Event evento = new Event
            {
                Id = item.Id,
                Erased = item.Erased,
                Created = item.Created,
                LastUpdate = item.LastUpdate,

                EventName = item.EventName,
                EventDate = item.EventDate
                
            };

            return evento;
        }

        public IEnumerable<EventDTO> MapperToList(IEnumerable<Event> events)
        {
            foreach (var item in events)
            {
                EventDTO eventDTO = new EventDTO
                {
                    Id = item.Id,
                    Erased = item.Erased,
                    Created = item.Created,
                    LastUpdate = item.LastUpdate,

                    EventName = item.EventName,
                    EventDate = item.EventDate                    
                };

                eventDTOs.Add(eventDTO);
            }

            return eventDTOs;
        }

        public EventDTO MapperToDTO(Event item)
        {
            EventDTO eventDTO = new EventDTO
            {
                Id = item.Id,
                Erased = item.Erased,
                Created = item.Created,
                LastUpdate = item.LastUpdate,

                EventName = item.EventName,
                EventDate = item.EventDate
            };

            return eventDTO;
        }
    }
}
