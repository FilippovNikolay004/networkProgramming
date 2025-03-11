using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject {
    public class ReservedBooks {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public Users User { get; set; }

        [ForeignKey("BookId")]
        public Books Book { get; set; }

        public DateTime ReservationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
