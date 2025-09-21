using ITI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        ITIContext context;
        public DepartmentController(ITIContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult DisplayAllDepartments()
        {
            List<Department> depts = context.Departments.ToList();
            return Ok(depts);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult DisplayDepartmentById(int id)
        {
            Department dept = context.Departments.FirstOrDefault(d => d.Id == id);
            if (dept == null)
            {
                return NotFound();
            }
            return Created("found dept ", dept);
        }
        [HttpGet("{name:alpha}")]
        
        public IActionResult DisplayDepartmentByName(string name)
        {
            Department dept = context.Departments.FirstOrDefault(d => d.Name == name);
            if (dept == null)
            {
                return NotFound();
            }
            return Created("found dept ", dept);
        }

        [HttpPost]
        public IActionResult AddDepartment(Department dept)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Departments.Add(dept);
            context.SaveChanges();

            return CreatedAtAction(
                nameof(DisplayDepartmentById),
                new { id = dept.Id },
                dept
            );
        }
        [HttpPut]
        public IActionResult UpdateDepartment(Department dept)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingDept = context.Departments.FirstOrDefault(d => d.Id == dept.Id);
            if (existingDept == null)
            {
                return NotFound();
            }
            existingDept.Name = dept.Name;
            context.SaveChanges();
            return NoContent();
        }
    }

}
