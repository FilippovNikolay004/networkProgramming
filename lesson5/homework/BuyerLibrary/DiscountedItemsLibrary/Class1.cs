using ListSectionsLibrary;
using CountryStocksLibrary;

namespace DiscountedItemsLibrary {
    public class DiscountedItems {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<ListSections> IdListSections { get; set; }
        public virtual ICollection<CountryStocks> IdCountryStocks { get; set; }
    }
}
