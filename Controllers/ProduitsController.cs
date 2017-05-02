using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupePjvApp.Controllers
{
    [Authorize]
    public class ProduitsController : BaseController
    {
        // GET: Produits

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FicheProduit()
        {
            return View("FicheProduit");
        }

        public ActionResult Produits()
        {
            return View("Produits");
        }
    }
}