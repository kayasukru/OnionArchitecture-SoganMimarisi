using OnionArchitecture.Application.DTOs;
using OnionArchitecture.Application.RequestParameters;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Abstractions.Services
{
    public interface IEventService
    {
        Task CreateEventAsync(CreateEventDTO createEventDTO);
        Task<IEnumerable<EventDTO>> GetAllEventsAsync(Pagination pagination);
    }
}
