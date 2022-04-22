using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Models.Entity;

namespace Task.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        DbTaskEntities db = new DbTaskEntities();
        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            

            var values = db.Tbl_Detail.Where(x => x.ItemId == id).ToList();
            return View(values);
            
        }

        [HttpGet]
        public ActionResult AddDetail(int id)
        {
            ViewBag.b = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddDetail(Tbl_Detail p,int id)
        {
            p.Date = DateTime.Now;
            p.ItemId = id;
            db.Tbl_Detail.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Master");
        }
        
        [HttpGet]
        public ActionResult UpdateDetail(int id)
        {
            ViewBag.c = id;
            Tbl_Detail t= db.Tbl_Detail.Find(id);
            return View(t);
        }

        [HttpPost]
        public ActionResult UpdateDetail(Tbl_Detail p,int id)
        {
            
            Tbl_Detail t = db.Tbl_Detail.Find(p.ItemId=id);
            t.Date = DateTime.Now;
            t.QTY = p.QTY;
            
            db.SaveChanges();
            return RedirectToAction("Index","Master");
        }

        public ActionResult DeleteDetail(Tbl_Detail p,int id)
        {
            Tbl_Detail t =db.Tbl_Detail.Find(p.ItemId=id);
            db.Tbl_Detail.Remove(t);
            db.SaveChanges();
            return RedirectToAction("Index", "Master");


        }
    }
}