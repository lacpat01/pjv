﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace groupePjvApp.Models
{
    public class Produit
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public byte[] Photo { get; set; }
    }
}