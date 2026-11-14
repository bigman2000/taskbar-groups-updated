<p align="center">
  <a href="../README.md">🇬🇧 English</a> · <a href="README.de.md">🇩🇪 Deutsch</a> · <a href="README.es.md">🇪🇸 Español</a> · <a href="README.fr.md">🇫🇷 Français</a> · <a href="README.it.md">🇮🇹 Italiano</a> · <a href="README.nl.md">🇳🇱 Nederlands</a> · <a href="README.pl.md">🇵🇱 Polski</a> · <b>🇧🇷 Português (Brasil)</b> · <a href="README.ru.md">🇷🇺 Русский</a> · <a href="README.uk.md">🇺🇦 Українська</a> · <a href="README.tr.md">🇹🇷 Türkçe</a> · <a href="README.az.md">🇦🇿 Azərbaycanca</a> · <a href="README.hr.md">🇭🇷 Hrvatski</a> · <a href="README.id.md">🇮🇩 Bahasa Indonesia</a> · <a href="README.vi.md">🇻🇳 Tiếng Việt</a> · <a href="README.th.md">🇹🇭 ไทย</a> · <a href="README.ja.md">🇯🇵 日本語</a> · <a href="README.ko.md">🇰🇷 한국어</a> · <a href="README.zh-CN.md">🇨🇳 简体中文</a> · <a href="README.zh-TW.md">🇹🇼 繁體中文</a> · <a href="README.ar.md">🇸🇦 العربية</a> · <a href="README.he.md">🇮🇱 עברית</a> · <a href="README.fa.md">🇮🇷 فارسی</a> · <a href="README.hi.md">🇮🇳 हिन्दी</a> · <a href="README.ur.md">🇵🇰 اردو</a> · <a href="README.bn.md">🇧🇩 বাংলা</a>
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
  <b>Taskbar Groups é um utilitário leve para Windows que permite criar grupos de atalhos na barra de tarefas.</b>
</p>
<p align="center">
  <a href="https://github.com/bigman2000/taskbar-groups-updated/releases">Download e notas da versão</a>
</p>

> ℹ️ **Nota:** Este projeto é um fork mantido ativamente de [tjackenpacken/taskbar-groups](https://github.com/tjackenpacken/taskbar-groups). O repositório original não é atualizado há muito tempo e parece abandonado, por isso este fork foi criado para corrigir bugs e adicionar novos recursos.

---

## 📖 Índice

* ➤ Instalação
* ➤ Criando seu primeiro grupo
* ➤ Documentação das janelas
  * Tela principal
  * Criação de grupo
  * Notas extras
* ➤ Cache de ícones
* ➤ Atalhos do programa
* ➤ Estrutura de pastas
* ➤ Atualizações recentes
* ➤ Licença

---

## 🔽 Como baixar o Taskbar Groups
1. Baixe o arquivo `.zip` da versão mais recente (link acima)
2. Extraia o `.zip` no local desejado
3. Execute `TaskbarGroups.exe` na pasta extraída

---

## 🛠️ Criando seu primeiro grupo
1. Clique em **"Adicionar grupo"**
2. Dê um nome e escolha um ícone para o grupo
3. Clique em **"Adicionar atalho"** e selecione arquivos `.exe` ou `.lnk` (ou arraste e solte)
4. Salve o grupo
5. Clique no cartão do grupo para abrir a pasta `Shortcuts`
6. Clique com o botão direito no atalho selecionado e escolha **"Fixar na barra de tarefas"**

---

## 🖥️ Documentação das janelas
Abaixo está a documentação de cada janela e seus recursos.

#### Tela principal
![Group overview screen](images/main-screen.png)
Tela principal aberta ao executar `TaskbarGroups.exe`. Permite criar, importar, pesquisar, ordenar, visualizar, editar, clonar, exportar ou excluir grupos e alterar o idioma (26 idiomas).

#### Criação de grupo
![Group creation screen](images/group-screen.png)
Na tela de criação/edição você configura o grupo:

* **Nome do grupo** — Qualquer nome (incluindo Unicode/cirílico, até 49 caracteres).
* **Largura** — Define quantos atalhos aparecem por linha.
* **Alterar ícone do grupo** — Clique em (+) ou arraste `.png`, `.jpg`, `.ico`, `.exe` ou `.lnk`.
* **Adicionar atalho** — Compatível com `.exe`, `.lnk`, `.url`, pastas, apps da Microsoft Store e jogos Steam.
* **Abrir todos os atalhos** — Permite abrir todos os itens do grupo com `Ctrl + Enter`.
* **Ativar janela em execução** — Alterna para a janela já aberta em vez de iniciar uma nova instância.
* **Mostrar rótulos / Tamanho do ícone** — Rótulos opcionais e tamanhos *Compacto*, *Médio* ou *Grande*.
* **Diretório de trabalho e argumentos** — Defina diretório, argumentos de inicialização e ícone personalizado (incluindo `.exe`/`.dll`).
* **Cor de fundo e opacidade** — Escuro, Claro ou Personalizado com opacidade de 0% a 100%.

#### Notas extras
Para executáveis o ícone é extraído diretamente; para `.lnk` e apps da Microsoft Store ele é resolvido automaticamente.

---

## 📦 Cache de ícones
Os ícones ficam em cache em `/config/<Nome_Grupo>/Icons` para abertura instantânea. Salvar o grupo recria o cache.

---

## ⌨️ Atalhos do programa
* **Teclas numéricas `1`–`9`, `0`** — Abre o atalho nas posições 1–10.
* **Setas / `Enter` / `Esc`** — Navegar, abrir ou fechar o menu.
* **`Ctrl + Enter`** — Abre todos os atalhos do grupo de uma vez (se habilitado).
* **Clique direito no atalho** — Menu de contexto: *Alternar para janela*, *Fechar janela*, *Abrir nova instância*, *Executar como administrador*, *Abrir local do arquivo*.

---

## 📁 Estrutura de pastas
* **`/config`** — Armazena as pastas de configuração de cada grupo.
* **`/config/<Group_Name>/Icons`** — Cache local de ícones do grupo.
* **`/config/<Group_Name>/GroupIcon.ico / GroupImage.png`** — Ícones gerados para o grupo.
* **`/config/<Group_Name>/ObjectData.xml`** — Configurações em XML do grupo.
* **`/config/lang.txt`** — Armazena o idioma selecionado.
* **`/JITComp`** — Perfis compilados para inicialização rápida.
* **`/Shortcuts`** — Atalhos `.lnk` para fixar na barra de tarefas.

---

## ✨ Atualizações recentes
* **Localização (26 idiomas)**: Tradução completa da interface com seletor de idioma e READMEs sincronizados nos 26 idiomas.
* **Painel de inicialização (`frmMain`)**: Tooltips, detecção de apps em execução, ativação de janela aberta, menu de contexto, tamanhos de ícone, rótulos, cantos arredondados do Windows 11 e navegação por teclado.
* **Editor de grupo (`frmGroup`)**: Reordenação por arrastar e soltar com rolagem automática, seletor de ícones de `.exe`/`.dll`/imagens e suporte a Unicode.
* **Janela principal (`frmClient`)**: Layout fixo, busca e ordenação, Visualizar, Clonar, Exportar/Importar (`.tgroup`/`.zip`), Exclusão rápida, selo `+N` e reordenação direta nos cartões.

---

## 📜 Licença
Este projeto está licenciado sob a [Licença MIT](https://github.com/bigman2000/taskbar-groups-updated/blob/master/LICENSE).

---
