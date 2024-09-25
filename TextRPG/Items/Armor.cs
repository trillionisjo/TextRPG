using Newtonsoft.Json;
using System;

namespace TextRPG {
    [Serializable]
    public class Armor : Item {
        [JsonProperty] public int Defense { get; set; }

        public Armor(int id, string name, int price, string desc, int defense) : base(id, name, price, desc) {
            Defense = defense;
        }

        public override string GetStatText () {
            return $"방어력 {Defense:+#;-#;0}";
        }
    }
}
