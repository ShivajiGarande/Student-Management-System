using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Models;
using MyApp.DB.DBOperations;
using System.Web.Security;

namespace Student.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        CourseRepository repository = null;

        public CourseController()
        {
            repository = new CourseRepository();
        }

        // GET: Course

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        [Authorize(Roles = "Admin")]
        public ActionResult Create(CourseModel model)
        {
            if (ModelState.IsValid)
            {
                int CourseId = repository.AddCourse(model);

                if (CourseId > 0)
                {
                    ModelState.Clear();
                    ViewBag.Issuccess = "Course Created Succesfully";
                }
            }

            return View();
        }
        public ActionResult DisplayCourse()
        {
            var result = repository.GetAllCourses();
            return View(result);
        }

        public ActionResult Details(int CourseId, CourseModel model)
        {
            var course = repository.GetCourse(CourseId);
            return View(course);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int CourseId)
        {
            var course = repository.GetCourse(CourseId);
            return View(course);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int CourseId ,CourseModel model)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateCourse(model.CourseId, model);
                return RedirectToAction("DisplayCourse");
            }
            return View();
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int CourseId)
        {
            repository.CourseDelete(CourseId);
            return RedirectToAction("DisplayCourse");
        }
    }
}