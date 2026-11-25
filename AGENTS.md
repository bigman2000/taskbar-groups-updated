# Development Guidelines (AGENTS.md)

## 1. Project & Tech Stack
- **Project:** `Taskbar Groups` (`taskbar-groups-updated`) — portable Windows utility written in C# 7.3 (.NET Framework 4.7.2, Windows Forms), solution `TaskbarGroups.sln`, primary project `main/client.csproj`.
- See [`docs/ARCHITECTURE.md`](docs/ARCHITECTURE.md) for module responsibilities, data formats, and internal mechanics, and [`ROADMAP.md`](ROADMAP.md) for implemented features and planned work.

## 2. Build & Verification
Build with Visual Studio MSBuild (NuGet packages are already restored under `packages/`):
```powershell
& "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe" TaskbarGroups.sln /p:Configuration=Debug /m
& "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe" TaskbarGroups.sln /p:Configuration=Release /m
```
- **`VERSION` auto-increment:** a local `Release` build automatically increments the 4th digit in the root `VERSION` file by `+1`. When verifying compilation without bumping the version, pass `/p:SkipVersionIncrement=true`.
- Always verify both `Debug` and `Release` builds complete with 0 errors and 0 warnings after any C# changes.

## 3. Code & WinForms Conventions
- **Naming:** give all controls and variables meaningful `camelCase` names using standard WinForms prefixes (`lbl...`, `pnl...`, `cmd...`, `txt...`, `chk...`, `cmb...`, `pic...`). Never leave auto-generated names like `label1`, `panel1`, or `button1`.
- **`client` namespace conflict:** because `main/client.cs` defines `static class client`, unqualified `client` inside the `client` namespace resolves to the class rather than the namespace. Use `global::client.Classes.*` in `.Designer.cs` files and wherever ambiguity occurs.
- **Portability:** keep the application self-contained as a single `TaskbarGroups.exe`. Do not introduce external satellite `.resources.dll` folders or heavy localization dependencies.

## 4. Localization & Documentation (26 Languages)
- **UI localization (`main/Classes/Localization*.cs`):** whenever UI strings are added or modified, update translations for **all 26 supported languages** in `LocalizationData.cs` and `LocalizationData2.cs`.
- **README files (`README.md` and `docs/README.<code>.md`):**
  - Always keep all 26 README files synchronized whenever functionality or project descriptions change.
  - Preserve the full 26-language switcher bar at the top of every README, using non-breaking spaces (`&nbsp;`) inside each link (so flags never wrap onto a different line from their language name) and including the English language name in parentheses for every language except English.
  - Screenshot links must point to the matching localized directory: `docs/images/<code>/` in the root `README.md` and `images/<code>/` in `docs/README.<code>.md`.

## 5. Versioning & Releases
- The root [`VERSION`](VERSION) file (`Major.Minor.Build.Revision`) is the single source of truth.
- Do not restore `[assembly: AssemblyVersion(...)]` or `[assembly: AssemblyFileVersion(...)]` in `main/Properties/AssemblyInfo.cs`; they are generated automatically into `obj/<Configuration>/GeneratedAssemblyVersion.cs` by the `PrepareVersion` MSBuild target.
- Major and minor releases can be triggered manually by pushing a `v*` tag (e.g., `v1.0.0.0`) or by updating `VERSION` before pushing to `master` — `.github/workflows/release.yml` handles building, tagging, and attaching the release `.zip`.
