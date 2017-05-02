using groupePjvApp.Models;
using groupePjvApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace groupePjvApp.Controllers
{
    public class LoginController : BaseController
    {        

        public ActionResult Index()
        {
            RepresentantViewModel viewModel = new RepresentantViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Representant = dal.ObtenirRepresentant(HttpContext.User.Identity.Name);
            }
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Index(RepresentantViewModel viewModel, string returnUrl)
        {
            int idElement = 0;
            if (Request.Form["btn-login"] != null)
            {
                if (ModelState.IsValid)
                {
                    
                    Representant representant = dal.Authentifier(viewModel.Representant.Courriel, viewModel.Representant.MotDePasse);
                    if (representant != null)
                    {
                         Session["representant"] = representant;


                        FormsAuthentication.SetAuthCookie(representant.Id.ToString(), false);
                        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                            return Redirect(returnUrl);
                        ElementListe element = new ElementListe();
                        idElement = dal.ajouterElement(element);
                        List<ElementListe> Liste = dal.ObtenirElements();
                        return RedirectToAction("Tableau", "Accueil");
                    }
                    ModelState.AddModelError("Utilisateur.Courriel", "Compte inexistant.");
                }
                return View("~/Views/Accueil/Index.cshtml", viewModel);
            }
            else if (Request.Form["btnCreer"] != null)
            {
                CreerCompte(viewModel.Representant);                
            }
            return View("~/Views/Accueil/Index.cshtml", viewModel);
        }

        [Authorize]
        public ActionResult CreerCompte()
        {
            return View();
        }

        [Authorize]
        public bool CreerCompte(Representant utilisateur)
        {
            if (ModelState.IsValid)
            {
                if(!dal.VerifierExistanceRepresentant(utilisateur.Courriel))
                {
                    int id = dal.AjouterRepresentant(utilisateur.Courriel, utilisateur.MotDePasse);
                    FormsAuthentication.SetAuthCookie(id.ToString(), false);
                    return true;
                }
                ModelState.AddModelError("UserExistant", "L'utilisateur est déja existant");               
            }
            return false;
        }

        
        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Accueil");
        }
    }
}