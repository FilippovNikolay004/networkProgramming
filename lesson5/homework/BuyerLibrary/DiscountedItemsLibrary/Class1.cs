namespace DiscountedItemsLibrary {
    public class DiscountedItems {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        // Внешние ключи
        public int IdListSections { get; set; }
        public ListSectionsLibrary.ListSections ListSections { get; set; }

        public int CountryStocksId { get; set; }
        public CountryStocksLibrary.CountryStocks CountryStocks { get; set; }
    }
}
