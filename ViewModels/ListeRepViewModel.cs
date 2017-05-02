using groupePjvApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace groupePjvApp.ViewModels
{
    public class ListeRepViewModel
    {
        public List<Representant> Representants { get; set; }

        public ListeRepViewModel(List<Representant> representants)
        {
            this.Representants = representants;
        }
    }
}