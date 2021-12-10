using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using webdev_semester_1.Models;
using webdev_semester_1.ViewModels;

namespace webdev_semester_1.Controllers
{
    public class UserMessageController : Controller
    {
        public readonly AlexAndersenDBContext _db;

        private readonly UserManager<User> _userManager;

        public UserMessageController(AlexAndersenDBContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // GET Index
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var thisUserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var Messages =
                        (from message in _db.Messages
                         join user in _db.Users
                         on message.SenderUserId equals user.Id
                         where message.ReceiverUserId == thisUserId
                         select new UserMessageVM
                         {
                             UserID = user.Id,
                             FirstName = user.FirstName,
                             LastName = user.LastName,

                             MessageId = message.MessageId,
                             MessageText = message.MessageText,
                             ReceiverUserId = message.ReceiverUserId,
                             SenderUserId = message.SenderUserId,
                             Read = message.Read
                         }).OrderByDescending(x => x.MessageId).ToList();


            return View(Messages);
        }

        // GET: Single message
        [Authorize]
        public IActionResult Message(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // TODO: Uodate message Read status when message is clicked!!

            var Message =
                        (from message in _db.Messages
                         join user in _db.Users
                         on message.SenderUserId equals user.Id
                         where message.MessageId == id
                         select new UserMessageVM
                         {
                             FirstName = user.FirstName,
                             LastName = user.LastName,

                             MessageId = message.MessageId,
                             MessageText = message.MessageText,
                             ReceiverUserId = message.ReceiverUserId,
                             SenderUserId = message.SenderUserId,
                             Read = message.Read
                         }).ToList();

            if (Message == null)
            {
                return NotFound();
            }

            return View(Message[0]);
        }
    }
}
