using System;
namespace TextRPG {
    public class CampScene : GameScene {
        protected override void WriteHeader () {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
        }

        protected override void WriteContent () {
        }

        protected override void WriteMenu () {
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전입장");
            Console.WriteLine("5. 휴식하기");
            Console.WriteLine("6. 저장하기");
            Console.WriteLine("7. 불러오기");
            Console.WriteLine();
        }

        protected override void HandleInput () {
            string input = Console.ReadLine() ?? string.Empty;
            int.TryParse(input, out var number);

            switch (number) {
            case 1: Game.CurrentScene = new PlayerStateScene(Game.Player); break;
            case 2: Game.CurrentScene = new InventoryScene(); break;
            case 3: Game.CurrentScene = new ShopScene(); break;
            case 4: Game.CurrentScene = new ChooseDungeonScene(); break;
            case 5: Game.CurrentScene = new RestScene(); break;
            case 6: SaveManager.Save(); break;
            case 7: SaveManager.Load(); break;
            }
        }

        private void LoadData() {
            //Data? data = SaveManager.Load();
            //if (data == null) {
            //    warningMessage = "!! 저장된 데이터가 없습니다 !!";
            //    return;
            //}

            //Game.Player = data.Player;
            //Game.PlayerItemList = data.PlayerItems;
            //Game.ShopItemList = data.ShopItems;
            //warningMessage = "!! 불러오기 성공 !!";
        }

        private void SaveData() {
            //SaveManager.Save();
        }
    }
}
