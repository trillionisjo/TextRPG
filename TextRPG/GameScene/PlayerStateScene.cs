using System;

namespace TextRPG {
    public class PlayerStateScene : GameScene {
        protected override void WriteHeader () {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
        }

        protected override void WriteContent () {
            string weaponAttack = Game.Player.GetEquiptedWeapon() == null ? "" : $"{Game.Player.WeaponAttack:+#;-#} ({Game.Player.GetEquiptedWeapon().Name})";
            string armorDefense = Game.Player.GetEquiptedArmor() == null ? "" : $"{Game.Player.ArmorDefense:+#;-#} ({Game.Player.GetEquiptedArmor().Name})";

            Console.WriteLine($"Lv {Game.Player.Level:D2}");
            Console.WriteLine($"Chad ( {Game.Player.Class} )");
            Console.WriteLine($"공격력 : {Game.Player.Attack} {weaponAttack}");
            Console.WriteLine($"방어력 : {Game.Player.Defense} {armorDefense}");
            Console.WriteLine($"체력 : {Game.Player.Health}");
            Console.WriteLine($"Gold : {Game.Player.Gold} G");
            Console.WriteLine();
        }

        protected override void WriteMenu () {
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        protected override void HandleInput (int selectedNumber) {
            switch (selectedNumber) {
            case 0: Game.ExitCurrentScene(); break;
            default: UpdateMessage(wrongInputMessage); break;
            }
        }
    }
}
