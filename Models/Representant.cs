using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace groupePjvApp.Models
{    
    public class Representant
    {
        public int Id { get; set; }
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
        public string Nom { get; set; }
        [Required]
        [Display(Name = "Courriel")]
        public string Courriel { get; set; }        
        [Required(ErrorMessage="Mot de passe obligatoire.")]
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }
        public byte[] Photo { get; set; }
    }
}