<p align="center">
  <a href="../README.md">🇬🇧 English</a> · <a href="README.de.md">🇩🇪 Deutsch</a> · <a href="README.es.md">🇪🇸 Español</a> · <b>🇫🇷 Français</b> · <a href="README.it.md">🇮🇹 Italiano</a> · <a href="README.nl.md">🇳🇱 Nederlands</a> · <a href="README.pl.md">🇵🇱 Polski</a> · <a href="README.pt-BR.md">🇧🇷 Português (Brasil)</a> · <a href="README.ru.md">🇷🇺 Русский</a> · <a href="README.uk.md">🇺🇦 Українська</a> · <a href="README.tr.md">🇹🇷 Türkçe</a> · <a href="README.az.md">🇦🇿 Azərbaycanca</a> · <a href="README.hr.md">🇭🇷 Hrvatski</a> · <a href="README.id.md">🇮🇩 Bahasa Indonesia</a> · <a href="README.vi.md">🇻🇳 Tiếng Việt</a> · <a href="README.th.md">🇹🇭 ไทย</a> · <a href="README.ja.md">🇯🇵 日本語</a> · <a href="README.ko.md">🇰🇷 한국어</a> · <a href="README.zh-CN.md">🇨🇳 简体中文</a> · <a href="README.zh-TW.md">🇹🇼 繁體中文</a> · <a href="README.ar.md">🇸🇦 العربية</a> · <a href="README.he.md">🇮🇱 עברית</a> · <a href="README.fa.md">🇮🇷 فارسی</a> · <a href="README.hi.md">🇮🇳 हिन्दी</a> · <a href="README.ur.md">🇵🇰 اردو</a> · <a href="README.bn.md">🇧🇩 বাংলা</a>
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
  <b>Taskbar Groups est un utilitaire léger pour Windows permettant de créer des groupes de raccourcis dans la barre des tâches.</b>
</p>
<p align="center">
  <a href="https://github.com/bigman2000/taskbar-groups-updated/releases">Téléchargement et notes de version</a>
</p>

> ℹ️ **Note :** Ce projet est un fork activement maintenu de [tjackenpacken/taskbar-groups](https://github.com/tjackenpacken/taskbar-groups). Le dépôt d'origine n'ayant pas été mis à jour depuis longtemps et semblant abandonné, ce fork a été créé pour corriger des bugs et ajouter de nouvelles fonctionnalités.

---

## 📖 Table des matières

* ➤ Installation
* ➤ Créer votre premier groupe
* ➤ Documentation des fenêtres
  * Fenêtre principale
  * Création de groupe
  * Notes supplémentaires
* ➤ Cache d'icônes
* ➤ Raccourcis clavier
* ➤ Structure des dossiers
* ➤ Mises à jour récentes
* ➤ Licence

---

## 🔽 Télécharger Taskbar Groups
1. Téléchargez l'archive `.zip` de la dernière version (lien ci-dessus)
2. Extrayez le fichier `.zip` à l'emplacement de votre choix
3. Lancez `TaskbarGroups.exe` dans le dossier extrait

---

## 🛠️ Créer votre premier groupe
1. Cliquez sur **"Ajouter un groupe"**
2. Donnez un nom au groupe et choisissez une icône
3. Cliquez sur **"Ajouter un raccourci"** et sélectionnez des fichiers `.exe` ou `.lnk` (ou glissez-déposez-les)
4. Enregistrez le groupe
5. Cliquez sur la carte du groupe pour ouvrir le dossier `Shortcuts`
6. Faites un clic droit sur le raccourci sélectionné et cliquez sur **"Épingler à la barre des tâches"**

---

## 🖥️ Documentation des fenêtres
Voici la description de chaque fenêtre et de ses fonctionnalités.

#### Fenêtre principale
![Group overview screen](images/main-screen.png)
Fenêtre principale ouverte au lancement de `TaskbarGroups.exe`. Permet de créer, importer, rechercher, trier, prévisualiser, modifier, cloner, exporter ou supprimer des groupes et de changer la langue (26 langues).

#### Création de groupe
![Group creation screen](images/group-screen.png)
Fenêtre de création et d'édition d'un groupe :

* **Nom du groupe** — Tout nom souhaité (y compris Unicode/cyrillique, 49 caractères max.).
* **Largeur** — Nombre de raccourcis affichés par ligne.
* **Icône du groupe** — Cliquez sur (+) ou glissez-déposez un fichier `.png`, `.jpg`, `.ico`, `.exe` ou `.lnk`.
* **Ajouter un raccourci** — Prend en charge `.exe`, `.lnk`, `.url`, dossiers, apps Microsoft Store et jeux Steam.
* **Tout ouvrir simultanément** — Permet de lancer tous les raccourcis du groupe avec `Ctrl + Entrée`.
* **Activer la fenêtre en cours** — Bascule vers la fenêtre déjà ouverte au lieu de relancer l'application.
* **Afficher les noms / Taille des icônes** — Libellés optionnels et tailles *Compact*, *Moyen* ou *Grand*.
* **Répertoire de travail et arguments** — Personnalisez le dossier de travail, les arguments et l'icône (y compris depuis `.exe`/`.dll`).
* **Couleur et opacité** — Sombre, Clair ou Personnalisé avec transparence de 0 % à 100 %.

#### Notes supplémentaires
Les icônes sont extraites directement des exécutables, ou résolues automatiquement pour les `.lnk` et les applications du Microsoft Store.

---

## 📦 Cache d'icônes
Le cache local dans `/config/<Nom_du_groupe>/Icons` permet une ouverture instantanée. Enregistrer le groupe régénère le cache.

---

## ⌨️ Raccourcis clavier
* **Touches `1`–`9`, `0`** — Lance le raccourci correspondant (1 à 10).
* **Flèches / `Entrée` / `Échap`** — Naviguer, lancer ou fermer le menu.
* **`Ctrl + Entrée`** — Ouvre tous les raccourcis du groupe en même temps (si activé).
* **Clic droit sur un raccourci** — Menu contextuel : *Basculer vers la fenêtre*, *Fermer la fenêtre*, *Nouvelle instance*, *Exécuter en tant qu'administrateur*, *Ouvrir l'emplacement du fichier*.

---

## 📁 Structure des dossiers
* **`/config`** — Contient les dossiers de configuration de chaque groupe.
* **`/config/<Group_Name>/Icons`** — Cache local des icônes du groupe.
* **`/config/<Group_Name>/GroupIcon.ico / GroupImage.png`** — Icônes générées pour le groupe.
* **`/config/<Group_Name>/ObjectData.xml`** — Paramètres XML du groupe et de ses raccourcis.
* **`/config/lang.txt`** — Enregistre la langue sélectionnée.
* **`/JITComp`** — Profils compilés pour accélérer le démarrage.
* **`/Shortcuts`** — Raccourcis `.lnk` générés pour l'épinglage à la barre des tâches.

---

## ✨ Mises à jour récentes
* **Localisation (26 langues)** : Traduction complète de l'interface avec sélecteur de langue et READMEs synchronisés dans 26 langues.
* **Panneau de lancement (`frmMain`)** : Infobulles, détection des apps actives, activation de fenêtre existante, menu contextuel, tailles d'icônes, libellés, coins arrondis Windows 11 et navigation clavier.
* **Éditeur de groupe (`frmGroup`)** : Réorganisation par glisser-déposer avec défilement automatique, sélecteur d'icônes `.exe`/`.dll`/images et support Unicode.
* **Fenêtre principale (`frmClient`)** : Mise en page fixe, recherche et tri, Aperçu, Cloner, Exporter/Importer (`.tgroup`/`.zip`), Suppression rapide, badge `+N` et réorganisation directe sur la carte.

---

## 📜 Licence
Ce projet est distribué sous [Licence MIT](https://github.com/bigman2000/taskbar-groups-updated/blob/master/LICENSE).

---
