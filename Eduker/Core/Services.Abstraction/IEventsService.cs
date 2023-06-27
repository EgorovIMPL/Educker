using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.ClientDto;

namespace Services.Abstraction
{
    public interface IEventsService
    {
        public Task<IEnumerable<EventsDto>> GetAllAsync();
        public Task<EventDetailsDto> GetInfoAsync(int id);
    }
}