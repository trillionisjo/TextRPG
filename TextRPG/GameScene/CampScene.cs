using System;
namespace TextRPG {
    public class CampScene : GameScene {
        protected override void WriteHeader () {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
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

        protected override void HandleInput (int selectedNumber) {
            switch (selectedNumber) {
            case 1: EnterNewScene(new PlayerStateScene()); break;
            case 2: EnterNewScene(new InventoryScene()); break;
            case 3: EnterNewScene(new ShopScene()); break;
            case 4: EnterNewScene(new ChooseDungeonScene()); break;
            case 5: EnterNewScene(new RestScene()); break;
            case 6: SaveData(); break;
            case 7: LoadData(); break;
            default: UpdateMessage(wrongInputMessage); break;
            }
        }

        private void LoadData() {
            if (SaveManager.Load()) {
                UpdateMessage(loadedMeessage);
            } else {
                UpdateMessage(loadFailMessage);
            }
        }

        private void SaveData() {
            SaveManager.Save();
            UpdateMessage(savedMessage);
        }
    }
}
