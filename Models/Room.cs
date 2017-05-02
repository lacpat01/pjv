﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace groupePjvApp.Models
{
    public class Room
    {
        [Required]
        public string Name { get; set; }
        [Range(1, 200)]
        public int Area { get; set; }
    }
}