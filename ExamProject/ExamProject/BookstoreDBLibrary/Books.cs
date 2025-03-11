using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject {
    public class Books {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string PublisherName { get; set; }
        public int NumberOfPages { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public double ProductionCost { get; set; }
        public double SellingPrice { get; set; }
        public bool IsSequel { get; set; }

        public ICollection<BookStock> BookStocks { get; set; }
        public ICollection<BookAuthors> BookAuthors { get; set; }
        public ICollection<ReservedBooks> ReservedBooks { get; set; }
        public ICollection<BookPromotions> BookPromotions { get; set; }
        public ICollection<SalesReports> SalesReports { get; set; }
    }
}
