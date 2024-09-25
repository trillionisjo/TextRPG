using System;

namespace TextRPG {
    public interface IWeaponEquipable {
        public Weapon EquiptedWeapon { get; }
        public void EquipWeapon (Weapon weapon);
        public void UnequipWeapon ();
        public void ToggleWeapon (Weapon weapon);
    }

    public interface IArmorEquipable {
        public Armor EquiptedArmor { get; }
        public void EquipArmor (Armor armor);
        public void UnequipArmor ();
        public void ToggleArmor (Armor armor);
    }

}
