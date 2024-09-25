using System;

namespace TextRPG {
    public abstract class DungeonScene : GameScene {
        protected int recommendedDefense;
        protected int rewardGold;
        protected double chance;

        private int previousHealth;
        private int previousGold;

        protected string name;
        private bool isDungeonCleared;

        protected void TryDungeon () {
            previousGold = Game.Player.Gold;
            previousHealth = Game.Player.Health;

            isDungeonCleared = true;
            if (Game.Player.Defense < recommendedDefense) {
                if (GetChance(chance)) {
                    isDungeonCleared = false;
                }
            }

            CalcResult();
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


        protected override void WriteHeader () {
            if (isDungeonCleared) {
                Console.WriteLine("던전 클리어");
                Console.WriteLine("축하합니다!!");
                Console.WriteLine($"{name}을 클리어 하였습니다.");
            } else {
                Console.WriteLine("던전 클리어 실패");
                Console.WriteLine($"{name} 공략에 실패하였습니다.");
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

        protected override void HandleInput () {
            if (Game.Player.Health <= 0) {
                Game.Player.Health = 1;
                Game.CurrentScene = new DeadScene();
                return;
            }

            var menuAction = new Dictionary<string, Action>() {
                { "0", Game.ExitCurrentScene },
            };
            HandleMenuInput(menuAction);
        }
    }
}
