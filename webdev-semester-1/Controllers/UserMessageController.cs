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
            Users = _db.Users;
        }

        public IEnumerable<User> Users { get; set; }

        // GET Index
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var thisUserId = Int32.Parse(_userManager.GetUserId(User));

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

            // Update message read-status to true if not already true
            Message dbMessage = _db.Messages.Find(id);
            if(dbMessage.Read == false)
            {
                dbMessage.Read = true;
            }
            _db.SaveChanges();

            // Get the message and sender
            UserMessageVM messageResult =
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
                         }).SingleOrDefault();

            if (messageResult == null)
            {
                return NotFound();
            }

            return View(messageResult);
        }

        // GET: Send message
        [Authorize]
        public IActionResult Send()
        {
            ViewBag.Users = _db.Users;
            return View();
        }

        // POST: Send message
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SendAsync(SendMessageVM thisMessage)
        {
            if(thisMessage == null)
            {
                return NotFound();
            }

            Message message = new Message
            {
                SenderUserId = Int32.Parse(_userManager.GetUserId(User)),
                ReceiverUserId = thisMessage.RecieverUserId,
                MessageText = thisMessage.Message
            };

            await _db.Messages.AddAsync(message);

            int result = await _db.SaveChangesAsync();

            if(result != 0)
            {
               return RedirectToAction("Index");
            }

            // Something failed
            return View(thisMessage);
        }

        // POST: Delete message
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Message message = _db.Messages.Find(id);

            if (message != null)
            {
                _db.Messages.Remove(message);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
