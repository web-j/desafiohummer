using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Domain.Models;
using Services.Base;

namespace Services.Services
{
    public class ServiceUserEvent : ServiceBase<UserEvent>, IServiceUserEvent
    {
        public readonly IRepositoryUserEvent _repositoryUserEvent;

        public ServiceUserEvent(IRepositoryUserEvent repositoryUserEvent) : base(repositoryUserEvent)
        {
            _repositoryUserEvent = repositoryUserEvent;
        }
    }
}
