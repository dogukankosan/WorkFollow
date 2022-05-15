using MVCFirmaCagri.Models.Classes;
using MVCFirmaCagri.Models.Entitiy;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCFirmaCagri.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DbWorkFollowEntities db = new DbWorkFollowEntities();
        public ActionResult List()
        {
            short id = (short)Session["id"];
            Company d = db.Company.Find(id);
            ViewBag.total = db.CompanyCall.Count(x => x.CompanyID == id).ToString();
            ViewBag.active = db.CompanyCall.Count(x => x.CompanyID == id && x.Status).ToString();
            ViewBag.passive = db.CompanyCall.Count(x => x.CompanyID == id && x.Status == false).ToString();
            return View(d);
        }
        public PartialViewResult GoogleActiveChart()
        {
            return PartialView();
        }
        public ActionResult ActivePassiveResult()
        {
            return Json(ActivePassives(), JsonRequestBehavior.AllowGet);
        }
        public List<ActivePassive> ActivePassives()
        {
            short? id = Session["id"] as short?;
            List<ActivePassive> ct = new List<ActivePassive>();
            ct.Add(new ActivePassive()
            {
                Status = "AKTİF",
                Values = (short)db.CompanyCall.Count(x => x.Status == true && x.CompanyID == id)
            });
            ct.Add(new ActivePassive()
            {
                Status = "PASİF",
                Values = (short)db.CompanyCall.Count(x => x.Status == false && x.CompanyID == id)
            });
            return (ct);
        }
    }
}