using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DB.DBOperations
{
    public class EnquiryRepository
    {
        public int AddEnquiry(EnquiryModel model)
        {
            using (var context = new sumatrain_dbEntities())
            {
                Enquiry enq = new Enquiry()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Subject = model.Subject

                };
                context.Enquiries.Add(enq);

                context.SaveChanges();

                return enq.EnquiryId;
            }
        }
    }
}
