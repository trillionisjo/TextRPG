using System;

static public class WriteHelper {
    public static string PadKorean(string input, int totalWidth) {
        int currentWidth = GetKoreanWidth(input);
        if (totalWidth < 0) {
            return input.PadRight(input.Length + (-totalWidth - currentWidth));
        } else if (totalWidth > 0) {
            return input.PadLeft(input.Length + (totalWidth - currentWidth));
        }
        return input;
    }

    private static int GetKoreanWidth(string input) {
        return input.Sum(c => IsKorean(c) ? 2 : 1);
    }

    private static bool IsKorean(char ch) {
        return ('가' <= ch && ch <= '힣') || ('ㄱ' <= ch && ch <= 'ㅎ') || ('ㅏ' <= ch && ch <= 'ㅣ');
    }
}
