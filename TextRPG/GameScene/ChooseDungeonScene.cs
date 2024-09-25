using System;

namespace TextRPG {
    public class ChooseDungeonScene : GameScene {
        protected override void WriteHeader () {
            Console.WriteLine("던전입장");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
        }

        protected override void WriteContent () {
            Console.WriteLine($"1. {WriteHelper.PadKorean("쉬운 던전", -12)} | 방어력 5 이상 권장");
            Console.WriteLine($"2. {WriteHelper.PadKorean("일반 던전", -12)} | 방어력 11 이상 권장");
            Console.WriteLine($"3. {WriteHelper.PadKorean("어려운 던전", -12)} | 방어력 17 이상 권장");
            Console.WriteLine();
        }

        protected override void WriteMenu () {
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        protected override void HandleInput () {
            var menuAction = new Dictionary<string, Action>() {
                { "0", Game.ExitCurrentScene },
                { "1", () => Game.CurrentScene = new EasyDungeonScene() },
                { "2", () => Game.CurrentScene = new NormalDungeonScene() },
                { "3", () => Game.CurrentScene = new HardDungeonScene() },
            };
            HandleMenuInput(menuAction);
        }
    }
}
