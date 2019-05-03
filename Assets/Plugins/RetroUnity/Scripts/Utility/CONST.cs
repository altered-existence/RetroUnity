using RetroUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AltX
{
    public class CONST : MonoBehaviour
    {
        public GameManager gameManager;

        public string corePlatform;

        public string snes = "snes";
        public string genesis = "genesis";
        public string gameBoy = "gba";

        void Start()
        {
            // ---> SNES Cores
            if (gameManager.CoreName == "snes9x" + "*" + ".dll")
            {
                corePlatform = snes;
            }
            // ---> Genesis Cores
            if (gameManager.CoreName == "genesis" + "*" + ".dll")
            {
                corePlatform = genesis;
            }
            // ---> Gameboy Cores
            if (gameManager.CoreName == "*" + "gba" + "*" + ".dll")
            {
                corePlatform = gameBoy;
            }
            // ---> Other Cores
            else
            {
                corePlatform = "LibRetro";
            }
        }
    }
}

