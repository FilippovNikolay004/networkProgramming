using BuyerLibrary;
using DiscountedItemsLibrary;

namespace ListSectionsLibrary {
    public class ListSections {
        public int Id { get; set; }
        public string MobilePhone { get; set; }
        public string Laptop { get; set; }
        public string KitchenAppliances { get; set; }
        public string Tablets { get; set; }
        public string TVs { get; set; }


        // Навигационные свойства
        public ICollection<Buyer> Buyers { get; set; } = new List<Buyer>();
        public ICollection<DiscountedItems> DiscountedItems { get; set; } = new List<DiscountedItems>();
    }
}
