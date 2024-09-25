using Newtonsoft.Json;
using System;
using System.Collections;

namespace TextRPG {
    public static class Game {
        private static Stack<GameScene> scenes;

        // onenternewscene
        public static Action OnEnterNewScene { get; set; }

        public static GameScene CurrentScene => scenes.Peek();
        public static Player Player { get; set; }
        public static List<Item> PlayerItemList { get; set; }
        public static List<ShopItem> ShopItemList { get; set; }

        public static Armor TraineesArmor { get; private set; }
        public static Armor IronArmor { get; private set; }
        public static Armor SpartanArmor { get; private set; }
        public static Weapon WornSword { get; private set; }
        public static Weapon BronzeAxe { get; private set; }
        public static Weapon SpartanSpear { get; private set; }

        private static void Init() {
            TraineesArmor = new Armor("수련자의 갑옷", 1000, "수련에 도움을 주는 갑옷입니다", 5);
            IronArmor = new Armor("무쇠갑옷", 2000, "무쇠로 만들어져 튼튼한 갑옷입니다.", 9);
            SpartanArmor = new Armor("스파르타의 갑옷", 3500, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 15);
            WornSword = new Weapon("낡은 검", 600, "쉽게 볼 수 있는 낡은 검 입니다.", 2);
            BronzeAxe = new Weapon("청동 도끼", 1500, "어디선가 사용됐던거 같은 도끼입니다.", 5);
            SpartanSpear = new Weapon("스파르타의 창", 3000, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7);

            Player = new Player(1, 100, 10, 5, 1500, "전사");
            PlayerItemList = new List<Item>();

            ShopItemList = new List<ShopItem>();
            ShopItemList.Add(new ShopItem(TraineesArmor, false));
            ShopItemList.Add(new ShopItem(IronArmor, false));
            ShopItemList.Add(new ShopItem(SpartanArmor, false));
            ShopItemList.Add(new ShopItem(WornSword, false));
            ShopItemList.Add(new ShopItem(BronzeAxe, false));
            ShopItemList.Add(new ShopItem(SpartanSpear, false));

            scenes = new Stack<GameScene>();
            EnterNewScene(new CampScene());
        }

        public static void Start() {
            Init();
            while (true) {
                CurrentScene.Run();
            }
        }

        public static void ExitCurrentScene() {
            scenes.Pop();
        }

        public static void GoBackToCampScene () {
            while (scenes.Count > 1) {
                scenes.Pop();
            }
        }

        public static void EnterNewScene(GameScene newScene) {
            OnEnterNewScene?.Invoke();
            scenes.Push(newScene);
        }

        public static Item GetItemByName (string name) {
            switch (name) {
            case "수련자의 갑옷": return TraineesArmor;
            case "무쇠갑옷": return IronArmor;
            case "스파르타의 갑옷": return SpartanArmor;
            case "낡은 검": return WornSword;
            case "청동 도끼": return BronzeAxe;
            case "스파르타의 창": return SpartanSpear;
            default: return null;
            }
        }
    }
}
