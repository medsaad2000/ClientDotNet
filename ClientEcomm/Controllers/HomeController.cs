using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ClientEcomm.Models;

namespace ClientEcomm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        CATALOGUECLIENT_Entities db = new CATALOGUECLIENT_Entities();
        // GET: Home


        public ActionResult Index()
        {
            ViewBag.listeCategorie = db.CAT_CATEGORIE.ToList().OrderBy(r => r.LIBELLE_CATEGORIE); //la liste des categories rangée par ordre alphabetique
            return View();
        }
    }
}