using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtareaNew.Models;
using ArtareaNew.Helper;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace ArtareaNew.Controllers
{
    public class AccountController : Controller
    {
        string secret = "5yHsVH4JfZDcapGPKrbhUQ6WHwMJaSZx";

        ArtareaEntities _db = new ArtareaEntities();

        // GET: Account
        public ActionResult Register()
        {
            var freelancer = LoginHelper.currentUser();

            if (freelancer != null)
            {
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Username, Email, Password, RepeatPassword")]RegisterModel Admin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_db.Admins.Where(x => x.Email == Admin.Email).Count() > 0)
                    {
                        ViewBag.RegistrationFailed = "ასეთი ელ.ფოსტით მომხმარებელი დარეგისტრირებულია";
                        return View();
                    }
                    else
                    {
                        Admin AdminTbl = new Admin();
                        AdminTbl.Username = Admin.Username.Trim();
                        AdminTbl.Email = Admin.Email.Trim();
                        AdminTbl.Password = PasswordHashHelper.Encrypt(secret + Admin.Password.Trim());
                        AdminTbl.Createdate = DateTime.Now;
                        _db.Admins.Add(AdminTbl);
                        _db.SaveChanges();


                        ViewBag.RegistrationSuccess = "თქვენ წარმატებით დარეგისტრირდით, გთხოვთ გაიაროთ ავტორიზაცია";
                        return View();
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return View();
        }


        public ActionResult Login()
        {
            var currentUser = LoginHelper.currentUser();


            if (currentUser != null)
            {
                return RedirectToAction("Index", "Admin");
            }


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login)
        {
            var hashedPassword = PasswordHashHelper.Encrypt(secret + login.Password);

            Admin Admin = _db.Admins.FirstOrDefault(x => x.Email == login.Email && x.Password == hashedPassword);

            if (Admin == null)
            {
                ViewBag.message = "მომხმარებლის სახელი ან პაროლი არასწორია";
                return View();
            }
            else
            {
                Session["LoggedInUser"] = Admin;

                return RedirectToAction("Index", "Admin");
            }


        }


        public ActionResult Logout()
        {
            LoginHelper.Logout();
            return RedirectToAction("Index", "Home");
        }


    }
}