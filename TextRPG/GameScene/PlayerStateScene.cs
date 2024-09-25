using System;

namespace TextRPG {
    public class PlayerStateScene : GameScene {
        private readonly Player player;

        public PlayerStateScene(Player player) {
            this.player = player;
        }

        protected override void WriteHeader () {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
        }

        protected override void WriteContent () {
            string weaponAttack = player.WeaponAttack == 0 ? "" : $"{player.WeaponAttack:+#;-#}";
            string armorDefense = player.ArmorDefense == 0 ? "" : $"{player.ArmorDefense:+#;-#}";

            Console.WriteLine($"Lv {player.Level:D2}");
            Console.WriteLine($"Chad ( {player.Class} )");
            Console.WriteLine($"공격력 : {player.Attack} {weaponAttack}");
            Console.WriteLine($"방어력 : {player.Defense} {armorDefense}");
            Console.WriteLine($"체력 : {player.Health}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
        }

        protected override void WriteMenu () {
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        protected override void HandleInput () {
            var menuAction = new Dictionary<string, Action>() {
                { "0", Game.ExitCurrentScene },
            };
            HandleMenuInput(menuAction);
        }
    }
}
