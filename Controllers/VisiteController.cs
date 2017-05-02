using groupePjvApp.Models;
using groupePjvApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupePjvApp.Controllers
{
    public class VisiteController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult InfosVisite()
        {
            return View("InfosVisite");
        }

        [Authorize]
        public ActionResult VisiteEtape2()
        {
            VisiteViewModel visite = new VisiteViewModel();
            visite.Produits = dal.ObtenirLesProduits();
            return View("VisiteEtape2", visite);
        }

        [Authorize]
        public ActionResult VisiteEtape3()
        {
            VisiteViewModel visite = new VisiteViewModel();
            visite.Produits = dal.ObtenirLesProduits();
            return View("VisiteEtape3", visite);
        }

        [Authorize]
        public ActionResult VisiteEtape4()
        {
            return View("VisiteEtape4");
        }

        [Authorize]
        public ActionResult VisiteEtape5()
        {
            VisiteViewModel visite = new VisiteViewModel();
            visite.Produits = dal.ObtenirLesProduits();
            return View("VisiteEtape5", visite);
        }

        [Authorize]
        public ActionResult VisiteEtape6()
        {
            VisiteViewModel visite = new VisiteViewModel();
            visite.Produits = dal.ObtenirLesProduits();
            return View("VisiteEtape6", visite);
        }

        [Authorize]
        public ActionResult VisiteEtape7()
        {
            return View("VisiteEtape7");
        }

        [Authorize]
        public ActionResult Rapport()
        {
            return View("Rapport");
        }
    }
}