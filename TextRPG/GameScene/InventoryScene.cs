using System;
using System.Diagnostics.Tracing;

namespace TextRPG {
    public class InventoryScene : GameScene {
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

        protected override void HandleInput (int selectedNumber) {
            switch (selectedNumber) {
            case 0: Game.ExitCurrentScene(); break;
            case 1: Game.EnterNewScene(new EquipmodeScene()); break;
            default: UpdateMessage(wrongInputMessage); break;
            }
        }

        protected virtual void WriteItemList() {
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
