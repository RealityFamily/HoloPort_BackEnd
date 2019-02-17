using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpResolver.Models
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
        public string IpAddress { get; set; }
        public Room Room { get; set; }
    }
}
