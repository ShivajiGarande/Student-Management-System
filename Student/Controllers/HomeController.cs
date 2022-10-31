using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.DB.DBOperations;
using MyApp.Models;

namespace Student.Controllers
{
    public class HomeController : Controller
    {

        EnquiryRepository repository = null;
        public HomeController()
        {
            repository = new EnquiryRepository();
        }

        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Contact_Us()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Contact_Us(EnquiryModel enquiry)
        {
            if (ModelState.IsValid)
            {
                int EnquiryId = repository.AddEnquiry(enquiry);
                if (EnquiryId > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Your Enquiry Successfully Submited...";
                }
            }
            return View();
        }

    }
}
