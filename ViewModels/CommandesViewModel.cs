using groupePjvApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace groupePjvApp.ViewModels
{
    public class CommandesViewModel
    {
        public List<ClassicBooks> ClassicBooks { get; set; }
        public Commande Commande { get; set; }        
        public Representant Representant { get; set; }
        
        public CommandesViewModel()
        {
            this.Commande = new Commande();
            this.ClassicBooks = new List<ClassicBooks>();
        }
    }
}