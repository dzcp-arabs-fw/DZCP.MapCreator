# DZCP.MapCreator
# not complete 
🔧 A professional in-game map editing system for **SCP: Secret Laboratory**, built on the DZCP Framework. Inspired by MapEditorReborn, but fully customized with modern systems and object-oriented architecture.

---

## ✨ Features

- 📦 Save and load maps in `.yml` format
- 🧱 Support for custom map objects (cubes, doors, spawn points, etc.)
- 🔁 Automatic map extraction from `/Configs`
- 📁 Organized map and schematic folders
- 🛠️ Full integration with Exiled API and Harmony patching
- 🧠 Extensible structure (Events, Plugins, Extensions)

---

## 📂 Project Structure

```text
DZCP.MapCreator/
│
├── API/
│   ├── Extensions/             # Bitwise tools, Vector converters, etc.
│   ├── Objects/                # Custom map object definitions
│   ├── Serialization/          # Map loading/saving system
│   └── Utilities/              # General helper tools
│
├── Events/
│   ├── Handlers/               # In-game event listeners
│   └── EventArgs/              # Custom event arguments
│
├── Commands/                   # Console and remote admin commands
│
├── Configs/                    # Configuration system
│
├── ToolGun/                    # ToolGun system (WIP)
│
└── Plugin.cs                   # Main plugin class
