using System;

namespace TextRPG {
    public class HardDungeonScene : DungeonScene {
        public HardDungeonScene () {
            recommendedDefense = 17;
            rewardGold = 2500;
            chance = 0.4;
            name = "어려운 던전";

            TryDungeon();
        }
    }
}
