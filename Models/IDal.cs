using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groupePjvApp.Models
{
    public interface IDal : IDisposable
    {

        /// <summary>
        /// Section Appel
        /// </summary>
        /// 
        #region Appel
        
        bool EnregistrerAppel(Appel appel);
        List<Appel> ObtenirAppelsParMagasin(int id);
        #endregion

        /// <summary>
        /// Section représentant
        /// </summary>
        
        #region Representant

                int AjouterRepresentant(string courriel, string motDePasse);
                Representant Authentifier(string nom, string motDePasse);
                Representant ObtenirRepresentant(int id);
                Representant ObtenirRepresentant(string idStr);
                bool VerifierExistanceRepresentant(string courriel);
                List<Representant> ObtenirTousLesRepresentant();
                int AjouterRepresentant(Representant representant);

        #endregion

        /// <summary>
        /// Section Magasin
        /// </summary>
        /// 
        #region Magasin

        List<Magasin> ObtenirLesMagasins();
        Magasin ObtenirMagasinParId(int id);
        #endregion

        /// <summary>
        /// Section Produit
        /// </summary>
        /// <returns></returns>
        #region Produit

        List<Produit> ObtenirLesProduits();
        Produit ObtenirProduitParId(int id);

        #endregion

        /// <summary>
        /// Section Commandes
        /// </summary>
        /// <returns></returns>
        #region Commandes

        List<Commande> ObtenirLesCommandes();

        int EnregistrerCommande(Commande commande);

        #endregion

        /// <summary>
        /// Produit Actuel
        /// </summary>
        /// <returns></returns>
        /// 
        #region Luminaires actuel

        int EnregistrerLuminairesActuel(LuminaireActuel luminaire);
        List<LuminaireActuel> ObtenirLuminairesActuelParMagasin(int idMagasin);

        #endregion


        int ajouterElement(ElementListe element);
        List<ElementListe> ObtenirElements();
    }
}
