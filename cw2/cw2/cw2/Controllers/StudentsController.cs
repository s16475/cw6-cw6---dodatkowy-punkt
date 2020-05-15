using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using cw2.Models;
using cw2.Services;
using Microsoft.AspNetCore.Mvc;

namespace cw2.Controllers
{

    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        private readonly IStudentsDbService _dbService;
        private const string ConString = "Server=localhost;Database=master;User Id = sa; Password=G3X@4@52;";

        public StudentsController(IStudentsDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            var list = new List<Student>();
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select IndexNumber, FirstName, LastName from Student";
                con.Open();

                SqlDataReader dataReader = com.ExecuteReader();
                while (dataReader.Read())
                {
                    var st = new Student
                    {
                    IndexNumber = dataReader["IndexNumber"].ToString(),
                    FirstName = dataReader["FirstName"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                    //Birthdate = dataReader["BirthDate"].ToString(),
                    //Studies = dataReader["Studies"].ToString(),
                    //Semester = dataReader["Semester"].ToString()      
                    };
                    list.Add(st);
                }
            }
            return Ok(list);
        }
    }
}

