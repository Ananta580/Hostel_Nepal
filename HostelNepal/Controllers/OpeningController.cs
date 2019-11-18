using HostelNepal.Models;
using HostelNepal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HostelNepal.Controllers
{
    public class OpeningController : Controller
    {
        // GET: Opening
        HostelNepalDBEntities db = new HostelNepalDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Search()
        {
            ViewBag.Sitters = db.tblRooms.ToList();
            ViewBag.Address = db.tblHostels.ToList();
            return PartialView("_Search");
        }
        [HttpPost]
        public ActionResult _Search(SearchViewModel searchView)
        {
            return RedirectToAction("Index");
        }
        public ActionResult _Banner()
        {
            ViewBag.Rooms = db.tblRooms.ToList();
            List<tblBanner> lst = db.tblBanners.Where(x => x.Activated =="True" || x.Activated == "true").ToList();
            return PartialView("_Banner",lst);
        }
        public ActionResult _LatestHostel()
        {
            ViewBag.Rooms = db.tblRooms.ToList();
            List<tblHostel> lst = db.tblHostels.Where(x => x.Latest == "True" || x.Latest == "true").ToList();
            return PartialView("_LatestHostel", lst);
        }
        public ActionResult _BestWarden()
        {
            
            ViewBag.Hostels = db.tblHostels.ToList();
            List<tblWarden> lst = db.tblWardens.Where(x => x.Best == "True" || x.Best == "true").ToList();
            return PartialView("_BestWarden", lst);
        }
        public ActionResult _LatestNews()
        {
            List<tblNew> lst = db.tblNews.ToList();
            return PartialView("_LatestNews", lst);
        }
        public ActionResult _Testomonial()
        {
            List<tblStudent> lst = db.tblStudents.Where(x=>x.Testomonial!=null).ToList();
            return PartialView("_TestoMonial", lst);
        }
    }
}