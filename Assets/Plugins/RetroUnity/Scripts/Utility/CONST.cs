using RetroUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AltX.Manager
{
    public class CONST : MonoBehaviour
    {
        public GameManager gameManager;

        public string corePlatform;

        public static string[] platforms;
        public static Sprite[] platformIcons;

        public string snes = "snes";
        public Sprite snesIcon;
        public string genesis = "genesis";
        public Sprite genesisIcon;
        public string gameBoy = "gba";
        public Sprite gameBoyIcon;
        public string doom = "doom";
        public Sprite doomIcon;

        void Start()
        {
            // ---> SNES Cores
            if (gameManager.CoreFileName == "snes9x" + "*" + ".dll")
            {
                corePlatform = snes;
            }
            // ---> Genesis Cores
            if (gameManager.CoreFileName == "genesis" + "*" + ".dll")
            {
                corePlatform = genesis;
            }
            // ---> Gameboy Cores
            if (gameManager.CoreFileName == "*" + "gba" + "*" + ".dll")
            {
                corePlatform = gameBoy;
            }
            // ---> DOOM Cores
            if (gameManager.CoreFileName == "prboom_libretro.dll")
            {
                corePlatform = gameBoy;
            }
            // ---> Other Cores
            else
            {
                corePlatform = "LibRetro";
            }

            // ---> ROM File Extensions
            if (gameManager.RomName == "*.smc" || gameManager.RomName == "*.SMC")
            {
                corePlatform = snes;
            }
            if (gameManager.RomName == "*.smd" || gameManager.RomName == "*.SMD")
            {
                corePlatform = genesis;
            }
            if (gameManager.RomName == "*.wad" || gameManager.RomName == "*.WAD")
            {
                corePlatform = "DOOM";
            }
            //gameManager.romPath = gameManager.romPath + "/" + corePlatform;
        }
    }
}

