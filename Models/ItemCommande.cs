using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace groupePjvApp.Models
{
    public class ItemCommande
    {
        [Required(ErrorMessage="Vous devez spécifier le produit")]
        public int Id { get; set; }
        [Required(ErrorMessage="Quantitée requise.")]
        public int Quantite { get; set; }
        [Required(ErrorMessage="Vous devez spécifier le id du produit.")]
        public int IdProduit { get; set; }
        [ForeignKey("IdProduit")]
        public virtual Produit Produit { get; set; }

        public ItemCommande()
        {
            this.Produit = new Produit();
        }

        public ItemCommande(Produit produit)
        {
            this.Produit = produit;
        }
    }
}