using Core.Interfaces.Repositories;
using Data;
using Domain.Models;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
    public class RepositoryUserEvent : RepositoryBase<UserEvent>, IRepositoryUserEvent
    {
        private readonly SQLContext _context;

        public RepositoryUserEvent(SQLContext context) : base(context)
        {
            _context = context;
        }
    }
}
