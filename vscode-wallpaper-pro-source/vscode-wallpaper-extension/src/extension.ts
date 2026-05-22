import * as vscode from 'vscode';
import * as fs from 'fs';
import * as path from 'path';
import * as os from 'os';

// CSS injection targets within VS Code's workbench
const SECTIONS = [
  { id: 'editor', label: 'Editor', icon: '📝', selector: '.editor-container, .monaco-editor, .overflow-guard' },
  { id: 'sidebar', label: 'Sidebar', icon: '📁', selector: '.sidebar, .part.sidebar' },
  { id: 'terminal', label: 'Terminal', icon: '💻', selector: '.terminal-outer-container, .integrated-terminal' },
  { id: 'panel', label: 'Bottom Panel', icon: '🔧', selector: '.part.panel, .panel' },
  { id: 'activityBar', label: 'Activity Bar', icon: '🎯', selector: '.activitybar, .part.activitybar' },
  { id: 'titleBar', label: 'Title Bar', icon: '🏷️', selector: '.titlebar-container, .part.titlebar' },
  { id: 'statusBar', label: 'Status Bar', icon: '📊', selector: '.statusbar, .part.statusbar' },
];

let panel: vscode.WebviewPanel | undefined;

export function activate(context: vscode.ExtensionContext) {
  console.log('Wallpaper Pro is now active!');

  // Register commands
  context.subscriptions.push(
    vscode.commands.registerCommand('wallpaperPro.openPanel', () => {
      openWallpaperPanel(context);
    }),
    vscode.commands.registerCommand('wallpaperPro.clearAll', () => {
      clearAllWallpapers();
    }),
    vscode.commands.registerCommand('wallpaperPro.randomize', () => {
      randomizeWallpapers(context);
    })
  );

  // Auto-apply on startup
  applyWallpapers(context);

  // Watch config changes
  context.subscriptions.push(
    vscode.workspace.onDidChangeConfiguration(e => {
      if (e.affectsConfiguration('wallpaperPro')) {
        applyWallpapers(context);
        if (panel) {
          panel.webview.postMessage({ type: 'configChanged', config: getConfig() });
        }
      }
    })
  );
}

function getConfig() {
  const cfg = vscode.workspace.getConfiguration('wallpaperPro');
  return {
    editorBackground: cfg.get<string>('editorBackground', ''),
    sidebarBackground: cfg.get<string>('sidebarBackground', ''),
    terminalBackground: cfg.get<string>('terminalBackground', ''),
    panelBackground: cfg.get<string>('panelBackground', ''),
    activityBarBackground: cfg.get<string>('activityBarBackground', ''),
    titleBarBackground: cfg.get<string>('titleBarBackground', ''),
    statusBarBackground: cfg.get<string>('statusBarBackground', ''),
    globalBackground: cfg.get<string>('globalBackground', ''),
    opacity: cfg.get<number>('opacity', 0.15),
    backgroundSize: cfg.get<string>('backgroundSize', 'cover'),
    backgroundPosition: cfg.get<string>('backgroundPosition', 'center'),
    blur: cfg.get<number>('blur', 0),
  };
}

function applyWallpapers(context: vscode.ExtensionContext) {
  const config = getConfig();
  const cssPath = getCustomCSSPath();
  const css = generateCSS(config);
  
  try {
    fs.writeFileSync(cssPath, css, 'utf8');
    showStatusBarMessage('🖼️ Wallpapers applied! Reload window to see changes.');
  } catch (err) {
    vscode.window.showErrorMessage(`Wallpaper Pro: Could not write CSS file. ${err}`);
  }
}

function getCustomCSSPath(): string {
  const homeDir = os.homedir();
  const vscodeDir = path.join(homeDir, '.vscode-wallpaper-pro');
  if (!fs.existsSync(vscodeDir)) {
    fs.mkdirSync(vscodeDir, { recursive: true });
  }
  return path.join(vscodeDir, 'wallpaper-styles.css');
}

function generateCSS(config: ReturnType<typeof getConfig>): string {
  const size = config.backgroundSize === 'stretch' ? '100% 100%' : config.backgroundSize;
  
  const makeRule = (selector: string, url: string, extraBlur?: number) => {
    if (!url) return '';
    const blur = extraBlur ?? config.blur;
    const filterStr = blur > 0 ? `filter: blur(${blur}px);` : '';
    return `
/* Wallpaper Pro: ${selector} */
${selector} {
  position: relative;
}
${selector}::before {
  content: '';
  position: absolute;
  top: 0; left: 0; right: 0; bottom: 0;
  background-image: url('${url}');
  background-size: ${size};
  background-position: ${config.backgroundPosition};
  background-repeat: no-repeat;
  opacity: ${config.opacity};
  pointer-events: none;
  z-index: 0;
  ${filterStr}
}`;
  };

  const global = config.globalBackground;
  let css = `/* === Wallpaper Pro — Auto Generated === */\n`;
  css += `/* Generated: ${new Date().toISOString()} */\n\n`;

  // Section-specific backgrounds override global
  const sections: Array<{ selector: string; key: keyof typeof config }> = [
    { selector: '.editor-container, .monaco-editor .overflow-guard', key: 'editorBackground' },
    { selector: '.part.sidebar', key: 'sidebarBackground' },
    { selector: '.terminal-outer-container', key: 'terminalBackground' },
    { selector: '.part.panel', key: 'panelBackground' },
    { selector: '.activitybar.part', key: 'activityBarBackground' },
    { selector: '.part.titlebar', key: 'titleBarBackground' },
    { selector: '.part.statusbar', key: 'statusBarBackground' },
  ];

  if (global) {
    css += makeRule('.monaco-workbench', global);
  }

  for (const { selector, key } of sections) {
    const url = config[key] as string;
    if (url) {
      css += makeRule(selector, url);
    }
  }

  // Terminal-specific: also target xterm canvas
  if (config.terminalBackground) {
    css += `
.xterm-viewport {
  background-image: url('${config.terminalBackground}') !important;
  background-size: ${size};
  background-position: ${config.backgroundPosition};
  background-repeat: no-repeat;
  opacity: 1;
}`;
  }

  return css;
}

function clearAllWallpapers() {
  const cfg = vscode.workspace.getConfiguration('wallpaperPro');
  const keys = ['editorBackground', 'sidebarBackground', 'terminalBackground',
    'panelBackground', 'activityBarBackground', 'titleBarBackground',
    'statusBarBackground', 'globalBackground'];
  
  Promise.all(keys.map(k => cfg.update(k, '', vscode.ConfigurationTarget.Global)))
    .then(() => {
      vscode.window.showInformationMessage('✅ All wallpapers cleared!');
    });
}

const SAMPLE_WALLPAPERS = [
  'https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=1920',
  'https://images.unsplash.com/photo-1542831371-29b0f74f9713?w=1920',
  'https://images.unsplash.com/photo-1475274047050-1d0c0975c63e?w=1920',
  'https://images.unsplash.com/photo-1518770660439-4636190af475?w=1920',
  'https://images.unsplash.com/photo-1478760329108-5c3ed9d495a0?w=1920',
  'https://images.unsplash.com/photo-1501854140801-50d01698950b?w=1920',
];

function randomizeWallpapers(context: vscode.ExtensionContext) {
  const cfg = vscode.workspace.getConfiguration('wallpaperPro');
  const pick = () => SAMPLE_WALLPAPERS[Math.floor(Math.random() * SAMPLE_WALLPAPERS.length)];
  
  cfg.update('globalBackground', pick(), vscode.ConfigurationTarget.Global)
    .then(() => vscode.window.showInformationMessage('🎲 Randomized! Reload window to apply.'));
}

let statusBarItem: vscode.StatusBarItem | undefined;

function showStatusBarMessage(msg: string) {
  if (!statusBarItem) {
    statusBarItem = vscode.window.createStatusBarItem(vscode.StatusBarAlignment.Right, 100);
    statusBarItem.command = 'wallpaperPro.openPanel';
  }
  statusBarItem.text = msg;
  statusBarItem.show();
  setTimeout(() => statusBarItem?.hide(), 5000);
}

function openWallpaperPanel(context: vscode.ExtensionContext) {
  if (panel) {
    panel.reveal(vscode.ViewColumn.One);
    return;
  }

  panel = vscode.window.createWebviewPanel(
    'wallpaperPro',
    '🖼️ Wallpaper Pro',
    vscode.ViewColumn.One,
    {
      enableScripts: true,
      retainContextWhenHidden: true,
    }
  );

  panel.webview.html = getWebviewContent(getConfig());

  panel.webview.onDidReceiveMessage(
    async (message) => {
      const cfg = vscode.workspace.getConfiguration('wallpaperPro');

      switch (message.type) {
        case 'updateSetting':
          await cfg.update(message.key, message.value, vscode.ConfigurationTarget.Global);
          break;

        case 'pickFile':
          const uris = await vscode.window.showOpenDialog({
            canSelectFiles: true,
            canSelectFolders: false,
            canSelectMany: false,
            filters: { Images: ['png', 'jpg', 'jpeg', 'gif', 'webp', 'svg', 'bmp'] }
          });
          if (uris && uris[0]) {
            panel?.webview.postMessage({ type: 'filePicked', key: message.key, path: uris[0].fsPath });
          }
          break;

        case 'applyAll':
          applyWallpapers(context);
          vscode.window.showInformationMessage(
            '✅ Wallpapers applied! Reload window to see them.',
            'Reload Now'
          ).then(choice => {
            if (choice === 'Reload Now') {
              vscode.commands.executeCommand('workbench.action.reloadWindow');
            }
          });
          break;

        case 'clearAll':
          clearAllWallpapers();
          break;

        case 'openCSSFile':
          const cssPath = getCustomCSSPath();
          vscode.workspace.openTextDocument(cssPath).then(doc => {
            vscode.window.showTextDocument(doc);
          });
          break;
      }
    },
    undefined,
    context.subscriptions
  );

  panel.onDidDispose(() => { panel = undefined; });
}

function getWebviewContent(config: ReturnType<typeof getConfig>): string {
  const configJson = JSON.stringify(config);
  const sectionsJson = JSON.stringify(SECTIONS);

  return `<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Wallpaper Pro</title>
<style>
  @import url('https://fonts.googleapis.com/css2?family=Syne:wght@400;600;700;800&family=Space+Mono:wght@400;700&display=swap');

  *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }

  :root {
    --bg: #0d0d12;
    --bg2: #13131a;
    --bg3: #1a1a24;
    --surface: #1e1e2e;
    --surface2: #252535;
    --border: #2a2a3e;
    --accent: #7c6aff;
    --accent2: #ff6a9b;
    --accent3: #6affd4;
    --text: #e8e8f0;
    --text2: #9090a8;
    --text3: #5a5a72;
    --radius: 12px;
    --glow: 0 0 20px rgba(124, 106, 255, 0.3);
  }

  body {
    font-family: 'Syne', sans-serif;
    background: var(--bg);
    color: var(--text);
    min-height: 100vh;
    padding: 0;
    overflow-x: hidden;
  }

  /* Animated background */
  body::before {
    content: '';
    position: fixed;
    inset: 0;
    background: 
      radial-gradient(ellipse 60% 50% at 20% 20%, rgba(124,106,255,0.08) 0%, transparent 60%),
      radial-gradient(ellipse 50% 60% at 80% 80%, rgba(255,106,155,0.06) 0%, transparent 60%);
    pointer-events: none;
    z-index: 0;
  }

  .app { position: relative; z-index: 1; max-width: 900px; margin: 0 auto; padding: 32px 24px; }

  /* Header */
  .header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    margin-bottom: 40px;
    padding-bottom: 24px;
    border-bottom: 1px solid var(--border);
  }
  .header-left { display: flex; align-items: center; gap: 16px; }
  .logo {
    width: 48px; height: 48px;
    background: linear-gradient(135deg, var(--accent), var(--accent2));
    border-radius: 14px;
    display: flex; align-items: center; justify-content: center;
    font-size: 24px;
    box-shadow: var(--glow);
  }
  .header h1 { font-size: 26px; font-weight: 800; letter-spacing: -0.5px; }
  .header h1 span { color: var(--accent); }
  .header p { font-family: 'Space Mono', monospace; font-size: 11px; color: var(--text3); margin-top: 2px; }

  .header-actions { display: flex; gap: 10px; }

  /* Buttons */
  .btn {
    padding: 10px 20px;
    border-radius: 8px;
    border: none;
    font-family: 'Syne', sans-serif;
    font-weight: 600;
    font-size: 13px;
    cursor: pointer;
    transition: all 0.2s ease;
    display: flex; align-items: center; gap: 8px;
  }
  .btn-primary {
    background: linear-gradient(135deg, var(--accent), #9b87ff);
    color: white;
    box-shadow: 0 4px 15px rgba(124,106,255,0.4);
  }
  .btn-primary:hover { transform: translateY(-2px); box-shadow: 0 6px 20px rgba(124,106,255,0.5); }
  .btn-secondary {
    background: var(--surface);
    color: var(--text2);
    border: 1px solid var(--border);
  }
  .btn-secondary:hover { background: var(--surface2); color: var(--text); border-color: var(--accent); }
  .btn-danger {
    background: rgba(255,80,80,0.1);
    color: #ff8080;
    border: 1px solid rgba(255,80,80,0.2);
  }
  .btn-danger:hover { background: rgba(255,80,80,0.2); }
  .btn-sm { padding: 7px 14px; font-size: 12px; border-radius: 6px; }

  /* Global section */
  .global-section {
    background: linear-gradient(135deg, rgba(124,106,255,0.08), rgba(255,106,155,0.05));
    border: 1px solid rgba(124,106,255,0.25);
    border-radius: var(--radius);
    padding: 24px;
    margin-bottom: 28px;
  }
  .global-section h2 { font-size: 14px; font-weight: 700; color: var(--accent); text-transform: uppercase; letter-spacing: 2px; margin-bottom: 16px; }

  /* Sections grid */
  .sections-header {
    display: flex; align-items: center; justify-content: space-between;
    margin-bottom: 20px;
  }
  .sections-header h2 { font-size: 14px; font-weight: 700; color: var(--text2); text-transform: uppercase; letter-spacing: 2px; }

  .sections-grid {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(380px, 1fr));
    gap: 16px;
    margin-bottom: 28px;
  }

  .section-card {
    background: var(--surface);
    border: 1px solid var(--border);
    border-radius: var(--radius);
    padding: 20px;
    transition: border-color 0.2s, box-shadow 0.2s;
  }
  .section-card:hover { border-color: var(--accent); box-shadow: 0 0 0 1px rgba(124,106,255,0.15); }
  .section-card.has-bg { border-color: rgba(124,106,255,0.4); }

  .card-header { display: flex; align-items: center; justify-content: space-between; margin-bottom: 14px; }
  .card-title { display: flex; align-items: center; gap: 10px; }
  .card-icon { font-size: 20px; }
  .card-label { font-size: 15px; font-weight: 700; }
  .card-badge {
    font-family: 'Space Mono', monospace;
    font-size: 10px;
    padding: 3px 8px;
    border-radius: 20px;
    background: rgba(106,255,212,0.12);
    color: var(--accent3);
    border: 1px solid rgba(106,255,212,0.2);
  }
  .card-badge.empty { background: transparent; color: var(--text3); border-color: var(--border); }

  /* Image input */
  .input-row { display: flex; gap: 8px; align-items: center; }
  .url-input {
    flex: 1;
    background: var(--bg3);
    border: 1px solid var(--border);
    border-radius: 8px;
    color: var(--text);
    font-family: 'Space Mono', monospace;
    font-size: 12px;
    padding: 9px 12px;
    outline: none;
    transition: border-color 0.2s;
    min-width: 0;
  }
  .url-input:focus { border-color: var(--accent); }
  .url-input::placeholder { color: var(--text3); }

  .preview-thumb {
    width: 80px; height: 48px;
    border-radius: 6px;
    overflow: hidden;
    background: var(--bg3);
    border: 1px solid var(--border);
    margin-top: 10px;
    display: none;
    position: relative;
  }
  .preview-thumb.visible { display: block; }
  .preview-thumb img { width: 100%; height: 100%; object-fit: cover; }
  .preview-thumb-clear {
    position: absolute; top: 2px; right: 2px;
    background: rgba(0,0,0,0.7); color: white;
    border: none; border-radius: 3px; padding: 1px 5px;
    font-size: 10px; cursor: pointer; line-height: 1.4;
  }

  /* Global settings */
  .settings-grid {
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 16px;
    margin-bottom: 28px;
  }
  .setting-group {
    background: var(--surface);
    border: 1px solid var(--border);
    border-radius: var(--radius);
    padding: 18px;
  }
  .setting-label {
    font-size: 12px;
    font-weight: 600;
    color: var(--text2);
    text-transform: uppercase;
    letter-spacing: 1px;
    margin-bottom: 10px;
    display: flex; align-items: center; gap: 6px;
  }
  
  .range-wrap { display: flex; align-items: center; gap: 10px; }
  input[type="range"] {
    flex: 1;
    -webkit-appearance: none;
    height: 4px;
    border-radius: 2px;
    background: var(--bg3);
    outline: none;
  }
  input[type="range"]::-webkit-slider-thumb {
    -webkit-appearance: none;
    width: 16px; height: 16px;
    border-radius: 50%;
    background: var(--accent);
    cursor: pointer;
    box-shadow: 0 0 6px rgba(124,106,255,0.5);
  }
  .range-val {
    font-family: 'Space Mono', monospace;
    font-size: 13px;
    color: var(--accent);
    min-width: 36px;
    text-align: right;
  }
  
  select {
    width: 100%;
    background: var(--bg3);
    border: 1px solid var(--border);
    border-radius: 8px;
    color: var(--text);
    font-family: 'Syne', sans-serif;
    font-size: 13px;
    padding: 9px 12px;
    outline: none;
    cursor: pointer;
  }
  select:focus { border-color: var(--accent); }

  /* Apply footer */
  .footer {
    background: var(--surface);
    border: 1px solid var(--border);
    border-radius: var(--radius);
    padding: 20px 24px;
    display: flex;
    align-items: center;
    justify-content: space-between;
    gap: 16px;
  }
  .footer-info { font-size: 12px; color: var(--text3); font-family: 'Space Mono', monospace; line-height: 1.6; }
  .footer-info strong { color: var(--text2); }
  .footer-actions { display: flex; gap: 10px; flex-shrink: 0; }

  /* Presets */
  .presets-strip {
    display: flex;
    gap: 8px;
    overflow-x: auto;
    padding-bottom: 4px;
    margin-bottom: 28px;
    scrollbar-width: thin;
    scrollbar-color: var(--border) transparent;
  }
  .preset-chip {
    flex-shrink: 0;
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 6px;
    cursor: pointer;
    padding: 8px;
    border-radius: 10px;
    border: 1px solid var(--border);
    background: var(--surface);
    transition: all 0.2s;
    width: 90px;
  }
  .preset-chip:hover { border-color: var(--accent); transform: translateY(-2px); }
  .preset-chip img {
    width: 72px; height: 45px;
    border-radius: 6px;
    object-fit: cover;
  }
  .preset-chip span { font-size: 10px; color: var(--text2); font-weight: 600; text-align: center; }

  .section-divider {
    font-size: 11px; font-weight: 700; color: var(--text3);
    text-transform: uppercase; letter-spacing: 2px;
    margin-bottom: 14px; margin-top: 4px;
  }

  .pulse-dot {
    width: 7px; height: 7px; border-radius: 50%;
    background: var(--accent3);
    display: inline-block;
    animation: pulse 2s ease-in-out infinite;
  }
  @keyframes pulse { 0%,100%{opacity:1;transform:scale(1)} 50%{opacity:0.5;transform:scale(0.8)} }
</style>
</head>
<body>
<div class="app">

  <!-- Header -->
  <div class="header">
    <div class="header-left">
      <div class="logo">🖼️</div>
      <div>
        <h1>Wallpaper <span>Pro</span></h1>
        <p>VS Code Background Manager</p>
      </div>
    </div>
    <div class="header-actions">
      <button class="btn btn-secondary btn-sm" onclick="clearAll()">🗑️ Clear All</button>
      <button class="btn btn-secondary btn-sm" onclick="openCSS()">📄 View CSS</button>
    </div>
  </div>

  <!-- Preset wallpapers -->
  <div class="section-divider">✨ Quick Presets</div>
  <div class="presets-strip" id="presetsStrip"></div>

  <!-- Global background -->
  <div class="global-section">
    <h2>🌍 Global Background</h2>
    <p style="font-size:12px;color:var(--text3);margin-bottom:14px;">Applied to entire VS Code. Section-specific settings override this.</p>
    <div id="global-input"></div>
  </div>

  <!-- Section-specific -->
  <div class="sections-header">
    <h2>🎨 Section Backgrounds</h2>
    <span style="font-size:12px;color:var(--text3);"><span class="pulse-dot"></span> Override global per section</span>
  </div>
  <div class="sections-grid" id="sectionsGrid"></div>

  <!-- Settings -->
  <div class="section-divider">⚙️ Global Settings</div>
  <div class="settings-grid">
    <div class="setting-group">
      <div class="setting-label">🔆 Opacity</div>
      <div class="range-wrap">
        <input type="range" id="opacityRange" min="1" max="100" value="15"
          oninput="updateOpacity(this.value)">
        <span class="range-val" id="opacityVal">15%</span>
      </div>
      <div style="font-size:11px;color:var(--text3);margin-top:8px;">Lower = more subtle overlay</div>
    </div>
    <div class="setting-group">
      <div class="setting-label">🌫️ Blur</div>
      <div class="range-wrap">
        <input type="range" id="blurRange" min="0" max="20" value="0"
          oninput="updateBlur(this.value)">
        <span class="range-val" id="blurVal">0px</span>
      </div>
      <div style="font-size:11px;color:var(--text3);margin-top:8px;">Frosted glass effect</div>
    </div>
    <div class="setting-group">
      <div class="setting-label">📐 Size</div>
      <select id="sizeSelect" onchange="updateSetting('backgroundSize', this.value)">
        <option value="cover">Cover (fill area)</option>
        <option value="contain">Contain (fit in area)</option>
        <option value="auto">Auto (original size)</option>
        <option value="stretch">Stretch (100%×100%)</option>
      </select>
    </div>
    <div class="setting-group">
      <div class="setting-label">🎯 Position</div>
      <select id="posSelect" onchange="updateSetting('backgroundPosition', this.value)">
        <option value="center">Center</option>
        <option value="top">Top</option>
        <option value="bottom">Bottom</option>
        <option value="left">Left</option>
        <option value="right">Right</option>
        <option value="top left">Top Left</option>
        <option value="top right">Top Right</option>
        <option value="bottom left">Bottom Left</option>
        <option value="bottom right">Bottom Right</option>
      </select>
    </div>
  </div>

  <!-- Footer -->
  <div class="footer">
    <div class="footer-info">
      <strong>How it works:</strong> Wallpaper Pro writes a CSS file to<br>
      <code>~/.vscode-wallpaper-pro/wallpaper-styles.css</code><br>
      Install the <strong>Custom CSS and JS Loader</strong> extension to apply it.
    </div>
    <div class="footer-actions">
      <button class="btn btn-secondary" onclick="clearAll()">🗑️ Clear All</button>
      <button class="btn btn-primary" onclick="applyAll()">⚡ Apply & Reload</button>
    </div>
  </div>

</div>

<script>
const vscode = acquireVsCodeApi();

const SECTIONS = ${sectionsJson};
let config = ${configJson};

const PRESETS = [
  { name: 'Mountains', url: 'https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=1920&q=80' },
  { name: 'Forest', url: 'https://images.unsplash.com/photo-1448375240586-882707db888b?w=1920&q=80' },
  { name: 'Galaxy', url: 'https://images.unsplash.com/photo-1475274047050-1d0c0975c63e?w=1920&q=80' },
  { name: 'Ocean', url: 'https://images.unsplash.com/photo-1505118380757-91f5f5632de0?w=1920&q=80' },
  { name: 'City', url: 'https://images.unsplash.com/photo-1477959858617-67f85cf4f1df?w=1920&q=80' },
  { name: 'Aurora', url: 'https://images.unsplash.com/photo-1531366936337-7c912a4589a7?w=1920&q=80' },
  { name: 'Desert', url: 'https://images.unsplash.com/photo-1509316785289-025f5b846b35?w=1920&q=80' },
  { name: 'Neon', url: 'https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=1920&q=80' },
  { name: 'Minimal', url: 'https://images.unsplash.com/photo-1518655048521-f130df041f66?w=1920&q=80' },
  { name: 'Abstract', url: 'https://images.unsplash.com/photo-1558591710-4b4a1ae0f04d?w=1920&q=80' },
];

// Map config key names to section ids
const sectionKeyMap = {
  'editor': 'editorBackground',
  'sidebar': 'sidebarBackground',
  'terminal': 'terminalBackground',
  'panel': 'panelBackground',
  'activityBar': 'activityBarBackground',
  'titleBar': 'titleBarBackground',
  'statusBar': 'statusBarBackground',
};

function init() {
  renderPresets();
  renderGlobalInput();
  renderSections();
  syncSettings();
}

function renderPresets() {
  const strip = document.getElementById('presetsStrip');
  strip.innerHTML = PRESETS.map(p => \`
    <div class="preset-chip" onclick="applyPreset('\${p.url}')">
      <img src="\${p.url.replace('1920', '200')}" alt="\${p.name}" loading="lazy">
      <span>\${p.name}</span>
    </div>
  \`).join('');
}

function applyPreset(url) {
  updateSetting('globalBackground', url);
  document.querySelector('#global-input .url-input').value = url;
  showPreview('global', url);
}

function makeInputHTML(key, value, placeholder) {
  return \`
    <div class="input-row">
      <input type="text" class="url-input" id="input-\${key}"
        placeholder="\${placeholder}"
        value="\${value || ''}"
        oninput="handleInput('\${key}', this.value)">
      <button class="btn btn-secondary btn-sm" onclick="pickFile('\${key}')">📂</button>
    </div>
    <div class="preview-thumb \${value ? 'visible' : ''}" id="thumb-\${key}">
      <img src="\${value || ''}" id="thumbImg-\${key}" alt="preview">
      <button class="preview-thumb-clear" onclick="clearInput('\${key}')">✕</button>
    </div>
  \`;
}

function renderGlobalInput() {
  const container = document.getElementById('global-input');
  container.innerHTML = makeInputHTML('globalBackground', config.globalBackground, 'https://... or /path/to/image.jpg');
}

function renderSections() {
  const grid = document.getElementById('sectionsGrid');
  grid.innerHTML = SECTIONS.map(s => {
    const key = sectionKeyMap[s.id];
    const val = config[key] || '';
    return \`
      <div class="section-card \${val ? 'has-bg' : ''}" id="card-\${s.id}">
        <div class="card-header">
          <div class="card-title">
            <span class="card-icon">\${s.icon}</span>
            <span class="card-label">\${s.label}</span>
          </div>
          <span class="card-badge \${val ? '' : 'empty'}">\${val ? 'SET' : 'NONE'}</span>
        </div>
        \${makeInputHTML(key, val, 'URL or file path...')}
      </div>
    \`;
  }).join('');
}

function syncSettings() {
  const opacityPct = Math.round(config.opacity * 100);
  document.getElementById('opacityRange').value = opacityPct;
  document.getElementById('opacityVal').textContent = opacityPct + '%';
  document.getElementById('blurRange').value = config.blur;
  document.getElementById('blurVal').textContent = config.blur + 'px';
  document.getElementById('sizeSelect').value = config.backgroundSize;
  document.getElementById('posSelect').value = config.backgroundPosition;
}

function handleInput(key, value) {
  clearTimeout(window._debounce);
  window._debounce = setTimeout(() => {
    updateSetting(key, value);
    showPreview(key, value);
  }, 500);
}

function showPreview(key, url) {
  const thumb = document.getElementById('thumb-' + key);
  const img = document.getElementById('thumbImg-' + key);
  if (thumb && img) {
    if (url) {
      img.src = url;
      thumb.classList.add('visible');
    } else {
      thumb.classList.remove('visible');
    }
  }
  // Update card badge
  const section = SECTIONS.find(s => sectionKeyMap[s.id] === key);
  if (section) {
    const card = document.getElementById('card-' + section.id);
    const badge = card?.querySelector('.card-badge');
    if (card && badge) {
      if (url) { card.classList.add('has-bg'); badge.classList.remove('empty'); badge.textContent = 'SET'; }
      else { card.classList.remove('has-bg'); badge.classList.add('empty'); badge.textContent = 'NONE'; }
    }
  }
}

function clearInput(key) {
  const input = document.getElementById('input-' + key);
  if (input) input.value = '';
  updateSetting(key, '');
  showPreview(key, '');
}

function updateSetting(key, value) {
  config[key] = value;
  vscode.postMessage({ type: 'updateSetting', key, value });
}

function updateOpacity(val) {
  document.getElementById('opacityVal').textContent = val + '%';
  updateSetting('opacity', parseFloat(val) / 100);
}

function updateBlur(val) {
  document.getElementById('blurVal').textContent = val + 'px';
  updateSetting('blur', parseInt(val));
}

function pickFile(key) {
  vscode.postMessage({ type: 'pickFile', key });
}

function applyAll() {
  vscode.postMessage({ type: 'applyAll' });
}

function clearAll() {
  vscode.postMessage({ type: 'clearAll' });
  config = {...config,
    globalBackground:'', editorBackground:'', sidebarBackground:'',
    terminalBackground:'', panelBackground:'', activityBarBackground:'',
    titleBarBackground:'', statusBarBackground:''};
  renderGlobalInput();
  renderSections();
}

function openCSS() {
  vscode.postMessage({ type: 'openCSSFile' });
}

// Receive messages from extension
window.addEventListener('message', e => {
  const msg = e.data;
  if (msg.type === 'filePicked') {
    const input = document.getElementById('input-' + msg.key);
    if (input) {
      input.value = msg.path;
      handleInput(msg.key, msg.path);
    }
  }
  if (msg.type === 'configChanged') {
    config = msg.config;
    renderGlobalInput();
    renderSections();
    syncSettings();
  }
});

init();
</script>
</body>
</html>`;
}

export function deactivate() {}
