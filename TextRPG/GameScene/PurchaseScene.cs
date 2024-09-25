using System;

namespace TextRPG {
    public class PurchaseScene : GameScene {
        protected override void WriteHeader () {
            Console.WriteLine("상점 - 아이템 구매");
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
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        protected override void HandleInput (int selectedNumber) {
            switch (selectedNumber) {
            case 0: Game.ExitCurrentScene(); break;
            case int n when 0 < n && n <= Game.ShopItemList.Count:
                BuyItem(Game.ShopItemList[n - 1]);
                break;
            default:
                UpdateMessage(wrongInputMessage);
                break;
            }
        }

        private void BuyItem (ShopItem shopItem) {
            if (shopItem.IsSold) {
                UpdateMessage(alreadyPurchasedItemMessage);
                return;
            }
            if (Game.Player.Gold < shopItem.Item.Price) {
                UpdateMessage(notEnoughGoldMessage);
                return;
            }
            shopItem.IsSold = true;
            Game.Player.ReduceGold(shopItem.Item.Price);
            Game.PlayerItemList.Add(shopItem.Item);
            UpdateMessage(purchasedMessage);
        }

        private void WriteSaleItemList () {
            int count = 1;
            foreach (ShopItem shopItem in Game.ShopItemList) {
                string price;
                if (shopItem.IsSold) {
                    price = "구매완료";
                } else {
                    price = $"{shopItem.Item.Price} G";
                }

                WriteItemDetails(count++, shopItem.Item.Name, shopItem.Item.GetStatText(), shopItem.Item.Desc, price);
            }
        }

        private void WriteItemDetails (int number, string name, string stat, string desc, string price) {
            Console.WriteLine($"- {number,2} {WriteHelper.PadKorean(name, NameWidth)} | {WriteHelper.PadKorean(stat, StatWidth)} | {WriteHelper.PadKorean(desc, DescWidth)} | {price, PriceWidth}");
        }
    }
}
