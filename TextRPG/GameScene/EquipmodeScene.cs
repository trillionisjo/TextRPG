using System;

namespace TextRPG {
    public class EquipmodeScene : GameScene {
        static protected int NameWidth = -15;
        static protected int StatWidth = 3;
        static protected int DescWidth = -30;


        protected override void WriteHeader () {
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
        }

        protected override void WriteContent () {
            Console.WriteLine("[아이템 목록]");
            WriteItemList();
            Console.WriteLine();
        }

        protected override void WriteMenu () {
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        protected override void HandleInput () {
            string input = Console.ReadLine() ?? string.Empty;

            if (input == "0") {
                Game.ExitCurrentScene();
            }

            if (int.TryParse(input, out var selectedIndex) && (0 < selectedIndex && selectedIndex <= Game.PlayerItemList.Count)) {
                EquipItem(Game.PlayerItemList[selectedIndex - 1]);
                warningMessage = null;
            } else {
                warningMessage = "!! 잘못된 입력입니다 !!";
            }
        }

        private void EquipItem (Item selectedItem) {
            switch (selectedItem) {
            case Weapon weapon:
                Game.Player.ToggleWeapon(weapon);
                break;

            case Armor armor:
                Game.Player.ToggleArmor(armor);
                break;
            }
        }

        private void WriteItemList () {
            int count = 1;
            foreach (Item item in Game.PlayerItemList) {
                
                string stat = "";
                bool equipted = false;

                if (item is Armor armor) {
                    if (Game.Player.GetEquiptedArmor() == armor) {
                        equipted = true;
                    }
                    stat = $"방어력 +{armor.Defense}";
                } else if (item is Weapon weapon) {
                    if (Game.Player.GetEquiptedWeapon() == weapon) {
                        equipted = true;
                    }
                    stat = $"공격력 +{weapon.Attack}";
                }
                
                string name = $"{(equipted ? "[E]" : "")}{item.Name}";

                WriteItemDetails(count++, name, stat, item.Desc);
            }
        }

        private void WriteItemDetails (int index, string name, string stat, string desc) {
            Console.WriteLine($"- {index,2} {WriteHelper.PadKorean(name, NameWidth)} | {WriteHelper.PadKorean(stat, StatWidth)} | {WriteHelper.PadKorean(desc, DescWidth)}");
        }
    }
}
