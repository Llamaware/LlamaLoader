# LlamaLoader

![preview](/img/preview.png)

A mod management tool, all-in-one auto-updater and installer for the [Tomb modloader](https://codeberg.org/basil/tomb) and [Llamaware](https://llamawa.re/) mod repository.

### Features

- **Attempts** to find your game directory.
- **Automatically** installs and updates Tomb.
- **Automatically** installs and updates selected Tomb-compatible mods.
- **Update** the game engine (NW.js) to a newer SDK-enabled build. (Experimental feature, use with caution!)
- **Decrypt** the game assets. (We're [beating](https://github.com/Llamaware/LlamaToolkit) a [dead](https://codeberg.org/basil/grimoire) [horse](https://github.com/kleineluka/burial) here.)
- **Extract** obfuscated game code.
- **Deobfuscate** JavaScript code.
- A **not-so-pretty** but easy-to-use GUI.
- **Fake** console logging.
- Basically **zero QA testing**, so don't try putting gibberish into the input boxes.
- It took **more than a few hours** to make this.

### Usage

- Launch the program.
- Find/select your game directory, then install/update Tomb.
- From the `Get Mods` tab, load the mod list, then install/update the mods you want.
- Don't change the URLs or else it won't work.

### Requirements

- OS: Only works on Windows.
- You need the .NET 8.0 Runtime.
- You need a `Node.js` installation to use the deobfuscator. (optional)

### Future improvements

- Mod uninstallation.
- Automated code extraction?
- Multiplatform? (will require a complete rewrite)
- Use APIs instead of HTML parsing.
- More verbose logging.
- There probably still won't be any safety features. Just don't be stupid while using it.

### License

LlamaLoader is licensed under the Tumbolia Public License.  
Tomb is licensed under the MIT License.  
[AngleSharp](https://github.com/AngleSharp/AngleSharp) is licensed under the MIT License.  
[decode-js](https://github.com/echo094/decode-js) is licensed under the MIT License.