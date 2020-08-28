using Adapter.Interfaces;
using Application.Interfaces;
using Commons.Enums;
using Core.Interfaces.Services;
using DTO.DTO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class ApplicationServiceEvent : IApplicationServiceEvent
    {
        private readonly IServiceEvent _serviceEvent;
        private readonly IMapperEvent _mapperEvent;

        private readonly IApplicationServiceUserEvent _applicationServiceUserEvent;
        private readonly IApplicationServiceUser _applicationServiceUser;

        private readonly IHttpContextAccessor _httpContextAccessor;


        public ApplicationServiceEvent(
            IServiceEvent serviceEvent, 
            IMapperEvent mapperEvent, 
            IApplicationServiceUserEvent applicationServiceUserEvent, 
            IApplicationServiceUser applicationServiceUser,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _serviceEvent = serviceEvent;
            _mapperEvent = mapperEvent;

            _applicationServiceUserEvent = applicationServiceUserEvent;
            _applicationServiceUser = applicationServiceUser;

            _httpContextAccessor = httpContextAccessor;
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

        // execution time
        public void ClosedEvent(EventDTO eventDTO)
        {
            var obj = _mapperEvent.MapperToEntity(eventDTO);

            obj.StatusEvent = EStatusEvent.CLOSED;

            _serviceEvent.Update(obj);
        }

        public IEnumerable<EventDTO> GetAllEventsAvailable()
        {
            ICollection<EventDTO> EventDTO = new List<EventDTO>();

            // busca o usuário da sessão
            var userSession = _httpContextAccessor.HttpContext.User.Identity.Name;

            // lista de eventos
            var obj = _serviceEvent.GetAll();
            var events = _mapperEvent.MapperToList(obj);

            // lista de eventos disponíveis
            var eventsInProgress = from a in events
                                  where a.StatusEvent == EStatusEvent.IN_PROGRESS
                                  select a.Id;

            // lista todos os userEvents
            var userEvents = _applicationServiceUserEvent.GetAll();

            // filtra os eventos que o usuário da sessão está participando
            var userEventsWithUserSession = from a in userEvents
                                            where a.UserId.ToString() == userSession
                                            select a.EventId;

            // compara as duas listas e retorna somente os id's de eventos disponíveis que o user não participa
            var list = eventsInProgress.Except(userEventsWithUserSession).ToList();

            // faz um get one em cada id e armazena num novo array
            foreach (var i in list)
            {
                var evento = GetById(i);
                EventDTO.Add(evento);
            }

            return EventDTO;
        }

        public IEnumerable<EventDTO> GetAllEventsUnavailable()
        {
            ICollection<EventDTO> EventDTOs = new List<EventDTO>();

            // lista de eventos
            var obj = _serviceEvent.GetAll();
            var events = _mapperEvent.MapperToList(obj);

            var userSession = _httpContextAccessor.HttpContext.User.Identity.Name;

            var userEvents = _applicationServiceUserEvent.GetAll();

            var userEventsWithUserSession = from a in userEvents
                                            where a.UserId.ToString() == userSession
                                            select a.EventId;



            foreach (var i in userEventsWithUserSession.ToList())
            {
                var eventsGet = GetById(i);
                EventDTOs.Add(eventsGet);
            }

            return EventDTOs;
        }


    }
}
