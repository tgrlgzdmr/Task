using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Models.Entity;

namespace Task.Controllers
{
    public class MasterController : Controller
    {
        
        DbTaskEntities db = new DbTaskEntities();
        public ActionResult Index()
        {
            var values = db.Tbl_Master.Where(x=>x.Situation==true).ToList();
            return View(values); 
        }

        public ActionResult RecycleBin()
        {
            var values = db.Tbl_Master.Where(x => x.Situation == false).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(Tbl_Master p)
        {
            p.Situation = true;
            db.Tbl_Master.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateItem(int id)
        {
            Tbl_Master t= db.Tbl_Master.Find(id);
            return View(t);
        }

        [HttpPost]
        public ActionResult UpdateItem(Tbl_Master p)
        {
            Tbl_Master t=db.Tbl_Master.Find(p.Id);
            t.Situation = true;
            t.Name=p.Name;
            t.Price = p.Price;
            t.Unit=p.Unit;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteItem(Tbl_Master p)
        {
            Tbl_Master t = db.Tbl_Master.Find(p.Id);
            t.Situation = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}