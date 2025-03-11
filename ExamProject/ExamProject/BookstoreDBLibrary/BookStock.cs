using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject {
    public class BookStock {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("BookId")]
        public Books Book { get; set; }
    }
}
