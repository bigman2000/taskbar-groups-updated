using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace client.Classes
{
    public sealed class LanguageInfo
    {
        public string Code { get; }
        public string NativeName { get; }

        public LanguageInfo(string code, string nativeName)
        {
            Code = code;
            NativeName = nativeName;
        }

        public override string ToString() => NativeName;
    }

    public static partial class Localization
    {
        public static readonly LanguageInfo[] SupportedLanguages = new LanguageInfo[]
        {
            new LanguageInfo("en", "English"),
            new LanguageInfo("de", "Deutsch (German)"),
            new LanguageInfo("es", "Español (Spanish)"),
            new LanguageInfo("fr", "Français (French)"),
            new LanguageInfo("it", "Italiano (Italian)"),
            new LanguageInfo("nl", "Nederlands (Dutch)"),
            new LanguageInfo("pl", "Polski (Polish)"),
            new LanguageInfo("pt-BR", "Português (Brasil) (Portuguese)"),
            new LanguageInfo("ru", "Русский (Russian)"),
            new LanguageInfo("uk", "Українська (Ukrainian)"),
            new LanguageInfo("tr", "Türkçe (Turkish)"),
            new LanguageInfo("az", "Azərbaycanca (Azerbaijani)"),
            new LanguageInfo("hr", "Hrvatski (Croatian)"),
            new LanguageInfo("id", "Bahasa Indonesia (Indonesian)"),
            new LanguageInfo("vi", "Tiếng Việt (Vietnamese)"),
            new LanguageInfo("th", "ไทย (Thai)"),
            new LanguageInfo("ja", "日本語 (Japanese)"),
            new LanguageInfo("ko", "한국어 (Korean)"),
            new LanguageInfo("zh-CN", "简体中文 (Chinese Simplified)"),
            new LanguageInfo("zh-TW", "繁體中文 (Chinese Traditional)"),
            new LanguageInfo("ar", "العربية (Arabic)"),
            new LanguageInfo("he", "עברית (Hebrew)"),
            new LanguageInfo("fa", "فارسی (Persian)"),
            new LanguageInfo("hi", "हिन्दी (Hindi)"),
            new LanguageInfo("ur", "اردو (Urdu)"),
            new LanguageInfo("bn", "বাংলা (Bengali)")
        };

        private static string currentLanguage;
        private static readonly Dictionary<string, Dictionary<string, string>> translations = BuildTranslations();

        private static string LangFilePath => Path.Combine(MainPath.path, "config", "lang.txt");

        public static string CurrentLanguage
        {
            get
            {
                if (currentLanguage == null)
                {
                    currentLanguage = LoadSavedLanguage();
                }
                return currentLanguage;
            }
        }

        public static void SetLanguage(string code)
        {
            if (string.IsNullOrWhiteSpace(code) || !translations.ContainsKey(code))
            {
                code = "en";
            }

            currentLanguage = code;
            try
            {
                string dir = Path.GetDirectoryName(LangFilePath);
                if (!string.IsNullOrEmpty(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                File.WriteAllText(LangFilePath, code);
            }
            catch
            {
                // Ignore disk write errors for language preference
            }
        }

        public static string T(string key)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;

            if (translations.TryGetValue(CurrentLanguage, out Dictionary<string, string> langDict) &&
                langDict.TryGetValue(key, out string value))
            {
                return value;
            }

            if (translations.TryGetValue("en", out Dictionary<string, string> enDict) &&
                enDict.TryGetValue(key, out string fallback))
            {
                return fallback;
            }

            return key;
        }

        public static string F(string key, params object[] args)
        {
            try
            {
                return string.Format(T(key), args);
            }
            catch
            {
                return T(key);
            }
        }

        private static string LoadSavedLanguage()
        {
            try
            {
                if (File.Exists(LangFilePath))
                {
                    string saved = File.ReadAllText(LangFilePath).Trim();
                    if (translations.ContainsKey(saved))
                        return saved;
                }
            }
            catch
            {
                // Ignore read errors
            }

            CultureInfo ui = CultureInfo.CurrentUICulture;
            if (translations.ContainsKey(ui.Name))
                return ui.Name;
            if (ui.Name.StartsWith("zh", StringComparison.OrdinalIgnoreCase))
                return ui.Name.Contains("TW") || ui.Name.Contains("HK") || ui.Name.Contains("Hant") ? "zh-TW" : "zh-CN";
            if (ui.Name.StartsWith("pt", StringComparison.OrdinalIgnoreCase))
                return "pt-BR";
            if (translations.ContainsKey(ui.TwoLetterISOLanguageName))
                return ui.TwoLetterISOLanguageName;

            return "en";
        }
    }
}

