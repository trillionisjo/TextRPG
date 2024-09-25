using System;

namespace TextRPG {
    public class PurchaseScene : GameScene {
        protected const int NameWidth = -15;
        protected const int StatWidth = -10;
        protected const int DescWidth = -50;
        protected const int PriceWidth = -8;

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

        protected override void HandleInput () {
            string input = Console.ReadLine() ?? string.Empty;

            if (input == "0") {
                Game.ExitCurrentScene();
            }

            if (int.TryParse(input, out var selectedIndex) && (0 < selectedIndex && selectedIndex <= Game.ShopItemList.Count)) {
                BuyItem(Game.ShopItemList[selectedIndex - 1]);
            } else {
                warningMessage = "!! 잘못된 입력입니다 !!";
            }
        }

        private void BuyItem (ShopItem shopItem) {
            if (shopItem.IsSold) {
                warningMessage = "!! 이미 구매한 상품입니다 !!";
                return;
            }

            if (Game.Player.Gold < shopItem.Item.Price) {
                warningMessage = "!! 골드가 부족합니다 !!";
                return;
            }
            Game.Player.Gold -= shopItem.Item.Price;

            shopItem.IsSold = true;
            Game.PlayerItemList.Add(shopItem.Item);
            warningMessage = null;
        }

        protected virtual void WriteSaleItemList () {
            int count = 1;
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

                WriteItemDetails(count++, shopItem.Item.Name, stat, shopItem.Item.Desc, price);
            }
        }

        protected virtual void WriteItemDetails (int number, string name, string stat, string desc, string price) {
            Console.WriteLine($"- {number,2} {WriteHelper.PadKorean(name, NameWidth)} | {WriteHelper.PadKorean(stat, StatWidth)} | {WriteHelper.PadKorean(desc, DescWidth)} | {price, PriceWidth}");
        }
    }
}
