using Adapter.Interfaces;
using Application.Interfaces;
using Commons.Enums;
using Core.Interfaces.Services;
using DTO.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class ApplicationServiceEvent : IApplicationServiceEvent
    {
        private readonly IServiceEvent _serviceEvent;
        private readonly IMapperEvent _mapperEvent;

        private readonly IApplicationServiceUserEvent _applicationServiceUserEvent;

        public ApplicationServiceEvent(IServiceEvent serviceEvent, IMapperEvent mapperEvent, IApplicationServiceUserEvent applicationServiceUserEvent)
        {
            _serviceEvent = serviceEvent;
            _mapperEvent = mapperEvent;

            _applicationServiceUserEvent = applicationServiceUserEvent;
        }

        public IEnumerable<EventDTO> GetAll()
        {
            var obj = _serviceEvent.GetAll();

            var not_deleted = obj.Where(a => a.Erased == EStatusErased.NOT_DELETED);

            return _mapperEvent.MapperToList(not_deleted);
        }

        public EventDTO GetById(int id)
        {
            var obj = _serviceEvent.GetById(id);
            var evento = _mapperEvent.MapperToDTO(obj);

            var userEvents = _applicationServiceUserEvent.GetAll();

            var listUserEventFiltered = from a in userEvents
                                        where a.EventId == evento.Id
                                        select a;

            foreach (var i in listUserEventFiltered)
            {
                evento.UserDTO.Add(i.User);
            }

            return evento;
        }

        public void Add(EventDTO eventDTO)
        {
            var obj = _mapperEvent.MapperToEntity(eventDTO);
            _serviceEvent.Add(obj);
        }

        public void Update(EventDTO eventDTO)
        {
            var obj = _mapperEvent.MapperToEntity(eventDTO);
            _serviceEvent.Update(obj);
        }

        public void Remove(EventDTO eventDTO)
        {
            var obj = _mapperEvent.MapperToEntity(eventDTO);
            _serviceEvent.Remove(obj);
        }

        public void Dispose()
        {
            _serviceEvent.Dispose();
        }
    }
}
