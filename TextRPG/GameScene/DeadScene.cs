using System;

namespace TextRPG {
    public class DeadScene : GameScene {
        protected override void WriteHeader () {
            Console.WriteLine("당신은 죽었습니다.");
            Console.WriteLine("죽음으로 인해 당신은 골드를 잃어버리게 됩니다.");
        }

        protected override void WriteContent () {
            Console.WriteLine("[골드]");
            Console.WriteLine($"{Game.Player.Gold} -> 0");
            Console.WriteLine();
        }

        protected override void WriteMenu () {
            Console.WriteLine("0. 나가기");
        }

        protected override void HandleInput (int selectedNumber) {
            switch (selectedNumber) {
            case 0: Game.GoBackToCampScene(); break;
            default: UpdateMessage(wrongInputMessage); break;
            }
        }

        protected override void DoAfterInput () {
            Game.Player.Gold = 0;
        }
    }
}
