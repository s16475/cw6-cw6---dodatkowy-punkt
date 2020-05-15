using System;
using cw2.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace cw2.Services
{
    public interface IStudentsDbService
    {
        IActionResult EnrollStudent(EnrollStudentRequest request);
        IActionResult PromoteStudent(PromoteStudentRequest promote);
        IActionResult GetStudent(string id);
    }
}
