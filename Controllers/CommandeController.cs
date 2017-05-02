using groupePjvApp.Models;
using groupePjvApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupePjvApp.Controllers
{
    [Authorize]
    public class CommandeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

       
        
        public ActionResult Commandes()
        {
            CommandesViewModel commandeViewModel = new CommandesViewModel();

            //ViewData["magasins"] = dal.ObtenirLesMagasins();
            //ViewData["produits"] = dal.ObtenirLesProduits();
            return View("Commandes", commandeViewModel);
        }

        [HttpPost]
        public ActionResult ConfirmerCommande(CommandesViewModel commandeViewModel)
        {            
                if (Request.Form["btn-commande"] != null)
                {
                    if (commandeViewModel != null)
                    {
                        commandeViewModel.Commande.Magasin = dal.ObtenirMagasinParId(commandeViewModel.Commande.Magasin.Id);
                        commandeViewModel.Representant = Session["representant"] as Representant;
                        foreach (ItemCommande item in commandeViewModel.Commande.ProduitsCommande)
                        {
                            item.Produit = dal.ObtenirProduitParId(item.Produit.Id);
                        }
                    /*commandeViewModel.Commande = new Commande(commandeViewModel.Magasin, commandeViewModel.ProduitsCommande);*/
                        if (ModelState.IsValid)
                        {
                            //ViewData["magasins"] = dal.ObtenirLesMagasins();
                            //ViewData["produits"] = dal.ObtenirLesProduits();
                            Commande commande = new Commande(commandeViewModel);
                            int id = dal.EnregistrerCommande(commande);
                        }
                    }
                }
                //ViewData["magasins"] = dal.ObtenirLesMagasins();
                //ViewData["produits"] = dal.ObtenirLesProduits();
            return View("Commandes", commandeViewModel);
        }

        public ActionResult CreateNewBook()
        {

            return PartialView("~/Views/Shared/ProduitCommande.cshtml");

        }
    }
}