# Lantern Mouse 🕯️🐭
![](Assets/milo-chicken-dance.gif)

**Lantern Mouse** is a puzzle platformer developed in Unity 2018, being created as a submission for the ReiHen PS Vita Homebrew Contest! This project brings an adorable new character and a fresh gameplay experience to the PlayStation Vita. 🕹️✨

## Table of Contents

- [About the Game](#about-the-game)
- [Features](#features)
- [Building the Game](#building-the-game)
- [Running on PS Vita](#running-on-ps-vita)
- [Requirements](#requirements)
- [Contributing](#contributing)
- [Credits](#credits)
- [License](#license)

## About the Game

*Lantern Mouse* follows a courageous little mouse 🐭 armed with a glowing lantern 🕯️, navigating mysterious environments filled with tricky puzzles and classic platforming fun. Designed especially for the PS Vita, it uses the power of light to unveil secrets and overcome challenges. 🌟

## Features

- Built with **Unity 2018** 🛠️
- Custom `unitybuilder.py` script for VPK creation 📦
- Exclusive for **PS Vita homebrew** 🎮
- Aiming for victory in the **ReiHen PS Vita Homebrew Contest** 🏆
- Unique light-based puzzle mechanics 💡

## Building the Game

Want to try building it yourself? Here’s how:

1. **Clone the repository**  
   ```bash
   git clone https://github.com/yourusername/lantern-mouse.git
   ```
2. **Open in Unity 2018**  
   - Start Unity 2018 and open the project folder.
3. **Build the Unity project**  
   - Go to `File > Build Settings`, target *PlayStation Vita* (with required plugins).
   - Export the build to a directory, e.g., `Build/`.
4. **Create the VPK using `unitybuilder.py`**  
   ```bash
   python unitybuilder.py --input ./Build/ --output ./LanternMouse.vpk
   ```

## Running on PS Vita

- Transfer `LanternMouse.vpk` to your Vita with your preferred tool (USB, FTP, etc.) 💾
- Install the VPK using VitaShell 🟦
- Launch *Lantern Mouse* right from your Vita menu! 🎉

## Requirements

- **Unity 2018** ⚙️
- **Python 3.x** (for the build script) 🐍
- PS Vita with custom firmware (VitaShell) 🔓
- [Optional] PKG Installer or another VPK manager 📲

## Contributing
"Discovered something's broken? wanna help fix?"
Contributions, bug reports, and feature ideas are welcome! Feel free to open an issue or a pull request. Let’s make Lantern Mouse even better together! 🤝

## Credits

- Game Concept & Development: Me lol, who else :)
- Special thanks to the ReiHen community and all PS Vita homebrew developers! 🙌

## License

This project is licensed as **view-only**.  
All rights reserved © 2025 Jyotiraditya Samal.

> 📌 This repository is provided for educational or reference purposes only.  
> Reuse, redistribution, or modification is **not permitted** without explicit permission.
