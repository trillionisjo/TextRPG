using System;
using Newtonsoft.Json;

namespace TextRPG {
    public class Player : IWeaponEquipable, IArmorEquipable {
        [JsonProperty] public int Level { get; set; }
        [JsonProperty] public int Health { get; set; }
        [JsonProperty] public float Attack { get; set; }
        [JsonProperty] public int WeaponAttack { get; set; }
        [JsonProperty] public int Defense { get; set; }
        [JsonProperty] public int ArmorDefense { get; set; }
        [JsonProperty] protected Weapon EquiptedWeapon { get; set; }
        [JsonProperty] protected Armor EquiptedArmor { get; set; }
        [JsonProperty] public int Gold { get; set; }
        [JsonProperty] public string Class { get; set; }
        [JsonProperty] public int DungeonClearCount { get; set; }

        public Player (int level, int health, float attack, int defense, int gold, string @class) { 
            Level = level;
            Health = health;
            Attack = attack;
            Defense = defense;
            Gold = gold;
            Class = @class;
            DungeonClearCount = 0;
        }

        public void ReduceGold(int amount) {
            Gold -= amount;
            if (Gold < 0) {
                Gold = 0;
            }
        }

        public void EquipWeapon (Weapon weapon) {
            UnequipWeapon();
            EquiptedWeapon = weapon;
            WeaponAttack = weapon.Attack;
            Attack += weapon.Attack;
        }

        public void UnequipWeapon () {
            if (EquiptedWeapon == null) {
                return;
            }
            Attack -= WeaponAttack;
            WeaponAttack = 0;
            EquiptedWeapon = null;
        }

        public void ToggleWeapon (Weapon weapon) {
            if (EquiptedWeapon == weapon) {
                UnequipWeapon();
            } else {
                EquipWeapon(weapon);
            }
        }

        public Weapon GetEquiptedWeapon () {
            return EquiptedWeapon;
        }

        public void EquipArmor (Armor armor) {
            UnequipArmor();
            EquiptedArmor = armor;
            ArmorDefense = armor.Defense;
            Defense += armor.Defense;
        }

        public void UnequipArmor () {
            if (EquiptedArmor == null) {
                return;
            }
            Defense -= ArmorDefense;
            ArmorDefense = 0;
            EquiptedArmor = null;
        }

        public void ToggleArmor (Armor armor) {
            if (EquiptedArmor == armor) {
                UnequipArmor();
            } else {
                EquipArmor(armor);
            }

        }
        public Armor GetEquiptedArmor () {
            return EquiptedArmor;
        }

        public void LevelUp() {
            Level += 1;
            Attack += 0.5f;
            Defense += 1;
        }

        public void DungeonCleared () {
            DungeonClearCount += 1;
            if (DungeonClearCount >= Level) {
                LevelUp();
                DungeonClearCount = 0;
            }
        }

        public void RestoreHelath() {
            Health = 100;
        }

        public void SaveData(StreamWriter writer) {
            writer.WriteLine(Level);
            writer.WriteLine(Health);
            writer.WriteLine(Attack);
            writer.WriteLine(Defense);
            writer.WriteLine(Gold);
            writer.WriteLine(Class);
            writer.WriteLine(DungeonClearCount);
            writer.WriteLine(EquiptedArmor == null ? "null" : EquiptedArmor.Name);
            writer.WriteLine(EquiptedWeapon == null ? "null" : EquiptedWeapon.Name);
        }

        public void LoadData(StreamReader reader) {
            int intValue;
            float floatValue;
            string name;

            int.TryParse(reader.ReadLine(), out intValue);
            Level = intValue;

            int.TryParse(reader.ReadLine(), out intValue);
            Health = intValue;

            float.TryParse(reader.ReadLine(), out floatValue);
            Attack = floatValue;

            int.TryParse(reader.ReadLine(), out intValue);
            Defense = intValue;

            int.TryParse(reader.ReadLine(), out intValue);
            Gold = intValue;

            Class = reader.ReadLine();

            int.TryParse(reader.ReadLine(), out intValue);
            DungeonClearCount = intValue;

            name = reader.ReadLine();
            if (name != null && name != "null") {
                EquiptedArmor = (Armor)Game.GetItemByName(name);
            }

            name = reader.ReadLine();
            if (name != null && name != "null") {
                EquiptedWeapon = (Weapon)Game.GetItemByName(name);
            }
        }


    }
        
}
