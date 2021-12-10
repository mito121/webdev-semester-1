using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdev_semester_1.Models;

namespace webdev_semester_1.Controllers
{
    public class MessageController : Controller
    {
        public readonly AlexAndersenDBContext _db;

        public MessageController(AlexAndersenDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Message> messages = _db.Messages;

            return View(messages);
        }
    }
}
