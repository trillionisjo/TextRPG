using System;

namespace TextRPG {
    public class EasyDungeonScene : DungeonScene {
        public EasyDungeonScene() {
            recommendedDefense = 5;
            rewardGold = 1000;
            chance = 0.4;
            name = "쉬운 던전";

            TryDungeon();
        }
    }
}
