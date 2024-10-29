# LlamaLoader

![preview](/img/preview.png)

An all-in-one auto-updater and installer for the [Tomb modloader](https://codeberg.org/basil/tomb) and [Llamaware](https://llamawa.re/) mod repository. Previously known as AutoTomb.

### Features

- **Attempts** to find your game directory.
- **Automatically** installs and updates Tomb.
- **Automatically** installs and updates selected Tomb-compatible mods.
- A **not-so-pretty** but easy-to-use GUI.
- **Fake** console logging.
- Basically **zero QA testing**, so don't try putting gibberish into the input boxes.
- It took **more than a few hours** to make this.

### Usage

The GUI should be self-explanatory.
Launch the program.
Find/select your game directory, install/update Tomb, then from the Mods tab, install/update the mods you want.
Don't change the URLs or else it won't work.

### Requirements

- OS: Only works on Windows.
- You need the .NET 8.0 Runtime.

### Future improvements

- Mod uninstallation.
- Multiplatform? (will require a complete rewrite)
- Use APIs instead of HTML parsing?
- More verbose logging.
- There probably still won't be any safety features. Just don't be stupid while using it.

### License

LlamaLoader is licensed under the Tumbolia Public License.
Tomb is licensed under the MIT License.