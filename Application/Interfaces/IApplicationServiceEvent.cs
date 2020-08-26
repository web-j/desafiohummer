using DTO.DTO;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServiceEvent
    {
        IEnumerable<EventDTO> GetAll();

        EventDTO GetById(int id);

        void Add(EventDTO obj);

        void Update(EventDTO obj);

        void Remove(EventDTO obj);

        void Dispose();
    }
}
