using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PauseSystem.Models;
using System.Collections.Generic;
using PauseSystem.Models.Entity;

namespace PauseSystem.Controllers
{
    public class AccountController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private IRepository<Medarbejdere> medarbejdereRepository;
        private IRepository<Kunde> KundeRepository;

        public AccountController()
        {
            medarbejdereRepository = unitOfWork.Repository<Medarbejdere>();
            KundeRepository = unitOfWork.Repository<Kunde>();
        }


        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (Request.QueryString.HasKeys() && Request.QueryString["kundenr"] != null && Request.QueryString["guid"] != null
                && SignIn(Request["kundenr"], Request["guid"], false)
                )
            {
                return RedirectToLocal(returnUrl);
            }

            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (SignIn(model.Username, model.Password,model.RememberMe))
            {
              return RedirectToLocal(returnUrl);
            }
            return View(model);

        }

        private bool SignIn(string userName,string password,bool rememberMe)
        {  
            
            var muser = medarbejdereRepository.Get(m => (m.Fornavn == userName && m.Password == password)
                || (m.SugarUser == userName && m.SugarPassword == password)).FirstOrDefault();
            if (muser != null)
            {
                PauseSecurity.Login(new PauseIdentity(muser.Id, muser.Fornavn, muser.Fornavn + " " + muser.EfterNavn, new List<string> { UserRoleTypes.Employee }), rememberMe);
                return true;
            }
             int kundenr = 0;
            if(int.TryParse(userName,out kundenr))
            {
                var kuser = KundeRepository.Get(k => k.KundeNr == kundenr && k.AfmeldingsPass == password).FirstOrDefault();
                PauseSecurity.Login(new PauseIdentity(kuser.Id, kuser.Navn,kuser.Navn, new List<string> { UserRoleTypes.Customer }), rememberMe);
                return true;
            }


            return false;

        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            ActionResult result;
            if (Url.IsLocalUrl(returnUrl))
            {
                result = this.Redirect(returnUrl);
            }
            else
            {
                result = base.RedirectToAction("Index", "Home");
            }
            return result;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            PauseSecurity.Logout();
            return RedirectToLocal(null);
        }

    }
}