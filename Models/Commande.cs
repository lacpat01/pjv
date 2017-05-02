using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using groupePjvApp.ViewModels;

namespace groupePjvApp.Models
{
    public class Commande
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vous devez spécifier une succursale pour commander.")]
        [ForeignKey("Id")]
        public virtual Magasin Magasin { get; set; }
        [ForeignKey("Id")]
        public virtual Representant Representant { get; set; }
        public DateTime DateCommande { get; set; }

        public virtual List<ItemCommande> ProduitsCommande { get; set; }

        public Commande()
        {
            this.ProduitsCommande = new List<ItemCommande>();
        }

        public Commande(Magasin magasin, List<ItemCommande> produitsCommande, Representant representant)
        {
            this.DateCommande = DateTime.Now;
            this.Magasin = magasin;
            this.ProduitsCommande = produitsCommande;
            this.Representant = representant;
        }

        public Commande(CommandesViewModel view )
        {
            this.DateCommande = DateTime.Now;
            this.Magasin = view.Commande.Magasin;
            this.ProduitsCommande = view.Commande.ProduitsCommande;
            this.Representant = view.Representant;
        }
    }
}