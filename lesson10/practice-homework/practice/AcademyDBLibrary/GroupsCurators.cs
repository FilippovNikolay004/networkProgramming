using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDBLibrary {
    class GroupsCurators {
        public int Id { get; set; }

        [ForeignKey("CuratorId")]
        public Curators Curators { get; set; }

        [ForeignKey("GroupId")]
        public Groups Groups { get; set; }
    }
}
