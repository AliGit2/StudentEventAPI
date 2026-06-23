using Microsoft.AspNetCore.Mvc;
using StudentEventAPI.Data;
using StudentEventAPI.DTOs;
using StudentEventAPI.Models;

namespace StudentEventAPI.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentsController(AppDbContext context) { _context = context; }

        // POST /api/students
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                StudentNumber = dto.StudentNumber
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = student.Id },
                new StudentResponseDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    StudentNumber = student.StudentNumber
                });
        }

        // GET /api/students/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound(new { message = "Student not found." });
            return Ok(new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                StudentNumber = student.StudentNumber
            });
        }

        // GET /api/students
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _context.Students.Select(s => new StudentResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                StudentNumber = s.StudentNumber
            }).ToList();
            return Ok(students);
        }
    }
}