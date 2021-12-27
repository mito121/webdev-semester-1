using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> MyTrips()
        {
            string Baseurl = "https://localhost:44336/";
            // Get from DB
            //IEnumerable<Assignment> objList = _db.Assignments;
            //return View(objList);

            // Get from API
            HttpClientHandler clientHandler = new HttpClientHandler();
            // Do this to avoid Untrusted root
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            List<Assignment> UserAssigments = new List<Assignment>();
            // Pass the handler to httpclient to avoid untrusted root
            using (var client = new HttpClient(clientHandler))
            {
                // Pass service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                // Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // Send request to web api REST service method GetTodoItems using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/assignments");
                // Check result
                if (Res.IsSuccessStatusCode)
                {
                    //Store the response details recieved from web api
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    //Deserialize response recieved from web api and store into TodoItems list
                    UserAssigments = JsonConvert.DeserializeObject<List<Assignment>>(Response);
                }
                // Pass list to view
                return View(UserAssigments);
            }
        }

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
    }
}
