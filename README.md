# **Retro**Unity
## **[Unity](https://unity.com)** Front-End for the **[LibRetro API](https://github.com/libretro)**

![](https://img.shields.io/badge/unity-2018.3%2B-blue.svg)

![Screenie](https://github.com/altered-existence/RetroUnity/raw/dev-collab/ScreenShot_0.png)


-----


## Instructions:

- Add core .dll's to "StreamingAssets/cores"
- Add ROM files to "StreaminAssets/roms/(PLATFORM)""
   - Super Nintendo ROMs would go in "StreamingAssets/roms/snes"
   - Sega Genesis ROMs would go in "StreamingAssets/roms/genesis"
- Play!
-----

## Cores Tested:

[x] - snes9x_libretro.dll

[-] - genesis_plus_gx_libretro.dll

[-] - gearsystem_libretro.dll

[-] - mednafen_gba_libretro.dll

-----


## Changes:

**05.03.2019**
  - Replace Example Models
  - Use 2D Mode for Example
  - Add function to list core libs in "cores" folder
    - Cores are listed in Dropdown
  - Replace CoreInputField with CoreDropdown


**05.02.2019**
  - Add UI Text Input Field for Core and ROM Selection
    - Example Core: "snes9x_libretro.dll"
    - Example ROM: "snes/Super Something World.smc"


**05.01.2019**
  - Update to Unity 2018.3.14f1
  - Allow changing loaded Core
  - Allow changing loaded ROM
  - Add ability to render to 2D Objects

## TODO:

- Add new scripts for Core and ROM Management
- Add ability to select Core and ROM Path(s)
- Add New UI to Select Core and ROM
- Add ability to download/update downloaded Cores
- Add "Scraper" functionality?

-----
## Dependencies:
- RetroArch Cores:
 - [Windows](https://buildbot.libretro.com/stable/1.7.6/windows/x86_64/RetroArch.7z)

### Note:

Due to the way this project handles Libraries, we currently target Windows x86_64 platform ONLY.

Linux, Mac and Android support will require a bit of work to implement.

-----

# Credits:

- Forked by: [Altered Existence](https://altered-existence.github.io/)


- Forked from: [Scorr/RetroUnity](https://github.com/Scorr/RetroUnity)


- Made with: [LibRetro](https://github.com/libretro)
  - Assets from [RetroArch](https://github.com/libretro/retroarch-assets)


- Made with: [Unity](https://unity.com/)


[![LibRetro](https://raw.githubusercontent.com/libretro/retroarch-assets/master/branding/libretro_logo.png)](https://github.com/libretro)
