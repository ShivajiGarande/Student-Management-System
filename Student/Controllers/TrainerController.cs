using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.DB.DBOperations;
using MyApp.Models;
using System.Web.Security;

namespace Student.Controllers
{
    [Authorize]
    public class TrainerController : Controller
    {
        TrainerRepository repository = null;


        public TrainerController()
        {
            repository = new TrainerRepository();
        }

        // GET: Trainer
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(TrainerModel model)
        {
            if (ModelState.IsValid)
            {
                int TrainerId = repository.AddTrainer(model);

                if (TrainerId > 0)
                {
                    ModelState.Clear();
                    ViewBag.Issuccess = "Student Created Succesfully";
                }
            }

            return View();
        }

        public ActionResult DisplayTrainer()
        {
            var result = repository.GetAllTrainers();
            return View(result);
        }

        public ActionResult Details( int TrainerId )
        {
            var trainer = repository.GetTrainer(TrainerId);
            return View(trainer);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int TrainerId)
        {
            var trainer = repository.GetTrainer(TrainerId);
            return View(trainer);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int TrainerId, TrainerModel model)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateTrainer(model.TrainerId, model);
                return RedirectToAction("DisplayTrainer");
            }
            return View();
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int TrainerId)
        {
            repository.TrainerDelete(TrainerId);
            return RedirectToAction("DisplayTrainer");
        }
    }
}