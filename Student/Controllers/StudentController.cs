using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Models;
using MyApp.DB.DBOperations;
using System.Web.Security;
using MyApp.DB;

namespace Student.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        StudentRepository repository = null;
        public StudentController()
        {
            repository = new StudentRepository();
        }


        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Trainer")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Trainer")]
        public ActionResult Create(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                int RollNumber = repository.AddStudent(model);

                if (RollNumber > 0)
                {
                    ModelState.Clear();
                    ViewBag.Issuccess = "Student Created Succesfully";
                }
            }
            return View();
        }

        public ActionResult DisplayStudent()
        {
            var result = repository.GetAllStudents();
            return View(result);
        }
        public ActionResult Details(int RollNumber)
        {
            var student = repository.GetStudent(RollNumber);
            return View(student);
        }


        [Authorize(Roles = "Admin,Trainer")]
        public ActionResult Edit(int RollNumber)
        {
            var student = repository.GetStudent(RollNumber);
            return View(student);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Trainer")]
        public ActionResult Edit(int RollNumber, StudentModel model)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateStudent(model.RollNumber, model);
                return RedirectToAction("DisplayStudent");
            }
            return View();
        }


        [Authorize(Roles = "Admin,Trainer")]
        public ActionResult Delete(int RollNumber)
        {
            repository.StudentDelete(RollNumber);
            return RedirectToAction("DisplayStudent");
        }
    }
}