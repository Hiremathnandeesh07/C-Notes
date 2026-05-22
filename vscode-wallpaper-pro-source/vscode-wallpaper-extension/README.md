# 🖼️ Wallpaper Pro — VS Code Background Manager

Set stunning wallpapers and background images for **every section** of VS Code with a beautiful built-in UI.

---

## ✨ Features

- 🎨 **Per-section backgrounds** — Editor, Sidebar, Terminal, Panel, Activity Bar, Title Bar, Status Bar
- 🌍 **Global background** — Apply one image to everything
- 🖼️ **10 quick presets** — Beautiful Unsplash photos, one click to apply
- 📂 **File browser** — Pick local images directly from your file system
- 🔆 **Opacity control** — Subtle overlay or bold wallpaper
- 🌫️ **Blur effect** — Frosted glass look
- 📐 **Size & position** — Cover, Contain, Auto, Stretch with 9 position options
- ⚡ **Live preview** — See thumbnails as you type URLs

---

## 🚀 Installation

### Step 1 — Install this extension

**Option A: Install from .vsix file**
1. Open VS Code
2. Press `Ctrl+Shift+P` → "Extensions: Install from VSIX"
3. Select the `vscode-wallpaper-pro-1.0.0.vsix` file

**Option B: Build & install manually**
```bash
cd vscode-wallpaper-extension
npm install
npm run compile
npx vsce package
code --install-extension vscode-wallpaper-pro-1.0.0.vsix
```

### Step 2 — Install Custom CSS and JS Loader

Wallpaper Pro generates a CSS file. To actually inject it into VS Code, you need:

1. Search **"Custom CSS and JS Loader"** by `be5invis` in Extensions marketplace
2. Install it

### Step 3 — Link the CSS file

1. Open VS Code settings (`Ctrl+,`)
2. Search for `vscode_custom_css.imports`
3. Add the path to Wallpaper Pro's generated CSS:

**macOS/Linux:**
```json
"vscode_custom_css.imports": [
  "file:///Users/YOUR_USERNAME/.vscode-wallpaper-pro/wallpaper-styles.css"
]
```

**Windows:**
```json
"vscode_custom_css.imports": [
  "file:///C:/Users/YOUR_USERNAME/.vscode-wallpaper-pro/wallpaper-styles.css"
]
```

### Step 4 — Enable Custom CSS

Press `Ctrl+Shift+P` → **"Enable Custom CSS and JS"** → Reload window

---

## 🎮 Usage

1. Press `Ctrl+Shift+P` → **"Wallpaper Pro: Open Wallpaper Manager"**
2. Choose a preset or paste any image URL
3. Set per-section backgrounds as desired
4. Adjust opacity, blur, size, position
5. Click **"⚡ Apply & Reload"**

---

## ⌨️ Commands

| Command | Description |
|---|---|
| `Wallpaper Pro: Open Wallpaper Manager` | Open the main UI |
| `Wallpaper Pro: Clear All Wallpapers` | Remove all backgrounds |
| `Wallpaper Pro: Randomize Wallpapers` | Apply a random preset |

---

## 💡 Tips

- **Opacity 10-20%** looks great for subtle texture
- **Blur 3-5px** gives a beautiful frosted glass effect
- Local file paths work great (e.g. `/home/user/Pictures/my-wallpaper.jpg`)
- The CSS file is at `~/.vscode-wallpaper-pro/wallpaper-styles.css` — you can hand-edit it too!

---

## 🛠️ Requirements

- VS Code 1.74+
- [Custom CSS and JS Loader](https://marketplace.visualstudio.com/items?itemName=be5invis.vscode-custom-css) extension for CSS injection

---

## 📝 License

MIT
