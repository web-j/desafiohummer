using Domain.Models;
using DTO.DTO;
using System.Collections.Generic;

namespace Adapter.Interfaces
{
    public interface IMapperUserEvent
    {
        UserEvent MapperToEntity(UserEventDTO userEventDTO);

        IEnumerable<UserEventDTO> MapperToList(IEnumerable<UserEvent> userEvents);

        UserEventDTO MapperToDTO(UserEvent userEvent);
    }
}
