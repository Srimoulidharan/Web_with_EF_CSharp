using Microsoft.AspNetCore.Mvc;
using Student_with_EF.Data;
using Student_with_EF.Models;

namespace Student_with_EF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        StudentDBContext _context;
        public StudentController(StudentDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.student);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _context.student.FindAsync(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var student = await _context.student.FindAsync(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            _context.student.Remove(student);
            await _context.SaveChangesAsync();

            return Ok("Student deleted");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, Student s)
        {
            var student = await _context.student.FindAsync(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            student.Name = s.Name;
            student.PhoneNumber = s.PhoneNumber;
            student.Department = s.Department;

            await _context.SaveChangesAsync();
            return Ok("Student Updated");
        }
        [HttpPost()]
        public  IActionResult Posting(Student s)
        {
            if (s != null)
            {
                _context.student.Add(s);
                _context.SaveChanges();
                return Ok("Student  Added successfully");
            }
            else
            {
                return BadRequest("Student  unable to add ");
            }
        }

    }
}
