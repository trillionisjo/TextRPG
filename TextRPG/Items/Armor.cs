using System;

namespace TextRPG {
    public class Armor : Item {
        public int Defense { get; set; }

        public Armor(string name, int price, string desc, int defense) : base(name, price, desc) {
            Defense = defense;
        }
    }
}
