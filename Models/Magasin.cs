using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace groupePjvApp.Models
{
    public class Magasin
    {
        public int Id { get; set; }
        [Display(Name = "Succursale")]
        public string Succursale { get; set; }
        [Display(Name = "Numéro")]
        [Required]
        public int Numero { get; set; }
        [Display(Name = "Région")]
        public string Region { get; set; }
        [Required]        
        public string Adresse { get; set; }       
    }
}