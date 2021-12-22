using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using webdev_semester_1.Models;
using webdev_semester_1.ViewModels;

namespace webdev_semester_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly AlexAndersenDBContext _db;

        public HomeController(ILogger<HomeController> logger, AlexAndersenDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            // Check if user has any unread messages
            var thisUserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var messageResult = (from message in _db.Messages
                                 where message.ReceiverUserId == thisUserId && message.Read == false
                                 select new Message { }
                                     ).ToList().Count();

            ViewBag.UnreadMessages = messageResult;

            return View();
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [Authorize]
        public IActionResult Calendar()
        {
            return View();
        }

        [Authorize]
        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Profile()
        {
            //IEnumerable<User> userList = _db.Users;
            //IEnumerable<Address> addressList = _db.Addresses;
            var thisUserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var UserProfile =
                        (from user in _db.Users
                         join address in _db.Addresses
                         on user.AddressId equals address.AddressId
                         where user.Id == thisUserId
                         select new UserProfileVM
                         {
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             AddressId = address.AddressId,
                             AddressName = address.AddressName,
                             CityId = address.CityId,
                             PostalCode = address.PostalCode
                         }).ToList();

            var theUser = UserProfile[0];

            return View(theUser);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
