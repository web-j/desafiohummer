using DTO.DTO;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServiceUserEvent
    {
        IEnumerable<UserEventDTO> GetAll();

        UserEventDTO GetById(int id);

        void Add(UserEventDTO obj);

        void Update(UserEventDTO obj);

        void Remove(UserEventDTO obj);

        void Dispose();
    }
}
