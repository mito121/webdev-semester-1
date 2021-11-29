using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdev_semester_1.Models;

namespace webdev_semester_1.Controllers
{
    public class AssignmentController : Controller
    {
        public readonly AlexAndersenDBContext _db;

        public AssignmentController(AlexAndersenDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult MyTrips()
        {
            //List<Assignment> assignments = new List<Assignment>();
            IEnumerable<Assignment> objList = _db.Assignments;

            return View(objList);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Assignments.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
