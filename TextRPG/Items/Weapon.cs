using Newtonsoft.Json;
using System;

namespace TextRPG {
    [Serializable]
    public class Weapon : Item {
        [JsonProperty] public int Attack { get; set; }

        public Weapon(int id, string name, int price, string desc, int attack) : base(id, name, price, desc) {
            Attack = attack;
        }

        public override string GetStatText () {
            return $"공격력 {Attack:+#;-#;0}";
        }
    }
}
