using groupePjvApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace groupePjvApp.ViewModels
{
    public class AppelViewModel
    {      
        [Required(ErrorMessage="Vous devez spécifier la succursale pour laquelle cet appel est logé.")]
        public int Magasin { get; set; }
        [Required(ErrorMessage="Veuillez vous reconnecter, il semble que vous soyez en mode déconnecté.")]
        public int Representant { get; set; }
        [Required(ErrorMessage="Vous devez spécifier la date d'appel")]
        public DateTime DateAppel { get; set; }
        [Required(ErrorMessage = "Vous devez spécifier le nom de l'appelant")]
        public string NomAppelant { get; set; }
        [Required(ErrorMessage = "Vous devez spécifier une résume de l'appel")]
        public string NotesAppel { get; set; }
        [Required(ErrorMessage = "Vous devez spécifier le département pour lequel l'appel a été logé.")]
        public string Departement { get; set; }
    }
}