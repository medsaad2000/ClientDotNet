using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ClientEcomm.Models;
using System.IO;

namespace ClientEcomm.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(ClientEcomm.Models.Client userModel)
        {
            using (CATALOGUECLIENT_Entities db = new CATALOGUECLIENT_Entities())
            {
                var userDetails = db.Client.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault();

                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Username ou Mot de Passe incorrecte";
                    return View("Index", userModel);
                }
                else
                {
                    Session["ClientID"] = userDetails.ClientID;
                    return RedirectToAction("Index", "Home");
                }

            }

        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}