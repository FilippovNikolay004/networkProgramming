using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDBLibrary {
    class GroupsLectures {
        public int Id { get; set; }

        [ForeignKey("GroupId")]
        public Groups Groups { get; set; }

        [ForeignKey("LectureId")]
        public Lectures Lectures { get; set; }
    }
}
