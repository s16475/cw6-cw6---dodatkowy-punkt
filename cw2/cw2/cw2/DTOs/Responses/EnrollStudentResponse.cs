using System;
namespace cw2.DTOs.Responses
{
    public class EnrollStudentResponse
    {
        public int IdEnrollment { get; set; }
        public int Semester { get; set; }
        public int IdStudy { get; set; }
        public DateTime StartDate { get; set; }

    }
}
