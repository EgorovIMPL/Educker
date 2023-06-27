using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly EduckerDbContext _dbContext;

        public EventsRepository(EduckerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Events>> GetAllAsync()
        {
            return await _dbContext.Events.ToListAsync();
        }

        public async Task<Events> GetAsync(int id)
        {
            return await _dbContext.Events.FindAsync(id);
        }
    }
}