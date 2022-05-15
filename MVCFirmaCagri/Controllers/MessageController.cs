using FluentValidation.Results;
using MVCFirmaCagri.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCFirmaCagri.Controllers
{
    public class MessageController : Controller
    {
        private readonly DbWorkFollowEntities db = new DbWorkFollowEntities();
        private readonly Validation.Message vaMessage = new Validation.Message();
        public ActionResult SenderList(short? adminid)
        {
            TempData["adminid"] = adminid;
            List<Company> degeradmin = db.Company.Where(x => x.IsAdmin == true).ToList();
            adminid = adminid is null ? degeradmin.Select(x => x.ID).FirstOrDefault() : adminid;
            short id = (short)Session["id"];
            db.Database.ExecuteSqlCommand("update Message set IsRead=1 where Receiver=" + id + "");
            db.SaveChanges();
            ViewBag.error = TempData["error"];
            ViewBag.nosender = TempData["nosender"];
            Models.Classes.Trash.ID1 = adminid;
            return View(degeradmin);
        }
        public PartialViewResult InComingMessage()
        {
            short? idadmin = Models.Classes.Trash.ID1;
            short id = (short)Session["id"];
            ViewBag.id = id;
            if (idadmin is null)
            {
                return PartialView();
            }

            Company values = db.Company.FirstOrDefault(x => x.IsAdmin == true && x.ID == idadmin);
            if (!(values is null))
                ViewBag.adminid = values.ID;
            List<Message> deger = db.Message.Where(x => (x.Receiver == id || x.Sender == id) && x.Status == true).OrderBy(x => x.ID).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Message()
        {
            short id = (short)Session["id"];
            List<Models.Entitiy.Message> deger = db.Message.Where(x => x.Status == true && x.Receiver == id && x.IsRead == false).OrderByDescending(x => x.ID).ToList();
            return PartialView(deger);
        }

        [ValidateInput(false)]
        public ActionResult MessageAdd(Message p)
        {
            ValidationResult result = vaMessage.Validate(p);
            if (result.IsValid)
            {
                short? admin = TempData["adminid"] as short?;
                if (admin is null)
                    admin = db.Company.FirstOrDefault(x => x.IsAdmin == true)?.ID;
                short id = (short)Session["id"];
                p.Status = true;
                p.IsRead = false;
                p.C_Date = DateTime.Now;
                if ((admin is null))
                {
                    TempData["nosender"] = "nosender";
                    return RedirectToAction("SenderList");
                }
                short idadmin = db.Company.Find(admin).ID;
                p.Receiver = idadmin;
                p.Sender = id;
                db.Message.Add(p);
                db.SaveChanges();
                return RedirectToAction("SenderList");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            TempData["error"] = "error";
            return RedirectToAction("SenderList");
        }
        public PartialViewResult Notification()
        {
            short id = (short)Session["id"];
            List<CompanyCall> deger = db.CompanyCall.Where(x => x.Status == true && x.CompanyID == id).OrderByDescending(x => x.ID).ToList();
            return PartialView(deger);
        }
    }
}