using System;

namespace TextRPG {
    public abstract class GameScene {
        protected string warningMessage;

        protected abstract void WriteHeader ();
        protected abstract void WriteContent ();
        protected abstract void WriteMenu ();
        protected abstract void HandleInput ();

        public void Run() {
            Console.Clear();
            WriteHeader();
            WriteContent();
            WriteMenu();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            if (warningMessage != null) {
                Console.WriteLine(warningMessage);
            }
            Console.Write(">> ");
            HandleInput();
        }

        // ReadInput 추가하기. 자식에게 입력 방법의 변경의 기회를 주자.

        protected void HandleMenuInput(Dictionary<string, Action> menuAction) {
            string input = Console.ReadLine() ?? string.Empty;

            if (menuAction.TryGetValue(input, out var action)) {
                action.Invoke();
                warningMessage = null;
            } else {
                warningMessage = "!! 잘못된 입력입니다 !!";
            }
        }
    }
}
