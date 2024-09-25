using Newtonsoft.Json;
using System.Text.Json;

namespace TextRPG {
    public class SaveData {
        [JsonProperty] public Player Player { get; set; }
        [JsonProperty] public List<Item> PlayerItems { get; set; }
        [JsonProperty] public List<ShopItem> ShopItems { get; set; }
    }

    public static class SaveManager {
        private static readonly string path = "gamesave.txt";
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

        public static void Save() {
            var data = new SaveData {
                Player = Game.Player,
                PlayerItems = Game.PlayerItemList,
                ShopItems = Game.ShopItemList,
            };

            string jsonString = JsonConvert.SerializeObject(data, settings);
            File.WriteAllText(path, jsonString);
        }

        public static bool Load() {
            if (!File.Exists(path)) {
                return false;
            }

            string jsonString = File.ReadAllText(path);
            var data = JsonConvert.DeserializeObject<SaveData>(jsonString, settings);
            Game.Player = data.Player;
            Game.PlayerItemList = data.PlayerItems;
            Game.ShopItemList = data.ShopItems;
            return true;
        }
    }
}
