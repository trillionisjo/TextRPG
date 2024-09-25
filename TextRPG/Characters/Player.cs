using System;
using Newtonsoft.Json;

namespace TextRPG {
    public class Player : IWeaponEquipable, IArmorEquipable {
        [JsonProperty] public int Level { get; protected set; }
        [JsonProperty] public int Health { get; set; }
        [JsonProperty] public float Attack { get; protected set; }
        [JsonProperty] public int WeaponAttack { get; protected set; }
        [JsonProperty] public int Defense { get; protected set; }
        [JsonProperty] public int ArmorDefense { get; protected set; }
        [JsonProperty] public Weapon EquiptedWeapon { get; protected set; }
        [JsonProperty] public Armor EquiptedArmor { get; protected set; }
        [JsonProperty] public int Gold { get; set; }
        [JsonProperty] public string Class { get; protected set; }
        [JsonProperty] public int DungeonClearCount { get; protected set; }

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

        public void EquipItem(Item item) {
            switch (item) {
            case Armor armor:
                ToggleArmor(armor);
                break;

            case Weapon weapon:
                ToggleWeapon(weapon);
                break;
            }
        }

        public void UnequipItem (Item item) {
            switch (item) {
            case Armor armor:
                if (EquiptedArmor != null && EquiptedArmor.Id == item.Id) {
                    UnequipArmor();
                }
                break;

            case Weapon weapon:
                if (EquiptedWeapon != null && EquiptedWeapon.Id == item.Id) {
                    UnequipWeapon();
                }
                break;
            }
        }

        public bool IsEquiptedItem(Item item) {
            switch (item) {
            case Armor armor:
                if (EquiptedArmor == null) {
                    return false;
                }
                if (armor.Id != EquiptedArmor.Id) {
                    return false;
                }
                return true;

            case Weapon weapon:
                if (EquiptedWeapon == null) {
                    return false;
                }
                if (weapon.Id != EquiptedWeapon.Id) {
                    return false;
                }
                return true;
            }
            return false;
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
            if (EquiptedWeapon != null && EquiptedWeapon.Id == weapon.Id) {
                UnequipWeapon();
            } else {
                EquipWeapon(weapon);
            }
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
            if (EquiptedArmor != null && EquiptedArmor.Id == armor.Id) {
                UnequipArmor();
            } else {
                EquipArmor(armor);
            }
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
    }
        
}
