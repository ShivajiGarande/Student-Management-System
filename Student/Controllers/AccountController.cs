using MyApp.DB;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Student.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.Membership model)
        {
            using (var context = new sumatrain_dbEntities())
            {
                bool IsValid = context.User1.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                if (IsValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName,false);
                    return RedirectToAction("DisplayStudent", "Student");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName And Password");
                    return View();
                }
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User1 model)
        {
            using (var context = new sumatrain_dbEntities())
            {
                context.User1.Add(model);
                context.SaveChanges();
            }

            return RedirectToAction("LogIn");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }
    }
}