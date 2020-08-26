using Core.Interfaces.Repositories;
using Data;
using Domain.Models;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
    public class RepositoryEvent : RepositoryBase<Event>, IRepositoryEvent
    {
        private readonly SQLContext _context;

        public RepositoryEvent(SQLContext context) : base(context)
        {
            _context = context;
        }
    }
}
