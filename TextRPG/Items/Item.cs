using System;
using Newtonsoft.Json;

namespace TextRPG {
    [Serializable]
    public abstract class Item {
        [JsonProperty] public int Id { get; protected set; }
        [JsonProperty] public string Name { get; protected set; }
        [JsonProperty] public int Price { get; protected set; }
        [JsonProperty] public string Desc { get; protected set; }

        public Item(int id, string name, int price, string desc) {
            Id = id;
            Name = name;
            Price = price;
            Desc = desc;
        }

        public abstract string GetStatText ();
    }
}
