using System;

namespace TextRPG {
    public class ShopItem {
        public Item Item { get; set; }
        public bool IsSold { get; set; }

        public ShopItem (Item item, bool isSold) {
            Item = item;
            IsSold = isSold;
        }
    }
}
