using IpResolver.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpResolver
{
    public class DataBase : DbContext
    {
        public DataBase(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
