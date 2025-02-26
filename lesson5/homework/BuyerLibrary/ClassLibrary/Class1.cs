namespace MyApp.Models {
    public class ListSections {
        public int Id { get; set; }
        public string MobilePhone { get; set; }
        public string Laptop { get; set; }
        public string KitchenAppliances { get; set; }
        public string Tablets { get; set; }
        public string TVs { get; set; }

        public ICollection<Buyer> Buyers { get; set; } = new List<Buyer>();
        public ICollection<DiscountedItems> DiscountedItems { get; set; } = new List<DiscountedItems>();
    }

    public class DiscountedItems {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ListSections ListSections { get; set; }

        public int CountryStocksId { get; set; }
        public virtual CountryStocks CountryStocks { get; set; }
    }

    public class CountryStocks {
        public int Id { get; set; }
        public string NameCountry { get; set; }
        public int Discount { get; set; }

        public ICollection<DiscountedItems> DiscountedItems { get; set; } = new List<DiscountedItems>();
    }

    public class Buyer {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public virtual ListSections ListSections { get; set; }
    }
}
