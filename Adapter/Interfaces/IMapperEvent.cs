using Domain.Models;
using DTO.DTO;
using System.Collections.Generic;

namespace Adapter.Interfaces
{
    public interface IMapperEvent
    {
        Event MapperToEntity(EventDTO eventDTO);

        IEnumerable<EventDTO> MapperToList(IEnumerable<Event> events);

        EventDTO MapperToDTO(Event evento);
    }
}
