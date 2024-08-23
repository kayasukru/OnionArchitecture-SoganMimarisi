using OnionArchitecture.Application.Abstractions.Services;
using OnionArchitecture.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Infrastructure.Services
{
    public class TextService : ITextService
    {
        public string FormatTextForEvent(IEnumerable<EventDTO> eventItems)
        {
            if (eventItems is null)
                throw new ArgumentNullException(nameof(eventItems));

            StringBuilder stringBuilder = new();

            foreach (var eventItem in eventItems)
            {
                if (eventItem is not null)
                    stringBuilder.AppendLine($"Event: {eventItem.Title} - Location: {eventItem.Location.City} - Date: {eventItem.Date.ToString("HH:mm - dd/mm/yyyy")}");
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
