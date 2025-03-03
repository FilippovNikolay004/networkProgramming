using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDBLibrary {
    class Departments {
        public int Id { get; set; }
        public string Building { get; set; }
        public string Name { get; set; }

        [ForeignKey("FacultyId")]
        public Faculties Faculties { get; set; }

        [ForeignKey("HeadId")]
        public Heads Heads { get; set; }

        public ICollection<Groups> Groups { get; set; }
    }
}
