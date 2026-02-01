using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRentalApplication.Models;
using WebAPIFundamenta.Models;

namespace WebAPIFundamenta.Controllers
{
    public class StudentController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public StudentController()
        {
            _context = new ApplicationDbContext();
        }

        // GET - api/Student/GetStudents
        [HttpGet]
        public IHttpActionResult GetAlStudent()
        {
            var data = _context.Students.ToList();
            return Ok(data);
        }

        // GET - api/Student/GetStudentById/1
        [HttpGet]
        public IHttpActionResult GetStudentById(int Id)
        {
            var data = _context.Students.FirstOrDefault(x => x.Id == Id);
            return Ok(data);
        }

        // POST - api/Student/AddNewStudent
        [HttpPost]
        public IHttpActionResult AddNewStudent(Students students)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid request");
            _context.Students.Add(students);
            _context.SaveChanges();
            return Ok(new
            {
                code = 200, 
                msg = "Student added successfully"
            });
        }

        // PUT - api/Student/UpdateStudent
        [HttpPut]
        public IHttpActionResult UpdateStudent(Students students)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid request");
            var studentData = _context.Students.FirstOrDefault(x => x.Id == students.Id);
            if (studentData == null)
                return NotFound();
            studentData.Name = students.Name;
            studentData.Age = students.Age;
            _context.SaveChanges();
            return Ok();
        }

        // DELETE - api/Student/1
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int Id) 
        {
            var studentData = _context.Students.FirstOrDefault(x => x.Id == Id);
            if (studentData == null)
                return NotFound();  
            _context.Students.Remove(studentData);
            _context.SaveChanges();
            return Ok();
        }
    }
}
