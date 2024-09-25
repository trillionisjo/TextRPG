using Newtonsoft.Json;
using System;

namespace TextRPG {
    [Serializable]
    public class ShopItem {
        [JsonProperty] public Item Item { get; set; }
        [JsonProperty] public bool IsSold { get; set; }

        public ShopItem (Item item, bool isSold) {
            Item = item;
            IsSold = isSold;
        }
    }
}
