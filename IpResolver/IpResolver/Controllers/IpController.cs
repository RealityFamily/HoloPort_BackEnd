using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IpResolver.Models;
using Microsoft.EntityFrameworkCore;

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
                IpAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString()
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
    }
}