using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webdev_semester_1.Models;
using webdev_semester_1.ViewModels;

namespace webdev_semester_1.Controllers
{
    public class UserAddressController : Controller
    {

        public readonly AlexAndersenDBContext _db;

        private readonly UserManager<User> _userManager;

        public UserAddressController(AlexAndersenDBContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        [HttpGet]
        // Set variable for database context
        

        // GET Index
        public IActionResult Index()
        {
            //IEnumerable<User> userList = _db.Users;
            //IEnumerable<Address> addressList = _db.Addresses;
            var thisUserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var UserProfile =
                        (from user in _db.Users
                        join address in _db.Addresses
                        on user.AddressId equals address.AddressId
                        where user.Id == thisUserId
                         select new UserProfileVM {
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


    }
}
