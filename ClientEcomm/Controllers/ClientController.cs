using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ClientEcomm.Models;

namespace ClientEcomm.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult AddOrEdit(int id=0)
        {
            Client clientModel = new Client();
            return View(clientModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Client clientModel)
        {
            using(CATALOGUECLIENT_Entities dbModel = new CATALOGUECLIENT_Entities())
            {
                dbModel.Client.Add(clientModel);
                dbModel.SaveChanges();

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration terminé . Veuillez se connecter";
            return View("AddOrEdit", new Client() );
        }


    }
}