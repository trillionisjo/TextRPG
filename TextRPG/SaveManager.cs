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

        public static void Save() {
            var stream = File.Open(fileName, FileMode.Create);
            var writer = new StreamWriter(stream);
            Game.Player.SaveData(writer);
            SavePlayerItemList(writer);
            SaveShopItemList(writer);
            writer.Close();
        }

        public static bool Load() {
            if (!File.Exists(fileName)) {
                return false;
            }

            var stream = File.Open(fileName, FileMode.Open);
            var reader = new StreamReader(stream);
            Game.Player.LoadData(reader);
            LoadPlayerItemList(reader);
            LoadShopItemList(reader);
            reader.Close();

            return true;
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
                Game.PlayerItemList.Add(Game.GetItemByName(name));
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
                Game.ShopItemList.Add(new ShopItem(Game.GetItemByName(name), isSold));
            }
        }
    }
}
