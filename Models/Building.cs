using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace groupePjvApp.Models
{
    public class Building
    {
        [Required]
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

        public Building()
        {
            Rooms = new List<Room>();
        }
    }
}