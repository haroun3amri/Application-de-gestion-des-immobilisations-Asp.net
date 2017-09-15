using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Immo_Demo.Models;
using WebMatrix.WebData;
using WebMatrix.Data;
using System.Web.Security;

namespace Immo_Demo.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
    [HttpGet]
       public ActionResult Login()
        {
            return View();
        }
        //********************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login logindata,string ReturnURL)
    {
       if(ModelState.IsValid)
       {

           if (WebSecurity.Login(logindata.Username, logindata.Password))
           { if(ReturnURL != null)
           {
               return Redirect(ReturnURL);
           }
           return RedirectToAction("Index", "Home");
           }
       else
           {  ModelState.AddModelError("", "Desole,Nom utilsateur ou Mot de passe sont Invalides  !!!");
              return View(logindata);
           }
       }
             ModelState.AddModelError("", "Desole,Nom utilsateur ou Mot de passe sont Invalides  !!!");
              return View(logindata);
        }
        //********************************
        [HttpGet]
        public ActionResult Register()
       {
           return View();
       }
        //**************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        //**************
        public ActionResult Register(Register Resigterdata,string role )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(Resigterdata.Username, Resigterdata.Password);
                    Roles.AddUserToRole(Resigterdata.Username, role);
                    
                    return RedirectToAction("Index", "Home");
                }
                catch (System.Web.Security.MembershipCreateUserException exception)
                {
                    ModelState.AddModelError("", "Desole,mais cet utilsateur existe deja !!!");
                    return View(Resigterdata);
                }
            }
            ModelState.AddModelError("", "Desole,mais cet utilsateur existe deja !!!");
            return View(Resigterdata);
        }

        //**************************
        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}