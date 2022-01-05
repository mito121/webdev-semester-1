using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using webdev_semester_1.Models;
using static System.Net.Mime.MediaTypeNames;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace webdev_semester_1.Controllers
{
    public class AssignmentController : Controller
    {
        public readonly AlexAndersenDBContext _db;
        private readonly UserManager<User> _userManager;

        public AssignmentController(AlexAndersenDBContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> AvailableTripsAsync()
        {
            // Get data from API
            string Baseurl = "https://localhost:44336/";

            HttpClientHandler clientHandler = new HttpClientHandler();
            // Do this to avoid Untrusted root
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            List<Assignment> AvailableAssignments = new List<Assignment>();
            // Pass the handler to httpclient, again to avoid untrusted root
            using (var client = new HttpClient(clientHandler))
            {
                // Pass service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                // Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // Send request to web api REST service method GetUserAssignments
                HttpResponseMessage Res = await client.GetAsync($"api/assignments/available");
                // Check result
                if (Res.IsSuccessStatusCode)
                {
                    //Store the response details recieved from web api
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    //Deserialize response recieved from web api and store into TodoItems list
                    AvailableAssignments = JsonConvert.DeserializeObject<List<Assignment>>(Response);
                }
                // Pass list to view
                return View(AvailableAssignments);
            }
        }

        [Authorize]
        public async Task<IActionResult> MyTrips()
        {
            // Get data from DB
            //IEnumerable<Assignment> objList = _db.Assignments;
            //return View(objList);

            // Get data from API
            string Baseurl = "https://localhost:44336/";
            var thisUserId = Int32.Parse(_userManager.GetUserId(User));

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            List<Assignment> UserAssigments = new List<Assignment>();
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/assignments/user/{thisUserId}");

                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    UserAssigments = JsonConvert.DeserializeObject<List<Assignment>>(Response);
                }
                return View(UserAssigments);
            }
        }

        // GET: Details
        [Authorize]
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

        // PUT: Request Assignment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestTrip(Assignment assignment)
        {
            string Baseurl = "https://localhost:44336/";
            var thisUserId = Int32.Parse(_userManager.GetUserId(User));

            int id = assignment.AssignmentId;

            assignment.Available = false;
            assignment.DriverUserId = thisUserId;

            StringContent modifiedAssignment = new StringContent(JsonSerializer.Serialize(assignment), Encoding.UTF8, Application.Json);

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.PutAsync($"api/assignments/{id}", modifiedAssignment);

                return RedirectToAction("Details", "Assignment", new { id });
            }
        }


        // PUT: Cancel Assignment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelTrip(Assignment assignment)
        {
            string Baseurl = "https://localhost:44336/";

            int id = assignment.AssignmentId;

            assignment.Available = true;
            assignment.DriverUserId = 0;

            StringContent modifiedAssignment = new StringContent(JsonSerializer.Serialize(assignment), Encoding.UTF8, Application.Json);

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.PutAsync($"api/assignments/{id}", modifiedAssignment);

                return RedirectToAction("Details", "Assignment", new { id });
            }
        }
    }
}
