using ASPCOREWEBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ASPCOREWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly MyDbContext context;

        public StudentsController(MyDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
          var data= await  context.Students.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var data = await context.Students.Where(i => i.StudentId == id).FirstOrDefaultAsync();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult<Student>>CreateStudent(Student student)
        {
            await context.AddAsync(student);
            await context.SaveChangesAsync();
            return Ok(student);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Student>>UpdateStudent(int Id,Student student)
        {
            if(Id!=student.StudentId)
            {
                return BadRequest();
            }
             context.Entry(student).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(student);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int Id)
        {
            var data = await context.Students.Where(i => i.StudentId == Id).FirstOrDefaultAsync();
            if(data!=null)
            {
                context.Students.Remove(data);
                await context.SaveChangesAsync();
                 return Ok(data);
            }
            return NotFound();
            
        }
    }
}
