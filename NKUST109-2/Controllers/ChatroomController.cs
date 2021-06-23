using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NKUST109_2.Data;
using NKUST109_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NKUST109_2
{
    [Authorize]
    public class ChatroomController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ChatroomController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FetchMessage(int fromIndex, int longPollSec)
        {
            var messageQuery = dbContext.ChatMessage;
            DateTime endTime = DateTime.Now.AddSeconds(longPollSec);
            while (DateTime.Now.CompareTo(endTime) < 0)
            {
                if (messageQuery.Any())
                {
                    int latestMessageIndex = messageQuery.OrderBy(message => message.Id).Last().Id;
                    if (latestMessageIndex >= fromIndex)
                    {
                        IQueryable<Message> messages = messageQuery.Where(message => message.Id >= fromIndex);
                        return Json(messages);
                    }
                }
                Thread.Sleep(300);
            }
            return StatusCode(StatusCodes.Status408RequestTimeout);
        }

        [HttpPost]
        public IActionResult SendMessage(string msg)
        {
            if (msg == "")
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            Message message = new Message()
            {
                Content = msg,
                Author = HttpContext.User.Identity.Name.Split("@")[0],
                Timestamp = DateTime.Now
            };
            EntityEntry<Message> entity = dbContext.ChatMessage.Add(message);
            dbContext.SaveChanges();
            int latestId = entity.Entity.Id;
            return Json(latestId);
        }
    }
}