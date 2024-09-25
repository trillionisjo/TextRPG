using System;

namespace TextRPG {
    public class ShopScene : GameScene {
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

        protected override void HandleInput (int selectedNumber) {
            switch (selectedNumber) {
            case 0: Game.ExitCurrentScene(); break;
            case 1: EnterNewScene(new PurchaseScene()); break;
            case 2: EnterNewScene(new SellScene()); break;
            default: UpdateMessage(wrongInputMessage); break;
            }
        }

        private void WriteSaleItemList () {
            foreach (ShopItem shopItem in Game.ShopItemList) {
                string price;
                if (shopItem.IsSold) {
                    price = "구매완료";
                } else {
                    price = $"{shopItem.Item.Price} G";
                }

                WriteItemDetails(shopItem.Item.Name, shopItem.Item.GetStatText(), shopItem.Item.Desc, price);
            }
        }

        private void WriteItemDetails(string name, string stat, string desc, string price) {
            Console.WriteLine($"{WriteHelper.PadKorean(name, NameWidth)} | {WriteHelper.PadKorean(stat, StatWidth)} | {WriteHelper.PadKorean(desc, DescWidth)} | {price, PriceWidth}");
        }
    }
}
