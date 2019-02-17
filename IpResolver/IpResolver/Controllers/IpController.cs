using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IpResolver.Models;
using Microsoft.EntityFrameworkCore;
using System.Timers;

namespace IpResolver.Controllers
{
    [Route("api/ip")]
    public class IpController : Controller
    {
        private readonly DataBase dbContext;

        public IpController(DataBase dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Connect()
        {
            Client client = new Client
            {
                IpAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                LifeTime = DateTime.Now.AddSeconds(20)
            };

            if (dbContext.Rooms.Count() == 0)
            {
                Room room = new Room()
                {
                    Users = new List<Client>(),
                    RoomName = "FirstRoom"
                };

                await dbContext.AddAsync(room);
                room.Users.Add(client);
                await dbContext.SaveChangesAsync();
                return Ok("Room has been created");
            }
            else
            {
                var resRoom = dbContext.Rooms.Include(r => r.Users).FirstOrDefault(r => r.RoomName == "FirstRoom");
                List<string> FullInfo = resRoom.Users.Select(s => s.IpAddress).ToList();
                resRoom.Users.Add(client);
                await dbContext.SaveChangesAsync();
                return Json(FullInfo);
            }
        }

        [HttpGet("Alive")]
        public async Task<IActionResult> Alive()
        {
            var resRoom = dbContext.Rooms.Include(r => r.Users).FirstOrDefault(r => r.RoomName == "FirstRoom");
            var client = resRoom.Users.FirstOrDefault(c => c.IpAddress == HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString());
            client.LifeTime = DateTime.UtcNow.AddSeconds(20);
            await dbContext.SaveChangesAsync();
            resRoom.Users.RemoveAll(c => c.LifeTime <= DateTime.Now);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}