using System;
using System.Diagnostics.Tracing;

namespace TextRPG {
    public class InventoryScene : GameScene {
        static protected int NameWidth = -15;
        static protected int StatWidth = 3;
        static protected int DescWidth = -30;

        protected override void WriteHeader () {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
        }

        protected override void WriteContent () {
            Console.WriteLine("[아이템 목록]");
            WriteItemList();
            Console.WriteLine();
        }

        protected override void WriteMenu () {
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        protected override void HandleInput () {
            var menuAction = new Dictionary<string, Action>() {
                { "0", Game.ExitCurrentScene },
                { "1", () => Game.CurrentScene = new EquipmodeScene()},
            };
            HandleMenuInput(menuAction);
        }

        protected virtual void WriteItemList() {

            // 다형성을 이용했음에도 결국 switch로 분기해줘야 하나? 마음에 안든다...
            foreach (Item item in Game.PlayerItemList) {
                string stat = "";
                if (item is Armor armor) {
                    stat = $"방어력 +{armor.Defense}";
                } else if (item is Weapon weapon) {
                    stat = $"공격력 +{weapon.Attack}";
                }

                WriteItemDetails(item.Name, stat, item.Desc);
            }
        }

        protected virtual void WriteItemDetails(string name, string stat, string desc) {
            Console.WriteLine($"{WriteHelper.PadKorean(name, NameWidth)} | {WriteHelper.PadKorean(stat, StatWidth)} | {WriteHelper.PadKorean(desc, DescWidth)}");
        }
    }
}
