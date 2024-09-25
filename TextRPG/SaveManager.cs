using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TextRPG {
    public class Data {
        public Player Player { get; set; }
        public List<Item> PlayerItems { get; set; }
        public List<ShopItem> ShopItems { get; set; }
    }

    public static class SaveManager {
        private static string fileName = "gamesave.txt";


        //public static void Save() {
        //    var saveData = new Data {
        //        Player = Game.Player,
        //        PlayerItems = Game.PlayerItemList,
        //        ShopItems = Game.ShopItemList,
        //    };

        //    string jsonString = JsonSerializer.Serialize(saveData);
        //    File.WriteAllText(fileName, jsonString);
        //}

        //public static Data? Load() {
        //    if (!File.Exists(fileName)) {
        //        return null;
        //    }
        //                                                          
        //    string jsonString = File.ReadAllText(fileName);           json을 이용하니 파일을 불러오는데서 자꾸 에러가 난다... 결국 수작업으로 세이브 로드를 해야하나.. 마음에 안든다.
        //    return JsonSerializer.Deserialize<Data>(jsonString);
        //}

        public static void Save() {
            var stream = File.Open(fileName, FileMode.Create);
            var writer = new StreamWriter(stream);
            Game.Player.SaveData(writer);
            SavePlayerItemList(writer);
            SaveShopItemList(writer);
            writer.Close();
        }

        public static void Load() {
            var stream = File.Open(fileName, FileMode.Open);
            var reader = new StreamReader(stream);
            Game.Player.LoadData(reader);
            LoadPlayerItemList(reader);
            LoadShopItemList(reader);
            reader.Close();
        }

        public static void SavePlayerItemList(StreamWriter writer) {
            writer.WriteLine(Game.PlayerItemList.Count);
            for (int i = 0; i < Game.PlayerItemList.Count; i++) {
                writer.WriteLine(Game.PlayerItemList[i].Name);
            }
        }

        public static void LoadPlayerItemList(StreamReader reader) {
            Game.PlayerItemList.Clear();
            int.TryParse(reader.ReadLine(), out var count);
            for (int i = 0; i < count; i++) {
                string? name = reader.ReadLine();
                if (name == null) {
                    continue;
                }
                Game.PlayerItemList.Add(GetItemByName(name));
            }
        }

        public static void SaveShopItemList(StreamWriter writer) {
            writer.WriteLine(Game.ShopItemList.Count);
            for (int i = 0; i < Game.ShopItemList.Count; i++) {
                writer.WriteLine(Game.ShopItemList[i].Item.Name);
                writer.WriteLine(Game.ShopItemList[i].IsSold);
            }
        }

        public static void LoadShopItemList (StreamReader reader) {
            Game.ShopItemList.Clear();
            int.TryParse(reader.ReadLine(), out var count);
            for (int i = 0; i < count; i++) {
                string? name = reader.ReadLine();
                if (name == null) {
                    continue;
                }
                bool.TryParse(reader.ReadLine(), out var isSold);
                Game.ShopItemList.Add(new ShopItem(GetItemByName(name), isSold));
            }
        }

        public static Item GetItemByName(string name) {
            switch (name) {
            case "수련자의 갑옷": return Game.TraineesArmor;
            case "무쇠갑옷": return Game.IronArmor;
            case "스파르타의 갑옷": return Game.SpartanArmor;
            case "낡은 검": return Game.WornSword;
            case "청동 도끼": return Game.BronzeAxe;
            case "스파르타의 창": return Game.SpartanSpear;
            default: return null;
            }
        }
    }
}
