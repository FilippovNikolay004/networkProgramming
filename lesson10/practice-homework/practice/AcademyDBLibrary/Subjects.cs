using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDBLibrary {
    class Subjects {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Lectures> Lectures { get; set; }
    }
}
