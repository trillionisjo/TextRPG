using System;

namespace TextRPG {
    public class ShopScene : GameScene {
        protected const int NameWidth = -15;
        protected const int StatWidth = -10;
        protected const int DescWidth = -50;
        protected const int PriceWidth = -8;

        protected override void WriteHeader () {
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
        }

        protected override void WriteContent () {
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{Game.Player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            WriteSaleItemList();
            Console.WriteLine();

        }

        protected override void WriteMenu () {
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        protected override void HandleInput () {
            var menuAction = new Dictionary<string, Action>() {
                { "0", Game.ExitCurrentScene },
                { "1", () => Game.CurrentScene = new PurchaseScene() },
                { "2", () => Game.CurrentScene = new SellScene() },
            };
            HandleMenuInput(menuAction);
        }

        private void WriteSaleItemList () {
            foreach (ShopItem shopItem in Game.ShopItemList) {
                string stat = "";
                string price = "";

                if (shopItem.Item is Armor armor) {
                    stat = $"방어력 {armor.Defense:+#;-#;0}";
                } else if (shopItem.Item is Weapon weapon) {
                    stat = $"공격력 {weapon.Attack:+#;-#;0}";
                }

                if (shopItem.IsSold) {
                    price = "구매완료";
                } else {
                    price = $"{shopItem.Item.Price} G";
                }

                WriteItemDetails(shopItem.Item.Name, stat, shopItem.Item.Desc, price);
            }
        }

        private void WriteItemDetails(string name, string stat, string desc, string price) {
            Console.WriteLine($"{WriteHelper.PadKorean(name, NameWidth)} | {WriteHelper.PadKorean(stat, StatWidth)} | {WriteHelper.PadKorean(desc, DescWidth)} | {price,8}");
        }
    }
}
