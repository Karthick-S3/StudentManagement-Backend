using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Contracts;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //get students
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await _studentRepository.GetStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        //get students by id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudents(int id)
        {
            try
            {
                var students = await _studentRepository.GetStudentById(id);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //get students leave percentage by id

        [HttpGet("leavepercentage/{id}")]
        public async Task<IActionResult> GetLeavePercentage(int id)
        {
            try
            {
                var students = await _studentRepository.GetLeavePercentage(id);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //get students grade wise by id
        [HttpGet("gradewise")]
        public async Task<IActionResult> GetStudentGradeWise()
        {
            try
            {
                var students = await _studentRepository.GetStudentGradeWise();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        //get students parent details 

        [HttpGet("parentdetails")]
        public async Task<IActionResult> GetParentDetails()
        {
            try
            {
                var students = await _studentRepository.GetParentDetails();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //delete student from table

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var students = await _studentRepository.GetStudentById(id);
                if (students == null)
                    return NotFound();
                await _studentRepository.DeleteStudent(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        //update student 
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            try
            {
                var students = await _studentRepository.GetStudentById(id);
                if (students == null)
                    return NotFound();
                await _studentRepository.UpdateStudent(id, student);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        //insert student
        [HttpPost]
        public async Task<IActionResult> GetStudents(Student student)
        {
            try
            {
                var students = await _studentRepository.AddStudent(student);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




    }
}
