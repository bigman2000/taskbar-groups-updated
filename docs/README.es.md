<p align="center">
  <a href="../README.md">🇬🇧 English</a> · <a href="README.de.md">🇩🇪 Deutsch</a> · <b>🇪🇸 Español</b> · <a href="README.fr.md">🇫🇷 Français</a> · <a href="README.it.md">🇮🇹 Italiano</a> · <a href="README.nl.md">🇳🇱 Nederlands</a> · <a href="README.pl.md">🇵🇱 Polski</a> · <a href="README.pt-BR.md">🇧🇷 Português (Brasil)</a> · <a href="README.ru.md">🇷🇺 Русский</a> · <a href="README.uk.md">🇺🇦 Українська</a> · <a href="README.tr.md">🇹🇷 Türkçe</a> · <a href="README.az.md">🇦🇿 Azərbaycanca</a> · <a href="README.hr.md">🇭🇷 Hrvatski</a> · <a href="README.id.md">🇮🇩 Bahasa Indonesia</a> · <a href="README.vi.md">🇻🇳 Tiếng Việt</a> · <a href="README.th.md">🇹🇭 ไทย</a> · <a href="README.ja.md">🇯🇵 日本語</a> · <a href="README.ko.md">🇰🇷 한국어</a> · <a href="README.zh-CN.md">🇨🇳 简体中文</a> · <a href="README.zh-TW.md">🇹🇼 繁體中文</a> · <a href="README.ar.md">🇸🇦 العربية</a> · <a href="README.he.md">🇮🇱 עברית</a> · <a href="README.fa.md">🇮🇷 فارسی</a> · <a href="README.hi.md">🇮🇳 हिन्दी</a> · <a href="README.ur.md">🇵🇰 اردو</a> · <a href="README.bn.md">🇧🇩 বাংলা</a>
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
  <b>Taskbar Groups es una utilidad ligera para Windows que permite crear grupos de accesos directos en la barra de tareas.</b>
</p>
<p align="center">
  <a href="https://github.com/bigman2000/taskbar-groups-updated/releases">Descargar y notas de la versión</a>
</p>

> ℹ️ **Nota:** Este proyecto es un fork mantenido activamente de [tjackenpacken/taskbar-groups](https://github.com/tjackenpacken/taskbar-groups). El repositorio original lleva mucho tiempo sin actualizarse y parece abandonado, por lo que se creó este fork para corregir errores y añadir nuevas funciones.

![-----------------------------------------------------](https://user-images.githubusercontent.com/56088716/103312593-8a37ff80-49eb-11eb-91d3-75488e21a0a9.png)

## 📖 Índice

* ➤ Instalación
* ➤ Crear tu primer grupo
* ➤ Documentación de ventanas
  * Ventana principal
  * Creación de grupo
  * Notas adicionales
* ➤ Caché de iconos
* ➤ Atajos de teclado
* ➤ Estructura de carpetas
* ➤ Actualizaciones recientes
* ➤ Licencia

![-----------------------------------------------------](https://user-images.githubusercontent.com/56088716/103312593-8a37ff80-49eb-11eb-91d3-75488e21a0a9.png)

## 🔽 Cómo descargar Taskbar Groups
1. Descarga el archivo `.zip` desde la última versión (enlace arriba)
2. Descomprime el archivo `.zip` en la ubicación deseada
3. Ejecuta `TaskbarGroups.exe` dentro de la carpeta extraída

![-----------------------------------------------------](https://user-images.githubusercontent.com/56088716/103312593-8a37ff80-49eb-11eb-91d3-75488e21a0a9.png)

## 🛠️ Crear tu primer grupo
1. Haz clic en **"Añadir grupo"**
2. Asigna un nombre y un icono al grupo
3. Haz clic en **"Añadir acceso directo"** y selecciona archivos `.exe` o `.lnk` (o arrástralos y suéltalos)
4. Guarda el grupo
5. Haz clic izquierdo en la tarjeta del grupo para abrir la carpeta `Shortcuts`
6. Haz clic derecho en el acceso directo seleccionado y elige **"Anclar a la barra de tareas"**

![-----------------------------------------------------](https://user-images.githubusercontent.com/56088716/103312593-8a37ff80-49eb-11eb-91d3-75488e21a0a9.png)

## 🖥️ Documentación de ventanas
A continuación se detalla el funcionamiento de cada ventana y sus componentes.

#### Ventana principal
![Group overview screen](https://user-images.githubusercontent.com/56088716/103317856-81025f00-49fa-11eb-907b-99623babf315.PNG)
Ventana principal al abrir `TaskbarGroups.exe`. Permite crear, importar, buscar, ordenar, previsualizar, editar, clonar, exportar o eliminar grupos y cambiar el idioma de la interfaz (26 idiomas).

#### Creación de grupo
![Group creation screen](https://user-images.githubusercontent.com/56088716/103452967-36efd680-4ca3-11eb-8244-2aed6fc5af97.PNG)
En la ventana de creación y edición puedes configurar todo el grupo:

* **Nombre del grupo** — Cualquier nombre (incluye Unicode/cirílico, hasta 49 caracteres).
* **Ancho** — Número de accesos directos por fila.
* **Cambiar icono del grupo** — Pulsa (+) o arrastra archivos `.png`, `.jpg`, `.ico`, `.exe` o `.lnk`.
* **Añadir acceso directo** — Compatible con `.exe`, `.lnk`, `.url`, carpetas, apps de Microsoft Store y juegos de Steam.
* **Abrir todos a la vez** — Permite abrir todos los accesos del grupo con `Ctrl + Enter`.
* **Activar ventana en ejecución** — Cambia a la ventana ya abierta en lugar de iniciar otra instancia.
* **Mostrar etiquetas / Tamaño de icono** — Etiquetas opcionales y tamaños *Compacto*, *Mediano* o *Grande*.
* **Directorio de trabajo y argumentos** — Configura ruta de trabajo, parámetros de lanzamiento e icono personalizado (incluso desde `.exe`/`.dll`).
* **Color de fondo y opacidad** — Oscuro, Claro o Personalizado, con opacidad del 0 % al 100 %.

#### Notas adicionales
Para ejecutables se extrae el icono directamente; para `.lnk` y apps de Microsoft Store se resuelve automáticamente el icono de destino o paquete.

![-----------------------------------------------------](https://user-images.githubusercontent.com/56088716/103312593-8a37ff80-49eb-11eb-91d3-75488e21a0a9.png)

## 📦 Caché de iconos
Los iconos se guardan en `/config/<Nombre_Grupo>/Icons` para abrir el menú al instante. Al guardar el grupo se regenera la caché.

![-----------------------------------------------------](https://user-images.githubusercontent.com/56088716/103312593-8a37ff80-49eb-11eb-91d3-75488e21a0a9.png)

## ⌨️ Atajos de teclado
* **Teclas numéricas `1`–`9`, `0`** — Abre el acceso directo en la posición 1–10.
* **Flechas / `Enter` / `Esc`** — Navegar, abrir el elemento seleccionado o cerrar la ventana.
* **`Ctrl + Enter`** — Abre todos los accesos del grupo simultáneamente (si está activado).
* **Clic derecho en un acceso** — Menú contextual: *Cambiar a la ventana*, *Cerrar ventana*, *Abrir nueva instancia*, *Ejecutar como administrador*, *Abrir ubicación del archivo*.

![-----------------------------------------------------](https://user-images.githubusercontent.com/56088716/103312593-8a37ff80-49eb-11eb-91d3-75488e21a0a9.png)

## 📁 Estructura de carpetas
* **`/config`** — Almacena la configuración de cada grupo.
* **`/config/<Group_Name>/Icons`** — Caché local de iconos del grupo.
* **`/config/<Group_Name>/GroupIcon.ico / GroupImage.png`** — Iconos generados para el acceso del grupo.
* **`/config/<Group_Name>/ObjectData.xml`** — Configuración XML del grupo y sus accesos directos.
* **`/config/lang.txt`** — Guarda el idioma seleccionado.
* **`/JITComp`** — Perfiles compilados para acelerar el inicio.
* **`/Shortcuts`** — Accesos `.lnk` generados para anclar a la barra de tareas.

![-----------------------------------------------------](https://user-images.githubusercontent.com/56088716/103312593-8a37ff80-49eb-11eb-91d3-75488e21a0a9.png)

## ✨ Actualizaciones recientes
* **Localización (26 idiomas)**: Traducción completa de la interfaz con selector de idioma en la ventana principal y READMEs sincronizados en los 26 idiomas.
* **Panel de lanzamiento (`frmMain`)**: Tooltips, detección de apps abiertas, activación de ventana existente, menú contextual, tamaños de icono, etiquetas, bordes redondeados de Windows 11 y navegación con teclado.
* **Editor de grupos (`frmGroup`)**: Reordenación por arrastrar y soltar con desplazamiento automático, selector de iconos desde `.exe`/`.dll`/imágenes y soporte Unicode.
* **Ventana principal (`frmClient`)**: Diseño fijo con desplazamiento independiente, búsqueda y ordenación, Vista previa, Clonar, Exportar/Importar (`.tgroup`/`.zip`), Eliminación rápida, insignia `+N` y reordenación en la tarjeta.

![-----------------------------------------------------](https://user-images.githubusercontent.com/56088716/103312593-8a37ff80-49eb-11eb-91d3-75488e21a0a9.png)

## 📜 Licencia
Este proyecto está bajo la [Licencia MIT](https://github.com/bigman2000/taskbar-groups-updated/blob/master/LICENSE).

![-----------------------------------------------------](https://user-images.githubusercontent.com/56088716/103312593-8a37ff80-49eb-11eb-91d3-75488e21a0a9.png)
