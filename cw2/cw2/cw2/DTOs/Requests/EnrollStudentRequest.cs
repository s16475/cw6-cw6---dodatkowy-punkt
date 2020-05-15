using System;
using System.ComponentModel.DataAnnotations;

namespace cw2.DTOs.Requests
{
    public class EnrollStudentRequest
    {
        [Required(ErrorMessage = "Musisz podać index")]
        [RegularExpression("^s[0-9]+$")]
        public string IndexNumber { get; set; }
        [Required(ErrorMessage = "Musisz podać imię")]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Musisz podać date urodzenia")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Musisz podać nazwisko")]
        [MaxLength(100)]
        public string BirthDate { get; set; }
        [Required(ErrorMessage = "Musisz podać kierunek studiów")]
        public string Studies { get; set; }

    }
}
