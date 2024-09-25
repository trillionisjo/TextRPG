using System;

namespace TextRPG {
    public abstract class GameScene {
        protected const int NameWidth = -15;
        protected const int StatWidth = -10;
        protected const int DescWidth = -50;
        protected const int PriceWidth = -8;

        protected const string wrongInputMessage = "잘못된 입력입니다.";
        protected const string alreadyPurchasedItemMessage = "이미 구매한 상품입니다.";
        protected const string notEnoughGoldMessage = "골드가 부족합니다.";
        protected const string restedMesaged = "휴식을 완료했습니다.";
        protected const string purchasedMessage = "구매를 완료하였습니다.";
        protected const string loadedMeessage = "불러오기를 완료하였습니다.";
        protected const string loadFailMessage= "불러오기를 실패하였습니다. ";
        protected const string savedMessage = "저장을 완료하였습니다.";


        protected string message;

        public GameScene() {
            Game.OnEnterNewScene += ClearMessage;
        }

        ~GameScene() {
            Game.OnEnterNewScene -= ClearMessage;
        }

        protected virtual void DoBeforeWriting () {
        }

        protected virtual void WriteHeader () {
        }

        protected virtual void WriteContent () {
        }

        protected virtual void WriteMenu () {
        }

        protected virtual int ReadInput () {
            int selectedNumber = -1;
            string input = Console.ReadLine() ?? string.Empty;
            int.TryParse(input, out selectedNumber);
            return selectedNumber;
        }

        protected virtual void HandleInput (int selectedNumber) {
        }

        protected virtual void DoAfterInput () {
        }

        public virtual void Run () {
            Console.Clear();
            DoBeforeWriting();
            WriteHeader();
            WriteContent();
            WriteMenu();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            (int x, int y) pos = Console.GetCursorPosition();
            if (message != null) {
                Console.SetCursorPosition(0, pos.y + 1);
                Console.WriteLine(message);
                Console.SetCursorPosition(pos.x, pos.y);
            }
            HandleInput(ReadInput());
            DoAfterInput();
        }

        protected void UpdateMessage (string message) {
            this.message = message;
        }

        protected void ClearMessage () {
            message = null;
        }
    }
}
