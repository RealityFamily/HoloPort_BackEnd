using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpResolver.Models
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }
        public List<Client> Users { get; set; }
    }
}
