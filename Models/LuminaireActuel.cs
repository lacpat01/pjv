using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace groupePjvApp.Models
{
    public class LuminaireActuel
    {
        public int Id { get; set; }
        public int IdMagasin { get; set; }
        [ForeignKey("IdMagasin")]
        public virtual Magasin Magasin { get; set; }
        public int IdProduit { get; set; }
        [ForeignKey("IdProduit")]
        public virtual Produit Produit { get; set; }
        public int Quantitee { get; set; }

        public LuminaireActuel()
        {

        }

        public LuminaireActuel(int idMagasin, int idProduit, int quantitee)
        {
            this.IdMagasin = idMagasin;
            this.IdProduit = idProduit;
            this.Quantitee = quantitee;
        }
    }
}