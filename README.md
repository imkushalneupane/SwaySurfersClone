# Tropical Dash!!

**Endless runner game built in Unity (Windows only).**  
This repo contains the full project files for Tropical Dash, including all scripts, assets, and scenes.

---

## 🛠️ Project Setup

- **Unity version:** Unity 6.2
- **Scripting backend:** Mono (default Windows build)  
- **Build target:** PC, Windows Standalone  
- **Scenes included:** `MainMenu.unity` and `Game.unity`
- **Dependencies:** Standard Unity packages only (no external packages)  

> Note: This is a single-player game. No multiplayer or dedicated server support.

---

## 💻 Building From Source

1. Open the project in **Unity Hub** with the correct version.  
2. Open **File → Build Settings**  
3. Select **PC, Mac & Linux Standalone → Windows (x86_64)**  
4. Add `Game.unity` and `Game.unity` to **Scenes In Build**  
5. Click **Build** and select an output folder  
6. The output will produce:
   - `Tropical Dash.exe`  
   - `Tropical Dash_Data` folder  

> Note: PlayerPrefs are used for highscore persistence; values from the Editor may persist separately from the build.

---

## 🧰 Development Notes

- **Controls:** `A/D` or arrow keys, `Space` or UpArrow to jump  
- **Highscore:** saved using PlayerPrefs  
- **Characters:** saved using PlayerPrefs
- **Build size:** ~500 MB uncompressed, ~200 MB compressed  

---

## ⚖️ License

* © 2025 KushalNeupane. All rights reserved. *


