using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace groupePjvApp.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }

        #region Appel

        public bool EnregistrerAppel(Appel appel)
        {
            try
            {
                bdd.Appel.Add(appel);
                bdd.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Appel>ObtenirAppelsParMagasin(int id)
        {
            try
            {
                var query = bdd.Appel.OrderByDescending(a => a.DateAppel).Where(a => a.Magasin.Id == id).Take(4).ToList();
                //return query.OrderByDescending(d => d.DateAppel).ToList();
                return query;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region Representant
        public int AjouterRepresentant(string courriel, string motDePasse)
        {
            string motDePasseEncode = EncodeMD5(motDePasse);
            Representant representant = new Representant { Courriel = courriel, MotDePasse = motDePasseEncode };
            bdd.Representant.Add(representant);
            bdd.SaveChanges();
            return representant.Id;
        }

        public int AjouterRepresentant(Representant representant)
        {
            representant.MotDePasse = EncodeMD5(representant.MotDePasse);
            bdd.Representant.Add(representant);
            bdd.SaveChanges();
            return representant.Id;
        }

        public Representant Authentifier(string courriel, string motDePasse)
        {
            string motDePasseEncode = EncodeMD5(motDePasse);
            return bdd.Representant.FirstOrDefault(u => u.Courriel == courriel && u.MotDePasse == motDePasseEncode);
        }

        public Representant ObtenirRepresentant(int id)
        {
            return bdd.Representant.FirstOrDefault(u => u.Id == id);
        }

        public bool VerifierExistanceRepresentant(string courriel)
        {
             return bdd.Representant.FirstOrDefault(u => u.Courriel == courriel) != null ? true : false;           
        }

        public Representant ObtenirRepresentant(string idString)
        {
            int id;
            if (int.TryParse(idString, out id))
                return ObtenirRepresentant(id);
            return null;
        }

        public List<Representant>ObtenirTousLesRepresentant()
        {
            return bdd.Representant.ToList();
        }

        #endregion

        #region Magasins
        /// <summary>
        ///  Section Magasins
        /// </summary>
        /// 

        public List<Magasin> ObtenirLesMagasins()
        {
            return bdd.Magasins.ToList();
        }

        public Magasin ObtenirMagasinParId(int id)
        {
            if(id != 0)
            {
                return bdd.Magasins.FirstOrDefault(u => u.Id == id);
            }
            return null;
        }


        #endregion

        #region Produits
        /// <summary>
        /// Section Produits
        /// </summary>
        /// 

        public List<Produit> ObtenirLesProduits()
        {
            return bdd.Produits.ToList();
        }

        public Produit ObtenirProduitParId(int id)
        {
            return bdd.Produits.FirstOrDefault(x => x.Id == id);
        }

        #endregion

        #region Commandes
        /// <summary>
        /// Section Commandes
        /// </summary>
        /// 

        public List<Commande> ObtenirLesCommandes()
        {
            return bdd.Commande.ToList();
        }

        public int EnregistrerCommande(Commande commande)
        {
            bdd.Commande.Add(commande);
            bdd.SaveChanges();
            return commande.Id;
        }

        #endregion

        #region Luminaires Actuel
        /// <summary>
        /// Section Luminaires Actuel
        /// </summary>
        /// 

        public int EnregistrerLuminairesActuel(LuminaireActuel luminaire)
        {
            try
            {
                bdd.LuminairesActuel.Add(luminaire);
                bdd.SaveChanges();
                return luminaire.Id;
            }
            catch (Exception e)
            {
                return 0;
            }            
        }

        public List<LuminaireActuel> ObtenirLuminairesActuelParMagasin(int idMagasin)
        {
            return bdd.LuminairesActuel.ToList();            
        }

        #endregion


        public int ajouterElement(ElementListe element)
        {
            bdd.ElementsListe.Add(element);
            bdd.SaveChanges();
            return element.Id;
        }

        public List<ElementListe> ObtenirElements()
        {
            return bdd.ElementsListe.ToList();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        private string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = motDePasse;
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }        
    }
}