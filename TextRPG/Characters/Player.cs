using System;

namespace TextRPG {
    public class Player : Character, IWeaponEquipable, IArmorEquipable {
        public string Class { get; set; }

        public int DungeonClearCount { get; set; }

        public Player (int level, int health, float attack, int defense, int gold, string @class)
            : base(level, health, attack, defense, gold) {
            Class = @class;
            DungeonClearCount = 0;
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
            EquiptedWeapon = null;
            Attack -= WeaponAttack;
            WeaponAttack = 0;
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
            EquiptedWeapon = null;
            Defense -= ArmorDefense;
            ArmorDefense = 0;
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

        public void MaxHealing() {
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
        }

        public void LoadData(StreamReader reader) {
            int intValue;
            float floatValue;

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
        }


    }
        
}
