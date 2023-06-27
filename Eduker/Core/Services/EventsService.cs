using Contract.ClientDto;
using Domain.Repositories;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services
{
    public class EventsService : IEventsService
    {
        private readonly IRepositoryManager _repositoryManager;

        public EventsService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<EventsDto>> GetAllAsync()
        {
            var entities = await _repositoryManager.EventsRepository.GetAllAsync();

            return entities.Select(e => new EventsDto
            {
                Id = e.Id,
                Name = e.Name,
                TimeStart = e.TimeStart,
                TimeEnd = e.TimeEnd,
                EducatorName = e.EducatorName,
                Address = e.Address,
                ImgPath=e.ImgPath
            });
        }

        public async Task<EventDetailsDto> GetInfoAsync(int id)
        {
            var entity = await _repositoryManager.EventsRepository.GetAsync(id);

            return new EventDetailsDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                TimeStart = entity.TimeStart,
                TimeEnd = entity.TimeEnd,
                EducatorName = entity.EducatorName,
                Address = entity.Address,
                Enrolled = entity.Enrolled,
                Price = entity.Price,
                ImgPath = entity.ImgPath
            };
        }
    }
}