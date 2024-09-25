using System;

namespace TextRPG {
    public class Weapon : Item {
        public int Attack { get; set; }

        public Weapon(string name, int price, string desc, int attack) : base(name, price, desc) {
            Attack = attack;
        }
    }
}
