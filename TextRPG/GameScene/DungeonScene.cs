using System;
using System.Xml;

namespace TextRPG {
    public class DungeonScene : GameScene {
        protected int recommendedDefense;
        protected int rewardGold;
        protected double failChance;

        private int previousHealth;
        private int previousGold;

        protected string dungeonName;
        private bool isDungeonCleared;

        public DungeonScene(string dungeonName, int recommendedDefense, int rewardGold, double failChance) {
            this.dungeonName = dungeonName;
            this.recommendedDefense = recommendedDefense;
            this.rewardGold = rewardGold;
            this.failChance = failChance;
        }

        protected void TryDungeon () {
            previousGold = Game.Player.Gold;
            previousHealth = Game.Player.Health;

            isDungeonCleared = true;
            if (Game.Player.Defense < recommendedDefense) {
                if (GetChance(failChance)) {
                    isDungeonCleared = false;
                }
            }
        }

        private void CalcResult () {
            if (isDungeonCleared == false) {
                Game.Player.Health /= 2;
                return;
            }
            Game.Player.DungeonCleared();
            CalcHealthResult();
            CalcGoldResult();
        }

        private void CalcHealthResult () {
            int decrease = new Random().Next(20, 35);
            int diff = Game.Player.Defense - recommendedDefense;
            if (diff < 0) {
                decrease -= new Random().Next(diff, 0);
            } else {
                decrease -= new Random().Next(0, diff);
            }
            Game.Player.Health -= decrease;
        }

        private void CalcGoldResult () {
            float attack = Game.Player.Attack;
            double rand = new Random().NextDouble();
            double rate = (rand * attack * 2 + attack) / 100f;
            int reward = (int)(rewardGold * rate);
            Game.Player.Gold += rewardGold + reward;
        }

        protected bool GetChance (double chance) {
            return new Random().NextDouble() < chance;
        }

        protected override void DoBeforeWriting () {
            TryDungeon();
            CalcResult();
        }

        protected override void WriteHeader () {
            if (isDungeonCleared) {
                Console.WriteLine("던전 클리어");
                Console.WriteLine("축하합니다!!");
                Console.WriteLine($"{dungeonName}을 클리어 하였습니다.");
            } else {
                Console.WriteLine("던전 클리어 실패");
                Console.WriteLine($"{dungeonName} 공략에 실패하였습니다.");
            }
            Console.WriteLine();
        }
        protected override void WriteContent () {
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {previousHealth} -> {Game.Player.Health}");
            Console.WriteLine($"Gold {previousGold} -> {Game.Player.Gold}");
            Console.WriteLine();
        }

        protected override void WriteMenu () {
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        protected override int ReadInput () {
            if (Game.Player.Health <= 0) {
                Game.Player.RestoreHelath();
                return 1;
            }
            return base.ReadInput();
        }

        protected override void HandleInput (int selectedNumber) {
            switch (selectedNumber) {
            case 0: Game.ExitCurrentScene(); break;
            case 1: Game.EnterNewScene(new DeadScene()); break;
            default: UpdateMessage(wrongInputMessage); break;
            }
        }
    }
}
