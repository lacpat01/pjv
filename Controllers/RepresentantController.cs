using groupePjvApp.Models;
using groupePjvApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupePjvApp.Controllers
{
    [Authorize]
    public class RepresentantController : BaseController
    {
        // GET: Representant
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListeRepresentants()
        {
            ListeRepViewModel representant = new ListeRepViewModel(dal.ObtenirTousLesRepresentant());
            
            
            return View("ListeRepresentants", representant);
        }

        public ActionResult AjoutRepresentant()
        {            
            return View("AjoutRepresentant");
        }

        [HttpPost]
        public ActionResult AjoutRepresentant(RepresentantViewModel representantViewModel)
        {
            Utilitaires utilitaire = new Utilitaires();
            try
            {
                var file = Request.Files[0];
                string fileName = file.FileName;
                string filePath = Path.GetFullPath(fileName);
                representantViewModel.Representant.Photo = utilitaire.convertir(filePath);
            }
            catch (Exception)
            {
                ModelState.AddModelError("PhotoManquante", "La photo est soit manquante ou incompatible.");
            }

            try
            {
                dal.AjouterRepresentant(representantViewModel.Representant);
            }
            catch (Exception)
            {
                
                ModelState.AddModelError("erreur", "Une erreur s'est produite, Veuillez recommencer.");
            }
            

            return View("AjoutRepresentant");
        }
    }
}