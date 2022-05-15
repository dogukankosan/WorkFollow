using FluentValidation.Results;
using MVCFirmaCagri.Models.Entitiy;
using MVCFirmaCagri.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using CompanyCall = MVCFirmaCagri.Models.Entitiy.CompanyCall;

namespace MVCFirmaCagri.Controllers
{
    public class HomeController : Controller
    {
        private readonly Models.Entitiy.DbWorkFollowEntities db = new DbWorkFollowEntities();
        private readonly Validation.CompanyCall validation = new Validation.CompanyCall();
        private readonly CompanyValidate validate = new CompanyValidate();
        public ActionResult List()
        {
            short id = (short)Session["id"];
            Company valCompany = db.Company.Find(id);
            ViewBag.dgr = TempData["addcomp"];
            return View(valCompany);
        }
        public ActionResult ActiveCall()
        {
            short id = (short)Session["id"];
            ViewBag.updatecall = TempData["updatecall"];
            ViewBag.addcal = TempData["addcal"];
            TempData["addcal"] = null;
            TempData["updatecall"] = null;
            List<CompanyCall> deger = db.CompanyCall.OrderByDescending(x => x.C_Date).Where(x => x.Status && x.CompanyID == id).ToList();
            ViewBag.dgr = deger.Count == 0
                ? "ÇÖZÜLMESİ BEKLENEN AKTİF ÇAĞRINIZ BULUNMAMAKTADIR"
                : deger.Count + " ADET ÇÖZÜLMESİ BEKLENEN ÇAĞRI BULUNMAKTADIR";
            return View(deger);
        }
        public ActionResult PassiveCall()
        {
            short id = (short)Session["id"];
            List<CompanyCall> deger = db.CompanyCall.OrderByDescending(x => x.C_Date).Where(x => x.Status == false && x.CompanyID == id).ToList();
            ViewBag.dgr = deger.Count == 0
                ? "ÇÖZÜLMÜŞ PASİF ÇAĞRINIZ BULUNMAMAKTADIR"
                : deger.Count + " ADET ÇÖZÜLMÜŞ ÇAĞRI BULUNMAKTADIR";
            return View(deger);
        }
        [HttpGet]
        public ActionResult AddCall()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCall(CompanyCall c)
        {
            short id = (short)Session["id"];
            c.CompanyID = id;
            ValidationResult result = validation.Validate(c);
            if (result.IsValid)
            {
                c.Status = true;
                db.CompanyCall.Add(c);
                db.SaveChanges();
                TempData["addcal"] = "addcal";
                return RedirectToAction("ActiveCall");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }
        public ActionResult Details(short id)
        {
            List<CallDetails> cl = db.CallDetails.Where(x => x.CompanyCall == id).OrderByDescending(x => x.C_Date).ToList();
            CompanyCall ca = db.CompanyCall.Find(id);
            ViewBag.dgr = ca.Company.CompanyName;
            return View(cl);
        }
        [HttpGet]
        public ActionResult Update(short id)
        {
            CompanyCall cml = db.CompanyCall.Find(id);
            return View(cml);
        }
        [HttpPost]
        public ActionResult Update(CompanyCall c)
        {
            short id = (short)Session["id"];
            c.CompanyID = id;
            ValidationResult result = validation.Validate(c);
            CompanyCall cml = db.CompanyCall.Find(c.ID);
            if (result.IsValid)
            {
                cml.C_Date = c.C_Date;
                cml.Description = c.Description;
                cml.Status = c.Status;
                cml.Subject = c.Subject;
                cml.CompanyID = c.CompanyID;
                db.SaveChanges();
                TempData["updatecall"] = "updatecall";
                return RedirectToAction("ActiveCall");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult UpdateCompany()
        {
            ViewBag.mukker = TempData["mukker"];
            short id = (short)Session["id"];
            Company valCompany = db.Company.Find(id);
            valCompany.Password = Encription.Enc.Description(valCompany.Password);
            return View(valCompany);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateCompany(Company p)
        {
            byte valudb = Convert.ToByte(db.Company.Count(x => x.CompanyMail == p.CompanyMail && p.ID != x.ID));
            if (valudb == 0)
            {
                ValidationResult result = validate.Validate(p);
                if (result.IsValid)
                {
                    Company valuecomp = db.Company.Find(p.ID);
                    valuecomp.CompanyName = p.CompanyName;
                    valuecomp.CompanyOfficial = p.CompanyOfficial;
                    valuecomp.CompanyTel = p.CompanyTel;
                    valuecomp.CompanyMail = p.CompanyMail;
                    valuecomp.Password = Encription.Enc.Log(p.Password);
                    valuecomp.CompanyActivity = p.CompanyActivity;
                    valuecomp.CompanyCity = p.CompanyCity;
                    valuecomp.CompanyTown = p.CompanyTown;
                    valuecomp.CompanyAdress = p.CompanyAdress;
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(Request.Files["logo"].InputStream))
                    {
                        fileData = binaryReader.ReadBytes(Request.Files["logo"].ContentLength);
                    }
                    valuecomp.CompanyImage = fileData.Length > 5 ? fileData : valuecomp.CompanyImage;
                    db.SaveChanges();
                    TempData["addcomp"] = "addcomp";
                    return RedirectToAction("List");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            TempData["mukker"] = "mukker";
            return RedirectToAction("UpdateCompany");
        }
    }
}