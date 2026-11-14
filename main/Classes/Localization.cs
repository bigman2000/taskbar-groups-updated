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
            new LanguageInfo("de", "Deutsch"),
            new LanguageInfo("es", "Español"),
            new LanguageInfo("fr", "Français"),
            new LanguageInfo("it", "Italiano"),
            new LanguageInfo("nl", "Nederlands"),
            new LanguageInfo("pl", "Polski"),
            new LanguageInfo("pt-BR", "Português (Brasil)"),
            new LanguageInfo("ru", "Русский"),
            new LanguageInfo("uk", "Українська"),
            new LanguageInfo("tr", "Türkçe"),
            new LanguageInfo("az", "Azərbaycanca"),
            new LanguageInfo("hr", "Hrvatski"),
            new LanguageInfo("id", "Bahasa Indonesia"),
            new LanguageInfo("vi", "Tiếng Việt"),
            new LanguageInfo("th", "ไทย"),
            new LanguageInfo("ja", "日本語"),
            new LanguageInfo("ko", "한국어"),
            new LanguageInfo("zh-CN", "简体中文"),
            new LanguageInfo("zh-TW", "繁體中文"),
            new LanguageInfo("ar", "العربية"),
            new LanguageInfo("he", "עברית"),
            new LanguageInfo("fa", "فارسی"),
            new LanguageInfo("hi", "हिन्दी"),
            new LanguageInfo("ur", "اردو"),
            new LanguageInfo("bn", "বাংলা")
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

