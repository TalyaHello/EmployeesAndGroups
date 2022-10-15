using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeesAndGroups.Models;

namespace EmployeesAndGroups.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public GroupsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            var @group = await _context.Groups.FindAsync(id);

            if (@group == null)
            {
                return NotFound();
            }

            return @group;
        }

        [HttpGet("GetGroupEmployees/{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetGroupEmployees(int id)
        {
            var desiredGroup = await _context.Groups
                                             .Include(g => g.Employees)
                                             .FirstOrDefaultAsync(group => group.Id == id);
            if (desiredGroup == null)
                return NotFound();
            desiredGroup.Employees.ForEach(x => x.Groups = null);
            return desiredGroup.Employees;
        }

        [HttpGet("GetNotManagementGroupEmployees")]
        public async Task<ActionResult<List<Employee>>> GetNotManagementGroupEmployees(string letterText)
        {
            var groups = await _context.Groups
                     .Include(g => g.Employees)
                     .Where(g => g.Name != "Руководство")
                     .ToListAsync();
            if (groups.Count == 0)
                return NotFound();
            List<Employee> result = new List<Employee>();
            groups.ForEach(gr =>
            {
                gr.Employees.ForEach(x => x.Groups = null);
                result.AddRange(gr.Employees);
            });
            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, Group @group)
        {
            if (id != @group.Id)
            {
                return BadRequest();
            }

            _context.Entry(@group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group @group)
        {
            _context.Groups.Add(@group);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup", new { id = @group.Id }, @group);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var @group = await _context.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(@group);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}
