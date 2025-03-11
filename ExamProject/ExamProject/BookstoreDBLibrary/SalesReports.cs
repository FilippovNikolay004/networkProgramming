using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject {
    public class SalesReports {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public Users User { get; set; }

        [ForeignKey("BookId")]
        public Books Book { get; set; }

        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; }
        public bool IsPromotion { get; set; }
    }
}
