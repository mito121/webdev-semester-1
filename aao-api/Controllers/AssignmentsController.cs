using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aao_api.Models;

namespace aao_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly AlexAndersenDBContext _context;

        public AssignmentsController(AlexAndersenDBContext context)
        {
            _context = context;
        }

        // GET: api/Assignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignments()
        {
            return await _context.Assignments.ToListAsync();
        }

        // GET: api/assignments/available
        [Route("available")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAvailableAssignments()
        {
            var availableAssignments = new List<Assignment>();

            await foreach (var assigment in _context.Assignments)
            {
                if (assigment.Available == true)
                {
                    availableAssignments.Add(assigment);
                }
            }

            return availableAssignments;
        }

        // GET: api/Assignments/user/5
        [Route("user/{driverUserId}")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetUserAssignments(int driverUserId)
        {
            var userAssignments = new List<Assignment>();

            await foreach (var assigment in _context.Assignments)
            {
                if (assigment.DriverUserId == driverUserId)
                {
                    userAssignments.Add(assigment);
                }
            }

            return userAssignments;
        }







        // GET: api/Assignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return assignment;
        }

        // PUT: api/Assignments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignment(int id, Assignment assignment)
        {
            if (id != assignment.AssignmentId)
            {
                return BadRequest();
            }

            _context.Entry(assignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Assignments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Assignment>> PostAssignment(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetAssignment", new { id = assignment.AssignmentId }, assignment);
            return CreatedAtAction(nameof(GetAssignment), new { id = assignment.AssignmentId }, assignment);

        }

        // DELETE: api/Assignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.AssignmentId == id);
        }
    }
}
