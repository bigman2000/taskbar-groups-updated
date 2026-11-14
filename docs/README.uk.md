<p align="center">
  <a href="../README.md">🇬🇧 English</a> · <a href="README.de.md">🇩🇪 Deutsch</a> · <a href="README.es.md">🇪🇸 Español</a> · <a href="README.fr.md">🇫🇷 Français</a> · <a href="README.it.md">🇮🇹 Italiano</a> · <a href="README.nl.md">🇳🇱 Nederlands</a> · <a href="README.pl.md">🇵🇱 Polski</a> · <a href="README.pt-BR.md">🇧🇷 Português (Brasil)</a> · <a href="README.ru.md">🇷🇺 Русский</a> · <b>🇺🇦 Українська</b> · <a href="README.tr.md">🇹🇷 Türkçe</a> · <a href="README.az.md">🇦🇿 Azərbaycanca</a> · <a href="README.hr.md">🇭🇷 Hrvatski</a> · <a href="README.id.md">🇮🇩 Bahasa Indonesia</a> · <a href="README.vi.md">🇻🇳 Tiếng Việt</a> · <a href="README.th.md">🇹🇭 ไทย</a> · <a href="README.ja.md">🇯🇵 日本語</a> · <a href="README.ko.md">🇰🇷 한국어</a> · <a href="README.zh-CN.md">🇨🇳 简体中文</a> · <a href="README.zh-TW.md">🇹🇼 繁體中文</a> · <a href="README.ar.md">🇸🇦 العربية</a> · <a href="README.he.md">🇮🇱 עברית</a> · <a href="README.fa.md">🇮🇷 فارسی</a> · <a href="README.hi.md">🇮🇳 हिन्दी</a> · <a href="README.ur.md">🇵🇰 اردو</a> · <a href="README.bn.md">🇧🇩 বাংলা</a>
</p>

<p align="center">
  <img src="https://raw.githubusercontent.com/tjackenpacken/taskbar-groups/master/main/Icon.ico" alt="Logo" width="150" height="150" />
</p>
<h1 align="center">Taskbar Groups</h1>
<p align="center">
<a href="https://github.com/bigman2000/taskbar-groups-updated/issues"><img alt="Issues open" src="https://img.shields.io/github/issues-raw/bigman2000/taskbar-groups-updated?style=for-the-badge" height="20"/></a>
<a href="https://github.com/bigman2000/taskbar-groups-updated/"><img alt="Last commit" src="https://img.shields.io/github/last-commit/bigman2000/taskbar-groups-updated?style=for-the-badge" height="20"/></a>
<a href="https://github.com/bigman2000/taskbar-groups-updated/releases"><img alt="Latest version" src="https://img.shields.io/github/v/tag/bigman2000/taskbar-groups-updated?label=Latest%20Version&style=for-the-badge" height="20"/></a>
<a href="https://github.com/bigman2000/taskbar-groups-updated/blob/master/LICENSE"><img alt="License" src="https://img.shields.io/github/license/bigman2000/taskbar-groups-updated?style=for-the-badge" height="20"/></a>
</p>
<p align="center">
  <b>Taskbar Groups — легка утиліта для Windows, що дозволяє створювати групи ярликів на панелі завдань.</b>
</p>
<p align="center">
  <a href="https://github.com/bigman2000/taskbar-groups-updated/releases">Завантажити та список змін</a>
</p>

> ℹ️ **Примітка:** Цей проєкт є форком [tjackenpacken/taskbar-groups](https://github.com/tjackenpacken/taskbar-groups), що активно розвивається. Оригінальний репозиторій давно не оновлювався і виглядає покинутим, тому було створено цей форк для виправлення помилок та додавання нових функцій.

---

## 📖 Зміст

* ➤ Встановлення
* ➤ Створення першої групи
* ➤ Документація вікон
  * Головне вікно
  * Редактор групи
  * Додатково
* ➤ Кешування іконок
* ➤ Гарячі клавіші
* ➤ Структура папок
* ➤ Останні оновлення
* ➤ Ліцензія

---

## 🔽 Як завантажити Taskbar Groups
1. Завантажте `.zip`-архів останнього релізу (посилання вище)
2. Розпакуйте архів у зручну папку
3. Запустіть `TaskbarGroups.exe` у розпакованій папці

---

## 🛠️ Створення першої групи
1. Натисніть **"Додати групу"**
2. Вкажіть назву групи та оберіть іконку
3. Натисніть **"Додати ярлик"** і виберіть `.exe` або `.lnk` (або перетягніть їх)
4. Збережіть групу
5. Натисніть на картку групи, щоб відкрити папку `Shortcuts`
6. Натисніть правою кнопкою на виділений ярлик і виберіть **"Закріпити на панелі завдань"**

---

## 🖥️ Документація вікон
Нижче наведено опис вікон програми та їхніх можливостей.

#### Головне вікно
![Group overview screen](images/main-screen.png)
Головне вікно керування групами при запуску `TaskbarGroups.exe`. Дозволяє створювати, імпортувати, шукати, сортувати, переглядати, редагувати, клонувати, експортувати та видаляти групи, а також змінювати мову (26 мов).

#### Редактор групи
![Group creation screen](images/group-screen.png)
У вікні створення та редагування налаштовуються параметри групи:

* **Назва групи** — Будь-яка назва (підтримується кирилиця та Unicode, до 49 символів).
* **Ширина** — Кількість ярликів в одному ряду.
* **Змінити іконку групи** — Натисніть (+) або перетягніть `.png`, `.jpg`, `.ico`, `.exe` чи `.lnk`.
* **Додати ярлик** — Підтримуються `.exe`, `.lnk`, `.url`, папки, застосунки Microsoft Store та ігри Steam.
* **Відкривати всі одночасно** — Запускає всі ярлики групи комбінацією `Ctrl + Enter`.
* **Активувати запущене вікно** — Перемикає на відкрите вікно замість повторного запуску.
* **Показувати підписи / Розмір іконок** — Опціональні підписи та розміри *Компактний*, *Середній*, *Великий*.
* **Робоча тека та аргументи** — Налаштування робочої директорії, параметрів запуску та власної іконки (у т.ч. з `.exe`/`.dll`).
* **Колір фону та прозорість** — Темна, Світла або Власна тема і прозорість 0%–100%.

#### Додатково
Для `.exe` іконка береться напряму; для `.lnk` та Microsoft Store іконка визначається автоматично.

---

## 📦 Кешування іконок
Іконки кешуються в `/config/<Назва_групи>/Icons` для миттєвого відкриття. Збереження оновлює кеш.

---

## ⌨️ Гарячі клавіші
* **Цифри `1`–`9`, `0`** — Запускає ярлик на позиції 1–10.
* **Стрілки / `Enter` / `Esc`** — Навігація, запуск або закриття вікна.
* **`Ctrl + Enter`** — Відкриває всі ярлики групи одночасно (якщо увімкнено).
* **Правий клік по ярлику** — Контекстне меню: *Перемкнутися на вікно*, *Закрити вікно*, *Новий екземпляр*, *Від імені адміністратора*, *Відкрити розташування файлу*.

---

## 📁 Структура папок
* **`/config`** — Папки конфігурації всіх груп.
* **`/config/<Group_Name>/Icons`** — Локальний кеш іконок групи.
* **`/config/<Group_Name>/GroupIcon.ico / GroupImage.png`** — Згенеровані іконки групи.
* **`/config/<Group_Name>/ObjectData.xml`** — XML-налаштування групи.
* **`/config/lang.txt`** — Зберігає обрану мову інтерфейсу.
* **`/JITComp`** — Профілі для прискореного запуску.
* **`/Shortcuts`** — Ярлики `.lnk` для закріплення на панелі завдань.

---

## ✨ Останні оновлення
* **Локалізація (26 мов)**: Повний переклад інтерфейсу з вибором мови та синхронізовані README 26 мовами.
* **Панель запуску (`frmMain`)**: Підказки, визначення запущених програм, активація відкритого вікна, контекстне меню, розміри іконок, підписи, заокруглення Windows 11 та навігація клавіатурою.
* **Редактор групи (`frmGroup`)**: Перетягування ярликів з автопрокруткою, вибір іконок з `.exe`/`.dll`/зображень, підтримка Unicode.
* **Головне вікно (`frmClient`)**: Фіксований заголовок і низ, пошук і сортування, Перегляд, Клонування, Експорт/Імпорт (`.tgroup`/`.zip`), швидке Видалення, значок `+N` та зміна порядку іконок на картці.

---

## 📜 Ліцензія
Проєкт поширюється за [ліцензією MIT](https://github.com/bigman2000/taskbar-groups-updated/blob/master/LICENSE).

---
