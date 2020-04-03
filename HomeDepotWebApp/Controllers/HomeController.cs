using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDepotWebApp.Controllers
{
    public class HomeController : Controller
    {
        private ByggepladsEntities1 db = new ByggepladsEntities1();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(KundeSet objUser)
        {
            if (ModelState.IsValid)
            {
                using (ByggepladsEntities1 db = new ByggepladsEntities1())
                {
                    var kunde = db.KundeSets.Where(a => a.Brugernavn.Equals(objUser.Brugernavn) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (kunde != null)
                    {
                        Session["UserID"] = kunde.Id.ToString();
                        Session["UserName"] = kunde.Brugernavn.ToString();
                        return RedirectToAction("KundeStyring", kunde);
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult KundeStyring(KundeSet kunde)
        {
            if (Session["UserID"] != null)
            {

                ViewBag.VærktøjId = new SelectList(db.VærktøjSet, "Id", "prinVærktøj");
                ViewBag.Name = kunde.Name;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
      
        [HttpPost]
        public ActionResult KundeStyring([Bind(Include = "Id,Afhentningstid,Antaldage,KundeId,VærktøjId,Status")] BookingSet booking)
        {
            if (ModelState.IsValid)
            {
                booking.KundeId = Int32.Parse(Session["UserID"].ToString());
                booking.Status = "Reserveret";
                db.BookingSets.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            ViewBag.VærktøjId = new SelectList(db.VærktøjSet, "Id", "printVærktøj");
            return View();
        }
    }
}