using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDBLibrary {
    class Groups {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        [ForeignKey("DepartmentId")]
        public Departments Departments { get; set; }

        public ICollection<GroupsLectures> GroupsLectures { get; set; }

        public ICollection<GroupsCurators> GroupsCurators { get; set; }
    }
}
