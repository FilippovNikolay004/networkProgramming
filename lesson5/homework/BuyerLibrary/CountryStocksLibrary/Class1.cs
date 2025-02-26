using DiscountedItemsLibrary;

namespace CountryStocksLibrary {
    public class CountryStocks {
        public int Id { get; set; }
        public string NameCounty { get; set; }
        public int Discount { get; set; }

        // Навигационное свойство
        public ICollection<DiscountedItems> DiscountedItems { get; set; } = new List<DiscountedItems>();
    }
}
