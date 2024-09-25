using System;

namespace TextRPG {
    public abstract class Character {
        public int Level { get; set; }
        public int Health { get; set; }
        public float Attack { get; set; }
        public int WeaponAttack { get; set; }
        public int Defense { get; set; }
        public int ArmorDefense { get; set; }
        protected Weapon EquiptedWeapon { get; set; }
        protected Armor EquiptedArmor { get; set; }
        public int Gold { get; set; }

        public Character (int level, int health, float attack, int defense, int gold) {
            Level = level;
            Health = health;
            Attack = attack;
            Defense = defense;
            Gold = gold;
        }
    }
}
