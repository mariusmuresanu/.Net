﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laborator11.Model
{
    public class Movie
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Ingredients must contain at least 2 characters!")]
        public string Title { get; set; }
        public int Runtime { get; set; }
        public double Rating { get; set; }
        public string Storyline { get; set; }
    }
}
