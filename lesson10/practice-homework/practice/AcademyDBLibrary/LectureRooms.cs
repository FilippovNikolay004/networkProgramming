using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDBLibrary {
    class LectureRooms {
        public int Id { get; set; }
        public string Building { get; set; }
        public string Name { get; set; }

        public ICollection<Schedules> Schedules { get; set; }
    }
}
