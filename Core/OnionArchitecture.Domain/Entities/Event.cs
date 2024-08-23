using OnionArchitecture.Domain.Common;
using OnionArchitecture.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Domain.Entities
{
    public class Event : EntityBase
    {
        public string Title { get; set; }
        public DateTimeOffset Date { get; set; }
        public Location Location { get; set; }
    }
}
