# Roadmap — Taskbar Groups

## Completed (v0.3.x)

### Main Window (`frmClient`) & Group Cards (`ucCategoryPanel`)
- [x] Fixed header and bottom action bar with independent scrollable group list and window resizing support.
- [x] Live search by group or program name and list sorting (`Default`, `A -> Z`, `Z -> A`).
- [x] In-app UI language selector directly in the main window (`cmbLanguage`).
- [x] Group **Preview**, **Clone**, **Export**/**Import** via `.tgroup`/`.zip`, and quick **Delete** with confirmation.
- [x] Responsive multi-row wrapping for all group mini-icons on window resize and direct 2D drag-and-drop reordering on cards.
- [x] Non-blocking asynchronous GitHub release version check.

### Group Editor (`frmGroup`)
- [x] Full Unicode and Cyrillic support in group names.
- [x] Enlarged reorder buttons preserving scroll position, plus drag-and-drop shortcut reordering with auto-scroll.
- [x] Custom shortcut icons from image files (`.png`, `.jpg`, `.bmp`, `.ico`) and embedded icons inside `.exe`/`.dll` via `frmIconPicker`.
- [x] Editable executable path (`FilePath`) per shortcut with automatic `WorkingDirectory` updates when a moved executable is picked.
- [x] Configurable popup icon sizes (`Compact`, `Medium`, `Large`), optional shortcut labels, background color themes, and opacity.

### Popup Launch Panel (`frmMain`)
- [x] Hover tooltips, optional shortcut name labels under icons, and Windows 11 rounded corners.
- [x] Running process detection with active-app highlight and option to focus existing windows instead of launching duplicates.
- [x] Right-click context menu (*Switch to window*, *Close window*, *Open new instance*, *Run as administrator*, *Open file location*).
- [x] Full keyboard navigation: arrow keys, number keys `1`–`9`/`0`, `Enter`, `Ctrl + Enter` (open all), and `Esc`.

### Localization & Documentation
- [x] Embedded UI localization across 26 languages with zero external `.resources.dll` dependencies.
- [x] Synchronized documentation in all 26 languages (`README.md` and `docs/README.<code>.md`) with per-language UI screenshots in `docs/images/<code>/`.

### Infrastructure & Releases
- [x] Single root `VERSION` file with automatic 4th-digit increment on local `Release` builds and manual `v*` tag support for major releases.
- [x] Automated GitHub Release builds and packaging via `.github/workflows/release.yml`.

---

## Planned / Backlog

- [ ] **One-click in-app updater** — download and install the latest GitHub release directly from `frmClient`.
- [ ] **Full backup & restore** — export and restore all groups, icons, and `config/lang.txt` in a single archive.
- [ ] **Global application settings dialog** — configure default click behavior, UI theme preferences, icon cache cleanup, and `JITComp` profile management.
- [ ] **Visual dividers & sections inside `frmMain`** — group shortcuts visually with section headers or separators inside a popup drawer.
- [ ] **Optional global hotkeys** — assign system-wide keyboard shortcuts to open specific groups on demand.
- [ ] **Broken shortcut diagnostics & Windows 11 pinning helper** — detect missing `FilePath` targets, batch-update base folders after app moves, and streamline pinning shortcuts in Windows 11.
