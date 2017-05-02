using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace groupePjvApp.Models
{
    public class ElementListe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Quantitee { get; set; }

        public ElementListe()
        {
            this.Id = 1;
            this.Nom = "Le nom";
            this.Quantitee = 4;
        }
    }
}