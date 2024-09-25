using System;

namespace TextRPG {
    public class NormalDungeonScene : DungeonScene {
        public NormalDungeonScene() {
            recommendedDefense = 11;
            rewardGold = 1700;
            chance = 0.4;
            name = "일반 던전";

            TryDungeon();
        }
    }
}
