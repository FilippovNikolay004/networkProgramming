using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDBLibrary {
    class Faculties {
        public int Id { get; set; }
        public int Building { get; set; }
        public string Name { get; set; }

        [ForeignKey("DeanId")]
        public Deans Deans { get; set; }

        public ICollection<Departments> Departments { get; set; }
    }
}
