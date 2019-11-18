using HostelNepal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HostelNepal.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        HostelNepalDBEntities db = new HostelNepalDBEntities();
        public ActionResult Index()
        {
            ViewBag.Choice = db.tblChoices.ToList();
            List<tblStudent> lst =db.tblStudents.ToList();
            return View(lst);
        }
        public ActionResult StudentSingle(int id)
        {
            tblStudent tb = db.tblStudents.Where(x => x.StudentId == id).FirstOrDefault();
            return View(tb);
        }
    }
}