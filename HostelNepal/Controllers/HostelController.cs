using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HostelNepal.Models;
using HostelNepal.Models.ViewModel;

namespace HostelNepal.Controllers
{
    public class HostelController : Controller
    {
        // GET: Hostel
        HostelNepalDBEntities db = new HostelNepalDBEntities();
        public ActionResult Index()
        {
            ViewBag.Students = db.tblStudents.ToList();
            ViewBag.Choices = db.tblChoices.ToList();
            ViewBag.Rooms = db.tblRooms.ToList();
            List<tblHostel> lst = db.tblHostels.ToList();
            return View(lst);
        }
        [Authorize(Roles ="Warden")]
        public ActionResult HostelIndex()
        {
                ViewBag.Rooms = db.tblRooms.ToList();
                foreach (var item in db.tblWardens.ToList())
                {
                    if (User.Identity.Name == item.UserName)
                    {
                        List<tblHostel> Wardenlist = db.tblHostels.Where(x => x.WardenId == item.WardenId).ToList();
                        if (Request.IsAuthenticated)
                        {
                            return View("WardenHostel", Wardenlist);
                        }
                    }
                }
            return RedirectToAction("Index", "Hostel");

        }
        [Authorize]
        public ActionResult BestChoice()
        {
            ViewBag.Rooms = db.tblRooms.ToList();
            List<tblChoice> lst = db.tblChoices.ToList();
            List<tblHostel> hostel = db.tblHostels.ToList();
            List<tblHostel> send = new List<tblHostel>();
            foreach (var item in lst)
            {
                foreach (var hst in hostel)
                {
                    if (item.HostelId == hst.HostelId)
                    {
                        send.Add(item.tblHostel);
                    }
                }

            }
            return View(send);
        }
        [Authorize(Roles ="Student")]
        public ActionResult StudentChoice()
        {
            ViewBag.Rooms = db.tblRooms.ToList();
            List<tblChoice> lst = db.tblChoices.ToList();
            List<tblHostel> hostel = db.tblHostels.ToList();
            List<tblHostel> send = new List<tblHostel>();
            foreach (var item in lst)
            {
                foreach (var hst in hostel)
                {
                    foreach (var std in db.tblStudents.ToList())
                    {
                        if (std.UserName == User.Identity.Name)
                        {
                            if (item.HostelId == hst.HostelId && std.StudentId==item.StudentId)
                            {
                                send.Add(item.tblHostel);
                            }
                        }
                    }
                    
                }

            }
            return View("StudentChoice",send);
        }
        [Authorize]
        public ActionResult Choose(int id)
        {
            tblChoice tc = new tblChoice();
            foreach (var item in db.tblStudents.ToList())
            {
                if (item.UserName == User.Identity.Name)
                {
                    tc.StudentId = item.StudentId;
                    tc.HostelId = id;
                    db.tblChoices.Add(tc);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Opening");
        }


        public ActionResult SingleHostel(int id)
        {
            ViewBag.Choices = db.tblChoices.ToList();
            ViewBag.Students = db.tblStudents.ToList();
            ViewBag.Room = db.tblRooms.ToList();
            ViewBag.Photo = db.tblPhotoes.ToList();
            tblHostel tb = db.tblHostels.Where(x => x.HostelId == id).FirstOrDefault();
            return View(tb);
        }
        [HttpGet]

        [Authorize(Roles = "Warden")]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View("AddOrEdit");
            }
            else
            {
                tblHostel th = db.tblHostels.Where(x => x.HostelId == id).FirstOrDefault();
                HostelViewModel hm = new HostelViewModel();
                tblPhoto photo = new tblPhoto();
                hm.HostelName = th.HostelName;
                hm.Description = th.Description;
                hm.Address = th.Address;
                hm.Phone = th.Phone;
                hm.Star = th.Star;
                hm.HostelId = id;
                hm.Capacity = th.Capacity;
                hm.DescriptionNext = th.DescriptionNext;
                hm.Facilites = th.Facilites;
                hm.Email = th.Email;
                hm.MapLocation = th.MapLocation;
                List<string> sth = new List<string>();
                foreach (var item in db.tblPhotoes.ToList())
                {

                    if (item.HostelId == id)
                    {
                        sth.Add(item.Photo);
                    }
                }
                hm.Photo = th.Photo;
                if (sth.Count != 0)
                {
                    hm.Photo1 = sth[0];
                    hm.Photo2 = sth[1];
                    hm.Photo3 = sth[2];
                }
                foreach (var item in db.tblPrices.ToList())
                {
                    List<tblRoom> to = db.tblRooms.Where(x => x.PriceId == item.PriceId).ToList();
                    foreach (var room in to)
                    {
                        if (room.RoomName == "One Sitter" && room.HostelId == id)
                        {
                            hm.OnesitterPrice = room.tblPrice.Price;
                        }
                        if (room.RoomName == "Two Sitter" && room.HostelId == id)
                        {
                            hm.TwositterPrice = room.tblPrice.Price;
                        }
                        if (room.RoomName == "Three Sitter" && room.HostelId == id)
                        {
                            hm.ThreesitterPrice = room.tblPrice.Price;
                        }
                    }
                }
                return View("AddOrEdit", hm);
            }
        }
        [HttpPost]
        [Authorize(Roles = "Warden")]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(HostelViewModel hm)
        {

            if (ModelState.IsValid)
            {
                if (hm.HostelId == 0)
                {
                    HttpPostedFileBase fup = Request.Files["Photo"];
                    HttpPostedFileBase one = Request.Files["Photo1"];
                    HttpPostedFileBase two = Request.Files["Photo2"];
                    HttpPostedFileBase three = Request.Files["Photo3"];
                    //Adding New One
                    tblHostel th = new tblHostel();
                    tblPhoto photo = new tblPhoto();
                    th.HostelName = hm.HostelName;
                    th.Description = hm.Description;
                    th.Address = hm.Address;
                    th.Phone = hm.Phone;
                    th.Star = hm.Star;
                    th.Capacity = hm.Capacity;
                    th.DescriptionNext = hm.DescriptionNext;
                    th.Facilites = hm.Facilites;
                    th.Photo = fup.FileName;
                    fup.SaveAs(Path.Combine(Server.MapPath("~/Images/Hostel/"), fup.FileName));
                    th.Email = hm.Email;
                    th.MapLocation = hm.MapLocation;
                    foreach (var item in db.tblWardens.ToList())
                    {
                        if (User.Identity.Name == item.UserName)
                        {
                            th.WardenId = item.WardenId;
                        }
                    }
                    db.tblHostels.Add(th);
                    db.SaveChanges();
                    tblRoom to1 = new tblRoom();
                    tblRoom to2 = new tblRoom();
                    tblRoom to3 = new tblRoom();
                    tblPrice pto1 = new tblPrice();
                    tblPrice pto2 = new tblPrice();
                    tblPrice pto3 = new tblPrice();
                    photo.Photo = one.FileName;
                    one.SaveAs(Path.Combine(Server.MapPath("~/Images/Hostel/"), one.FileName));
                    photo.HostelId = th.HostelId;
                    to1.RoomName = "One Sitter";
                    to1.HostelId = th.HostelId;
                    pto1.Price = hm.OnesitterPrice;
                    db.tblPhotoes.Add(photo);
                    db.tblPrices.Add(pto1);
                    db.SaveChanges();
                    to1.PriceId = pto1.PriceId;
                    db.tblRooms.Add(to1);
                    db.SaveChanges();
                    photo.Photo = two.FileName;
                    two.SaveAs(Path.Combine(Server.MapPath("~/Images/Hostel/"), two.FileName));
                    photo.HostelId = th.HostelId;
                    to2.RoomName = "Two Sitter";
                    to2.HostelId = th.HostelId;
                    pto2.Price = hm.TwositterPrice;
                    db.tblPhotoes.Add(photo);
                    db.tblPrices.Add(pto2);
                    db.SaveChanges();
                    to2.PriceId = pto2.PriceId;
                    db.tblRooms.Add(to2);
                    db.SaveChanges();
                    photo.Photo = three.FileName;
                    three.SaveAs(Path.Combine(Server.MapPath("~/Images/Hostel/"), three.FileName));
                    photo.HostelId = th.HostelId;
                    to3.RoomName = "Three Sitter";
                    to3.HostelId = th.HostelId;
                    pto3.Price = hm.ThreesitterPrice;
                    db.tblPhotoes.Add(photo);
                    db.tblPrices.Add(pto3);
                    db.SaveChanges();
                    to3.PriceId = pto3.PriceId;
                    db.tblRooms.Add(to3);
                    db.SaveChanges();

                }
                else
                {
                    HttpPostedFileBase fup = Request.Files["Photo"];
                    HttpPostedFileBase one = Request.Files["Photo1"];
                    HttpPostedFileBase two = Request.Files["Photo2"];
                    HttpPostedFileBase three = Request.Files["Photo3"];
                    tblHostel th = db.tblHostels.Where(x => x.HostelId == hm.HostelId).FirstOrDefault();
                    th.HostelName = hm.HostelName;
                    th.Description = hm.Description;
                    th.Address = hm.Address;
                    th.Phone = hm.Phone;
                    th.Star = hm.Star;
                    th.Capacity = hm.Capacity;
                    th.Email = hm.DescriptionNext;
                    th.Facilites = hm.Facilites;
                    th.Email = hm.Email;
                    th.MapLocation = hm.MapLocation;
                    int i = 0;
                    foreach(var item in db.tblPhotoes.ToList())
                    {
                        if (item.HostelId == hm.HostelId && i==0)
                        {
                            if (one.ContentLength > 0)
                            {
                                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Hostel/"), item.Photo));
                                item.Photo = one.FileName;
                                one.SaveAs(Path.Combine(Server.MapPath("~/Images/Hostel/"), one.FileName));
                                break;
                            }
                            if (two.ContentLength > 0)
                            {
                                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Hostel/"),item.Photo));
                                one.SaveAs(Path.Combine(Server.MapPath("~/Images/Hostel/"), two.FileName));
                                item.Photo = two.FileName;
                                break;
                            }
                            if (three.ContentLength > 0)
                            {
                                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Hostel/"), item.Photo));
                                one.SaveAs(Path.Combine(Server.MapPath("~/Images/Hostel/"), three.FileName));
                                item.Photo = three.FileName;
                                break;
                            }
                        }
                    }
                    db.SaveChanges();
                    List<tblRoom> to = db.tblRooms.Where(x => x.HostelId == hm.HostelId).ToList();
                    foreach (var item in to)
                    {
                        if (item.RoomName == "One Sitter")
                        {
                            item.tblPrice.Price = hm.OnesitterPrice;
                        }
                        if (item.RoomName == "Two Sitter")
                        {
                            item.tblPrice.Price = hm.TwositterPrice;
                        }
                        if (item.RoomName == "Three Sitter")
                        {
                            item.tblPrice.Price = hm.ThreesitterPrice;
                        }
                    }
                    db.SaveChanges();

                }
               
            }
            return RedirectToAction("Index", "Opening");
        }
    }
}