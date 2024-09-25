using System;

namespace TextRPG {
    public interface IWeaponEquipable {
        public void EquipWeapon (Weapon weapon);
        public void UnequipWeapon ();
        public void ToggleWeapon (Weapon weapon);
        public Weapon GetEquiptedWeapon ();
    }

    public interface IArmorEquipable {
        public void EquipArmor (Armor armor);
        public void UnequipArmor ();
        public void ToggleArmor (Armor armor);
        public Armor GetEquiptedArmor ();
    }

}
