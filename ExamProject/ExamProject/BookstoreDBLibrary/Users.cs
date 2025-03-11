using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject {
    public class Users {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public ICollection<ReservedBooks> ReservedBooks { get; set; }
        public ICollection<SalesReports> SalesReports { get; set; }
    }
}
