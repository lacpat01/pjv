using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace groupePjvApp.Models
{
    public class InitGroupePjv : DropCreateDatabaseAlways<BddContext> 
    {
        protected override void Seed(BddContext context)
        {
            Utilitaires utilitaires = new Utilitaires();   

            Representant rep1 = new Representant { Id = 1, Courriel = "patrickla@hotmail.com", Photo = utilitaires.convertir("C:/pat.png"), Prenom = "Patrick", Nom = "Lachance", MotDePasse = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes("Tableau1"))) };
            context.Representant.Add(rep1);
            Magasin magasin = new Magasin { Id = 1, Succursale = "BMR Val D'Or", Numero = 61524563, Region = "Abitibi", Adresse = "1234, Boul, Tremblay, Val-D'Or, GHT 1V8" };
            Produit produit = new Produit { Id = 1, Code = "A21", Libelle = "Ampoule DEL A21" };            

            context.Representant.Add(new Representant { Id = 2, Courriel = "jf@konnexion.ca", Prenom = "Jeff", Photo = utilitaires.convertir("C:/jeff.png"), Nom = "Léveillé", MotDePasse = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes("Bonjour2017"))) });
            context.Magasins.Add(magasin);
            context.Magasins.Add(new Magasin { Id = 2, Succursale = "BMR Val D'Or", Numero = 61524563, Region = "Abitibi", Adresse = "1234, Boul, Tremblay, Val-D'Or, GHT 1V8" });
            context.Magasins.Add(new Magasin { Id = 3, Succursale = "BMR Québec", Numero = 61524563, Region = "Abitibi", Adresse = "1234, Boul, Tremblay, Val-D'Or, GHT 1V8" });
            context.Magasins.Add(new Magasin { Id = 4, Succursale = "BMR Château-Richer", Numero = 61524563, Region = "Abitibi", Adresse = "1234, Boul, Tremblay, Val-D'Or, GHT 1V8" });

            context.Produits.Add(produit);
            context.Produits.Add(new Produit { Id = 2, Code = "A22", Libelle = "Ampoule DEL A22" });
            context.Produits.Add(new Produit { Id = 3, Code = "A23", Libelle = "Ampoule DEL A23" });
            context.Produits.Add(new Produit { Id = 4, Code = "A24", Libelle = "Ampoule DEL A24" });

            context.LuminairesActuel.Add(new LuminaireActuel { Id = 1, IdProduit = 2, IdMagasin = 1, Quantitee = 10 });
            
            base.Seed(context);
        }
    }
}