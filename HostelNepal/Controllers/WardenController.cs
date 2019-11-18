using HostelNepal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HostelNepal.Controllers
{
    public class WardenController : Controller
    {
        // GET: Warden
        HostelNepalDBEntities db = new HostelNepalDBEntities();
        public ActionResult Index()
        {
            ViewBag.Hostels = db.tblHostels.ToList();
            List<tblWarden> lst = db.tblWardens.ToList();
            return View(lst);
        }
        public ActionResult SingleWarden(int id)
        {
            ViewBag.List = new List<tblHostel>();
            ViewBag.Rooms = db.tblRooms.ToList();
            ViewBag.Hostels = db.tblHostels.ToList();
            tblWarden tb = db.tblWardens.Where(x => x.WardenId == id).FirstOrDefault();
            return View(tb);
        }
    }
}