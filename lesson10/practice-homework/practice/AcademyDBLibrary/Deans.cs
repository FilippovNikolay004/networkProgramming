using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDBLibrary {
    class Deans {
        public int Id { get; set; }

        [ForeignKey("TeacherId")]
        public Teachers Teachers { get; set; }

        public ICollection<Faculties> Faculties { get; set; }
    }
}
