#### Mod Prority Patch

Makes the CM3D2 1.11 "Mod as GameData" feature prioritize the Mod Folder over the GameData
Meaning you can replace existing models in your mods, in a similar fashion to Deflarc

---
#### Installing

Place the **CM3D2.TextureResolution.Patcher.dll** in your CM3D2 ReiPatcher Patches directory, and execute ReiPatcher.

---
#### Building

Make sure you have MSBuild v14 installed (Comes with VS2015)
Place **Mono.Cecil** and **ReiPatcher.exe** references in the References folder, then Execute **build.bat**