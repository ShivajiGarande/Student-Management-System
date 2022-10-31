using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MyApp.Models
{
    public class TrainerModel
    {

        public int TrainerId { get; set; }

        [Required]
        public string TrainerName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int? Experience { get; set; }

    }
}
