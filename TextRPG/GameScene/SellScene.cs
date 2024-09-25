using System;

namespace TextRPG {
    public class SellScene : GameScene {
        protected const int NameWidth = -15;
        protected const int StatWidth = -10;
        protected const int DescWidth = -50;
        protected const int PriceWidth = -8;
        protected const float rate = 0.85f;

        protected override void WriteHeader () {
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
        }
        
        protected override void WriteContent () {
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{Game.Player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            WriteItemList();
            Console.WriteLine();
        }

        protected override void WriteMenu () {
            Console.WriteLine("0. 나가기");
        }

        protected override void HandleInput () {
            string input = Console.ReadLine() ?? string.Empty;

            if (input == "0") {
                Game.ExitCurrentScene();
            }

            if (int.TryParse(input, out var selectedIndex) && (0 < selectedIndex && selectedIndex <= Game.PlayerItemList.Count)) {
                SellItem(selectedIndex - 1);
            } else {
                warningMessage = "!! 잘못된 입력입니다 !!";
            }
        }

        private void SellItem(int index) {
            Item item = Game.PlayerItemList[index];

            switch (item) {
            case Weapon weapon:
                Game.Player.UnequipWeapon();
                break;

            case Armor armor:
                Game.Player.UnequipArmor();
                break;
            }

            RestoreItem(item);
            Game.PlayerItemList.Remove(item);
            Game.Player.Gold += (int)(item.Price * rate);
        }

        private void RestoreItem(Item item) {
            for (int i = 0; i < Game.ShopItemList.Count; i++) {
                if (Game.ShopItemList[i].Item == item) {
                    Game.ShopItemList[i].IsSold = false;
                }
            }
        }

        private void WriteItemList () {
            int count = 1;
            foreach (Item item in Game.PlayerItemList) {
                string stat = "";
                string price = $"{(int)(item.Price * rate)} G";

                if (item is Armor armor) {
                    stat = $"방어력 {armor.Defense:+#;-#;0}";
                } else if (item is Weapon weapon) {
                    stat = $"공격력 {weapon.Attack:+#;-#;0}";
                }

                WriteItemDetails(count++, item.Name, stat, item.Desc, price);
            }
        }

        private void WriteItemDetails (int number, string name, string stat, string desc, string price) {
            Console.WriteLine($"- {number,2} {WriteHelper.PadKorean(name, NameWidth)} | {WriteHelper.PadKorean(stat, StatWidth)} | {WriteHelper.PadKorean(desc, DescWidth)} | {price,PriceWidth}");
        }
    }
}
