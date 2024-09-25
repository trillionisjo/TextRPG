using System;

namespace TextRPG {
    public class EquipmodeScene : GameScene {
        protected override void WriteHeader () {
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
        }

        protected override void WriteContent () {
            Console.WriteLine("[아이템 목록]");
            WriteItemList();
            Console.WriteLine();
        }

        protected override void WriteMenu () {
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        protected override void HandleInput (int selectedNumber) {
            switch (selectedNumber) {
            case 0:
                Game.ExitCurrentScene();
                break;
            case int n when 0 < n && n <= Game.PlayerItemList.Count:
                Game.Player.EquipItem(Game.PlayerItemList[n - 1]);
                break;
            default:
                UpdateMessage(wrongInputMessage);
                break;
            }
        }

        private void WriteItemList () {
            int count = 1;
            foreach (Item item in Game.PlayerItemList) {
                bool equipted = Game.Player.IsEquiptedItem(item);                
                string name = $"{(equipted ? "[E]" : "")}{item.Name}";
                WriteItemDetails(count++, name, item.GetStatText(), item.Desc);
            }
        }

        private void WriteItemDetails (int index, string name, string stat, string desc) {
            Console.WriteLine($"- {index,2} {WriteHelper.PadKorean(name, NameWidth)} | {WriteHelper.PadKorean(stat, StatWidth)} | {WriteHelper.PadKorean(desc, DescWidth)}");
        }
    }
}
