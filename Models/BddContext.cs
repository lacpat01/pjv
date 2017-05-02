using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace groupePjvApp.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Representant> Representant { get; set; }
        public DbSet<Magasin> Magasins { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Commande> Commande { get; set; }
        public DbSet<ItemCommande> ItemCommande { get; set; }
        public DbSet<Appel> Appel { get; set; }
        public DbSet<LuminaireActuel> LuminairesActuel { get; set; }
        public DbSet<ElementListe> ElementsListe { get; set; }
    }
}