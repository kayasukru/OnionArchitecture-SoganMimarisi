using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Abstractions.Services;
using OnionArchitecture.Application.DTOs;
using OnionArchitecture.Application.RequestParameters;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Services
{
    public class EventService : IEventService
    {
        private readonly EventifyDbContext _context;

        public EventService(EventifyDbContext context)
        {
            _context = context;
        }

        public async Task CreateEventAsync(CreateEventDTO createEventDTO)
        {
            if (createEventDTO is not null)
            {
                var newEvent = new Event()
                {
                    Title = createEventDTO.Title,
                    Date = createEventDTO.Date,
                    Location = createEventDTO.Location,
                };

                await _context.Events.AddAsync(newEvent);

                await _context.SaveChangesAsync();
            }
            else
                throw new NullReferenceException();
        }

        public async Task<IEnumerable<EventDTO>> GetAllEventsAsync(Pagination pagination)
        {
            return await _context.Events
                .AsNoTracking() //aşağıdaki alan şeklinde yapılacaksa bu özellik olmamalı
                .Select(x => new EventDTO()
            {
                Title = x.Title,
                Date = x.Date,
                Location = x.Location,
                /*
                Location = new Domain.ValueObject.Location()
                {
                    City = x.Location.City,
                    District = x.Location.District,
                    PostalCode = x.Location.PostalCode,
                    Street = x.Location.Street,
                },
                */
            })
                .Skip(pagination.PageCount * pagination.ItemCount)
                .Take(pagination.ItemCount)
                .ToListAsync();
        }
    }
}
