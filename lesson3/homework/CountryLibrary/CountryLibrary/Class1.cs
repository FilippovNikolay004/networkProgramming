﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CountryLibrary {
    public class Country {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public long Population { get; set; }
        public double Area { get; set; }
        public string Continent { get; set; }
    }
}
