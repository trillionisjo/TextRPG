using Newtonsoft.Json;
using System;

namespace TextRPG {
    [Serializable]
    public class Weapon : Item {
        [JsonProperty] public int Attack { get; set; }

        public Weapon(string name, int price, string desc, int attack) : base(name, price, desc) {
            Attack = attack;
        }
    }
}
