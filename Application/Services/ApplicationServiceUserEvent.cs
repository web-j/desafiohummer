using Adapter.Interfaces;
using Application.Interfaces;
using Core.Interfaces.Services;
using DTO.DTO;
using System.Collections.Generic;

namespace Application.Services
{
    public class ApplicationServiceUserEvent : IApplicationServiceUserEvent
    {
        private readonly IServiceUserEvent _serviceUserEvent;
        private readonly IMapperUserEvent _mapperUserEvent;

        public ApplicationServiceUserEvent(IServiceUserEvent serviceUserEvent, IMapperUserEvent mapperUserEvent)
        {
            _serviceUserEvent = serviceUserEvent;
            _mapperUserEvent = mapperUserEvent;
        }

        public IEnumerable<UserEventDTO> GetAll()
        {
            var obj = _serviceUserEvent.GetAll();

            return _mapperUserEvent.MapperToList(obj);
        }

        public UserEventDTO GetById(int id)
        {
            var obj = _serviceUserEvent.GetById(id);
            return _mapperUserEvent.MapperToDTO(obj);
        }

        public void Add(UserEventDTO eventDTO)
        {
            var obj = _mapperUserEvent.MapperToEntity(eventDTO);
            _serviceUserEvent.Add(obj);
        }

        public void Update(UserEventDTO eventDTO)
        {
            var obj = _mapperUserEvent.MapperToEntity(eventDTO);
            _serviceUserEvent.Update(obj);
        }

        public void Remove(UserEventDTO eventDTO)
        {
            var obj = _mapperUserEvent.MapperToEntity(eventDTO);
            _serviceUserEvent.Remove(obj);
        }

        public void Dispose()
        {
            _serviceUserEvent.Dispose();
        }
    }
}
