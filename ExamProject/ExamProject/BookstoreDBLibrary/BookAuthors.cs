using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject {
    public class BookAuthors {
        public int Id { get; set; }

        [ForeignKey("AuthorId")]
        public Authors Author { get; set; }

        [ForeignKey("BookId")]
        public Books Book { get; set; }
    }
}
