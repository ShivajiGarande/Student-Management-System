using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class StudentModel
    {
        public int RollNumber { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string Gender { get; set; }

        public int? CourseId { get; set; }

    }
}
