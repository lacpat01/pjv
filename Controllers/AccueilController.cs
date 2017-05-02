using groupePjvApp.Models;
using groupePjvApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace groupePjvApp.Controllers
{
    [Authorize]
    public class AccueilController : BaseController
    {
        private Utilitaires utilitaires = new Utilitaires();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tableau()
        {
            return View("Tableau");
        }

        public ActionResult Support()
        {
            return View("Support");
        }        

        public ActionResult Liste()
        {
            MagasinsViewModel viewModel = new MagasinsViewModel();

            viewModel.Magasins = dal.ObtenirLesMagasins();

            return View("Liste", viewModel);
        }        

        public ActionResult ConfirmerCommande()
        {
            return View("ConfirmerCommande");
        }

        public ActionResult Commandes()
        {
            CommandesViewModel viewModel = new CommandesViewModel();

            ViewData["magasins"] = dal.ObtenirLesMagasins();
            ViewData["produits"] = dal.ObtenirLesProduits();
            return View("Commandes", viewModel);
        }

        public ActionResult Appel()
        {
            AppelViewModel appelViewModel = new AppelViewModel();

            return View("Appel", appelViewModel);
        }

        [HttpPost]
        public ActionResult Appel(AppelViewModel appelView)
        {
            if(ModelState.IsValid)
            {
                if (Request.Form["btn-Appel"] != null)
                {
                    Appel appel = new Appel(Session["representant"] as Representant, appelView.DateAppel, dal.ObtenirMagasinParId(appelView.Magasin),
                                            appelView.NomAppelant, appelView.NotesAppel, appelView.Departement);
                    var results = new List<ValidationResult>();
                    var context = new ValidationContext(appel, null, null);
                    List<string> listeMesssage = new List<string>();
                    if (!Validator.TryValidateObject(appel, context, results))
                    {
                        foreach (ValidationResult result in results)
                        {
                            listeMesssage.Add(result.ErrorMessage);
                        }

                        ViewData["messageErreurs"] = listeMesssage;
                    }
                    else
                    {
                        if (dal.EnregistrerAppel(appel))
                        {
                            listeMesssage.Add("L'appel a bien été enregistré.");
                            ViewData["messageSucces"] = listeMesssage;
                            List<Appel> liste = dal.ObtenirAppelsParMagasin(appel.Magasin.Id);
                        }
                        else
                        {
                            listeMesssage.Add("Il y a eu un erreur lors de l'enregistrement.");
                            ViewData["messageErreurs"] = listeMesssage;
                        }
                    }
                }
            }
            
            return View("Appel", appelView);
        }

        [HttpPost]
        public ActionResult Contacter()
        {
            if (Request.Form["btn-login"] != null)
            {
                string message = Request.Form["txtMessageSupport"];
                if(!string.IsNullOrEmpty(message))
                {
                    if(EnvoyerCourriel(message))
                    {
                        MessagesViewModel messagesViewModel = new MessagesViewModel(new List<string>());
                        messagesViewModel.Messages.Add("Merci! Votre courriel a été envoyé avec succès.");
                        return View("Support", messagesViewModel);
                    }                                        
                }
                else
                {
                    ModelState.AddModelError("MessageSupportManquant", "Vous devez tapper un message pour contacter le support.");
                }

            }
            return View("Support");
        }

        private bool EnvoyerCourriel(string message)
        {  
            if(!string.IsNullOrEmpty(message))
            {
                if(Session["representant"] != null)
                {
                    Representant rep = Session["representant"] as Representant;
                    if (utilitaires.EnvoyerCourriel("Demande du support", message, rep))
                    {
                        return true;
                    }
                    else
                    {
                        ModelState.AddModelError("courrielerreur", "Il y a eu une erreur lors de l'envoit du courriel.");
                        return false;
                    }
                }                
            }
            return false;            
        }

    }
}