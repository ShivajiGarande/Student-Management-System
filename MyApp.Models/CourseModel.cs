using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }
        
        [Required]
        public string CourseName { get; set; }

        [Required]
        public int? Fees { get; set; }

    }
}
