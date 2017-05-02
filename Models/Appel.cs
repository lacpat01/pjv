using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using groupePjvApp.ViewModels;

namespace groupePjvApp.Models
{
    public class Appel
    {        
        public int Id { get; set; }
        [Required(ErrorMessage="Vous devez être connecté pour pouvoir ajouter un appel à l'historique.")]
        public int IdRepresentant { get; set; }
        [ForeignKey("IdRepresentant")]
        public virtual Representant Representant { get; set; }
        [Required(ErrorMessage = "Vous devez spécifier la date.")]        
        public DateTime DateAppel { get; set; }
        //[Required(ErrorMessage = "Vous devez spécifier pour quelle succursale était l'appel.")]
        public int IdMagasin { get; set; }
        [ForeignKey("IdMagasin")]
        public virtual Magasin Magasin{ get; set; }
        [Required(ErrorMessage="Vous de vez spécifier le nom de l'appelant.")]
        public String NomAppelant { get; set; }
        [Required(ErrorMessage="Vous devez spécifier les notes.")]
        public string NotesAppel { get; set; }        
        public string Departement { get; set; }
        public string Autre { get; set; }

        public Appel(Representant representant, DateTime dateAppel, Magasin magasin, string nomAppelant, string notesAppel, string departement)
        {
            this.Representant = representant;
            this.DateAppel = dateAppel;
            this.Magasin = magasin;
            this.NomAppelant = nomAppelant;
            this.NotesAppel = notesAppel;
            this.Departement = departement;
        }

        public Appel()
        {

        }
    }
}