namespace SiegeCharmSearcher.Shared {
    internal class Strings {
        const string LocalizedStringNotFound = "Localized string not found.";

        internal virtual string RainbowSixSiegeNotFound {
            get { return LocalizedStringNotFound; }
        }

        internal virtual string PIDFound {
            get { return LocalizedStringNotFound; }
        }
    }

    internal sealed class USEnglishStrings : Strings {
        internal override string RainbowSixSiegeNotFound {
            get {
                return "Rainbow Six Siege not found. Restart the application after launching the game.";
            }
        }

        internal override string PIDFound {
            get { return "Rainbow Six Siege PID: {0}"; }
        }
    }

    internal sealed class KoreanStrings : Strings {
        internal override string RainbowSixSiegeNotFound {
            get {
                return "레인보우 식스 시즈가 발견되지 않았습니다. 게임을 시작한 후에 다시 시작하십시오.";
            }
        }

        internal override string PIDFound {
            get { return "레인보우 식스 시즈 PID: {0}"; }
        }
    }
}