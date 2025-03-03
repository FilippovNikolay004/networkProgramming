using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDBLibrary {
    class Teachers {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public ICollection<Assistants> Assistants { get; set; }
        public ICollection<Lectures> Lectures { get; set; }
        public ICollection<Deans> Deans { get; set; }
        public ICollection<Curators> Curators { get; set; }
        public ICollection<Heads> Heads { get; set; }

    }
}
