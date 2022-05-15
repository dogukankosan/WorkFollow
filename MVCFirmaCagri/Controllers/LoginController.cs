using FluentValidation.Results;
using MVCFirmaCagri.Models.Entitiy;
using MVCFirmaCagri.Validation;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCFirmaCagri.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly DbWorkFollowEntities db = new DbWorkFollowEntities();
        private readonly LoginValidate validate = new LoginValidate();
        private readonly CompanyMail CompanyMail = new CompanyMail();
        [HttpGet]
        public ActionResult Log()
        {
            ViewBag.mailsuccses = TempData["mailsuccses"];
            ViewBag.mailerror = TempData["mailerror"];
            ViewBag.cap = TempData["cap"];
            ViewBag.dgr = TempData["error"];
            return View();
        }
        [HttpPost]
        public ActionResult Log(Company d)
        {
            ValidationResult cs = validate.Validate(d);
            string encoderesponse = Request.Form["g-Recaptcha-Response"];
            bool iscaptcha = CAPTCHA.Capt.Validate(encoderesponse);
            d.Password = Encription.Enc.Log(d.Password);
            Company cp = db.Company.FirstOrDefault(x => x.CompanyMail == d.CompanyMail && x.Password == d.Password && x.IsAdmin == false);
            if (iscaptcha)
            {
                if (cs.IsValid)
                {
                    if (cp is null)
                    {
                        TempData["error"] = "error";
                        return RedirectToAction("Log");
                    }
                    FormsAuthentication.SetAuthCookie(cp.ID.ToString(), false);
                    Session["id"] = cp?.ID;
                    return RedirectToAction("List", "Home");
                }
                foreach (var item in cs.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            TempData["cap"] = "cap";
            return RedirectToAction("Log");
        }
        public ActionResult ErrorPage()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Log");
        }
        public PartialViewResult RememberPassword()
        {
            return PartialView();
        }
        public ActionResult RememberMail(Company p)
        {
            ValidationResult result = CompanyMail.Validate(p);
            if (result.IsValid)
            {
                byte i = Convert.ToByte(db.Company.Count(x => x.CompanyMail == p.CompanyMail));
                if (i > 0)
                {
                    SmtpClient client = new SmtpClient();
                    MailMessage message = new MailMessage();
                    client.Credentials = new NetworkCredential("infocaritakip@yandex.com", "drzkuiiddylbmwsl");
                    client.Port = Convert.ToInt32(587);
                    client.Host = "smtp.yandex.com.tr";
                    client.EnableSsl = true;
                    message.To.Add(p.CompanyMail.ToString());
                    message.From = new MailAddress("infocaritakip@yandex.com", "İŞ TAKİP ŞİFRE UNUTTUM");
                    message.Subject = "İŞ TAKİP FİRMA ÇAĞRIDAN GELEN ŞİFRE UNUTTUM";
                    message.Body = "GİRİŞ ŞİFREİNİZ = " + Encription.Enc.Description(db.Company.Where(x => x.CompanyMail == p.CompanyMail).Select(x => x.Password).FirstOrDefault().ToString());
                    client.Send(message);
                    TempData["mailsuccses"] = "mailsuccses";
                    return RedirectToAction("Log");
                }
                TempData["mailerror"] = "mailerror";
                return RedirectToAction("Log");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View("Log");
        }
    }
}