using System;
using Newtonsoft.Json;

namespace TextRPG {
    [Serializable]
    public abstract class Item {
        [JsonProperty] public string Name { get; set; }
        [JsonProperty] public int Price { get; set; }
        [JsonProperty] public string Desc { get; set; }

        public Item(string name, int price, string desc) {
            Name = name;
            Price = price;
            Desc = desc;
        }
    }
}
