using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDBLibrary {
    class Lectures {
        public int Id { get; set; }

        [ForeignKey("SubjectId")]
        public Subjects Subjects { get; set; }

        [ForeignKey("TeacherId")]
        public Teachers Teachers { get; set; }

        public ICollection<GroupsLectures> GroupsLectures { get; set; }

        public ICollection<Schedules> Schedules { get; set; }
    }
}
