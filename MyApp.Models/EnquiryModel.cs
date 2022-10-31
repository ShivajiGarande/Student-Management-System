using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class EnquiryModel
    {
        public int EnquiryId { get; set; }

       
        public string FirstName { get; set; }


      
        public string LastName { get; set; }


        public string Subject { get; set; }
    }
}
