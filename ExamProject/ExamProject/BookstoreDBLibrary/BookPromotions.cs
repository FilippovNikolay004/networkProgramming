using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject {
    public class BookPromotions {
        public int Id { get; set; }
        public string Theme { get; set; }
        public double Discount { get; set; }

        [ForeignKey("BookId")]
        public Books Book { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
