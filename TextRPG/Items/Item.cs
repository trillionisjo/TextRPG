using System;

namespace TextRPG {
    public abstract class Item {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Desc { get; set; }

        public Item(string name, int price, string desc) {
            Name = name;
            Price = price;
            Desc = desc;
        }
    }
}
