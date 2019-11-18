using HostelNepal.Models;
using HostelNepal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HostelNepal.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        HostelNepalDBEntities db = new HostelNepalDBEntities();
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel l, string returnUrl = "")
        {
            var users = db.tblusers.Where(x => x.Email == l.Username || x.UserName == l.Username && x.Password == l.Password).FirstOrDefault();
            if (users != null)
            {
                FormsAuthentication.SetAuthCookie(users.UserName, l.RememberMe);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Opening");
                }


            }
            else
            {
                ModelState.AddModelError("", "Invalid User");
            }
            return View("Login");
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Opening");
        }
        [Authorize]
        public ActionResult Photo(string name)
        {
            foreach (var item in db.tblStudents.ToList())
            {
                if (item.UserName == name)
                {
                    return PartialView("PhotoStudent", item);
                }
            }
            foreach (var item in db.tblWardens.ToList())
            {
                if (item.UserName == name)
                {
                    return PartialView("PhotoWarden", item);
                }
            }
            return PartialView("Photo");
        }


        public ActionResult Registration(string user)
        {
            if(user=="warden")
            {
                return View("Warden");
            }
            else
            {
                return View("Student");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(StudentRegistrationViewModel ts = null, WardenRegistrationViewModel tw = null)
        {
            
           
            tbluser us = new tbluser();
            if (ts.StudentUserName!= null)
            {
                if (ts.StudentId == 0)
                {
                    tblStudent student = new tblStudent();
                    HttpPostedFileBase pic = Request.Files["StudentPhoto"];
                    HttpPostedFileBase avt = Request.Files["AvatarPhoto"];
                    student.UserName = ts.StudentUserName;
                    student.StudentName = ts.StudentName;
                    student.PermanentAddress = ts.PermanentAddress;
                    student.TemporaryAddress = ts.TemporaryAddress;
                    student.Phone = ts.StudentPhone;
                    student.Email = ts.StudentEmail;
                    student.Education = ts.Education;
                    student.DOB = ts.DOB;
                    student.Age = Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(student.DOB.Value.Year);
                    student.Photo = pic.FileName;
                    student.AvatarPhoto = avt.FileName;
                    student.UserName = ts.StudentUserName;
                    student.Password = ts.StudentPassword;
                    us.UserName = ts.StudentUserName;
                    us.Password = ts.StudentPassword;
                    us.Email = ts.StudentEmail;
                    if (pic.ContentLength > 0)
                    {
                        pic.SaveAs(Path.Combine(Server.MapPath("~/Images/Student"), pic.FileName));
                    }
                    if (avt.ContentLength > 0)
                    {
                        avt.SaveAs(Path.Combine(Server.MapPath("~/Images/Student"), avt.FileName));
                    }
                    db.tblusers.Add(us);
                    db.tblStudents.Add(student);
                    db.SaveChanges();
                    tbluser tb = db.tblusers.Where(x => x.UserName == student.UserName).FirstOrDefault();
                    tblUserRole tr = new tblUserRole();
                    tr.UserId = tb.UserId;
                    tr.RoleId = 2;
                    db.tblUserRoles.Add(tr);
                    db.SaveChanges();
                }
                else
                {
                    StudentRegistrationViewModel sm = ts;
                    tblStudent student = db.tblStudents.Where(x => x.StudentId == sm.StudentId).FirstOrDefault();
                    HttpPostedFileBase pic = Request.Files["StudentPhoto"];
                    HttpPostedFileBase avt = Request.Files["AvatarPhoto"];
                    student.UserName = sm.StudentUserName;
                    student.StudentName = sm.StudentName+" " + sm.StudentSurName;
                    student.PermanentAddress = sm.PermanentAddress;
                    student.TemporaryAddress = sm.TemporaryAddress;
                    student.Phone = sm.StudentPhone;
                    student.Email = sm.StudentEmail;
                    student.Education = sm.Education;
                    student.DOB = sm.DOB;
                    student.Testomonial = sm.Testomonial;
                    student.Age = Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(student.DOB.Value.Year);
                    if (pic.ContentLength > 0)
                    {
                        System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Student/"), sm.StudentPhoto));
                        student.Photo = pic.FileName;
                        avt.SaveAs(Path.Combine(Server.MapPath("~/Images/Student/"), pic.FileName));
                    }
                    if (avt.ContentLength > 0)
                    {
                        System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Student/"), sm.AvatarPhoto));
                        student.AvatarPhoto = avt.FileName;
                        avt.SaveAs(Path.Combine(Server.MapPath("~/Images/Student/"), avt.FileName));
                    }
                    student.UserName = sm.StudentUserName;
                    student.Password = sm.StudentPassword;
                    foreach (var item in db.tblusers.ToList())
                    {
                        if (item.UserName == User.Identity.Name)
                        {
                            item.UserName = sm.StudentUserName;
                            item.Email = sm.StudentEmail;
                            item.Password = sm.StudentPassword;
                        }
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index", "Opening");
                }
            }

            if (tw.UserName != null)
            {
                if (tw.WardenId == 0)
                {
                    tblWarden warden = new tblWarden();
                    HttpPostedFileBase fup = Request.Files["Photo"];
                    var filename = fup.FileName;
                    warden.WardenName = tw.WardenName + " " + tw.WardenSurName;
                    warden.WardenAddress = tw.WardenAddress;
                    warden.WardenPhone = tw.WardenPhone;
                    warden.Email = tw.Email;
                    warden.Photo = filename;
                    warden.UserName = tw.UserName;
                    warden.Password = tw.Password;
                    us.UserName = tw.UserName;
                    us.Password = tw.Password;
                    us.Email = tw.Email;
                    if (fup.ContentLength > 0)
                    {
                        fup.SaveAs(Path.Combine(Server.MapPath("~/Images/Warden/"), fup.FileName));
                    }
                    db.tblusers.Add(us);
                    db.tblWardens.Add(warden);
                    db.SaveChanges();
                    tbluser tb = db.tblusers.Where(x => x.UserName == warden.UserName).FirstOrDefault();

                    tblUserRole tr = new tblUserRole();
                    tr.UserId = tb.UserId;
                    tr.RoleId = 3;
                    db.tblUserRoles.Add(tr);
                    db.SaveChanges();

                }
                else {
                    tblWarden warden = db.tblWardens.Where(x => x.WardenId == tw.WardenId).FirstOrDefault();
                    HttpPostedFileBase fup = Request.Files["Photo"];
                    warden.WardenName = tw.WardenName + " " + tw.WardenSurName;
                    warden.WardenAddress = tw.WardenAddress;
                    warden.WardenPhone = tw.WardenPhone;
                    warden.Email = tw.Email;
                    warden.Password = tw.Password;
                    if (fup.ContentLength > 0)
                    {
                        System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Warden/"), tw.Photo));
                        warden.Photo = fup.FileName;
                        fup.SaveAs(Path.Combine(Server.MapPath("~/Images/Warden/"), fup.FileName));
                    }

                    warden.UserName = tw.UserName;
                    foreach (var item in db.tblusers.ToList())
                    {
                        if (item.UserName == User.Identity.Name)
                        {
                            item.Password = tw.Password;
                            item.UserName = tw.UserName;
                            item.Email = tw.Email;
                        }
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index", "Opening");
                }
                
            }
            return RedirectToAction("Login", "Account");
        }
        public JsonResult CheckUsernameAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = db.tblusers.Where(x => x.UserName == userdata).SingleOrDefault();
            if (SeachData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }
        public JsonResult CheckEmailAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = db.tblusers.Where(x => x.Email == userdata).SingleOrDefault();
            if (SeachData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit()
        {
            if (User.IsInRole("warden"))
            {
                WardenRegistrationViewModel wm = new WardenRegistrationViewModel();
                foreach (var item in db.tblWardens.ToList())
                {
                    if (item.UserName == User.Identity.Name)
                    {
                        wm.WardenId = item.WardenId;
                        wm.UserName = item.UserName;
                        wm.WardenAddress = item.WardenAddress;
                        string[] name = item.WardenName.Split(' ');
                        wm.WardenName = name[0];
                        wm.WardenSurName = name[1];
                        wm.WardenPhone = item.WardenPhone;
                        wm.Email = item.Email;
                        wm.WardenQuotes = item.WardenQuotes;
                        wm.Password = item.Password;
                        wm.ConfirmPassword = item.Password;
                        wm.Photo = item.Photo;
                    }
                }
                return View("Warden", wm);
            }
            else
            {
                StudentRegistrationViewModel wm = new StudentRegistrationViewModel();
                foreach (var item in db.tblStudents.ToList())
                {
                    if (item.UserName == User.Identity.Name)
                    {
                        wm.StudentId = item.StudentId;
                        wm.StudentUserName = item.UserName;
                        wm.PermanentAddress = item.PermanentAddress;
                        wm.TemporaryAddress = item.TemporaryAddress;
                        string[] name = item.StudentName.Split(' ');
                        wm.StudentName = name[0];
                        wm.StudentSurName = name[1];
                        wm.StudentPhone = item.Phone;
                        wm.StudentEmail = item.Email;
                        wm.Testomonial = item.Testomonial;
                        wm.DOB = item.DOB;
                        wm.Education = item.Education;
                        wm.AvatarPhoto = item.AvatarPhoto;
                        wm.StudentPhoto = item.Photo;
                        wm.StudentPassword = item.Password;
                        wm.ComfirmPassword = item.Password;
                    }
                }
                return View("Student", wm);
            }
        }

    }
    
}