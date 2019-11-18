using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HostelNepal.Models;

namespace HostelNepal.Controllers
{
    public class OfficeController : Controller
    {
        // GET: Office
        HostelNepalDBEntities db = new HostelNepalDBEntities();
        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public ActionResult _Message()
        {
            return PartialView("_Message");
        }
        [HttpPost]
        public PartialViewResult _Message(tblMessage tm)
        {
            if (ModelState.IsValid)
            {
                tm.Subject = "To Warden";
                tm.Tag = "warden";
                db.tblMessages.Add(tm);
                db.SaveChanges();
            }
            return PartialView("_Message");
            
        }
        public ActionResult _MessageUs()
        {
            return PartialView("_MessageUs");
        }
        [HttpPost]
        public PartialViewResult _MessageUs(tblMessage tm)
        {
            if (ModelState.IsValid)
            {
                tm.Tag = "hostelnepal";
                db.tblMessages.Add(tm);
                db.SaveChanges();
            }
            return PartialView("_MessageUs");

        }
    }
}