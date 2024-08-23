using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Domain.ValueObject
{
    public class Location
    {
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
