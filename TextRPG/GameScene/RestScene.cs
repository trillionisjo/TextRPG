using System;

namespace TextRPG {
    public class RestScene : GameScene {
        private int cost = 500;

        protected override void WriteHeader () {
            Console.WriteLine("휴식하기");
            Console.WriteLine($"{cost} G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {Game.Player.Gold} G)");
            Console.WriteLine();
        }
        protected override void WriteContent () {
        }

        protected override void WriteMenu () {
            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        protected override void HandleInput (int selectedNumber) {
            switch (selectedNumber) {
            case 0: Game.ExitCurrentScene(); break;
            case 1: Rest(); break;
            default: UpdateMessage(wrongInputMessage); break;
            }
        }

        private void Rest() {
            if (Game.Player.Gold >= cost) {
                Game.Player.ReduceGold(cost);
                Game.Player.RestoreHelath();
                UpdateMessage(restedMesaged);
            } else {
                UpdateMessage(notEnoughGoldMessage);
            }
        }
    }
}
