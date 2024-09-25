using Newtonsoft.Json;
using System;

namespace TextRPG {
    [Serializable]
    public class Armor : Item {
        [JsonProperty] public int Defense { get; set; }

        public Armor(string name, int price, string desc, int defense) : base(name, price, desc) {
            Defense = defense;
        }
    }
}
