using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Domain.Models;
using Services.Base;

namespace Services.Services
{
    public class ServiceEvent : ServiceBase<Event>, IServiceEvent
    {
        public readonly IRepositoryEvent _repositoryEvent;

        public ServiceEvent(IRepositoryEvent repositoryEvent) : base(repositoryEvent)
        {
            _repositoryEvent = repositoryEvent;
        }
    }
}
