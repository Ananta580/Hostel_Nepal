using HostelNepal.Models;
using HostelNepal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HostelNepal.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        HostelNepalDBEntities db = new HostelNepalDBEntities();
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult Banner()
        {
            List<BannerViewModel> lst = new List<BannerViewModel>();
            
            foreach (var item in db.tblBanners.Include("tblHostel").ToList())
            {
                BannerViewModel banner = new BannerViewModel();
                banner.BannerId = item.BannerId;
                    if (item.Activated == "true")
                    {

                        banner.Activated = true;
                    }
                    if (item.Activated == "false")
                    {
                        banner.Activated = false;
                    }
                    banner.HostelId = item.HostelId;
                    banner.Photo = item.Photo;
                    // banner.HostelName = item.tblHostel.HostelName;
                    lst.Add(banner);
            }
            return View("Banner",lst);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Banner(List<BannerViewModel> ban)
        {
            
            List<BannerViewModel> lst = new List<BannerViewModel>();
            foreach (var item in db.tblBanners.ToList())
            {
                foreach (var thing in ban)
                {
                    if (thing.Activated == true && thing.BannerId==item.BannerId)
                    {
                        item.Activated = "true";
                    }
                    if (thing.Activated == false && thing.BannerId == item.BannerId)
                    {
                        item.Activated = "false";
                    }
                    db.SaveChanges();
                }
            }
            foreach (var item in db.tblBanners.Include("tblHostel").ToList())
            {
                BannerViewModel banner = new BannerViewModel();
                banner.BannerId = item.BannerId;
                if (item.Activated == "true")
                {

                    banner.Activated = true;
                }
                if (item.Activated == "false")
                {
                    banner.Activated = false;
                }
                banner.HostelId = item.HostelId;
                banner.Photo = item.Photo;
                banner.HostelName = item.tblHostel.HostelName;
                lst.Add(banner);
            }
            return View("Banner", lst);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AddOrEdit(int id = 0)
        {
            ViewBag.Hostels = db.tblHostels.ToList();
            if (id == 0)
            {
                return View("AddOrEdit");
            }
            else
            {
               
                tblBanner tb = db.tblBanners.Where(x => x.BannerId == id).FirstOrDefault();
                BannerViewModel banner = new BannerViewModel();
                banner.BannerId = tb.BannerId;
                banner.HostelId = tb.HostelId;
                banner.HostelName = tb.tblHostel.HostelName;
                banner.Photo = tb.Photo;
                return View("AddOrEdit", banner);
            }
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddOrEdit(BannerViewModel banner)
        {
            if (banner.BannerId == 0)
            {
                HttpPostedFileBase fup = Request.Files["Photo"];
                tblBanner tb = new tblBanner();
                tb.HostelId = banner.HostelId;
                tb.Photo = fup.FileName;
                if (fup.ContentLength > 0)
                {
                    fup.SaveAs(Path.Combine(Server.MapPath("~/Images/Banner/"), fup.FileName));
                }
                db.tblBanners.Add(tb);
                db.SaveChanges();
                return RedirectToAction("Banner", "Admin");
            }
            else
            {
                HttpPostedFileBase fup = Request.Files["Photo"];
                tblBanner tb = db.tblBanners.Where(x => x.BannerId == banner.BannerId).FirstOrDefault();
                tb.HostelId = banner.HostelId;
                if (fup.ContentLength > 0)
                {
                    System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Banner/"), tb.Photo));
                    tb.Photo = fup.FileName;
                    fup.SaveAs(Path.Combine(Server.MapPath("~/Images/Banner/"), fup.FileName));
                }
                db.SaveChanges();
                return RedirectToAction("Banner", "Admin");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult News()
        {
            return View("News", db.tblNews.ToList());
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddOrEditNews(int id = 0)
        {
            if (id == 0)
            {
                return View("AddOrEditNews");
            }
            else
            {
                tblNew tn = db.tblNews.Where(x => x.NewsId == id).FirstOrDefault();
                return View("AddOrEditNews", tn);
            }
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddOrEditNews(tblNew news)
        {
            if (news.NewsId == 0)
            {
                HttpPostedFileBase fup = Request.Files["Photo"];
                news.Photo = fup.FileName;
                if (fup.ContentLength > 0)
                {
                    fup.SaveAs(Path.Combine(Server.MapPath("~/Images/News/"), fup.FileName));
                }
                db.tblNews.Add(news);
                db.SaveChanges();
                return RedirectToAction("News", "Admin");
            }
            else
            {
                HttpPostedFileBase fup = Request.Files["Photo"];
                tblNew tb = db.tblNews.Where(x => x.NewsId == news.NewsId).FirstOrDefault();
                tb.Title = news.Title;
                tb.Description = news.Description;
                if (fup.ContentLength > 0)
                {
                    System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/News/"), tb.Photo));
                    tb.Photo = fup.FileName;
                    fup.SaveAs(Path.Combine(Server.MapPath("~/Images/News/"), fup.FileName));
                }
                db.SaveChanges();
                return RedirectToAction("News", "Admin");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id,string name="")
        {
            if (name=="News")
            {
                tblNew news= db.tblNews.Where(x => x.NewsId == id).FirstOrDefault();
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/News/"), news.Photo));
                db.tblNews.Remove(news);
                db.SaveChanges();
                return RedirectToAction("News", "Admin");
            }
            if (name == "Banner")
            {
                tblBanner add = db.tblBanners.Where(x => x.BannerId == id).FirstOrDefault();
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Banner/"), add.Photo));
                db.tblBanners.Remove(add);
                db.SaveChanges();
                return RedirectToAction("Banner", "Admin");
            }
            return RedirectToAction("Index", "Opening");
        }
    }
}